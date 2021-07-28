using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GLB;

namespace Singh_Creates_Library
{
    public partial class Welcome : Form
    {
        int Lib_Id;
        public void Id(int a)
        {
            Lib_Id = a;
        }

        public Welcome()
        {
            InitializeComponent();
        }

        private void aDDDEPARTMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {


            this.Hide();
            Add_D D = new Add_D();
            D.Show();

        }

        private void vIEWDEPARTMENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            V_Dept V = new V_Dept();
            V.Show();
        }

        private void aDDCOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Course C = new Add_Course();
            C.Show();
        }

        private void vIEWCOURSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            V_C V = new V_C();
            V.Show();
        }

        private void aDDSTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Student ST = new Add_Student();
            ST.Show();
        }

        private void aDDBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Books B = new Add_Books();
            B.Show();
        }

        private void vIEWBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            V_Books V = new V_Books();
            V.Show();
        }

        private void aDDISSUEBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Add_Issue_Books I = new Add_Issue_Books();
            I.Show();
        }

        private void rEISSUEBOOKSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Re_Issue R = new Re_Issue();
            R.Show();
        }

        private void submitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book_Fine BF = new Book_Fine();
            BF.Show();
        }

        private void vIEWSTUDENTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_ST V = new View_ST();
            V.Show();
        }
    }
}