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
    public partial class frmThemNguoiDung : Form
    {
        public frmThemNguoiDung()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDanhSachNguoiDung frm = new frmDanhSachNguoiDung();
            frm.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string QuyenHan;
            QuyenHan=this.cboQuyenHan.SelectedItem.ToString();
            cmd.CommandText = "INSERT INTO QuanLyNguoiDung VALUES('" + txtTenDangNhap.Text + "','" + txtMatKhau.Text + "','" + QuyenHan + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm Dữ Liệu Thành Công");
            this.Close();
            frmDanhSachNguoiDung frm = new frmDanhSachNguoiDung();
            frm.Show();
        }
    }
}
