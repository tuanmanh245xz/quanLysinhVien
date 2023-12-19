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
    public partial class frmDSLop : Form
    {
        string Khoa_ID;
        public frmDSLop(string Ma)
        {
            Khoa_ID = Ma;
            InitializeComponent();
        }

        private void frmDSLop_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Lop WHERE ID_Khoa='"+Khoa_ID+"'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(td.Rows[i][0].ToString());
                item.SubItems.Add(td.Rows[i][1].ToString());
                listView1.Items.Add(item);

            }
            con.Close();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLop_Khoa frm = new frmLop_Khoa();
            frm.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string str;
            int row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;
            frmSuaLop frm = new frmSuaLop(str,Khoa_ID);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmThemLop frm = new frmThemLop(Khoa_ID);
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string str;
            int row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;
            this.Close();
            frmSuaLop frm = new frmSuaLop(str,Khoa_ID);
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string str;
            int row = this.listView1.SelectedItems[0].Index;
            str = this.listView1.Items[row].SubItems[0].Text;
            this.Close();
            frmXoaLop frm = new frmXoaLop(str,Khoa_ID);
            frm.Show();
        }
    }
}
