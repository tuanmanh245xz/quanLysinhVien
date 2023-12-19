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
    public partial class Khoa_Lop : Form
    {
        public Khoa_Lop()
        {
            InitializeComponent();
        }

        private void Khoa_Lop_Load(object sender, EventArgs e)
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

        private void cboDSKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenKhoa;
            TenKhoa=cboDSKhoa.SelectedItem.ToString();
            cmd.CommandText = "select* from Khoa where TenKhoa='" +TenKhoa + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaKhoa = td.Rows[0][0].ToString();
            cmd.CommandText = "SELECT * FROM Lop WHERE ID_Khoa='" + MaKhoa+ "'";
            SqlDataReader rd1;
            rd1 = cmd.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            for (int i = 0; i < td1.Rows.Count; i++)
            {
                this.cboDSLop.Items.Add(td1.Rows[i][1]);
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDS_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenLop;
            TenLop = cboDSLop.SelectedItem.ToString();
            cmd.CommandText = "SELECT Lop_ID FROM Lop WHERE TenLop='"+TenLop+"'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaLop;
            MaLop = td.Rows[0][0].ToString();
            con.Close();
            frmDSSV frmDS = new frmDSSV(MaLop);
            frmDS.Show();
            this.Close();

        }
    }
}
