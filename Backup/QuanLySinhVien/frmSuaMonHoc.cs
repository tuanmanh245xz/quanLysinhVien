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
    public partial class frmSuaMonHoc : Form
    {
        string MaMonHoc;
        public frmSuaMonHoc(string Ma)
        {
            MaMonHoc = Ma;
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            int SoTrinh;
            SoTrinh = Convert.ToInt16(txtSoTrinh.Text);
            cmd.CommandText = "UPDATE MonHoc SET TenMonHoc='" +txtTenMonHoc.Text + "',SoTrinh="+SoTrinh+",GiangVien='"+txtGiangVien.Text+"'WHERE MonHoc_ID='" +MaMonHoc + "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("CẬP NHẬT DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO");
                this.Close();
                frmDSMonHoc frm = new frmDSMonHoc();
                frm.Show();
            }
            

        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSMonHoc frm = new frmDSMonHoc();
            frm.Show();
        }

        private void frmSuaMonHoc_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM MonHoc WHERE MonHoc_ID='" +MaMonHoc + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtMaMonHoc.Text = td.Rows[0][0].ToString();
            this.txtTenMonHoc.Text = td.Rows[0][1].ToString();
            this.txtSoTrinh.Text = td.Rows[0][2].ToString();
            this.txtGiangVien.Text = td.Rows[0][3].ToString();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSMonHoc frm = new frmDSMonHoc();
            frm.Show();
        }
    }
}
