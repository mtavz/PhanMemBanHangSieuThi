using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBanHangSieuThi_DAL;
using PhanMemBanHangSieuThi_Entity;

namespace PhanMemBanHangSieuThi
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private EC_tblNhanVien EC_NV = new EC_tblNhanVien();
        private SQL_tblNhanVien DAL_NV = new SQL_tblNhanVien();

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            dgvDanhSach.DataSource = DAL_NV.getAllNhanVien();
            dgvDanhSach.Focus();
        }

        private void dgvDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtTenDN.Text = dgvDanhSach.Rows[e.RowIndex].Cells["TenDN"].Value.ToString();
            txtTenNV.Text = dgvDanhSach.Rows[e.RowIndex].Cells["TenNV"].Value.ToString();
            txtSDT.Text = dgvDanhSach.Rows[e.RowIndex].Cells["SDT"].Value.ToString();
            txtDiaChi.Text = dgvDanhSach.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            if (dgvDanhSach.Rows[e.RowIndex].Cells["GT"].Value.ToString() != "")
            {
                if (dgvDanhSach.Rows[e.RowIndex].Cells["GT"].Value.ToString() == "Nam")
                {
                    cboGioiTinh.Text = "Nam";
                }
                else
                {
                    cboGioiTinh.Text = "Nữ";
                }
            } 
            else
            {
                cboGioiTinh.ResetText();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmNhanVien_Load(null, null);
        }

        private void gan()
        {
            EC_NV.DiaChi = txtDiaChi.Text;
            EC_NV.SDT = txtSDT.Text;
            EC_NV.TenNV = txtTenNV.Text;
            EC_NV.TenDn = txtTenDN.Text;
            if (cboGioiTinh.Text == "Nam")
            {
                EC_NV.GT = "Nam";
            }
            else
            {
                EC_NV.GT = "Nu";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            gan();
            txtTenNV.Enabled = false;
            txtSDT.Enabled = false;
            txtDiaChi.Enabled = false;
            cboGioiTinh.Enabled = false;
            dgvDanhSach.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnRefresh.Enabled = true;

            DAL_NV.updateNhanVien(EC_NV);

            frmNhanVien_Load(null, null);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtTenNV.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            cboGioiTinh.Enabled = true;
            dgvDanhSach.Enabled = false;
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnRefresh.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Có chắc chắn muốn xóa thông tin tài khoản " + txtTenDN.Text,"Xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EC_NV.TenDn = txtTenDN.Text;
                EC_NV.TenNV = "";
                EC_NV.SDT = "";
                EC_NV.DiaChi = "";
                EC_NV.GT = "";
                DAL_NV.updateNhanVien(EC_NV);
                frmNhanVien_Load(null, null);
            }
        }
    }
}
