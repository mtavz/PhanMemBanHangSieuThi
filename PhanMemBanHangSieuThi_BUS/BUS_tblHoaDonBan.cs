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
    public class BUS_tblHoaDonBan
    {
        SQL_tblHoaDonBan bus = new SQL_tblHoaDonBan();
        public void addHoaDonBan(EC_tblHoaDonBan et)
        {
            bus.addHoaDonBan(et);
        }
        //Sua du lieu
        public void updateHoaDonBan(EC_tblHoaDonBan et)
        {
            bus.updateHoaDonBan(et);
        }
        //Xoa du lieu
        public void delHoaDonBan(EC_tblHoaDonBan et)
        {
            bus.delHoaDonBan(et);
        }
        //select
        public DataTable getAllHoaDonBan()
        {
            return bus.getAllHoaDonBan();
        }
        public DataTable getHoaDonBan(string dk)
        {
            return bus.getHoaDonBan(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
    }
}
