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
    public partial class Add_Issue_Books : Singh_Creates_Library.Welcome
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        public Add_Issue_Books()
        {
            InitializeComponent();
        }

        private void Books_Available_Click(object sender, EventArgs e)
        {
            
            if (txt_S_Book.Text != "")
            {
                SqlCommand cmd1 = new SqlCommand("Issue_Books_Reg", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Action", "Issue");
                cmd1.Parameters.AddWithValue("@U_Book_Id", txt_S_Book.Text);
                cn.Open();
                int b = Convert.ToInt32(cmd1.ExecuteScalar());
                cn.Close();
                if (b > 0)
                {
                    SqlCommand cmd = new SqlCommand("Add_Books_Reg", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "Issue");
                    cmd.Parameters.AddWithValue("@U_Book_Id", txt_S_Book.Text);
                    cn.Open();
                    int a = Convert.ToInt32(cmd.ExecuteScalar());
                    cn.Close();
                    if (a > 0)
                    {
                        lbl_BookMsg.Visible = true;
                        lbl_BookValue.Visible = true;
                        lbl_BookMsg.Text = "Total Books Available for Issue is";
                        lbl_BookValue.Text = (a - b).ToString();
                    }

                    else
                    {
                        MessageBox.Show("Not Found");
                    }
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
            else
            {
                MessageBox.Show("Please Insert Book Information For Searching");
            }
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            if (txt_U_Book_Id.Text == "")
            {
                MessageBox.Show("Please Insert Book Library Id");
            }
            else if (txt_St_Id.Text == "")
            {
                MessageBox.Show("Please Insert Student Library Id");
            }
            else if (txt_Total.Text == "")
            {
                MessageBox.Show("Please Insert Issue Total Books");
            }
            else if (txt_Return.Text == "")
            {
                MessageBox.Show("Please Insert Book Return Date");
            }
            else if (radio_Y.Checked == false)
            {
                MessageBox.Show("Please Click On Yes Button");
            }
            else
            {
                SqlCommand cmd1 = new SqlCommand("Add_Books_Reg", cn);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Action", "Book_View1");
                cmd1.Parameters.AddWithValue("@U_Book_Id", txt_U_Book_Id.Text);
                cn.Open();
                string B = string.Empty;
                B = (string)cmd1.ExecuteScalar();
                cn.Close();

                if (B == txt_U_Book_Id.Text)

                {
                    SqlCommand cmd2 = new SqlCommand("ST_Info_Reg", cn);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@Action", "View_ST");
                    cmd2.Parameters.AddWithValue("@St_Lib_Id", txt_St_Id.Text);
                    cn.Open();
                    string C = string.Empty;
                    C = (string)cmd2.ExecuteScalar();
                    cn.Close();
                    if (C == txt_St_Id.Text)
                    {

                        string Y = string.Empty;
                        if (radio_Y.Checked == true)
                        {
                            Y = "Yes";
                        }

                        SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Action", "Insert");
                        cmd.Parameters.AddWithValue("@U_Book_Id", txt_U_Book_Id.Text);
                        cmd.Parameters.AddWithValue("@St_Lib_Id", txt_St_Id.Text);
                        cmd.Parameters.AddWithValue("@Issue_Books_Total", txt_Total.Text);
                        cmd.Parameters.AddWithValue("@Lib_Id", Global_Var.G_V());
                        cmd.Parameters.AddWithValue("@Return_Date", txt_Return.Text);
                        cmd.Parameters.AddWithValue("@Yes", Y);
                        cn.Open();
                        int a = cmd.ExecuteNonQuery();
                        cn.Close();
                        if (a > 0)
                        {
                            MessageBox.Show("Inserted Successfully");
                        }
                        else
                        {
                            MessageBox.Show("Already Exists This Book on this Id");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Student Library  Id So Please Enter Correct Student Library Id");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Book Library Id So Please Enter Correct Book Library Id");
                }
            }
        }

        private void St_Search_Click(object sender, EventArgs e)
        {
            if (txt_ST_Id_S.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "ST");
                cmd.Parameters.AddWithValue("@St_Lib_Id", txt_ST_Id_S.Text);
                cn.Open();
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
                if (a > 0)
                {
                    label7.Visible = true;
                    lbl_6.Visible = true;
                    label7.Text = "Total Book Issue On Student ID is";
                    lbl_6.Text = a.ToString();
                }
                else
                {
                    MessageBox.Show("Not Issue Book on This Student Id");
                }
            }
            else
            {
                MessageBox.Show("Please Insert Student Library ID");
            }
        }
    }
}
