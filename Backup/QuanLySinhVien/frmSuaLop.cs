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
    public partial class frmSuaLop : Form
    {
        string Khoa_ID;
        string MaLop;
        public frmSuaLop(string Ma,string MaKhoa)
        {
            Khoa_ID = MaKhoa;
            MaLop = Ma;
            InitializeComponent();
        }

        private void frmSuaLop_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Khoa";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cboKhoa.Items.Add(td.Rows[i][1]);
            }
            cmd.CommandText = "SELECT * FROM Lop WHERE Lop_ID='" + MaLop + "'";
            SqlDataReader rd1;
            rd1 = cmd.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            this.txtMaLop.Text = td1.Rows[0][0].ToString();
            this.txtTenLop.Text = td1.Rows[0][1].ToString();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSLop frm = new frmDSLop(Khoa_ID);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenKhoa;
            TenKhoa = cboKhoa.SelectedItem.ToString();
            cmd.CommandText = "SELECT Khoa_ID FROM Khoa WHERE TenKhoa='" + TenKhoa + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaKhoa;
            MaKhoa = td.Rows[0][0].ToString();
            cmd.CommandText = "UPDATE Lop SET TenLop='" + txtTenLop.Text + "',ID_Khoa='" + MaKhoa + "' WHERE Lop_ID='" + MaLop + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN SỬA LẠI DỮ LIỆU KHÔNG?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("SỬA DỮ LIỆU THÀNH CÔNG");
                this.Close();
                frmDSLop frm = new frmDSLop(Khoa_ID);
                frm.Show();
            }
            
        }
    }
}
