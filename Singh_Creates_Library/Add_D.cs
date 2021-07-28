using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using GLB;

namespace Singh_Creates_Library
{
    public partial class Add_D : Singh_Creates_Library.Welcome
    {
        public Add_D()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Add_Dept_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Insert");
            cmd.Parameters.AddWithValue("@Lib_Id",Global_Var.G_V());
            cmd.Parameters.AddWithValue("@Dept_Name",txt_Dept.Text);
            cn.Open();
            int a = cmd.ExecuteNonQuery();
            cn.Close();
            if(a>0)
            {
                label3.Visible = true;
                label3.Text = "Inserted Successfully";
                txt_Dept.Text = "";
            }
            else{
                MessageBox.Show("Already Exist");
            }
        }
    }
}
