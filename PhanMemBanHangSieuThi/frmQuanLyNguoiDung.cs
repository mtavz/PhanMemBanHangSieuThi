using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using PhanMemBanHangSieuThi;
using PhanMemBanHangSieuThi_BUS;
using PhanMemBanHangSieuThi_DAL;
using PhanMemBanHangSieuThi_Entity;

namespace PhanMemBanHangSieuThi
{
    public partial class frmQuanLyNguoiDung : Form
    {
        private bool _them = false;
        private bool _codulieu = false;
        private bool _online = false;
        private EC_tblNhanVien ectNhanVien = new EC_tblNhanVien();
        private BUS_tblNhanVien busNV = new BUS_tblNhanVien();
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            DataTable tbl = busNV.getNguoiDung();
            dgvThongTinNguoiDung.DataSource = tbl;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = false;
            txtTenDangNhap.ReadOnly = false;
            txtMatKhau.ReadOnly = false;
            dgvThongTinNguoiDung.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chỉ sửa được mật khẩu !!!");
            _them = false;
            if (txtTenDangNhap.Text != "")
            {
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;            
                btnCapNhat.Enabled = false;

                btnLuu.Enabled = true;
                txtTenDangNhap.Enabled = true;
                txtMatKhau.Enabled = true;
                //dgvThongTinNguoiDung.Enabled = false;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult xacnhan;
            xacnhan = MessageBox.Show("Bạn có chắc chắn muốn xóa không??", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (xacnhan == DialogResult.OK)
            {
                ectNhanVien.TenDn = txtTenDangNhap.Text;                
                string thongbao = busNV.delNhanVien(ectNhanVien);
                if (thongbao != "")
                { 
                    MessageBox.Show("Không thể thực hiện!!!\n" + thongbao, "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                btnCapNhat_Click(null, null);
            }           
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            DataTable tbl = busNV.getNguoiDung();
            dgvThongTinNguoiDung.DataSource = tbl;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool _kt = true;            
            txtTenDangNhap.Text = txtTenDangNhap.Text;
            if (_them)
            {
                for (int _i = 0; _i < dgvThongTinNguoiDung.RowCount - 1; _i++)
                {
                    if (txtTenDangNhap.Text == dgvThongTinNguoiDung.Rows[_i].Cells[0].Value.ToString())
                    {
                        _kt = false;
                        break;
                    }
                }
            }
            if (_kt)
            {
                if (txtTenDangNhap.Text != "")
                {
                    dgvThongTinNguoiDung.Enabled = true;
                    //update co so du lieu
                    ectNhanVien.TenDn = txtTenDangNhap.Text;
                    ectNhanVien.MatKhau = txtMatKhau.Text;
                    //kiem tra thao tac la them hay sua
                    if (_them == false) busNV.updateNguoiDung(ectNhanVien);
                    else busNV.addNhanVien(ectNhanVien);
                    txtMatKhau.ReadOnly = false;
                    txtTenDangNhap.ReadOnly = false;
                    btnThem.Enabled = true;
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    btnCapNhat.Enabled = true;
                    btnLuu.Enabled = true;

                    btnCapNhat_Click(sender, e);
                    _codulieu = false;
                }
                else
                {
                    MessageBox.Show("Không có Tên đăng nhập!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!!!", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (btnLuu.Enabled)
            {
               
                dgvThongTinNguoiDung.Enabled = true;
                txtMatKhau.ReadOnly = true;
                txtTenDangNhap.ReadOnly = true;
                //chinh trang thai cac nut
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnLuu.Enabled = false;
                btnCapNhat.Enabled = true;
                //reset
                btnCapNhat_Click(sender, e);
            }
            else
            {
                //update du lieu
                _online = false;
                frmMain frm = new frmMain();
                frm.Show();
                this.Close();
            }
        }

        private void dgvThongTinNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvThongTinNguoiDung.Rows.Count - 1)
            {
                txtTenDangNhap.Text = dgvThongTinNguoiDung.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtMatKhau.Text = dgvThongTinNguoiDung.Rows[e.RowIndex].Cells[1].Value.ToString();                      
            }
            if (e.RowIndex >= dgvThongTinNguoiDung.Rows.Count - 1)
            {
                txtTenDangNhap.ResetText();
                txtMatKhau.ResetText();
            }
        }
    }
}
