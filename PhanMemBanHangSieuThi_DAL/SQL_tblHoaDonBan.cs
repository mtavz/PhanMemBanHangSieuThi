using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblHoaDonBan
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addHoaDonBan(EC_tblHoaDonBan et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblHoaDonBan	(MaHDB, MaKH, NgayBan, TongTien)    VALUES   ( '" + et.MaHDB + "' , N'" + et.MaKH + "', N'" + et.NgayBan + "', N'" + et.TongTien + "')");
        }
        //Sua du lieu
        public void updateHoaDonBan(EC_tblHoaDonBan et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE  tblHoaDonBan   SET  MaKH =N'" + et.MaKH + "', NgayBan =N'" + et.NgayBan + "', TongTien =N'" + et.TongTien + "'");
        }
        //Xoa du lieu
        public void delHoaDonBan(EC_tblHoaDonBan et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblHoaDonBan WHERE MaHDB = '" + et.MaHDB + "'");
        }
        //select
        public DataTable getAllHoaDonBan()
        {
            return cn.getDatatable(@"SELECT * FROM tblHoaDonBan ");
        }
        public DataTable getAllHoaDonBan(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblHoaDonBan " + dk);
        }
        //select chi tiet
        public DataTable getThongTinHoaDonBan()
        {
            return cn.getDatatable(@"SELECT MaHDB as MaHDB, MaKH, NgayBan, TongTien FROM tblHoaDonBan");
        }
        public DataTable getThongTinHoaDonBan(string dk)
        {
            return cn.getDatatable(@"SELECT MaHDB as MaHDB, MaKH, NgayBan, TongTien FROM tblHoaDonBan where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblHoaDonBan", Field));
        }
        public DataTable getHoaDonBan(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblHoaDonBan " + dk);
        }
    }
}
