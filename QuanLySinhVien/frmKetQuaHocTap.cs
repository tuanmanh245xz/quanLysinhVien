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
    public partial class frmKetQuaHocTap : Form
    {
        string SinhVien_ID;
        public frmKetQuaHocTap(string MaSinhVien)
        {
            SinhVien_ID = MaSinhVien;
            InitializeComponent();
        }

        private void frmKetQuaHocTap_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TenMonHoc,SoTrinh,LanThi,DiemThi,DiemTongKet FROM MonHoc,KetQua WHERE KetQua.ID_MonHoc=MonHoc.MonHoc_ID AND KetQua.ID_SinhVien='"+SinhVien_ID+"' ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                item.SubItems.Add(td.Rows[i][1].ToString());
                item.SubItems.Add(td.Rows[i][2].ToString());
                item.SubItems.Add(td.Rows[i][3].ToString());
                item.SubItems.Add(td.Rows[i][4].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
            

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            this.Close();
           

        }

        private void listView1_Click(object sender, EventArgs e)
        {
          int LanThi;
          
          string TenMonHoc;
          int row;
          row = this.listView1.SelectedItems[0].Index;
          LanThi =Convert.ToInt16( this.listView1.Items[row].SubItems[2].Text);
          TenMonHoc = this.listView1.Items[row].SubItems[0].Text;
         

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemKetQua frm = new frmThemKetQua(SinhVien_ID);
            this.Close();
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int LanThi;
            string MonHoc_ID;
            string TenMonHoc;
            int row;
            row = this.listView1.SelectedItems[0].Index;
            LanThi = Convert.ToInt16(this.listView1.Items[row].SubItems[2].Text);
            TenMonHoc = this.listView1.Items[row].SubItems[0].Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT MonHoc_ID FROM MonHoc WHERE TenMonHoc='" + TenMonHoc + "' ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            MonHoc_ID = td.Rows[0][0].ToString();
            con.Close();
            this.Close();
            frmSuaKetQua frm = new frmSuaKetQua(SinhVien_ID,MonHoc_ID,LanThi);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int LanThi;
            string MonHoc_ID;
            string TenMonHoc;
            int row;
            row = this.listView1.SelectedItems[0].Index;
            LanThi = Convert.ToInt16(this.listView1.Items[row].SubItems[2].Text);
            TenMonHoc = this.listView1.Items[row].SubItems[0].Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT MonHoc_ID FROM MonHoc WHERE TenMonHoc='" + TenMonHoc + "' ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            MonHoc_ID = td.Rows[0][0].ToString();
            cmd.CommandText = "DELETE FROM KetQua WHERE ID_SinhVien='" + SinhVien_ID + "' AND ID_MonHoc='"+MonHoc_ID+"' AND LanThi="+LanThi+" ";
            DialogResult result;
            result = MessageBox.Show("BẠN CÓ MUỐN XOÁ KẾT QUẢ KHÔNG?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("XÓA THÀNH CÔNG", "THÔNG BÁO");
                this.Close();
                frmKetQuaHocTap frm = new frmKetQuaHocTap(SinhVien_ID);
                frm.Show();
            }
         
            

        }
    }
}
