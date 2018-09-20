using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using PhanMemBanHangSieuThi_DAL;
using PhanMemBanHangSieuThi_Entity;
using PhanMemBanHangSieuThi_BUS;
namespace PhanMemBanHangSieuThi
{
    public partial class frmTimKiemHangHoa : Form
    {
        SQL_tblSanPham sp = new SQL_tblSanPham();
        SQL_tblLoaiHang lh = new SQL_tblLoaiHang();
        EC_tblSanPham sanpham = new EC_tblSanPham();
        DataTable dt = new DataTable();
        string dieukien = "";
        public void SetNull()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtMaSP.Text = "";
            txtSoLuong.Text = "";
            txtLoiNhuan.Text = "";
            txtGiaNhap.Text = "";
            txtGiaBan.Text = "";
            txtMoTa.Text = "";
            txtNSX.Text = "";
            txtNCC.Text = "";
        }
        public frmTimKiemHangHoa()
        {
            InitializeComponent();
        }
        public void TimKiem()
        {
            if (rbtnMaHang.Checked == true)
            {
                dieukien = " MaSP like N'%" + txtTimKiem.Text + "%'";
            }
            if (rbtnTenHang.Checked == true)
            {
                dieukien = " TenSP like N'%" + txtTimKiem.Text + "%'";
            }
            if (rbtnCaoThap.Checked == true) dieukien += "order by GiaBan desc";
            if (rbtnThapCao.Checked == true) dieukien += "order by GiaBan asc";
            dgvSanPham.DataSource = sp.getThongTinSanPham(dieukien);
        }
        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                txtMaSP.Text = dgvSanPham.Rows[dong].Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.Rows[dong].Cells[1].Value.ToString();
                txtMaLH.Text = dgvSanPham.Rows[dong].Cells[2].Value.ToString();
                txtSoLuong.Text = dgvSanPham.Rows[dong].Cells[3].Value.ToString();
                txtLoiNhuan.Text = dgvSanPham.Rows[dong].Cells[4].Value.ToString();
                txtGiaNhap.Text = dgvSanPham.Rows[dong].Cells[5].Value.ToString();
                txtGiaBan.Text = dgvSanPham.Rows[dong].Cells[6].Value.ToString();
                txtMoTa.Text = dgvSanPham.Rows[dong].Cells[7].Value.ToString();
                txtNSX.Text = dgvSanPham.Rows[dong].Cells[8].Value.ToString();
                txtNCC.Text = dgvSanPham.Rows[dong].Cells[10].Value.ToString();
            }
            catch { }
        }

        private void frmTimKiemHangHoa_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = sp.getAllSanPham();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SetNull();
            txtTimKiem.Text = "Nhập từ khóa tìm kiếm...";
            rbtnMaHang.Checked = false;
            rbtnTenHang.Checked = false;
            cbLoaiHang.Text = "";
            rbtnThapCao.Checked = false;
            rbtnCaoThap.Checked = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TimKiem();
            SetNull();
        }

        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            txtTimKiem.SelectionStart = txtTimKiem.Text.Length;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbLoaiHang_Click(object sender, EventArgs e)
        {
            cbLoaiHang.SelectionStart = cbLoaiHang.Text.Length;
            dt = lh.getField("TenLH");
            cbLoaiHang.Items.Clear();
            cbLoaiHang.Items.Add("Tất cả");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbLoaiHang.Items.Add(dt.Rows[i]["TenLH"].ToString());
            }
        }

        private void cbLoaiHang_TextChanged(object sender, EventArgs e)
        {
            DataTable tb = new DataTable();
            string maloaihang;
            if (cbLoaiHang.Text == "Tất cả")
            {
                dieukien = "";
            }
            if (cbLoaiHang.SelectedIndex != 0)
            {
                tb = lh.getThongTinLoaiHang(" TenLH like N'%" + cbLoaiHang.Text + "%'");
                maloaihang = tb.Rows[0]["MaLH"].ToString();
                dieukien = " MaLH = '" + maloaihang + "'";
            }
            if (rbtnTenHang.Checked == true) dieukien += "and TenSP like N'%" + txtTimKiem.Text + "%'";
            if (rbtnMaHang.Checked == true) dieukien += "and MaSP like N'%" + txtTimKiem.Text + "%'";
            if (rbtnCaoThap.Checked == true) dieukien += "order by GiaBan desc";
            if (rbtnThapCao.Checked == true) dieukien += "order by GiaBan asc";
            dgvSanPham.DataSource = sp.getThongTinSanPham(dieukien);
        }
    }
}