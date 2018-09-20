using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;


namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblPhieuBaoHanh
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addPhieuBaoHanh(EC_tblPhieuBaoHanh et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblPhieuBaoHanh	(SoPhieu, MaSP, MaKH, NgayBatDau, NgayKetThuc, SoLan)    VALUES   ( N'" + et.SoPhieu + "' , N'" + et.MaSP + "', N'" + et.MaKH + "', N'" + et.NgayBatDau + "', N'" + et.NgayKetThuc + "', N'" + et.SoLan + "')");
        }
        //Sua du lieu
        public void updatePhieuBaoHanh(EC_tblPhieuBaoHanh et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE   tblPhieuBaoHanh   SET  MaSP =N'" + et.MaSP + "', MaKH =N'" + et.MaKH + "', NgayBatDau =N'" + et.NgayBatDau + "', SoLan =N'" + et.SoLan + "'");
        }
        //Xoa du lieu
        public void delPhieuBaoHanh(EC_tblPhieuBaoHanh et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblPhieuBaoHanh WHERE SoPhieu = '" + et.SoPhieu + "'");
        }
        //select
        public DataTable getAllPhieuBaoHanh()
        {
            return cn.getDatatable(@"SELECT * FROM tblPhieuBaoHanh ");
        }
        public DataTable getAllPhieuBaoHanh(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblPhieuBaoHanh " + dk);
        }
        //select chi tiet
        public DataTable getThongTinPhieuBaoHanh()
        {
            return cn.getDatatable(@"SELECT SoPhieu as SoPhieu, MaSP, NgayBatDau, NgayKetThuc, SoLan FROM tblPhieuBaoHanh");
        }
        public DataTable getThongTinPhieuBaoHanh(string dk)
        {
            return cn.getDatatable(@"SELECT SoPhieu as SoPhieu, MaSP, NgayBatDau, NgayKetThuc, SoLan FROM tblPhieuBaoHanh where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblPhieuBaoHanh", Field));
        }
        public DataTable getPhieuBaoHanh(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblPhieuBaoHanh " + dk);
        }
    }
}
