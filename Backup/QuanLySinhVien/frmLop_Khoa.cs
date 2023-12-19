using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QuanLySinhVien
{
    public partial class frmLop_Khoa : Form
    {
        public frmLop_Khoa()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLop_Khoa_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Khoa";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cboDSKhoa.Items.Add(td.Rows[i][1]);
            }
            con.Close();
        }

        private void btnDSLop_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenKhoa;
            TenKhoa = cboDSKhoa.SelectedItem.ToString();
            cmd.CommandText = "SELECT Khoa_ID FROM Khoa WHERE TenKhoa='" + TenKhoa + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaKhoa;
            MaKhoa = td.Rows[0][0].ToString();
           
            con.Close();
            this.Close();
            frmDSLop frmDS = new frmDSLop(MaKhoa);
            frmDS.Show();
        }
    }
}
