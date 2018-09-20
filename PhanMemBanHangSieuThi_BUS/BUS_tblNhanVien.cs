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
    public class BUS_tblNhanVien
    {
        SQL_tblNhanVien bus = new SQL_tblNhanVien();
        public void addNhanVien(EC_tblNhanVien et)
        {
            bus.addNhanVien(et);
        }
        //Sua du lieu
        public void updateNhanVien(EC_tblNhanVien et)
        {
            bus.updateNhanVien(et);
        }
        //Xoa du lieu
        public string delNhanVien(EC_tblNhanVien et)
        {
            return bus.delNhanVien(et);
        }
        //select
        public DataTable getAllNhanVien()
        {
            return bus.getAllNhanVien();
        }
        public DataTable getNhanVien(string dk)
        {
            return bus.getNhanVien(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
        public string checkLogin(string Username, string Password)
        {
            return bus.checkLogin(Username, Password);
        }
        public DataTable getNguoiDung()
        {
            return bus.getNguoiDung();
        }
        public void updateNguoiDung(EC_tblNhanVien et)
        {
            bus.updateNguoiDung(et);
        }
    }
}
