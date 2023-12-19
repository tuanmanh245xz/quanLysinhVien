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
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Khoa";
            SqlDataReader rd, rd1;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cboKhoa.Items.Add(td.Rows[i][1]);
            }
            cmd1.CommandText = "SELECT * FROM MonHoc";
            rd1 = cmd1.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            for (int i = 0; i < td1.Rows.Count; i++)
            {
                this.cboMonHoc.Items.Add(td1.Rows[i][1]);
            }
            con.Close();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenKhoa;
            TenKhoa = cboKhoa.SelectedItem.ToString();
            cmd.CommandText = "select* from Khoa where TenKhoa='" + TenKhoa + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaKhoa = td.Rows[0][0].ToString();
            cmd.CommandText = "SELECT * FROM Lop WHERE ID_Khoa='" + MaKhoa + "'";
            SqlDataReader rd1;
            rd1 = cmd.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            for (int i = 0; i < td1.Rows.Count; i++)
            {
                this.cboLop.Items.Add(td1.Rows[i][1]);
            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenLop;
            TenLop = cboLop.SelectedItem.ToString();
            cmd.CommandText = "select* from Lop where TenLop ='" + TenLop + "'";
            SqlDataReader rd,rd1;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaLop = td.Rows[0][0].ToString();
            string TenMonHoc;
            TenMonHoc = cboMonHoc.SelectedItem.ToString();
            cmd.CommandText = "SELECT  MonHoc_ID FROM MonHoc WHERE TenMonHoc='" + TenMonHoc + "'";
            rd1 = cmd.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            string MaMonHoc = td1.Rows[0][0].ToString();
            con.Close();

            this.Close();
            frmHienBaoCao frm = new frmHienBaoCao(MaLop,MaMonHoc);
            frm.Show();
        }
    }
}
