using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblChiTietHoaDon
    {
        private string _MaHD;

        public string MaHD
        {
            get { return _MaHD; }
            set { _MaHD = value; }
        }
        private string _MaSP;
        public string MaSP
        {
            get { return _MaSP; }
            set { _MaSP = value; }
        }
        private int _SoLuong;
        public int SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }
        private int _DonGia;
        public int DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }
        private int _ThanhTien;
        public int ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }
    }
}
