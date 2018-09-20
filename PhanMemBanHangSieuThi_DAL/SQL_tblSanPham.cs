using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblSanPham
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addSanPham(EC_tblSanPham et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblSanPham	(MaSP, TenSP, MaLH, SoLuong, GiaNhap, GiaBan, MoTa, NSX, HinhAnh)    VALUES   ( '" + et.MaSP + "' , N'" + et.TenSP + "', N'" + et.MaLH + "', N'" + et.SoLuong + "', N'" + et.GiaNhap + "', N'" + et.GiaBan + "', N'" + et.MoTa + "', N'" + et.NSX + "', N'" + et.HinhAnh + "')");
        }
        //Sua du lieu
        public void updateSanPham(EC_tblSanPham et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE  tblSanPham   SET  TenSP =N'" + et.TenSP + "', MaLH =N'" + et.MaLH + "', SoLuong =N'" + et.SoLuong + "', LoiNhuan =N'" + et.LoiNhuan + "', GiaNhap =N'" + et.GiaNhap + "', GiaBan =N'" + et.GiaBan + "', MoTa =N'" + et.MoTa + "', NSX =N'" + et.NSX + "', HinhAnh =N'" + et.HinhAnh + "', NhaCC =N'" + et.NCC + "'");
        }
        //Xoa du lieu
        public void delSanPham(EC_tblSanPham et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblSanPham WHERE MaSP = '" + et.MaSP + "'");
        }
        //select
        public DataTable getAllSanPham()
        {
            return cn.getDatatable(@"SELECT * FROM tblSanPham ");
        }
        public DataTable getAllSanPham(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblSanPham " + dk);
        }
        //select chi tiet
        public DataTable getThongTinSanPham()
        {
            return cn.getDatatable(@"SELECT MaSP as MaSP, TenSP, MaLH, SoLuong, LoiNhuan, GiaNhap, GiaBan, MoTa, NSX, HinhAnh, NhaCC FROM tblSanPham");
        }
        public DataTable getThongTinSanPham(string dk)
        {
            return cn.getDatatable(@"SELECT MaSP as MaSP, TenSP, MaLH, SoLuong, LoiNhuan, GiaNhap, GiaBan, MoTa, NSX, HinhAnh, NhaCC FROM tblSanPham where " + dk);
        }
        public DataTable getSanPham(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblSanPham " + dk);
        }
        public string getLastSP()
        {
            return cn.getValue(@"select top 1 MaSP from tblSanPham order by MaSP desc");
        }
    }
}
