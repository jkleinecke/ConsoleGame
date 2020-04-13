using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class NameForm : Form
    {
        public string RoomName { get; set; }

        public NameForm()
        {
            InitializeComponent();

        }

        private void NameForm_Load(object sender, EventArgs e)
        {

            teName.Text = RoomName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomName = teName.Text;
        }
    }
}
