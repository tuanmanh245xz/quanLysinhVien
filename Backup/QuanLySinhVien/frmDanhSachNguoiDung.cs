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
    public partial class frmDanhSachNguoiDung : Form
    {
        public frmDanhSachNguoiDung()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDanhSachNguoiDung_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM QuanLyNguoiDung";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                item.SubItems.Add(td.Rows[i][1].ToString());
                item.SubItems.Add(td.Rows[i][2].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string TenDangNhap;
            string MatKhau;
            int row = this.listView1.SelectedItems[0].Index;
            TenDangNhap = this.listView1.Items[row].SubItems[0].Text;
            MatKhau = this.listView1.Items[row].SubItems[1].Text;



        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string TenDangNhap;
            string MatKhau;
            int row = this.listView1.SelectedItems[0].Index;
            TenDangNhap = this.listView1.Items[row].SubItems[0].Text;
            MatKhau = this.listView1.Items[row].SubItems[1].Text;
            frmSuaNguoiDung frm = new frmSuaNguoiDung(TenDangNhap, MatKhau);
            this.Close();
            frm.Show();
          

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string TenDangNhap;
            string MatKhau;
            int row = this.listView1.SelectedItems[0].Index;
            TenDangNhap = this.listView1.Items[row].SubItems[0].Text;
            MatKhau = this.listView1.Items[row].SubItems[1].Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM QuanLyNguoiDung WHERE TenDangNhap='" + TenDangNhap + "' and MatKhau='" + MatKhau + "'";
            DialogResult result;
            result = MessageBox.Show("Bạn Muốn Xoá Dữ Liệu Người Dùng Không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Xoá Dữ Liệu Thành Công");
                this.Close();
                frmDanhSachNguoiDung frm = new frmDanhSachNguoiDung();
                frm.Show();
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmThemNguoiDung frm = new frmThemNguoiDung();
            frm.Show();
        }
    }
}
