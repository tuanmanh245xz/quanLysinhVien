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
    public partial class frmSuaKetQua : Form
    {
        string SinhVien_ID, MonHoc_ID;
        int LanThi;
        public frmSuaKetQua(string MaSinhVien,string MaMonHoc,int Thi)
        {
            SinhVien_ID = MaSinhVien;
            MonHoc_ID = MaMonHoc;
            LanThi = Thi;
            InitializeComponent();
        }

        private void frmSuaKetQua_Load(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText="SELECT DiemThi,DiemTongKet FROM KetQua WHERE ID_SinhVien='"+SinhVien_ID+"' AND ID_MonHoc='"+MonHoc_ID+"' AND LanThi="+LanThi+"";
            SqlDataReader rd,rd1;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            this.txtDiemThi.Text = td.Rows[0][0].ToString();
            this.txtDiemTongKet.Text = td.Rows[0][1].ToString();
            this.txtLanThi.Text = LanThi.ToString();
            cmd.CommandText = "SELECT TenMonHoc FROM MonHoc WHERE MonHoc_ID='" + MonHoc_ID + "'";
            rd1 = cmd.ExecuteReader();
            DataTable td1 = new DataTable();
            td1.Load(rd1);
            this.txtTenMonHoc.Text = td1.Rows[0][0].ToString();
            con.Close();
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmKetQuaHocTap frm = new frmKetQuaHocTap(SinhVien_ID);
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            
            double DiemThi;
            DiemThi = Convert.ToDouble(txtDiemThi.Text);
            double TongKet;
            TongKet = Convert.ToDouble(txtDiemTongKet.Text);
            cmd.CommandText = "UPDATE KetQua SET DiemThi=" + DiemThi + ",DiemTongKet=" + TongKet + " WHERE ID_SinhVien='" + SinhVien_ID+ "' AND ID_MonHoc='" + MonHoc_ID + "' AND LanThi="+LanThi+"";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN THAY ĐỔI THÔNG TIN KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("CẬP NHẬT THÀNH CÔNG", "THÔNG BÁO");
            }
            this.Close();
            frmKetQuaHocTap frm = new frmKetQuaHocTap(SinhVien_ID);
            frm.Show();
            
        }
    }
}
