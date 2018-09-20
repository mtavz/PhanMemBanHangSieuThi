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
    public class BUS_tblSanPham
    {
        SQL_tblSanPham bus = new SQL_tblSanPham();
        public void addSanPham(EC_tblSanPham et)
        {
            bus.addSanPham(et);
        }
        //Sua du lieu
        public void updateSanPham(EC_tblSanPham et)
        {
            bus.updateSanPham(et);
        }
        //Xoa du lieu
        public void delSanPham(EC_tblSanPham et)
        {
            bus.delSanPham(et);
        }
        //select
        public DataTable getAllSanPham()
        {
            return bus.getAllSanPham();
        }
        public DataTable getSanPham(string dk)
        {
            return bus.getSanPham(dk);
        }
        //public DataTable getField(string Field)
        //{
            //return bus.getField(Field);
        //}
    }
}
