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
    public class BUS_tblLoaiHang
    {
        SQL_tblLoaiHang bus = new SQL_tblLoaiHang();
        public void addLoaiHang(EC_tblLoaiHang et)
        {
            bus.addLoaiHang(et);
        }
        //Sua du lieu
        public void updateLoaiHang(EC_tblLoaiHang et)
        {
            bus.updateLoaiHang(et);
        }
        //Xoa du lieu
        public void delLoaiHang(EC_tblLoaiHang et)
        {
            bus.delLoaiHang(et);
        }
        //select
        public DataTable getAllLoaiHang()
        {
            return bus.getAllLoaiHang();
        }
        public DataTable getLoaiHang(string dk)
        {
            return bus.getLoaiHang(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
    }
}
