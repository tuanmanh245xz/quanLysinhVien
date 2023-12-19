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
    public partial class frmThemLop : Form
    {
        string Khoa_ID;
        public frmThemLop(string Ma)
        {
            Khoa_ID = Ma;
            InitializeComponent();
        }

        private void frmThemLop_Load(object sender, EventArgs e)
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
        }

        private void btnThemLop_Click(object sender, EventArgs e)
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
           
            cmd.CommandText = "INSERT INTO Lop VALUES('" + txtMaLop.Text + "','" + txtTenLop.Text + "','" + MaKhoa + "')";
            cmd.ExecuteNonQuery();
            DialogResult result;
            result = MessageBox.Show("THÊM DỮ LIỆU THÀNH CÔNG", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
                frmThemLop frm = new frmThemLop(Khoa_ID);
                frm.Show();
            }
           
          }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSLop frm = new frmDSLop(Khoa_ID);
            frm.Show();
        }
    }
}
