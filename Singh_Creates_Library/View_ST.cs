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
    public partial class View_ST : Singh_Creates_Library.Welcome
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
        public View_ST()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("ST_Info_Reg", cn);
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
    }
}
