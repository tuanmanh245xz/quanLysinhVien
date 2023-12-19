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
    public partial class frmxoaSV : Form
    {
        string Lop_ID;
        string _code;
        public frmxoaSV(string code,string MaLop)
        {
            Lop_ID = MaLop;
            _code = code;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmxoaSV_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT SinhVien_ID,TenSinhVien,GioiTinh,NgaySinh,NoiSinh,NoiOHienTai,KhoaHoc,LyLich,TenLop FROM SinhVien,Lop WHERE Lop_ID=ID_Lop and SinhVien_ID='" + _code + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
          
            this.txtmsv.Text= td.Rows[0][0].ToString();
            this.txttsv.Text= td.Rows[0][1].ToString();
            this.mskns.Text= td.Rows[0][3].ToString();
            this.txtns.Text= td.Rows[0][4].ToString();
            this.txttt.Text = td.Rows[0][5].ToString();
            this.txtkh.Text = td.Rows[0][6].ToString();
            this.lstll.Items.Add(td.Rows[0][7].ToString());
            this.txtlh.Text=td.Rows[0][8].ToString();
            int sex;
            sex = Convert.ToInt16(td.Rows[0][2]);
            if (sex == 0)
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd1.CommandText = "DELETE FROM KetQua Where ID_SinhVien='" + txtmsv.Text + "'";
            cmd2.CommandText = "DELETE FROM SinhVien Where SinhVien_ID='" + txtmsv.Text + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY XÓA THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("XÓA THÀNH CÔNG", "THÔNG BÁO");
            }
            con.Close();
            this.Close();
            frmDSSV frm = new frmDSSV(Lop_ID);
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSSV frm = new frmDSSV(Lop_ID);
            frm.Show();
        }

        private void btnXoaKetQuaHocTap_Click(object sender, EventArgs e)
        {
            string MaSV;
            string TenSV;
            MaSV = txtmsv.Text;
            TenSV = txttsv.Text;
            frmXoaKetQuaHocTap frm = new frmXoaKetQuaHocTap(MaSV,TenSV);
            frm.Show();
        }
    }
}
