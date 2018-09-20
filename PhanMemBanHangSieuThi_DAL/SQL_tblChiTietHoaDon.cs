using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblChiTietHoaDon
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addChiTietHoaDon(EC_tblChiTietHoaDon et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblChiTietHoaDon	(MaHD, MaSP, SoLuong, DonGia, ThanhTien)    VALUES   ( '" + et.MaHD + "' , N'" + et.MaSP + "', N'" + et.SoLuong + "', N'" + et.DonGia + "', '" + et.ThanhTien + "')");
        }
        //Sua du lieu
        public void updateChiTietHoaDon(EC_tblChiTietHoaDon et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE   tblChiTietHoaDon   SET  SoLuong =N'" + et.SoLuong + "', DonGia =N'" + et.DonGia + "', ThanhTien =N'" + et.ThanhTien + "'");
        }
        //Xoa du lieu
        public void delChiTietHoaDon(EC_tblChiTietHoaDon et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblChiTietHoaDon WHERE MaHD = '" + et.MaHD + " AND MaSP = '" + et.MaSP + "'");
        }
        //select
        public DataTable getAllChiTietHoaDon()
        {
            return cn.getDatatable(@"SELECT * FROM tblChiTietHoaDon ");
        }
        public DataTable getAllChiTietHoaDon(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblChiTietHoaDon " + dk);
        }
        //select chi tiet
        public DataTable getThongTinChiTietHoaDon()
        {
            return cn.getDatatable(@"SELECT MaHD,maSp as MaHD, MaSP, SoLuong, DonGia, ThanhTien FROM tblChiTietHoaDon");
        }
        public DataTable getThongTinChiTietHoaDon(string dk)
        {
            return cn.getDatatable(@"SELECT MaHD,maSp as MaHD, MaSP, SoLuong, DonGia, ThanhTien FROM tblChiTietHoaDon where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblChiTietHoaDon", Field));
        }
        public DataTable getChiTietHoaDon(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblChiTietHoaDon " + dk);
        }
        public DataTable getChiTiet(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblChiTietHoaDon " + dk);
        }
        public DataTable LayRaMaHD()//lấy ra top 1 mã thiết bị có tên mã thiết bị là gì đó
        {
            return cn.getDatatable("select top 1  MaHD from tblChiTietHoaDon order by MaHD desc ");
        }
        public DataTable LayRaNhanVien()//lấy ra top 1 mã thiết bị có tên mã thiết bị là gì đó
        {
            return cn.getDatatable("select TenNV from tblNhanVien ");
        }
        public DataTable LayRaSP(EC_tblChiTietHoaDon ec)
        {
            return cn.getDatatable("select *from tblSanPham where MaSP=N'" + ec.MaSP + "'");
        }
        public DataTable TongSL(EC_tblChiTietHoaDon ec)
        {
            return cn.getDatatable("select sum(SoLuong)as TongSL from tblChiTietHoaDon where MaHD=N'" + ec.MaHD + "' group by MaHD");
        }
        public DataTable TongTien(EC_tblChiTietHoaDon ec)
        {
            return cn.getDatatable("select sum(ThanhTien)as TongTien from tblChiTietHoaDon where MaHD=N'" + ec.MaHD + "' group by MaHD");
        }
    }
}
