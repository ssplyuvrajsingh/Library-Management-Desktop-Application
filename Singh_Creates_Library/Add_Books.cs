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
    public partial class Add_Books : Singh_Creates_Library.Welcome
    {
        public Add_Books()
        {
            InitializeComponent();
        }

        private void Add_Books_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (txt_BookName.Text == "")
            {
                MessageBox.Show("Please Insert Book Name");
            }
            else if (txt_Auther.Text == "")
            {
                MessageBox.Show("Please Insert Book Auther Name");
            }
            else if (txt_Publication.Text == "")
            {
                MessageBox.Show("Please Insert Book Publication Name");
            }
            else if (txt_Price.Text == "")
            {
                MessageBox.Show("Please Insert Book Price");
            }
            else if (txt_Quantity.Text == "")
            {
                MessageBox.Show("Please Insert Book Quantity");
            }
            else if (txt_Book_Id.Text == "")
            {
                MessageBox.Show("Please Insert Book Id");
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Add_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Book_Name", txt_BookName.Text);
                cmd.Parameters.AddWithValue("@Book_Auther_Name", txt_Auther.Text);
                cmd.Parameters.AddWithValue("@Book_Publication_Name", txt_Publication.Text);
                cmd.Parameters.AddWithValue("@Book_Price", txt_Price.Text);
                cmd.Parameters.AddWithValue("@Book_Quantity", txt_Quantity.Text);
                cmd.Parameters.AddWithValue("@Lib_Id", Global_Var.G_V());
                cmd.Parameters.AddWithValue("@U_Book_Id", txt_Book_Id.Text);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    MessageBox.Show("Inserted Successfully");
                    txt_BookName.Text = "";
                    txt_Auther.Text = "";
                    txt_Publication.Text = "";
                    txt_Price.Text = "";
                    txt_Quantity.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Inserted");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
