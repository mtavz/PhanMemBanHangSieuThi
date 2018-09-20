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
    public class BUS_tblNhaCungCap
    {
        SQL_tblNhaCungCap bus = new SQL_tblNhaCungCap();
        public void addNhaCungCap(EC_tblNhaCungCap et)
        {
            bus.addNhaCungCap(et);
        }
        //Sua du lieu
        public void updateNhaCungCap(EC_tblNhaCungCap et)
        {
            bus.updateNhaCungCap(et);
        }
        //Xoa du lieu
        public void delNhaCungCap(EC_tblNhaCungCap et)
        {
            bus.delNhaCungCap(et);
        }
        //select
        public DataTable getAllNhaCungCap()
        {
            return bus.getAllNhaCungCap();
        }
        public DataTable getNhaCungCap(string dk)
        {
            return bus.getNhaCungCap(dk);
        }
        public DataTable getField(string Field)
        {
            return bus.getField(Field);
        }
    }
}
