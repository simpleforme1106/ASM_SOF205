using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLBanHang;
using DTO_QLBanHang;

namespace BUS_QLBanHang
{
    public class BUS_Hang
    {
        DAL_Hang dalHang = new DAL_Hang();
        public DataTable getHang()
        {
            return dalHang.getHang();
        }
        public bool InsertHang(DTO_Hang hang)
        {
            return dalHang.insertHang(hang);
        }
        public bool UpdateHang(DTO_Hang hang)
        {
            return dalHang.UpdateHang(hang);
        }
        public bool DeleteHang(int maHang)
        {
            return dalHang.DeleteHang(maHang);
        }
        public DataTable SearchHang(string tenHang)
        {
            return dalHang.SearchHang(tenHang);
        }
        //public DataTable ThongKeHang()
        //{
        //    return dalHang.ThongKeHang();
        //}
        //public DataTable ThongKeTonKho()
        //{
        //    return dalHang.ThongKeTonKho();
        //}
    }
}
