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
    public class DAL_Hang : DBConnect
    {
        public DataTable getHang()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHHANG";
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
        }
        public bool insertHang(DTO_Hang hang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERTHANG";
                cmd.Parameters.AddWithValue("tenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("soLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("donGiaNhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("donGiaBan", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("hinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("ghiChu", hang.GhiChu);
                cmd.Parameters.AddWithValue("email", hang.EmailNV);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
            return false;
        }
        public bool UpdateHang(DTO_Hang hang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATEHANG";
                cmd.Parameters.AddWithValue("maHang", hang.MaHang);
                cmd.Parameters.AddWithValue("tenHang", hang.TenHang);
                cmd.Parameters.AddWithValue("soLuong", hang.SoLuong);
                cmd.Parameters.AddWithValue("donGiaNhap", hang.DonGiaNhap);
                cmd.Parameters.AddWithValue("donGiaBan", hang.DonGiaBan);
                cmd.Parameters.AddWithValue("hinhAnh", hang.HinhAnh);
                cmd.Parameters.AddWithValue("ghiChu", hang.GhiChu);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
            }
            catch (Exception e)
            {

            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
            return false;
        }
        public bool DeleteHang(int maHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETEHANG";
                cmd.Parameters.AddWithValue("maHang", maHang);
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
        public DataTable SearchHang(string tenHang)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCHHANG";
                cmd.Parameters.AddWithValue("tenHang", tenHang);
                cmd.Connection = _conn;
                DataTable dtHang = new DataTable();
                dtHang.Load(cmd.ExecuteReader());
                return dtHang;
            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
        }
        //public DataTable ThongKeHang()
        //{
            
        //}
        //public DataTable ThongKeTonKho()
        //{

        //}
    }
}
