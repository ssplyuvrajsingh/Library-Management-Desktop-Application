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
    public partial class Add_Course : Singh_Creates_Library.Welcome
    {
        public Add_Course()
        {
            InitializeComponent();
        }

        private void Add_Course_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Add_Dept_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "dd_Dept");
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "--Select Department--";
                dt.Rows.InsertAt(row, 0);


                cb_Dept.ValueMember = "Dept_Id";
                cb_Dept.DisplayMember = "Dept_Name";
                cb_Dept.DataSource = dt;
            }
            else
            {
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "--Data Not Found";
                dt.Rows.InsertAt(row, 0);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(cb_Dept.SelectedValue) == 0)
            {
                lbl_Dept.Visible = true;
                lbl_Dept.Text = "Please Select Department";
            }
            else if (txt_Course.Text == "")
            {
                lbl_C.Visible = true;
                lbl_C.Text = "Can't Blank";
            }
            else
            {
                SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Add_Course_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Insert");
                cmd.Parameters.AddWithValue("@Lib_Id", Global_Var.G_V());
                cmd.Parameters.AddWithValue("@Dept_Id", Convert.ToInt16(cb_Dept.SelectedValue));
                cmd.Parameters.AddWithValue("@Course_Name", txt_Course.Text);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    lbl_Msg.Visible = true;
                    lbl_Msg.Text = "Inserted Successfully";
                }
                else
                {
                    lbl_Msg.Visible = false;
                    lbl_Msg.Text = "Already Exists";
                }
            }
        }
    }
}
