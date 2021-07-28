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
    public partial class Re_Issue : Singh_Creates_Library.Welcome
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        public Re_Issue()
        {
            InitializeComponent();
        }

        private void RE_Click(object sender, EventArgs e)
        {
            if (txt_U_Book_Id.Text == "")
            {
                MessageBox.Show("Please Insert Book Library Id");
            }
            else if (txt_St_Id.Text == "")
            {
                MessageBox.Show("Please Insert Student Library Id");
            }
            else if (txt_Return.Text == "")
            {
                MessageBox.Show("Please Insert Book Return Date");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Re");
                cmd.Parameters.AddWithValue("@U_Book_Id", txt_U_Book_Id.Text);
                cmd.Parameters.AddWithValue("@St_Lib_Id", txt_St_Id.Text);
                cmd.Parameters.AddWithValue("@Lib_Id", Global_Var.G_V());
                cmd.Parameters.AddWithValue("@Return_Date", txt_Return.Text);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    txt_U_Book_Id.Text = "";
                    txt_St_Id.Text = "";
                    txt_Return.Text = "";
                    MessageBox.Show("Re-Issue Successfully");
                }
                else
                {
                    MessageBox.Show("Not Re-Issue Because You Entered Wrong Information So Please Enter Correct Information");
                }
            }
        }

        private void Re_Issue_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "View");
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dt;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            if (txt_Search.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "View1");
                cmd.Parameters.AddWithValue("@Search", txt_Search.Text);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                cn.Close();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
            else
            {
                MessageBox.Show("Please Insert Book or Student Library ID For Searching Information Then Click On Search Button");
            }
        }
    }
}
