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
    public partial class frmThemSV : Form
    {
        string Lop_ID;
        string hinhanh;
        public frmThemSV(string ma)
        {
            Lop_ID = ma;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            MessageBox.Show("CẬP NHẬT DỮ LIỆU THÀNH CÔNG");
           this.Close();
            frmThemSV frm = new frmThemSV(Lop_ID);
            frm.Show();
           
            

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM Lop order by Lop_ID ";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            for (int i = 0; i < td.Rows.Count; i++)
            {
                this.cbxTenLop.Items.Add(td.Rows[i][1]);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDSSV frm = new frmDSSV(Lop_ID);
            frm.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sex;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string TenLop;
            TenLop = cbxTenLop.SelectedItem.ToString();
            cmd.CommandText = "select* from Lop where TenLop ='" + TenLop + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            DataTable td = new DataTable();
            td.Load(rd);
            string MaLop = td.Rows[0][0].ToString();
            if (radioButton7.Checked == true)
                sex = 0;
            else
                sex = 1;
            
            cmd.CommandText = "INSERT INTO SinhVien VALUES('" + txtmaSV.Text + "','" + txtTenSV.Text + "'," + sex + ",'" + mskNgaySinh.Text + "','" + txtNoiS.Text + "','" + txtTT.Text + "','" + txtKH.Text + "','" + txtLL.Text + "','" + MaLop + "','"+hinhanh+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            string strmasv;
            string strtensv;
            strtensv = txtTenSV.Text;
            strmasv = txtmaSV.Text;
            frmthemkqSV frm = new frmthemkqSV(strmasv,strtensv);
            frm.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            OpenFileDialog dl = new OpenFileDialog();
            dl.InitialDirectory = Application.StartupPath + @"hinhanh/";
            if (dl.ShowDialog() == DialogResult.OK)
            {
                hinhanh = dl.FileName.Substring(dl.FileName.LastIndexOf("\\") + 1, dl.FileName.Length - dl.FileName.LastIndexOf("\\") - 1);
                pictureBox1.Image = new Bitmap(Application.StartupPath + @"\hinhanh\" + hinhanh);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
