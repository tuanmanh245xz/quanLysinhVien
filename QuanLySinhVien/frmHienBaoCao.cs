using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class frmHienBaoCao : Form
    {
        string Lop_ID, MonHoc_ID;
        public frmHienBaoCao(string MaLop,string MaMonHoc)
        {
            Lop_ID = MaLop;
            MonHoc_ID = MaMonHoc;
            InitializeComponent();
        }
    }
}
