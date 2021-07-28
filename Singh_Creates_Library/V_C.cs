using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Singh_Creates_Library
{
    public partial class V_C : Singh_Creates_Library.Welcome
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        int C_Id;
        public V_C()
        {
            InitializeComponent();
        }

        private void V_C_Load(object sender, EventArgs e)
        {
            Dis();
            
        }

        private void Dis()
        {
            dd_Dept_Dis();

            SqlCommand cmd1 = new SqlCommand("Add_Course_Reg", cn);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.AddWithValue("@Action", "View");
            cn.Open();
            SqlDataReader dr1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(dr1);
            cn.Close();
            if (dt1.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt1;
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            C_Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            //dd_Dept_Dis();
            cb_De.SelectedItem=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Course.Text=dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        
        private void dd_Dept_Dis()
        {
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


                cb_De.ValueMember = "Dept_Id";
                cb_De.DisplayMember = "Dept_Name";
                cb_De.DataSource = dt;
            }
            else
            {
                DataRow row = dt.NewRow();
                row[0] = 0;
                row[1] = "--Data Not Found";
                dt.Rows.InsertAt(row, 0);

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Course.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Add_Course_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@Dept_Id", cb_De.SelectedValue);
                cmd.Parameters.AddWithValue("@Course_Name",txt_Course.Text);
                cmd.Parameters.AddWithValue("@Course_Id", C_Id);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    Dis();
                    txt_Course.Text = "";
                    MessageBox.Show("Updated Successfully");
                }
                else
                {
                    MessageBox.Show("Not Update");
                }
            }
            else
            {
                MessageBox.Show("Please Select a Data for Update Then Click On Update Button");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (txt_Course.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Add_Course_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Delete");
    
                cmd.Parameters.AddWithValue("@Course_Id", C_Id);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    Dis();
                    txt_Course.Text = "";
                    MessageBox.Show("Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("Not Delete");
                }
            }
            else
            {
                MessageBox.Show("Please Select a Data for Update Then Click On Update Button");
            }
        }
    }
}
