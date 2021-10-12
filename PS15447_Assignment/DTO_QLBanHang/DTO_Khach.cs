using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLBanHang
{
    public class DTO_Khach
    {
        private string dienThoai;
        private string tenKhach;
        private string diaChi;
        private string phai;
        public string emailKhach; //Ghi nhận nhân viên nào nhập Khách hàng
        private string maNv;
        public string DienThoai
        {
            get
            {
                return dienThoai;
            }
            set
            {
                dienThoai = value;
            }
        }
        public string TenKhach
        {
            get
            {
                return tenKhach;
            }
            set
            {
                tenKhach = value;
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
        public string GioiTinh
        {
            get
            {
                return phai;
            }
            set
            {
                phai = value;
            }
        }
        public string MaNhanVien
        {
            get
            {
                return maNv;
            }
            set
            {
                maNv = value;
            }
        }
        public DTO_Khach(string dienThoai, string tenKhach, string diaChi, string phai, string email = null)
        {
            this.dienThoai = dienThoai;
            this.tenKhach = tenKhach;
            this.diaChi = diaChi;
            this.phai = phai;
            this.emailKhach = email;
        }
    }
}
