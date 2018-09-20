using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblKhachHang
    {
        private string _MaKH;
 
        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }

        private string _TenKH;
 
        public string TenKH
        {
            get { return _TenKH; }
            set { _TenKH = value; }
        }

        private string _GT;

        public string GT
        {
            get { return _GT; }
            set { _GT = value; }
        }
        private string _DiaChi;

        public string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
        private string _SDT;

        public string SDT
        {
            get { return _SDT; }
            set { _SDT = value; }
        }
        private string _LoaiKH;

        public string LoaiKH
        {
            get { return _LoaiKH; }
            set { _LoaiKH = value; }
        }
        private string _GhiChu;

        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }

        public EC_tblKhachHang(string ten, string gt, string diachi, string loai, string sdt, string ghichu)
        {
            DateTime date = DateTime.Now;
            Random rand = new Random();
            this.MaKH = date.Year.ToString().Substring(2, 2) + date.Month.ToString() + date.Day.ToString() + rand.Next(0, 9999).ToString();
            this.TenKH = ten;
            this.GT = gt;
            this.DiaChi = diachi;
            this.LoaiKH = loai;
            this.SDT = sdt;
            this.GhiChu = ghichu;
        }

        public EC_tblKhachHang()
        {
            // TODO: Complete member initialization
        }
    }
}
