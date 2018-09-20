using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_DAL;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_BUS
{
    public class BUS_tblKhachHang
    {
        SQL_tblKhachHang bus = new SQL_tblKhachHang();
        public void addKhachHang(EC_tblKhachHang et)
        {
            bus.addKhachHang(et);
        }
        //Sua du lieu
        public void updateKhachHang(EC_tblKhachHang et)
        {
            bus.updateKhachHang(et);
        }
        //Xoa du lieu
        public void delKhachHang(EC_tblKhachHang et)
        {
            bus.delKhachHang(et);
        }
        //select
        public DataTable getAllKhachHang()
        {
            return bus.getAllKhachHang();
        }
        public DataTable getKhachHang(string dk)
        {
            return bus.getKhachHang(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
    }
}
