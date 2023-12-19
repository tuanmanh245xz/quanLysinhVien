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
    public partial class frmSuaThongTinSinhVien : Form
    {
        string SinhVien_ID;
        string hinhanh;
        public frmSuaThongTinSinhVien(string MaSinhVien)
        {
            SinhVien_ID = MaSinhVien;
            InitializeComponent();
        }

        private void cboLop_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Lop order by Lop_ID ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cboLop.Items.Add(td.Rows[i][1]);
            }
            con.Close();
        }

        private void frmSuaThongTinSinhVien_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT SinhVien.* FROM SinhVien WHERE SinhVien_ID='" + SinhVien_ID + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);

            this.txtMaSinhVien.Text = td.Rows[0][0].ToString();
            this.txtTenSinhVien.Text = td.Rows[0][1].ToString();
            this.mskNgaySinh.Text = td.Rows[0][3].ToString();
            this.txtNoiSinh.Text = td.Rows[0][4].ToString();
            this.txtOHienTai.Text = td.Rows[0][5].ToString();
            this.txtKhoaHoc.Text = td.Rows[0][6].ToString();
            this.txtLyLich.Text = td.Rows[0][7].ToString();
            string hinhanh;
            hinhanh = td.Rows[0][9].ToString();
            this.pictureBox1.Image = new Bitmap(Application.StartupPath + @"\hinhanh\" + hinhanh);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            int sex;
            sex = Convert.ToInt16(td.Rows[0][2]);
            if (sex == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            con.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmChiTietSinhVien frm = new frmChiTietSinhVien(SinhVien_ID);
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            int sex;
            if (radioButton1.Checked == true)
                sex = 0;
            else
                sex = 1;
            string TenLop = cboLop.SelectedItem.ToString();
            cmd.CommandText = "select Lop_ID from Lop where TenLop ='" + TenLop + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaLop = td.Rows[0][0].ToString();
            cmd.CommandText = "UPDATE SinhVien SET TenSinhVien='" + txtTenSinhVien.Text + "',GioiTinh=" + sex + ",NgaySinh='" + mskNgaySinh.Text + "',NoiSinh='" + txtNoiSinh.Text + "',NoiOHienTai='" + txtOHienTai.Text + "',KhoaHoc='" + txtKhoaHoc.Text + "',LyLich='" + txtLyLich.Text + "',ID_Lop='" + MaLop + "',HinhAnh='" + hinhanh + "'WHERE SinhVien_ID='" + SinhVien_ID + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("CẬP NHẬT THÀNH CÔNG", "THÔNG BÁO");
            }
            con.Close();
            this.Close();
            frmChiTietSinhVien frm = new frmChiTietSinhVien(SinhVien_ID);
            frm.Show();
        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dl = new OpenFileDialog();
            dl.InitialDirectory = Application.StartupPath + @"hinhanh/";
            if (dl.ShowDialog() == DialogResult.OK)
            {
                hinhanh = dl.FileName.Substring(dl.FileName.LastIndexOf("\\") + 1, dl.FileName.Length - dl.FileName.LastIndexOf("\\") - 1);
                pictureBox1.Image = new Bitmap(Application.StartupPath + @"\hinhanh\" + hinhanh);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnKetQuaHocTap_Click(object sender, EventArgs e)
        {
            frmKetQuaHocTap frm = new frmKetQuaHocTap(SinhVien_ID);
            frm.Show();
        }
    }
}
