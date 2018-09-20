using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblNhaCungCap
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addNhaCungCap(EC_tblNhaCungCap et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblNhaCungCap (TenNCC, DiaChi, SDT)    VALUES   ( '" + et.TenNCC + "' , N'" + et.DiaChi + "', N'" + et.SDT + "')");
        }
        //Sua du lieu
        public void updateNhaCungCap(EC_tblNhaCungCap et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE   tblNhaCungCap   SET  DiaChi =N'" + et.DiaChi + "', SDT = '" + et.SDT + "'");
        }
        //Xoa du lieu
        public void delNhaCungCap(EC_tblNhaCungCap et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblNhaCungCap WHERE TenNCC = '" + et.TenNCC + "'");
        }
        //select
        public DataTable getAllNhaCungCap()
        {
            return cn.getDatatable(@"SELECT * FROM tblNhaCungCap ");
        }
        public DataTable getAllNhaCungCap(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblNhaCungCap " + dk);
        }
        //select chi tiet
        public DataTable getThongTinNhaCungCap()
        {
            return cn.getDatatable(@"SELECT TenNCC as TenNCC, DiaChi, SDT FROM tblNhaCungCap");
        }
        public DataTable getThongTinNhaCungCap(string dk)
        {
            return cn.getDatatable(@"SELECT TenNCC as TenNCC, DiaChi, SDT FROM tblNhaCungCap where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblNhaCungCap", Field));
        }
        public DataTable getNhaCungCap(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblNhaCungCap " + dk);
        }
    }
}
