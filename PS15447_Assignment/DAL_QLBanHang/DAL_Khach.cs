using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;

namespace DAL_QLBanHang
{
    public class DAL_Khach : DBConnect
    {
        
        public DataTable getKhach()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHKH";
                cmd.Connection = _conn;
                DataTable dtkhach = new DataTable();
                dtkhach.Load(cmd.ExecuteReader());
                return dtkhach;
            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
        }
        public bool insertKhach(DTO_Khach khach)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERTKHACHHANG";
                cmd.Parameters.AddWithValue("dienThoai", khach.DienThoai);
                cmd.Parameters.AddWithValue("tenKhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("diaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("phai", khach.GioiTinh);
                cmd.Parameters.AddWithValue("email", khach.emailKhach);
                //Query và kiểm tra
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool UpdateKhach(DTO_Khach khach)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATEKHACHHANG";
                cmd.Parameters.AddWithValue("dienThoai", khach.DienThoai);
                cmd.Parameters.AddWithValue("tenKhach", khach.TenKhach);
                cmd.Parameters.AddWithValue("diaChi", khach.DiaChi);
                cmd.Parameters.AddWithValue("phai", khach.GioiTinh);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool DeleteKhach(string soDT)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETEKHACHHANG";
                cmd.Parameters.AddWithValue("dienThoai", soDT);
                cmd.Connection = _conn;
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable SearchKhach(string soDT)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCHKHACHHANG";
                cmd.Parameters.AddWithValue("dienThoai", soDT);
                cmd.Connection = _conn;
                DataTable dtKhach = new DataTable();
                dtKhach.Load(cmd.ExecuteReader());
                return dtKhach;
            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
        }
    }
}
