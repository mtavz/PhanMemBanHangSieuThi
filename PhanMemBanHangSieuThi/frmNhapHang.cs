using System;
using System.IO;
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
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private int _rowindex;
        private string _src = "";
        private string _dst = "";
        private SQL_tblSanPham DAL_SP = new SQL_tblSanPham();
        private SQL_tblLoaiHang DAL_LH = new SQL_tblLoaiHang();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadAnh = new OpenFileDialog();
            LoadAnh.Filter = "Image(*.png,*.jpg)|*.png;*.jpg|All files(*.*)|*.*";
            LoadAnh.ShowDialog();
            if (LoadAnh.FileName != "")
            {
                _src = LoadAnh.FileName;
                picAnh.Load(LoadAnh.FileName);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bool _daco = false;
            for (int i = 0; i < dgvDanhSach.RowCount;i++)
            {
                if (txtMaSP.Text == dgvDanhSach.Rows[i].Cells["MaSP"].Value.ToString())
                {
                    //cap nhat lai thong tin
                    dgvDanhSach.Rows[i].Cells["TenSP"].Value = txtTenSP.Text;
                    dgvDanhSach.Rows[i].Cells["SoLuong"].Value = txtSoLuong.Text;
                    dgvDanhSach.Rows[i].Cells["Loai"].Value = cboLoai.SelectedValue;
                    dgvDanhSach.Rows[i].Cells["MoTa"].Value = txtThongTin.Text;
                    dgvDanhSach.Rows[i].Cells["GiaNhap"].Value = txtGiaNhap.Text;
                    dgvDanhSach.Rows[i].Cells["GiaBan"].Value = txtGiaBan.Text;
                    dgvDanhSach.Rows[i].Cells["NSX"].Value = txtNSX.Text;
                    _dst = "AnhSP/" + txtMaSP.Text + ".jpg";
                    if (picAnh.Image != null)
                    {
                        dgvDanhSach.Rows[i].Cells["Anh"].Value = txtMaSP.Text + ".jpg";
                        picAnh.Image = null;
                        File.Delete(_dst);
                        File.Copy(_src, _dst);
                    }
                    else
                    {
                        dgvDanhSach.Rows[i].Cells["Anh"].Value = "";
                        File.Delete(_dst);
                    }
                    _daco = true;
                    break;
                }
            }
            if (!_daco)
            {
                if (picAnh.Image != null)
                {
                    dgvDanhSach.Rows.Add(txtMaSP.Text, txtTenSP.Text, cboLoai.SelectedValue, txtSoLuong.Text, txtGiaNhap.Text, txtGiaBan.Text, txtThongTin.Text, txtNSX.Text, txtMaSP.Text + ".jpg");
                    _dst = "AnhSP/" + txtMaSP.Text + ".jpg";
                    File.Delete(_dst);
                    File.Copy(_src, _dst);
                }
                else dgvDanhSach.Rows.Add(txtMaSP.Text, txtTenSP.Text, cboLoai.SelectedValue, txtSoLuong.Text, txtGiaNhap.Text, txtGiaBan.Text, txtThongTin.Text, txtNSX.Text);
            }

            picAnh.Image = null;
            txtMaSP.Text = "--" + txtMaSP.Text;
            txtTenSP.ResetText();
            cboLoai.ResetText();
            txtSoLuong.ResetText();
            txtGiaBan.ResetText();
            txtGiaNhap.ResetText();
            txtNSX.ResetText();
            txtThongTin.ResetText();
            btnXong.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            string _lastSP = DAL_SP.getLastSP();
            cboLoai.DataSource = DAL_LH.getAllLoaiHang();
            cboLoai.DisplayMember = "TenLH";
            cboLoai.ValueMember = "MaLH";
            txtMaSP.Text = "--" + _lastSP;
            cboLoai.ResetText();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dgvDanhSach.Rows.RemoveAt(_rowindex);
            txtTenSP.ResetText();
            cboLoai.ResetText();
            txtSoLuong.ResetText();
            txtGiaBan.ResetText();
            txtGiaNhap.ResetText();
            txtNSX.ResetText();
            txtThongTin.ResetText();
            if (dgvDanhSach.RowCount == 0)
            {
                btnXong.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void dgvDanhSach_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            _rowindex = e.RowIndex;
            txtMaSP.Text = dgvDanhSach.Rows[_rowindex].Cells["MaSP"].Value.ToString();
            txtTenSP.Text = dgvDanhSach.Rows[_rowindex].Cells["TenSP"].Value.ToString();
            txtSoLuong.Text = dgvDanhSach.Rows[_rowindex].Cells["SoLuong"].Value.ToString();
            try
            {
                cboLoai.SelectedValue = dgvDanhSach.Rows[_rowindex].Cells["Loai"].Value;
            }
            catch
            {
                cboLoai.ResetText();
            }
            txtThongTin.Text = dgvDanhSach.Rows[_rowindex].Cells["MoTa"].Value.ToString();
            txtGiaNhap.Text = dgvDanhSach.Rows[_rowindex].Cells["GiaNhap"].Value.ToString();
            txtGiaBan.Text = dgvDanhSach.Rows[_rowindex].Cells["GiaBan"].Value.ToString();
            txtNSX.Text = dgvDanhSach.Rows[_rowindex].Cells["NSX"].Value.ToString();
            if (dgvDanhSach.Rows[_rowindex].Cells["Anh"].Value != null && dgvDanhSach.Rows[_rowindex].Cells["Anh"].Value.ToString() != "")
            {
                picAnh.Load("AnhSP/" + dgvDanhSach.Rows[_rowindex].Cells["Anh"].Value.ToString());
            }
            else
            {
                picAnh.Image = null;
            }
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < dgvDanhSach.RowCount; i++)
            {
                EC_tblSanPham EC_SP = new EC_tblSanPham();
                gan(EC_SP, i);
                DAL_SP.addSanPham(EC_SP);

            }
            dgvDanhSach.Rows.Clear();
            btnXong.Enabled = false;
            btnXoa.Enabled = false;
            MessageBox.Show("Đã nhập " + i.ToString() + " sản phẩm!!!");
        }

        private void gan(EC_tblSanPham EC_SP, int i)
        {
            if (dgvDanhSach.Rows[i].Cells["TenSP"].Value != null) EC_SP.TenSP = dgvDanhSach.Rows[i].Cells["TenSP"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["MaSP"].Value != null) EC_SP.MaSP = dgvDanhSach.Rows[i].Cells["MaSP"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["SoLuong"].Value != null) EC_SP.SoLuong = dgvDanhSach.Rows[i].Cells["SoLuong"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["Loai"].Value != null) EC_SP.MaLH = dgvDanhSach.Rows[i].Cells["Loai"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["MoTa"].Value != null) EC_SP.MoTa = dgvDanhSach.Rows[i].Cells["MoTa"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["GiaNhap"].Value != null) EC_SP.GiaNhap = dgvDanhSach.Rows[i].Cells["GiaNhap"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["GiaBan"].Value != null) EC_SP.GiaBan = dgvDanhSach.Rows[i].Cells["GiaBan"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["NSX"].Value != null) EC_SP.NSX = dgvDanhSach.Rows[i].Cells["NSX"].Value.ToString();
            if (dgvDanhSach.Rows[i].Cells["Anh"].Value != null) EC_SP.HinhAnh = dgvDanhSach.Rows[i].Cells["Anh"].Value.ToString();
        }
    }
}
