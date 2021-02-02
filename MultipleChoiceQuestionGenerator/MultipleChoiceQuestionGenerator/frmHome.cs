using MultipleChoiceQuestionGenerator.Common;
using MultipleChoiceQuestionGenerator.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleChoiceQuestionGenerator
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        
        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.ShowDialog();
        }

        private void setUpSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSubject frm = new frmSubject();
            frm.ShowDialog();
        }

        private void questionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            Com.MODopenDB();
        }
    }
}
