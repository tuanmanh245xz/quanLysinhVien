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
    public partial class frmTimSinhVien : Form
    {
        public frmTimSinhVien()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTimSinhVien_Load(object sender, EventArgs e)
        {
            txtTuKhoa.Text = "Nhập Từ Khoá?";
        }
        public int KiemTra()
        {
            if (radioButton1.Checked == true)
                return 1;
            else if (radioButton2.Checked == true)
                return 2;
            else
                return 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (KiemTra() == 1)
            {

                cmd.CommandText = "SELECT SinhVien.SinhVien_ID,SinhVien.TenSinhVien,Lop.TenLop,Khoa.TenKhoa FROM SinhVien,Lop,Khoa WHERE Lop.Lop_ID=SinhVien.ID_Lop AND Khoa.Khoa_ID=Lop.ID_Khoa AND SinhVien.SinhVien_ID='" + txtTuKhoa.Text + "'";
                SqlDataReader rd;
                rd = cmd.ExecuteReader();

                DataTable td = new DataTable();
                td.Load(rd);
                if (td.Rows.Count != 0)
                {

                    ListViewItem item = new ListViewItem(td.Rows[0][0].ToString());
                    item.SubItems.Add(td.Rows[0][1].ToString());
                    item.SubItems.Add(td.Rows[0][2].ToString());
                    item.SubItems.Add(td.Rows[0][3].ToString());
                    listView1.Items.Add(item);
                }
                else
                    MessageBox.Show("Không Có Sinh Viên Có Mã " + txtTuKhoa.Text);
            }
            else if (KiemTra() == 2)
            {
                cmd.CommandText = "SELECT SinhVien.SinhVien_ID,SinhVien.TenSinhVien,Lop.TenLop,Khoa.TenKhoa FROM SinhVien,Lop,Khoa WHERE Lop.Lop_ID=SinhVien.ID_Lop AND Khoa.Khoa_ID=Lop.ID_Khoa AND SinhVien.TenSinhVien like '%" + txtTuKhoa.Text + "%'";
                SqlDataReader rd;
                rd = cmd.ExecuteReader();

                DataTable td = new DataTable();
                td.Load(rd);
                if (td.Rows.Count != 0)
                {
                    for (int i = 0; i < td.Rows.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                        item.SubItems.Add(td.Rows[i][1].ToString());
                        item.SubItems.Add(td.Rows[i][2].ToString());
                        item.SubItems.Add(td.Rows[i][3].ToString());
                        listView1.Items.Add(item);
                    }
                }
                else
                    MessageBox.Show("Không Có Sinh Viên Có Tên " + txtTuKhoa.Text);
            }
            else
                MessageBox.Show("Chọn Chức Năng Tìm Kiếm");
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string str;
            int row;
            row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;

        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            string str;
            int row;
            row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;

            frmChiTietSinhVien frm = new frmChiTietSinhVien(str);
            this.Close();
            frm.Show();
        }
            
    }
}
