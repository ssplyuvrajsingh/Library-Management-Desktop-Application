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
    
    public partial class V_Books : Singh_Creates_Library.Welcome
    {
        int Id;
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        
        public V_Books()
        {
            InitializeComponent();
        }

        private void V_Books_Load(object sender, EventArgs e)
        {
            Dis();
        }
        private void Dis()
        {
            SqlCommand cmd = new SqlCommand("Add_Books_Reg", cn);
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
            else
            {
                MessageBox.Show("Data Not Found");
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Add_Books_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Book_View");
            cmd.Parameters.AddWithValue("@Search", txt_Book.Text+'%');
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
                MessageBox.Show("Data Not Found");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_Msg.Text = "UPDATE BOOKS INFORMATION";
            panel2.Visible = true;
            btn_Update.Visible = true;
            btn_Delete.Visible = false;
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_B.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Auther.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Publication.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Price.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_Quantity.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_B.Text == "")
            {
                MessageBox.Show("Please Insert Book Name For Update");
            }
            else if (txt_Auther.Text == "")
            {
                MessageBox.Show("Please Insert Book Auther Name For Update");
            }
            else if (txt_Publication.Text == "")
            {
                MessageBox.Show("Please Insert Book Publication Name For Update");
            }
            else if (txt_Price.Text == "")
            {
                MessageBox.Show("Please Insert Book Price For Update");
            }
            else if (txt_Quantity.Text == "")
            {
                MessageBox.Show("Please Insert Book Quantity For Update");
            }
            else
            {

                SqlCommand cmd = new SqlCommand("Add_Books_Reg", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Update");
                cmd.Parameters.AddWithValue("@Book_Id", Id);
                cn.Open();
                int a = cmd.ExecuteNonQuery();
                cn.Close();
                if (a > 0)
                {
                    
                    MessageBox.Show("Update Successfully");
                    Dis();
                    txt_B.Text = "";
                    txt_Auther.Text = "";
                    txt_Publication.Text = "";
                    txt_Price.Text = "";
                    txt_Quantity.Text = "";
                }
                else
                {
                    MessageBox.Show("Not Updated");
                }
            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            lbl_Msg.Text = "DELETE BOOKS INFORMATION";
            panel2.Visible = true;
            btn_Delete.Visible = true;
            btn_Update.Visible = false;
            Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            txt_B.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txt_Auther.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txt_Publication.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txt_Price.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txt_Quantity.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Add_Books_Reg", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Action", "Delete");
            cmd.Parameters.AddWithValue("@Book_Id", Id);
            cn.Open();
            int a = cmd.ExecuteNonQuery();
            cn.Close();
            if (a > 0)
            {
                

                MessageBox.Show("Delete Successfully");
                Dis();
                txt_B.Text = "";
                txt_Auther.Text = "";
                txt_Publication.Text = "";
                txt_Price.Text = "";
                txt_Quantity.Text = "";
            }
            else
            {
                MessageBox.Show("Not Delete");
            }
        }
    }
}
