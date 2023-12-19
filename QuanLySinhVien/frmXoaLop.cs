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
    public partial class frmXoaLop : Form
    {
        string Khoa_ID;
        string MaLop;
       
        public frmXoaLop(string Ma,string MaKhoa)
        {
            Khoa_ID = MaKhoa;
            MaLop = Ma;
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSLop frm = new frmDSLop(Khoa_ID);
            frm.Show();
        }

        private void frmXoaLop_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Lop WHERE Lop_ID='"+MaLop+"'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtMaLop.Text = td.Rows[0][0].ToString();
            this.txtTenLop.Text = td.Rows[0][1].ToString();
            string MaKhoa;
            MaKhoa = td.Rows[0][2].ToString();
            cmd.CommandText = "SELECT TenKhoa FROM Khoa WHERE Khoa_ID='" + MaKhoa + "'";
            SqlDataReader rd1;
            rd1 = cmd.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            this.txtKhoa.Text = td1.Rows[0][0].ToString();
            con.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            SqlCommand cmd3 = new SqlCommand();
            cmd.Connection = con;
            cmd1.Connection = con;
            cmd2.Connection = con;
            cmd3.Connection = con;
            cmd1.CommandText = "SELECT SinhVien_ID FROM SinhVien WHERE ID_Lop='" + MaLop + "'";
            SqlDataReader rd;
            rd=cmd1.ExecuteReader();
            DataTable td=new DataTable();
            td.Load(rd);
            string MaSinhVien;
            if (td.Rows.Count == 0)
            {
                MaSinhVien = "";
            }
            else
            {
                MaSinhVien = td.Rows[0][0].ToString();
            }
            cmd2.CommandText = "DELETE FROM KetQua WHERE ID_SinhVien='" + MaSinhVien + "' ";
            cmd3.CommandText = "DELETE FROM SinhVien WHERE SinhVien_ID='" + MaSinhVien + "' AND ID_Lop='" + MaLop + "'";
            cmd.CommandText = "DELETE FROM Lop WHere Lop_ID='" + MaLop + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN XOÁ DỮ LIỆU KHÔNG?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("DỮ LIỆU ĐÃ ĐƯỢC XOÁ","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                this.Close();
                frmDSLop frm = new frmDSLop(Khoa_ID);
                frm.Show();
                 
               
            }                

        }
    }
}
