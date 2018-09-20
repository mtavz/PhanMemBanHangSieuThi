using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PhanMemBanHangSieuThi_Entity;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblKhachHang
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addKhachHang(EC_tblKhachHang et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblKhachHang	(MaKH, TenKH, GT, DiaChi, SDT, LoaiKH, GhiChu)    VALUES   ( '" + et.MaKH + "' , N'" + et.TenKH + "', N'" + et.GT + "', N'" + et.DiaChi + "', N'" + et.SDT + "', N'" + et.LoaiKH + "', N'" + et.GhiChu + "')");
        }
        //Sua du lieu
        public void updateKhachHang(EC_tblKhachHang et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE   tblKhachHang  SET  TenKH = N'" + et.TenKH + "', GT = N'" + et.GT + "', DiaChi = N'" + et.DiaChi + "', SDT = N'" + et.SDT + "', LoaiKH = N'" + et.LoaiKH + "', GhiChu = N'" + et.GhiChu + "'");
        }
        //Xoa du lieu
        public void delKhachHang(EC_tblKhachHang et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblKhachHang WHERE MaKH = '" + et.MaKH + "'");
        }
        //select
        public DataTable getAllKhachHang()
        {
            return cn.getDatatable(@"SELECT * FROM tblKhachHang ");
        }
        public DataTable getAllKhachHang(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblNhanVien " + dk);
        }
        //select chi tiet
        public DataTable getThongTinKhachHang()
        {
            return cn.getDatatable(@"SELECT MaKH as MaKH, TenKH, GT, DiaChi, SDT, LoaiKH, GhiChu FROM tblKhachHang");
        }
        public DataTable getThongTinKhachHang(string dk)
        {
            return cn.getDatatable(@"SELECT MaKH as MaKH, TenKH, GT, DiaChi, SDT, LoaiKH, GhiChu FROM tblKhachHang where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblKhachHang", Field));
        }
        public DataTable getKhachHang(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblKhachHang " + dk);
        }
    }
}
