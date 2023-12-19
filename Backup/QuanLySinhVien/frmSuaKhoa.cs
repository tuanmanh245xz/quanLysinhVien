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
    public partial class frmSuaKhoa : Form
    {
        string MaKhoa;
        public frmSuaKhoa(string Ma)
        {
            MaKhoa = Ma;
            InitializeComponent();
        }

        private void frmSuaKhoa_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TenKhoa FROM Khoa WHERE Khoa_ID='" +MaKhoa + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtMaKhoa.Text = MaKhoa;
            this.txtTenKhoa.Text = td.Rows[0][0].ToString();
            con.Close();
        }

        private void btnSuaKhoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Khoa SET TenKhoa='" + txtTenKhoa.Text+ "'WHERE Khoa_ID='" + MaKhoa+ "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("CẬP NHẬT DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO");
                this.Close();
                frmKhoa frm = new frmKhoa();
                frm.Show();
            }
            
       
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmKhoa frm = new frmKhoa();
            frm.Show();
        }
    }
}
