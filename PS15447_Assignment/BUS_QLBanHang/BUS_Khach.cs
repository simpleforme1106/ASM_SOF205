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
    public class BUS_Khach
    {
        DAL_Khach dalKhach = new DAL_Khach();
        public bool insertKhach(DTO_Khach khach)
        {
            return dalKhach.insertKhach(khach);
        }
        public DataTable getKhach()
        {
            return dalKhach.getKhach();
        }
        public bool UpdateKhach(DTO_Khach khach)
        {
            return dalKhach.UpdateKhach(khach);
        }
        public bool DeleteKhach(string soDT)
        {
            return dalKhach.DeleteKhach(soDT);
        }
        public DataTable SearchKhach(string soDT)
        {
            return dalKhach.SearchKhach(soDT);
        }
    }
}
