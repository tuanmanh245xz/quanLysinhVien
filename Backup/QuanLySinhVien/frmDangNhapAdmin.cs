using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmDangNhapAdmin : Form
    {
        public frmDangNhapAdmin()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhapNguoiDung login = new DangNhapNguoiDung();
            if (login.DangNhap(txtTenDangNhap.Text, txtMatKhau.Text, txtQuyenHan.Text) == true)
            {
                MessageBox.Show("Xin Chào Admin", "Đăng Nhập Thành Công",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                frmDanhSachNguoiDung frm = new frmDanhSachNguoiDung();
                this.Close();
                frm.Show();
            }
            else
                MessageBox.Show("Thông Tin Không Đúng.Xin vui Lòng Kiểm Tra Lại","Lỗi Đăng Nhập",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
