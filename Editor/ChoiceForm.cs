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
    public partial class ChoiceForm : Form
    {
        public string Description { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;

        public ChoiceForm()
        {
            InitializeComponent();

        }


        private void ChoiceForm_Load(object sender, EventArgs e)
        {
            teDescription.Text = Description;
            teLink.Text = Link;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Description = teDescription.Text;
            Link = teLink.Text;
        }
    }
}
