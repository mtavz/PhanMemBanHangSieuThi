using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblNhanVien
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addNhanVien(EC_tblNhanVien et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblNhanVien	(TenDn, MatKhau, TenNV, GT, DiaChi, SDT)    VALUES   ( '" + et.TenDn + "' , N'" + et.MatKhau + "', N'" + et.TenNV + "', N'" + et.GT + "', '" + et.DiaChi + "', '" + et.SDT + "')");
        }
        //Sua du lieu
        public void updateNhanVien(EC_tblNhanVien et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE tblNhanVien SET TenNV =N'" + et.TenNV + "', GT =N'" + et.GT + "', DiaChi = N'" + et.DiaChi + "', SDT = '" + et.SDT + "' where TenDn = '" + et.TenDn + "'");
        }
        //Xoa du lieu
        public string delNhanVien(EC_tblNhanVien et)
        {
            return cn.ThucThiCauLenhSQL_CoThongBao(@"DELETE FROM tblNhanVien WHERE TenDn = N'" + et.TenDn + "'");
        }
        //select
        public DataTable getAllNhanVien()
        {
            return cn.getDatatable(@"SELECT TenDn, TenNV, GT, DiaChi, SDT FROM tblNhanVien ");
        }
        public DataTable getAllNhanVien(string dk)
        {
            return cn.getDatatable(@"SELECT TenDn, TenNV, GT, DiaChi, SDT FROM tblNhanVien " + dk);
        }
        //select chi tiet
        public DataTable getThongTinNhanVien()
        {
            return cn.getDatatable(@"SELECT TenDn as TenDn, MatKhau, TenNV, GT, DiaChi, SDT FROM tblNhanVien");
        }
        public DataTable getThongTinNhanVien(string dk)
        {
            return cn.getDatatable(@"SELECT TenDn as TenDn, MatKhau, TenNV, GT, DiaChi, SDT FROM tblNhanVien where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblNhanVien", Field));
        }
        public DataTable getNhanVien(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblNhanVien " + dk);
        }
        public string checkLogin(string Username, string Password)
        {
            return cn.getValue(@"SELECT TenDn,MatKhau FROM tblNhanVien WHERE TenDn ='" + Username + "' and MatKhau ='" + Password + "'");
        }
        public DataTable getNguoiDung()
        {
            return cn.getDatatable(@"SELECT TenDn, MatKhau FROM tblNhanVien " );
        }
        public void updateNguoiDung(EC_tblNhanVien et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE tblNhanVien set MatKhau =N'" + et.MatKhau + "'WHERE TenDn = '"+ et.TenDn + "'");
        }
    }
}
