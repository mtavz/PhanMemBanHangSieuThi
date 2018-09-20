using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemBanHangSieuThi_Entity
{
    public class EC_tblLoaiHang
    {
        private string _MaLH;
        public string MaLH
        {
            get { return _MaLH; }
            set { _MaLH = value; }
        }
        private string _TenLH;
        public string TenLH
        {
            get { return _TenLH; }
            set { _TenLH = value; }
        }
    }
}
