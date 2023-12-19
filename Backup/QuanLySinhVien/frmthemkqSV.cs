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
    public partial class frmthemkqSV : Form
    {
        string masv;
        string tensv;
        public frmthemkqSV(string strmasv,string strtensv )
        {
            masv = strmasv;
            tensv = strtensv;
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmthemkqSV_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM MonHoc  order by MonHoc_ID ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cbxmonhoc.Items.Add(td.Rows[i][1]);
            }
            this.txtMaSV.Text= masv;
            this.txtTenSV.Text = tensv;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenMonHoc;
            TenMonHoc = cbxmonhoc.SelectedItem.ToString();
            cmd.CommandText = "select* from MonHoc where TenMonHoc ='" + TenMonHoc + "'";

            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaMonHoc = td.Rows[0][0].ToString();
            int LanThi;
            LanThi=Convert.ToInt16(txtLanThi.Text);
            double DiemThi;
            DiemThi = Convert.ToDouble(txtDiemThi.Text);
            double TongKet;
            TongKet = Convert.ToDouble(txtTongKet.Text);
            cmd.CommandText = "INSERT INTO KetQua VALUES('" + MaMonHoc + "','" + masv+ "',"+LanThi+","+DiemThi+","+TongKet+")";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thêm Dữ Liệu Thành Công!");
            Close();
            frmthemkqSV frm = new frmthemkqSV(masv,tensv);
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
