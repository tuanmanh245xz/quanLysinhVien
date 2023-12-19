using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace QuanLySinhVien
{
    class DangNhapHeThong
    {
        public bool LoginHeThong(string TenDangNhap, string MatKhau)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = KetNoi.str;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT TenDangNhap,MatKhau FROM QuanLyNguoiDung WHERE TenDangNhap='"+TenDangNhap+"' AND MatKhau='"+MatKhau+"' ";
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
