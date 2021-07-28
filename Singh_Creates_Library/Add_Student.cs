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
    public partial class Add_Student : Singh_Creates_Library.Welcome
    {
        SqlConnection cn=new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        public Add_Student()
        {
            InitializeComponent();
        }

        private void Add_Student_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Add_Course_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "cb_View");
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "--Select Course--";
                dt.Rows.InsertAt(row, 0);


                cb_Course.ValueMember = "Course_Id";
                cb_Course.DisplayMember = "Course_Name";
                cb_Course.DataSource = dt;
            }
            else
            {
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "--Data Not Found--";
                dt.Rows.InsertAt(row, 0);
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cb_Course.SelectedValue) == 0)
            {
                MessageBox.Show("Please Select Course");
            }
            else if (txt_Name.Text == "")
            {
                MessageBox.Show("Please Enter Student  Name");
            }
            else if (txt_Session.Text == "")
            {
                MessageBox.Show("Please Enter Student Session");
            }
            else if (txt_Mobile.Text == "")
            {
                MessageBox.Show("Please Enter Student Mobile No.");
            }
            else if (txt_E_mail.Text == "")
            {
                MessageBox.Show("Please Enter Student E-mail Address");
            }
            else if (txt_Lib_Id.Text == "")
            {
                MessageBox.Show("Please Enter Student Library Id Who want to create's for Student");
            }
            else if (txt_F_Name.Text == "")
            {
                MessageBox.Show("Please Enter Student Father's Name");
            }
            else if (radio_Male.Checked == false && radio_Female.Checked == false)
            {
                MessageBox.Show("Please Select Student Gender");
            }
            else
            {
                string G = string.Empty;
                if (radio_Male.Checked == true)
                {
                    G = "Male";
                }
                else if (radio_Female.Checked == true)
                {
                    G = "Female";
                }

                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("ST_Info_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Lib_Id", Global_Var.G_V());
                cmd.Parameters.AddWithValue("@Course_Id", Convert.ToInt32(cb_Course.SelectedValue));
                cmd.Parameters.AddWithValue("@ST_Name", txt_Name.Text);
                cmd.Parameters.AddWithValue("@Session", txt_Session.Text);
                cmd.Parameters.AddWithValue("@Mobile", txt_Mobile.Text);
                cmd.Parameters.AddWithValue("@E_mail", @txt_E_mail.Text);
                cmd.Parameters.AddWithValue("@St_Lib_Id", txt_Lib_Id.Text);
                cmd.Parameters.AddWithValue("@Gender", G);
                cmd.Parameters.AddWithValue("@Father_Name", txt_F_Name.Text);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    txt_Name.Text = "";
                    txt_Session.Text = "";
                    txt_Mobile.Text = "";
                    txt_E_mail.Text = "";
                    txt_Lib_Id.Text = "";
                    if (radio_Male.Checked == true)
                    {
                        radio_Male.Checked = false;
                    }
                    else if (radio_Female.Checked == true)
                    {
                        radio_Female.Checked = false;
                    }
                    MessageBox.Show("Inserted Successfully");

                }
            }
                
        }
    }
}
