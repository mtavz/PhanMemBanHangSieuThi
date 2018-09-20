using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblNhanVien
    {
        private string _TenDn;

        public string TenDn
        {
            get { return _TenDn; }
            set { _TenDn = value; }
        }
        private string _MatKhau;

        public string MatKhau
        {
            get { return _MatKhau; }
            set { _MatKhau = value; }
        }
        private string _TenNV;

        public string TenNV
        {
            get { return _TenNV; }
            set { _TenNV = value; }
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
    }
}
