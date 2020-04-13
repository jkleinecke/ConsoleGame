using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using EngineTest1;
using System.IO;

namespace Editor
{
    public partial class EditorForm : Form
    {
        private string m_strBaseFolder = string.Empty;
        private List<string> m_strFiles = new List<string>();
        private string m_strPrevious = string.Empty;
        private Room m_ActiveRoom = null;
        private int m_nSelectedChoiceIndex = -1;
        private bool m_bDirty = false;

        public EditorForm()
        {
            InitializeComponent();

            ReloadFiles();
            RefreshRoomData();
        }

        private void SetActiveRoom(Room room)
        {
            if (room != m_ActiveRoom)
            {
                if(m_bDirty)
                {
                    //--TODO: Restructure this to a propose set active room and allow for YesNoCancel
                    if( MessageBox.Show("Save changes to room?", "Save?", MessageBoxButtons.YesNo) == DialogResult.Yes )
                    {
                        SaveActiveRoom();
                    }
                }

                m_ActiveRoom = room;
                m_nSelectedChoiceIndex = -1;
                m_bDirty = false;

                RefreshRoomData();
            }
        }

        private void ReloadFiles()
        {
            bool bValid = string.IsNullOrEmpty(m_strBaseFolder) == false && Directory.Exists(m_strBaseFolder);

            if(bValid)
            {
                m_strFiles = new List<string>(Directory.GetFiles(m_strBaseFolder, "*.json", SearchOption.TopDirectoryOnly));
            }
            else
            {
                m_strFiles.Clear();
            }

            RefreshFileList();
        }

        private void RefreshFileList()
        {
            bool bValid = string.IsNullOrEmpty(m_strBaseFolder) == false && Directory.Exists(m_strBaseFolder);

            cmbActiveFile.Items.Clear();

            if (bValid)
            {
                foreach(var file in m_strFiles)
                {
                    var name = Path.GetFileNameWithoutExtension(file);
                    cmbActiveFile.Items.Add(name);
                }

                if(m_ActiveRoom != null)
                {
                    cmbActiveFile.SelectedItem = m_ActiveRoom.Name;
                }
            }
            else
            {
               
                
            }

            cmbActiveFile.Enabled = bValid;
            btnNewFile.Enabled = bValid;
        }

        private void RefreshRoomData()
        {
            bool bValidRoom = m_ActiveRoom != null;

            lvChoices.Items.Clear();
            if (bValidRoom)
            {
                teDescription.Text = m_ActiveRoom.Description;
                tePrompt.Text = m_ActiveRoom.ChoicePrompt;
                cmbActiveFile.SelectedItem = m_ActiveRoom.Name;

                for (int i = 0; i < m_ActiveRoom.Choices.Count; ++i)
                {
                    var choice = m_ActiveRoom.Choices[i];
                    var item = new ListViewItem();
                    item.Selected = m_nSelectedChoiceIndex == i;
                    lvChoices.Items.Add(item);
                    
                    item.Text = choice.Description;

                    var siLink = new ListViewItem.ListViewSubItem();
                    item.SubItems.Add(siLink);
                    siLink.Text = choice.Link;

                }
                
            }
            else
            {
                teDescription.Text = string.Empty;
                tePrompt.Text = string.Empty;
               
            }

            teDescription.Enabled = bValidRoom;
            tePrompt.Enabled = bValidRoom;
            lvChoices.Enabled = bValidRoom;


            btnPrevious.Enabled = string.IsNullOrEmpty(m_strPrevious) == false;
            btnRename.Enabled = bValidRoom;

            RefreshChoiceButtons();
            RefreshSaveButton();
        }

        private void RefreshSaveButton()
        {
            bool bValidRoom = m_ActiveRoom != null;
            btnSave.Enabled = bValidRoom && m_bDirty;

            string strTitle = "Editor";

            if(bValidRoom)
            {
                strTitle += " - ";

                if(m_bDirty)
                {
                    strTitle += "*";
                }

                strTitle += m_ActiveRoom.Name;
            }

            this.Text = strTitle;
        }

        private void SetDirty()
        {
            m_bDirty = true;
            RefreshSaveButton();
        }

        private void RefreshChoiceButtons()
        {
            bool bValidRoom = m_ActiveRoom != null;
            bool bValidSelection = bValidRoom && m_nSelectedChoiceIndex >= 0 && m_nSelectedChoiceIndex < m_ActiveRoom.Choices.Count;

            btnAddChoice.Enabled = bValidRoom;
            btnRemoveChoice.Enabled = bValidSelection;
            btnEditChoice.Enabled = bValidSelection;
        }


        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = browseBaseFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                m_strBaseFolder = browseBaseFolder.SelectedPath;
                
                var room = new Room();
                room.Name = "start";

                m_strPrevious = string.Empty;

                ReloadFiles();
                SetActiveRoom(room);

                SaveActiveRoom();
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var result = browseBaseFolder.ShowDialog();

            if (result == DialogResult.OK)
            {
                m_strBaseFolder = browseBaseFolder.SelectedPath;
                
                if(File.Exists(Path.Combine(m_strBaseFolder, "start.json")))
                {
                    var room = readRoomFile("start");
                    room.Name = "start";

                    SetActiveRoom(room);
                }

                ReloadFiles();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveActiveRoom();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            MoveToRoom(m_strPrevious);
        }

        private void MoveToRoom(string name)
        {
            if (string.IsNullOrEmpty(name) == false)
            {
                var room = readRoomFile(name);
                room.Name = name; 
                
                if (m_ActiveRoom != null)
                {
                    m_strPrevious = m_ActiveRoom.Name;
                }

                SetActiveRoom(room);
            }
        }

        private void btnAddChoice_Click(object sender, EventArgs e)
        {
            ChoiceForm dlg = new ChoiceForm();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                RoomChoiceOption choice = new RoomChoiceOption();
                choice.Description = dlg.Description;
                choice.Link = dlg.Link;

                m_ActiveRoom.Choices.Add(choice);
                m_nSelectedChoiceIndex = m_ActiveRoom.Choices.Count - 1;
                SetDirty();

                RefreshRoomData();
            }
        }

        private void btnRemoveChoice_Click(object sender, EventArgs e)
        {
            if (m_nSelectedChoiceIndex >= 0 && m_nSelectedChoiceIndex < m_ActiveRoom.Choices.Count)
            {
                m_ActiveRoom.Choices.RemoveAt(m_nSelectedChoiceIndex);

                if (m_nSelectedChoiceIndex >= m_ActiveRoom.Choices.Count)
                {
                    m_nSelectedChoiceIndex = m_ActiveRoom.Choices.Count - 1;
                }

                RefreshRoomData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NameForm dlg = new NameForm();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                MakeNewRoom(dlg.RoomName);
            }
        }

        private void MakeNewRoom(string name)
        {
            if (m_ActiveRoom != null)
            {
                m_strPrevious = m_ActiveRoom.Name;
            }

            var room = new Room();
            room.Name = name;

            SetActiveRoom(room);
            SaveActiveRoom();

            ReloadFiles();
        }

        private void cmbActiveFile_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var name = cmbActiveFile.SelectedItem.ToString();

            MoveToRoom(name);
        }

        private Room readRoomFile(string file)
        {
            string path = Path.Combine(m_strBaseFolder, file + ".json");

            using (StreamReader reader = File.OpenText(path))
            {
                var text = reader.ReadToEnd();
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.AllowTrailingCommas = true;
                options.IgnoreNullValues = true;
                return JsonSerializer.Deserialize<Room>(text, options);
            }
        }

        private void SaveActiveRoom()
        {
            if (m_ActiveRoom != null)
            {
                string path = Path.Combine(m_strBaseFolder, m_ActiveRoom.Name + ".json");
                var options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string json = JsonSerializer.Serialize<Room>(m_ActiveRoom, options);

                using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(json);
                    }
                }

                m_bDirty = false;
                RefreshSaveButton();
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            NameForm dlg = new NameForm();
            dlg.RoomName = m_ActiveRoom.Name;

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string oldPath = Path.Combine(m_strBaseFolder, m_ActiveRoom.Name + ".json");

                File.Delete(oldPath);
                m_ActiveRoom.Name = dlg.RoomName;

                SaveActiveRoom();
            }

            ReloadFiles();
            RefreshRoomData();
        }

        private void lvChoices_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                m_nSelectedChoiceIndex = e.ItemIndex;
            }
            else
            {
                m_nSelectedChoiceIndex = -1;
            }
            RefreshChoiceButtons();
        }

        private void btnEditChoice_Click(object sender, EventArgs e)
        {
            ChoiceForm dlg = new ChoiceForm();
            RoomChoiceOption choice = m_ActiveRoom.Choices[m_nSelectedChoiceIndex];
            dlg.Description = choice.Description;
            dlg.Link = choice.Link;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                choice.Description = dlg.Description;
                choice.Link = dlg.Link;

                SetDirty();
                RefreshRoomData();
            }
        }

        private void teDescription_TextChanged(object sender, EventArgs e)
        {
            if (m_ActiveRoom != null && teDescription.Text != m_ActiveRoom.Description)
            {
                m_ActiveRoom.Description = teDescription.Text;
                SetDirty();
            }
        }

        private void tePrompt_TextChanged(object sender, EventArgs e)
        {
            if (m_ActiveRoom != null && tePrompt.Text != m_ActiveRoom.ChoicePrompt)
            {
                m_ActiveRoom.ChoicePrompt = tePrompt.Text;
                SetDirty();
            }
        }

        private void lvChoices_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if(e.CancelEdit == false)
            {
                RoomChoiceOption choice = m_ActiveRoom.Choices[e.Item];
                choice.Description = e.Label;

                SetDirty();
            }
        }

        private void lvChoices_ItemActivate(object sender, EventArgs e)
        {
            RoomChoiceOption choice = m_ActiveRoom.Choices[m_nSelectedChoiceIndex];

            switch(choice.Link)
            {
                case "$previous":
                    MoveToRoom(m_strPrevious);
                    break;
                case "$end":
                    // do nothing
                    break;
                case "$repeat":
                    // do nothing
                    break;
                default:
                    if (m_strFiles.Contains(Path.Combine(m_strBaseFolder, choice.Link + ".json")))
                    {
                        MoveToRoom(choice.Link);
                    }
                    else
                    {
                        MakeNewRoom(choice.Link);
                    }
                    break;
            }
        }

        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if( m_bDirty )
            {
                var result = MessageBox.Show("Do you want to save your changes?", "Save?", MessageBoxButtons.YesNoCancel);

                switch(result)
                {
                    case DialogResult.Yes:
                        // Save then quit
                        SaveActiveRoom();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.No:
                        // do nothing
                        break;
                }
            }
        }
    }
}
