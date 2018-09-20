using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhanMemBanHangSieuThi_Entity;
using System.Data;

namespace PhanMemBanHangSieuThi_DAL
{
    public class SQL_tblLoaiHang
    {
        KetNoiDB cn = new KetNoiDB();
        //Them du lieu
        public void addLoaiHang(EC_tblLoaiHang et)
        {
            cn.ThucThiCauLenhSQL(@"INSERT INTO tblLoaiHang	(MaLH, TenLH)    VALUES   ( '" + et.MaLH + "' , N'" + et.TenLH + "')");
        }
        //Sua du lieu
        public void updateLoaiHang(EC_tblLoaiHang et)
        {
            cn.ThucThiCauLenhSQL(@"UPDATE  tblLoaiHang   SET  TenLH =N'" + et.TenLH + "'");
        }
        //Xoa du lieu
        public void delLoaiHang(EC_tblLoaiHang et)
        {
            cn.ThucThiCauLenhSQL(@"DELETE FROM tblLoaiHang WHERE MaLH = '" + et.MaLH + "'");
        }
        //select
        public DataTable getAllLoaiHang()
        {
            return cn.getDatatable(@"SELECT * FROM tblLoaiHang ");
        }
        public DataTable getAllLoaiHang(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblLoaiHang " + dk);
        }
        //select chi tiet
        public DataTable getThongTinLoaiHang()
        {
            return cn.getDatatable(@"SELECT MaLH as MaLH, TenLH FROM tblLoaiHang");
        }
        public DataTable getThongTinLoaiHang(string dk)
        {
            return cn.getDatatable(@"SELECT MaLH as MaLH, TenLH FROM tblLoaiHang where " + dk);
        }
        public DataTable getField(string Field)
        {
            return cn.getDatatable(String.Format(@"SELECT distinct {0} FROM tblLoaiHang", Field));
        }
        public DataTable getLoaiHang(string dk)
        {
            return cn.getDatatable(@"SELECT * FROM tblLoaiHang " + dk);
        }
    }
}
