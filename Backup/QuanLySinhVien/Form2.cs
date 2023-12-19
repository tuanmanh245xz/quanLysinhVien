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
    public partial class frmDSSV : Form
    {
        string MaLop;
        public frmDSSV(string Ma)
        {
            MaLop = Ma;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT SinhVien_ID,TenSinhVien,GioiTinh,NgaySinh,NoiSinh,NoiOHienTai,KhoaHoc,LyLich,TenLop,TenKhoa FROM SinhVien,Lop,Khoa WHERE Lop_ID=ID_Lop AND Khoa_ID=ID_Khoa AND ID_Lop='"+MaLop+"'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                item.SubItems.Add(td.Rows[i][1].ToString());
                if (Convert.ToInt16(td.Rows[i][2]) == 0)
                    item.SubItems.Add("Nam");
                else
                    item.SubItems.Add("Nu");
                //item.SubItems.Add(td.Rows[i][2].ToString());
                item.SubItems.Add(td.Rows[i][3].ToString());
                item.SubItems.Add(td.Rows[i][4].ToString());
                item.SubItems.Add(td.Rows[i][5].ToString());
                item.SubItems.Add(td.Rows[i][6].ToString());
                item.SubItems.Add(td.Rows[i][7].ToString());
                item.SubItems.Add(td.Rows[i][8].ToString());
                
                item.SubItems.Add(td.Rows[i][9].ToString());
                listView1.Items.Add(item);
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemSV frmthem = new frmThemSV(MaLop);
            frmthem.Show();
            this.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Khoa_Lop frm = new Khoa_Lop();
            frm.Show();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        //public string listView1_MouseClick(object sender, MouseEventArgs e)
        //{
           
        //}

      private void listView1_Click(object sender, EventArgs e)
        {
            string str;
            int row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;
            frmsuaSV frm = new frmsuaSV(str,MaLop);
           
            
        }


      private void button2_Click(object sender, EventArgs e)
      {
      
      }

      private void button2_Click_1(object sender, EventArgs e)
      {
          string str;
          int row = this.listView1.SelectedItems[0].Index;
          str = this.listView1.Items[row].SubItems[0].Text;
          frmsuaSV frm = new frmsuaSV(str,MaLop);
          frm.Show();
          this.Close();
      }

      private void button3_Click(object sender, EventArgs e)
      {
          string str;
          int row = this.listView1.SelectedItems[0].Index;
          str = this.listView1.Items[row].SubItems[0].Text;
          frmxoaSV frm = new frmxoaSV(str,MaLop);
          frm.Show();
          this.Close();
      }

      private void btnChiTiet_Click(object sender, EventArgs e)
      {
          string str;
          int row = this.listView1.SelectedItems[0].Index;
          str = this.listView1.Items[row].SubItems[0].Text;
          frmChiTietSinhVien frm = new frmChiTietSinhVien(str);
         
          frm.Show();

      }

      //private void listView1_DoubleClick(object sender, EventArgs e)
      //{

      //}
      //public string listView1_MouseClick()
      //{
      //}
    }
}
