using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanHangSieuThi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frm = new frmQuanLyNguoiDung();
            frm.Show();
            this.Hide();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnHuongDanCaiDat_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKeHangHoa_Click(object sender, EventArgs e)
        {

        }

        private void btnQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.Show();
        }

        private void btNhapHangMoi_Click(object sender, EventArgs e)
        {
            frmNhapHang frm = new frmNhapHang();
            frm.Show();
        }

        private void btnQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.Show();
        }

        private void btnTimKiemHang_Click(object sender, EventArgs e)
        {
            frmTimKiemHangHoa frm = new frmTimKiemHangHoa();
            frm.Show();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            frmBanHangSieuThi frm = new frmBanHangSieuThi();
            frm.Show();
        }

        private void btnHuongDanSuDung_Click(object sender, EventArgs e)
        {
            frmHuongDan fr = new frmHuongDan();
            fr.Show();
        }
    }
}
