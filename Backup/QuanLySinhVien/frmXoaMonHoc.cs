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
    public partial class frmXoaMonHoc : Form
    {
        string MaMonHoc;
        public frmXoaMonHoc(string Ma)
        {
            MaMonHoc = Ma;
            InitializeComponent();
        }

        private void frmXoaMonHoc_Load(object sender, EventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSMonHoc frm = new frmDSMonHoc();
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            cmd.Connection = con;
            cmd1.Connection = con;
            cmd.CommandText = "DELETE FROM KetQua WHERE ID_MonHoc='" + MaMonHoc + "'";
            cmd1.CommandText = "DELETE FROM MonHoc Where MonHoc_ID='" + MaMonHoc+ "'";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN XÓA THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {   
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                MessageBox.Show("XÓA THÀNH CÔNG", "THÔNG BÁO");
                con.Close();
                this.Close();
                frmDSMonHoc frm = new frmDSMonHoc();
                frm.Show();
            }
           

        }
    }
}
