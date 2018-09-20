using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBanHangSieuThi_BUS;

namespace PhanMemBanHangSieuThi
{
    public partial class frmDangNhap : Form
    {
        BUS_tblNhanVien busNV = new BUS_tblNhanVien();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == null)
            {
                MessageBox.Show("Chưa nhập mã nhân viên đăng nhập !");
            }
            if (txtMatKhau.Text == null)
            {
                MessageBox.Show("Chưa nhập mật khẩu !");
            }
            if (busNV.checkLogin(txtTenDangNhap.Text, txtMatKhau.Text) != null)
            {
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu chưa đúng !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
