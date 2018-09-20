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
    public class BUS_tblPhieuBaoHanh
    {
        SQL_tblPhieuBaoHanh bus = new SQL_tblPhieuBaoHanh();
        public void addPhieuBaoHanh(EC_tblPhieuBaoHanh et)
        {
            bus.addPhieuBaoHanh(et);
        }
        //Sua du lieu
        public void updatePhieuBaoHanh(EC_tblPhieuBaoHanh et)
        {
            bus.updatePhieuBaoHanh(et);
        }
        //Xoa du lieu
        public void delPhieuBaoHanh(EC_tblPhieuBaoHanh et)
        {
            bus.delPhieuBaoHanh(et);
        }
        //select
        public DataTable getAllPhieuBaoHanh()
        {
            return bus.getAllPhieuBaoHanh();
        }
        public DataTable getPhieuBaoHanh(string dk)
        {
            return bus.getPhieuBaoHanh(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
    }
}
