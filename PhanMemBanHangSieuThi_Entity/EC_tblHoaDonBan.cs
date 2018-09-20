using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblHoaDonBan
    {
        private string _MaHDB;

        public string MaHDB
        {
            get { return _MaHDB; }
            set { _MaHDB = value; }
        }
        private string _MaKH;

        public string MaKH
        {
            get { return _MaKH; }
            set { _MaKH = value; }
        }
        private string _NgayBan;

        public string NgayBan
        {
            get { return _NgayBan; }
            set { _NgayBan = value; }
        }
        private int _TongTien;

        public int TongTien
        {
            get { return _TongTien; }
            set { _TongTien = value; }
        }
    }
}
