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
    public partial class V_Dept : Singh_Creates_Library.Welcome
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        int Dept_Id;
        public V_Dept()
        {
            InitializeComponent();
        }

        private void V_Dept_Load(object sender, EventArgs e)
        {

            Dis();
        }

        private void Dis()
        {
            SqlCommand cmd = new SqlCommand("Add_Dept_Reg", cn);
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

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            Dept_Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_Dept.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_Dept.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Add_Dept_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@Dept_Id", Dept_Id);
                cmd.Parameters.AddWithValue("@Dept_Name", txt_Dept.Text);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    Dis();
                    txt_Dept.Text = "";
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
            if (txt_Dept.Text != "")
            {
                SqlCommand cmd = new SqlCommand("Add_Dept_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Delete");
                cmd.Parameters.AddWithValue("@Dept_Id", Dept_Id);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    Dis();
                    txt_Dept.Text = "";
                    MessageBox.Show("Deleted Sucessfully");
                }
                else
                {
                    MessageBox.Show("Not Delete");
                }
            }
            else
            {
                MessageBox.Show("Please Select Data for Delete Then Click On Delete Button");
            }
        }
    }
}
