using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DTO_QLBanHang;
using System.Data;

namespace DAL_QLBanHang
{
    public class DAL_NhanVien : DBConnect
    {
        public bool NhanVienDangNhap(DTO_NhanVien nv)
        {
            //Use sql statement
            try
            {
                //Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANGNHAP";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("matKhau", nv.MatKhau);
                //Query và kiểm tra
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch(Exception e) { }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
            return false;
        }
        public bool NhanVienQuenMatKhau(string email)
        {
            //using store procedure
            try
            {
                //Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "QUENMATKHAU";
                cmd.Parameters.AddWithValue("email", email);
                //Query và kiểm tra
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public bool TaoMatKhau(string email, string matKhauMoi)
        {
            //using store procedure
            try
            {
                //Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TAOMOIMATKHAU";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("matKhau", matKhauMoi);
                //Query và kiểm tra
                if (Convert.ToInt16(cmd.ExecuteScalar()) > 0)
                    return true;
            }
            catch { }
            finally
            {
                _conn.Close();
            }
            return false;
        }
        public DataTable VaiTroNhanVien(string email)
        {
            //using store procedure
            try
            {
                //Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LAYVAITRONHANVIEN";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Connection = _conn;
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
        }
        public bool UpdateMatKhau(string email, string matKhauCu, string matKhauMoi)
        {
            //using store procedure
            try
            {
                //Ket noi
                _conn.Open();
                //Command (mặc định command type = text nên chúng ta khỏi phải làm gì nhiều)
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DOIMATKHAU";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("old", matKhauCu);
                cmd.Parameters.AddWithValue("new", matKhauMoi);
                //Query và kiếm tra
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
        public DataTable getNhanVien()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DANHSACHNV";
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
        public bool insertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                //Ket noi
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "INSERTNHANVIEN";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("tenNv", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("diaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("tinhTrang", nv.TinhTrang);
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
        public bool UpdateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UPDATENHANVIEN";
                cmd.Parameters.AddWithValue("email", nv.Email);
                cmd.Parameters.AddWithValue("tenNv", nv.TenNhanVien);
                cmd.Parameters.AddWithValue("diaChi", nv.DiaChi);
                cmd.Parameters.AddWithValue("vaiTro", nv.VaiTro);
                cmd.Parameters.AddWithValue("tinhTrang", nv.TinhTrang);
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
        public DataTable SearchNhanVien(string tenNhanvien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SEARCHNHANVIEN";
                cmd.Parameters.AddWithValue("tenNv", tenNhanvien);
                cmd.Connection = _conn;
                DataTable dtNhanVien = new DataTable();
                dtNhanVien.Load(cmd.ExecuteReader());
                return dtNhanVien;
            }
            finally
            {
                //Dong ket noi
                _conn.Close();
            }
        }
        public bool DeleteNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DELETENHANVIEN";
                cmd.Parameters.AddWithValue("email", email);
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
    }
}
