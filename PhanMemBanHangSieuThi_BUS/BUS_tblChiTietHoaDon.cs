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
    public class BUS_tblChiTietHoaDon
    {
        SQL_tblChiTietHoaDon bus = new SQL_tblChiTietHoaDon();
        public void addChiTietHoaDon(EC_tblChiTietHoaDon et)
        {
            bus.addChiTietHoaDon(et);
        }
        //Sua du lieu
        public void updateChiTietHoaDon(EC_tblChiTietHoaDon et)
        {
            bus.updateChiTietHoaDon(et);
        }
        //Xoa du lieu
        public void delChiTietHoaDon(EC_tblChiTietHoaDon et)
        {
            bus.delChiTietHoaDon(et);
        }
        //select
        public DataTable getAllChiTietHoaDon()
        {
            return bus.getAllChiTietHoaDon();
        }
        public DataTable getChiTietHoaDon(string dk)
        {
            return bus.getChiTietHoaDon(dk);
        }
        public DataTable getChiTiet(string dk)
        {
            return bus.getChiTiet(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
        public DataTable LayRaMaHD()
        {
            return bus.LayRaMaHD();
        }
        public DataTable LayRaNV()
        {
            return bus.LayRaNhanVien();
        }
        public DataTable LayRaSP(EC_tblChiTietHoaDon ec)
        {
            return bus.LayRaSP(ec);
        }
        public DataTable TongSL(EC_tblChiTietHoaDon ec)
        {
            return bus.TongSL(ec);
        }
        public DataTable TongTien(EC_tblChiTietHoaDon ec)
        {
            return bus.TongTien(ec);
        }
    }
}
