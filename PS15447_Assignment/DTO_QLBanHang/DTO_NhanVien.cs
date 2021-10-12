using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_NhanVien
    {
        private string email;
        private string tenNv;
        private string diaChi;
        private int vaiTro;
        private int tinhTrang;
        private string matKhau;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string TenNhanVien
        {
            get
            {
                return tenNv;
            }
            set
            {
                tenNv = value;
            }
        }
        public string DiaChi
        {
            get
            {
                return diaChi;
            }
            set
            {
                diaChi = value;
            }
        }
        public int VaiTro
        {
            get
            {
                return vaiTro;
            }
            set
            {
                vaiTro = value;
            }
        }
        public int TinhTrang
        {
            get
            {
                return tinhTrang;
            }
            set
            {
                tinhTrang = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;
            }
            set
            {
                matKhau = value;
            }
        }
        public DTO_NhanVien(string email, string tenNv, string diaChi, int vaiTro, int tinhTrang, string matKhau)
        {
            this.email = email;
            this.tenNv = tenNv;
            this.diaChi = diaChi;
            this.vaiTro = vaiTro;
            this.tinhTrang = tinhTrang;
            this.matKhau = matKhau;
        }
        public DTO_NhanVien(string email, string tenNv, string diaChi, int vaiTro, int tinhTrang)
        {
            this.email = email;
            this.tenNv = tenNv;
            this.diaChi = diaChi;
            this.vaiTro = vaiTro;
            this.tinhTrang = tinhTrang;
        }
        public DTO_NhanVien()
        {
        }
    }
}
