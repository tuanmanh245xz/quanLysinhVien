using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace QuanLySinhVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Khoa_Lop frm2 = new Khoa_Lop();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void khoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhoa frm = new frmKhoa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void lớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLop_Khoa frm = new frmLop_Khoa();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mônHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDSMonHoc frm = new frmDSMonHoc();
            frm.MdiParent = this;
            frm.Show();
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmDangNhapAdmin frm = new frmDangNhapAdmin();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tìmKiếmSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTimSinhVien frm = new frmTimSinhVien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDangNhapHeThong frm = new frmDangNhapHeThong();
            frm.MdiParent = this;
            frm.Show();
        }
        public void EnableMenu()
        {
            sinhViênToolStripMenuItem.Enabled = true;
            khoaToolStripMenuItem.Enabled = true;
            lớpToolStripMenuItem.Enabled = true;
            mônHọcToolStripMenuItem.Enabled = true;
            tìmKiếmSinhViênToolStripMenuItem.Enabled = true;
            báoCáoSinhViênToolStripMenuItem.Enabled = true;
        }
        public void DisableMenu()
        {
            sinhViênToolStripMenuItem.Enabled = false;
            khoaToolStripMenuItem.Enabled = false;
            lớpToolStripMenuItem.Enabled = false;
            mônHọcToolStripMenuItem.Enabled = false;
            tìmKiếmSinhViênToolStripMenuItem.Enabled = false;
            báoCáoSinhViênToolStripMenuItem.Enabled = false;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableMenu();
        }

        private void báoCáoSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trợGiupToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saoLưuDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = KetNoi.str;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "BACKUP DATABASE [QuanLySinhVien] TO DISK='E:\\backup.bak'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Backup Database Quản Lý Sinh Viên Thành Công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString(),"BACKUP DATABASE");
                    return;
                }
                
            
        }

        private void phụcHồiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = KetNoi.str;
                con.Open();
                string strpath = "E:\\backup.bak";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "USE master RESTORE DATABASE [QuanLySinhVien] FROM DISK='" + strpath + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Restore Database Quản Lý Sinh Viên Thành Công!","Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.ToString(), "ERROR RESTORE DATABASE");
                return;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
            
    }
}
