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
    public partial class frmThemKhoa : Form
    {
        public frmThemKhoa()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmKhoa frm = new frmKhoa();
            frm.Show();
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT INTO Khoa VALUES('" +txtMaKhoa.Text+"','" +txtTenKhoa.Text + "')";
            cmd.ExecuteNonQuery();
            DialogResult result;
            result = MessageBox.Show("THÊM DỮ LIỆU THÀNH CÔNG","THÔNG BÁO",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                this.Close();
                frmThemKhoa frm = new frmThemKhoa();
                frm.Show();
            }
        }

        private void frmThemKhoa_Load(object sender, EventArgs e)
        {

        }
    }
}
