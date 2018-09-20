using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblPhieuBaoHanh
    {
        private string _SoPhieu;
        public string SoPhieu
        {
            get { return _SoPhieu; }
            set { _SoPhieu = value; }
        }
        private string _MaSP;
        public string MaSP
        {
            get { return _MaSP; }
            set { _MaSP = value; }
        }
        private string _MaKH;
        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        private string _NgayBatDau;
        public string NgayBatDau
        {
            get { return _NgayBatDau; }
            set { _NgayBatDau = value; }
        }
        private string _NgayKetThuc;
        public string NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { _NgayKetThuc = value; }
        }
        private string _SoLan;
        public string SoLan
        {
            get { return _SoLan; }
            set { _SoLan = value; }
        }
    }
}
