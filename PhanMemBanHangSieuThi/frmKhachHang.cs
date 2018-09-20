using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PhanMemBanHangSieuThi_Entity;
using PhanMemBanHangSieuThi_BUS;

namespace PhanMemBanHangSieuThi
{
    public partial class frmKhachHang : Form
    {
        BUS_tblKhachHang busKH = new BUS_tblKhachHang();
        int dong = -1;
        string action = "";
        public frmKhachHang()
        {
            InitializeComponent();
        }
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            dgvKH.DataSource = busKH.getAllKhachHang();
            for (int i = 0; i < dgvKH.RowCount; i++)
            {
                if (i % 2 == 0)
                    dgvKH.Rows[i].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            grbKhachhang.Enabled = false;

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dong < 0) 
            {
                MessageBox.Show("Chưa chọn khách hàng để sửa.");
                return;
            }
            action = "Edit";
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            grbKhachhang.Enabled = true;
        }



        private void frmKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dong = e.RowIndex;
            if (dong < 0) return;
            txtName.Text = dgvKH.Rows[dong].Cells["TenKH"].Value.ToString();
            cmbGT.Text = dgvKH.Rows[dong].Cells["GT"].Value.ToString();
            txtAddress.Text = dgvKH.Rows[dong].Cells["DiaChi"].Value.ToString();
            txtSDT.Text = dgvKH.Rows[dong].Cells["SDT"].Value.ToString();
            txtNote.Text = dgvKH.Rows[dong].Cells["GhiChu"].Value.ToString();
            cmbType.Text = dgvKH.Rows[dong].Cells["LoaiKH"].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            action = "Add";
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnEdit.Enabled = false;
            grbKhachhang.Enabled = true;
            txtName.Text = "";
            cmbGT.Text = "Nam";
            txtAddress.Text = "";
            txtSDT.Text = "";
            txtNote.Text = "";
            cmbType.Text = "Bình thường";
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dong < 0)
            {
                MessageBox.Show("Chưa chọn khách hàng để xóa.");
                return;
            }
            EC_tblKhachHang ec = new EC_tblKhachHang();
            ec.MaKH = dgvKH.Rows[dong].Cells["MaKH"].Value.ToString();
            busKH.delKhachHang(ec );
            MessageBox.Show("Xóa ok!");
            frmKhachHang_Load(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(action)
            {
                case "Add":
                    
                    if(txtName.Text=="")
                    {
                        MessageBox.Show("Chưa nhập tên khách hàng!");
                        return;
                    }
                    if (txtSDT.Text == "")
                    {
                        MessageBox.Show("Chưa nhập số điện thoại!");
                        return;
                    }
                    if (txtAddress.Text == "")
                    {
                        MessageBox.Show("Chưa nhập địa chỉ!");
                        return;
                    }
                    EC_tblKhachHang ecKH = new EC_tblKhachHang(txtName.Text,cmbGT.Text,txtAddress.Text,cmbType.Text,txtSDT.Text,txtNote.Text);
                    busKH.addKhachHang(ecKH);
                    break;

                case "Edit":
                    if(txtName.Text=="")
                    {
                        MessageBox.Show("Chưa nhập tên khách hàng!");
                        return;
                    }
                    if (txtSDT.Text == "")
                    {
                        MessageBox.Show("Chưa nhập số điện thoại!");
                        return;
                    }
                    if (txtAddress.Text == "")
                    {
                        MessageBox.Show("Chưa nhập địa chỉ!");
                        return;
                    }
                    EC_tblKhachHang ecKHupdate = new EC_tblKhachHang(txtName.Text,cmbGT.Text,txtAddress.Text,cmbType.Text,txtSDT.Text,txtNote.Text);
                    busKH.updateKhachHang(ecKHupdate);
                    break;
                default:
                    break;
            }
            frmKhachHang_Load(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grbKhachhang.Enabled = false;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
        }

        
    }
}
