using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    class DangNhapNguoiDung
    {
        public bool DangNhap(string TenDangNhap, string MatKhau, string QuyenHan)
        {
           
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM QuanLyNguoiDung WHERE TenDangNhap='" + TenDangNhap + "' and MatKhau='" + MatKhau + "' and QuyenHan='" + QuyenHan + "'";
            SqlDataReader rd;
            rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
    }
}
