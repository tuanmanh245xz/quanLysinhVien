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
    public partial class frmSuaNguoiDung : Form
    {
        string TenDangNhap;
        string MatKhau;
        public frmSuaNguoiDung(string Ten,string Ma)
        {
            TenDangNhap = Ten;
            MatKhau = Ma;
            InitializeComponent();
        }

        private void frmSuaNguoiDung_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT* FROM QuanLyNguoiDung WHERE TenDangNhap='" + TenDangNhap + "' and MatKhau='" + MatKhau + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtTenDangNhap.Text = td.Rows[0][0].ToString();
            this.txtMatKhau.Text = td.Rows[0][1].ToString();
            this.txtQuyenHan.Text = td.Rows[0][2].ToString();
            con.Close();


        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDanhSachNguoiDung frm = new frmDanhSachNguoiDung();
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText="UPDATE QuanLyNguoiDung SET QuyenHan='"+txtQuyenHan.Text+"' WHERE TenDangNhap='"+txtTenDangNhap.Text+"' AND MatKhau='"+txtMatKhau.Text+"'";
            DialogResult result;
            result = MessageBox.Show("Bạn Có Muốn Thay Đổi Thông Tin Không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Sửa Thông Tin Thành Công");
                this.Close();
                frmDanhSachNguoiDung frm = new frmDanhSachNguoiDung();
                frm.Show();
            }
        }
    }
}
