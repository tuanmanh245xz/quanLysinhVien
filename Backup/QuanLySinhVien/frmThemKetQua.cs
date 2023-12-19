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
    public partial class frmThemKetQua : Form
    {
        string SinhVien_ID;
        public frmThemKetQua(string MaSinhVien)
        {
            SinhVien_ID = MaSinhVien;
            InitializeComponent();
        }

        private void frmThemKetQua_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TenMonHoc FROM MonHoc  order by MonHoc_ID ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cboMonHoc.Items.Add(td.Rows[i][0]);
            }
            con.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenMonHoc;
            TenMonHoc = cboMonHoc.SelectedItem.ToString();
            cmd.CommandText = "select* from MonHoc where TenMonHoc ='" + TenMonHoc + "'";

            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaMonHoc = td.Rows[0][0].ToString();
            int LanThi;
            LanThi = Convert.ToInt16(txtLanThi.Text);
            double DiemThi;
            DiemThi = Convert.ToDouble(txtDiemThi.Text);
            double TongKet;
            TongKet = Convert.ToDouble(txtDiemTongKet.Text);
            cmd.CommandText = "INSERT INTO KetQua VALUES('" + MaMonHoc + "','" +SinhVien_ID+ "'," + LanThi + "," + DiemThi + "," + TongKet + ")";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm Dữ Liệu Thành Công!");
            this.Close();
            frmKetQuaHocTap frm = new frmKetQuaHocTap(SinhVien_ID);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmKetQuaHocTap frm = new frmKetQuaHocTap(SinhVien_ID);
            frm.Show();
        }
    }
}
