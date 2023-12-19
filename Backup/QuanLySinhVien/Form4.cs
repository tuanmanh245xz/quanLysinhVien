using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace QuanLySinhVien
{
    public partial class frmsuaSV : Form
    {   string hinhanh;
        string _code;
        string Lop_ID;
        public frmsuaSV(string code,string MaLop)
        {
            Lop_ID = MaLop;
            _code = code;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmsuaSV_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT SinhVien_ID,TenSinhVien,GioiTinh,NgaySinh,NoiSinh,NoiOHienTai,KhoaHoc,LyLich,TenLop,HinhAnh FROM SinhVien,Lop WHERE Lop_ID=ID_Lop and SinhVien_ID='" + _code + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            //MessageBox.Show(td.Rows[0][8].ToString());
            this.txtmsv.Text = td.Rows[0][0].ToString();
            this.txttsv.Text = td.Rows[0][1].ToString();
            this.mskns.Text = td.Rows[0][3].ToString();
            this.txtnois.Text = td.Rows[0][4].ToString();
            this.txttt.Text = td.Rows[0][5].ToString();
            this.txtkh.Text = td.Rows[0][6].ToString();
            this.txtll.Text = td.Rows[0][7].ToString();
            hinhanh = td.Rows[0][9].ToString();
            this.pictureBox1.Image = new Bitmap(Application.StartupPath + @"\hinhanh\" + hinhanh);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            // this.cbxLop.Items.Add(td.Rows[0][8].ToString());
            int sex;
            sex = Convert.ToInt16(td.Rows[0][2]);
            if (sex == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSSV frm = new frmDSSV(Lop_ID);
            frm.Show();
        }

        private void cbxLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            string TenLop = cbxLop.SelectedItem.ToString();
            cmd.CommandText = "select* from Lop where TenLop ='" + TenLop + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaLop = td.Rows[0][0].ToString();
            cmd.CommandText = "UPDATE SinhVien SET TenSinhVien='" + txttsv.Text + "',GioiTinh=" + sex + ",NgaySinh='" + mskns.Text + "',NoiSinh='" + txtnois.Text + "',NoiOHienTai='" + txttt.Text + "',KhoaHoc='" + txtkh.Text + "',LyLich='" + txtll.Text + "',ID_Lop='" + MaLop + "',HinhAnh='"+hinhanh+"'WHERE SinhVien_ID='" + txtmsv.Text + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("CẬP NHẬT THÀNH CÔNG", "THÔNG BÁO");
            }
            con.Close();
            this.Close();
            frmDSSV frm = new frmDSSV(Lop_ID);
            frm.Show();
        }

        private void cbxLop_Click(object sender, EventArgs e)
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
                this.cbxLop.Items.Add(td.Rows[i][1]);
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string MaSV;
            string TenSV;
            MaSV = txtmsv.Text;
            TenSV = txttsv.Text;
            frmsuakqSV frmsua = new frmsuakqSV(MaSV, TenSV);
            frmsua.Show();
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
    }
}