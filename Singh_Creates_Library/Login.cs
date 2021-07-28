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
using System.Data.SqlClient;
using System.Configuration;

namespace Singh_Creates_Library
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Lib.Text == "")
            {
                lbl_Id.Visible = true;
                lbl_Id.Text = "Please Enter Librarian Id";
            }
            else if (txt_Pass.Text == "")
            {
                lbl_Pass.Visible = true;
                lbl_Pass.Text = "Please Enter Password";
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("tbl_Lib_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@U_Id", txt_Lib.Text);
                cmd.Parameters.AddWithValue("@Pass", txt_Pass.Text);
                cn.Open();
                int a = Convert.ToInt16(cmd.ExecuteScalar());
                cn.Close();
                if (a > 0)
                {
                    Global_Var G = new Global_Var();
                    G.G_Id(a);
                    this.Hide();
                    Welcome W = new Welcome();
                    W.Show();
                }
                else
                {
                    label3.Visible = true;
                    label3.Text = "Please Enter Correct Librarian Id Or Password";
                }
            }
        }
    }
}
