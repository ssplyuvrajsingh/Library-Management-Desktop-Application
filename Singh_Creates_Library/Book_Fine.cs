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
using System.Linq;

namespace Singh_Creates_Library
{
    public partial class Book_Fine : Singh_Creates_Library.Welcome
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        public Book_Fine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_U_Book_Id.Text == "")
            {
                MessageBox.Show("Please Insert Book Library Id");
            }
            else if (txt_St_Id.Text == "")
            {
                MessageBox.Show("Please Insert Student Library Id");
            }
            else if (txt_Fine.Text == "")
            {
                MessageBox.Show("Please Insert Fine");
            }
            else if (radio_pay.Checked == false && radio_Due.Checked == false)
            {
                MessageBox.Show("Please Select Pay or Due Option");
            }
            else
            {
                string P = string.Empty;
                SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "View2");
                cmd.Parameters.AddWithValue("@U_Book_Id", txt_U_Book_Id.Text);
                cmd.Parameters.AddWithValue("@St_Lib_Id", txt_St_Id.Text);
                cn.Open();
                int a = Convert.ToInt32(cmd.ExecuteScalar());
                cn.Close();
                if (a > 0)
                {

                    if (radio_pay.Checked == true)
                    {
                        P = "Pay";
                    }
                    else if (radio_Due.Checked == true)
                    {
                        P = "Due";
                    }
                    SqlCommand cmd1 = new SqlCommand("Book_Fine_Reg", cn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Action", "Insert");
                    cmd1.Parameters.AddWithValue("@Issue_Id", a);
                    cmd1.Parameters.AddWithValue("@Fine", txt_Fine.Text);
                    cmd1.Parameters.AddWithValue("@Pay", P);
                    cmd1.Parameters.AddWithValue("@Lib_Id", Global_Var.G_V());

                    cn.Open();
                    int b = cmd1.ExecuteNonQuery();
                    cn.Close();
                    if (b > 0)
                    {
                        txt_U_Book_Id.Text = "";
                        txt_St_Id.Text = "";
                        txt_Fine.Text = "";
                        if (radio_pay.Checked == true)
                        {
                            radio_pay.Checked = false;
                        }
                        else if (radio_Due.Checked == true)
                        {
                            radio_Due.Checked = false;
                        }
                        MessageBox.Show("Inserted SuccessfullY");
                    }
                    else
                    {
                        MessageBox.Show("Not Insert");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter Correct Book ID or Stuent Library ID");
                }
            }
            
        }

        private void Check_Click(object sender, EventArgs e)
        {
            if (txt_U_Book_Id1.Text == "")
            {
                MessageBox.Show("Please Insert Book Library Id");
            }
            else if (txt_St_Id1.Text == "")
            {
                MessageBox.Show("Please Insert Student Library Id");
            }
            else
            {
                string P = string.Empty;
                SqlCommand cmd = new SqlCommand("Issue_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "View3");
                cmd.Parameters.AddWithValue("@U_Book_Id", txt_U_Book_Id1.Text);
                cmd.Parameters.AddWithValue("@St_Lib_Id", txt_St_Id1.Text);
                cn.Open();
                string D = Convert.ToString((DateTime)cmd.ExecuteScalar());
                cn.Close();
                label9.Visible = true;
                label9.Text ="Return Date is " +D+"(mm:dd:yyyy)";
            }
        }

        private void C_Fine_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_St_Lib_Id2.Text == "")
                {
                    MessageBox.Show("Please Insert Student Library Id");
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("Book_Fine_Reg", cn);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.AddWithValue("@Action", "View2");
                    cmd1.Parameters.AddWithValue("@St_Lib_Id", txt_St_Lib_Id2.Text);
                    cn.Open();
                    var a = cmd1.ExecuteScalar().ToString();
                    cn.Close();
                    if (!string.IsNullOrEmpty(a))
                    {
                        label14.Visible = true;
                        label14.Text = "Total Fine is " + a.ToString();
                    }
                    else
                    {
                        label14.Visible = true;
                        label14.Text = "Fine is Not On this Student ID";
                    }


                    SqlCommand cmd = new SqlCommand("Book_Fine_Reg", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "View1");
                    cmd.Parameters.AddWithValue("@St_Lib_Id", txt_St_Lib_Id2.Text);
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    cn.Close();
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                cn.Close();
            }
        }

        private void Book_Fine_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Book_Fine_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "View");
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
