using IntellisenseTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Designer
{
    public partial class Form1 : Form
    {
        private Task obtainSuggestions;

        public Form1()
        {
            InitializeComponent();

            obtainSuggestions = Task.CompletedTask;
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBox1.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                textBox1.Text += listBox1.Items[index];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (obtainSuggestions.Status == TaskStatus.Running)
            {
                return;
            }
            else
            {
                listBox1.DataSource = Suggester.Suggest("D:\\Antlr_Grammar\\Antlr.Grammar\\", "Grammar", textBox1.Text);
            }
        }
    }
}