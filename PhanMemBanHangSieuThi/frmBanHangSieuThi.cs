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
using PhanMemBanHangSieuThi_Entity;

namespace PhanMemBanHangSieuThi
{
    public partial class frmBanHangSieuThi : Form
    {
        private DateTime ngay;
        BUS_tblChiTietHoaDon busHD = new BUS_tblChiTietHoaDon();
        EC_tblChiTietHoaDon ecHD = new EC_tblChiTietHoaDon();
        BUS_tblHoaDonBan busH = new BUS_tblHoaDonBan();
        EC_tblHoaDonBan ecH = new EC_tblHoaDonBan();
        BUS_tblKhachHang busKH = new BUS_tblKhachHang();
        EC_tblKhachHang ecKH = new EC_tblKhachHang();
        public frmBanHangSieuThi()
        {
            InitializeComponent();
        }
        public void NgayGio()
        {
            ngay = DateTime.Today;
            string strNgay = ngay.ToString();
            string strGio = DateTime.Now.ToString();
            strGio = strGio.Substring(10, strGio.Length - 10);
            strNgay = strNgay.Substring(0, 10);
            lblNgay.Text = strNgay;
            lblGio.Text = strGio;
        }
        void TuDanhMaTB()//ham này dùng trong trường hợp thêm tb thì nếu chỉ nhập tên tb thì sẽ tự động đánh MaTB
        {
            DataTable MaHD;
            MaHD = busHD.LayRaMaHD();
            txtMaHD.DataBindings.Clear();
            txtMaHD.DataBindings.Add("Text", MaHD, "MaHD", true);
            string MP = txtMaHD.Text;
            int stt = int.Parse(MP.Substring(3, MP.Length - 3)) + 1;
            if (stt < 10)           {txtMaHD.Text = MP.Substring(0, 3) + "000000" + stt.ToString();}
            else if(stt < 100)      {txtMaHD.Text = MP.Substring(0, 3) + "00000" + stt.ToString();}
            else if(stt < 1000)     txtMaHD.Text = MP.Substring(0, 3) + "0000" + stt.ToString();
            else if (stt < 10000)   txtMaHD.Text = MP.Substring(0, 3) + "000" + stt.ToString();
            else if (stt < 100000)  txtMaHD.Text = MP.Substring(0, 3) + "00" + stt.ToString();
            else if (stt < 1000000) txtMaHD.Text = MP.Substring(0, 3) + "0" + stt.ToString();
            else txtMaHD.Text = MP.Substring(0, 3) + stt.ToString();

        }
        void NhanVien()
        {
            cboNhanVien.DataSource = busHD.LayRaNV();
            cboNhanVien.DisplayMember = "TenNV";
        }
        //tính tổng số lượng
        void TongSL()
        {
            DataTable tongsl;
            ecHD.MaHD = txtMaHD.Text;
            tongsl = busHD.TongSL(ecHD);
            txtTongSoLuong.DataBindings.Clear();
            txtTongSoLuong.DataBindings.Add("Text", tongsl, "TongSL", true);
        }
        //tính tổng tiền
        void TongTien()
        {
            DataTable tongtien;
            ecHD.MaHD = txtMaHD.Text;
            tongtien = busHD.TongTien(ecHD);
            txtTongTien.DataBindings.Clear();
            txtTongTien.DataBindings.Add("Text", tongtien, "TongTien", true);
            if(txtTongTien.Text!="")
            {
                ecH.TongTien = int.Parse(txtTongTien.Text);
                ecH.MaHDB = txtMaHD.Text;
                busH.updateHoaDonBan(ecH);
            }
            
        }
        private void HienThi()
        {
            dgvDanhSach.DataSource = busHD.getChiTietHoaDon("and MaHD=N'"+txtMaHD.Text+"'");
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmBanHangSieuThi_Load(object sender, EventArgs e)
        {
            NgayGio();
            TuDanhMaTB();
            NhanVien();
            HienThi();
            TongSL();
            TongTien();
            txtMaHD.ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable SP;
            ecHD.MaSP = txtMaSP.Text;
            SP = busHD.LayRaSP(ecHD);
            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add("Text",SP, "TenSP", true);
            txtDonGia.DataBindings.Clear();
            txtDonGia.DataBindings.Add("Text", SP, "GiaBan", true);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable themMaHD;
            themMaHD = busH.getHoaDonBan("where MaHDB=N'" + txtMaHD.Text + "'");
            if(themMaHD.Rows.Count==0)
            {
                ecH.MaHDB = txtMaHD.Text;
                ecH.NgayBan = DateTime.Today.Year.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString()+
                    " " + DateTime.Today.Hour.ToString() + ":" + DateTime.Today.Minute.ToString() + ":" + DateTime.Today.Second.ToString() ;
                ecH.MaKH = txtMaKH.Text;
                if(txtMaKH.Text=="")
                {
                    MessageBox.Show("Bạn chưa nhập thông tin khach hàng");
                }
                else
                { busH.addHoaDonBan(ecH); }
                
            }
            if(txtMaSP.Text==""||txtSoLuong.Text=="")
            {
                MessageBox.Show("Bạn chưa nhập thông tin sản phẩm");
            }
            else
            {
                ecHD.MaHD = txtMaHD.Text;
                ecHD.MaSP = txtMaSP.Text;
                ecHD.SoLuong = int.Parse(txtSoLuong.Text);
                ecHD.DonGia = int.Parse(txtDonGia.Text);
                ecHD.ThanhTien = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text);
                busHD.addChiTietHoaDon(ecHD);
                txtMaSP.Text = "";
                txtTenSP.Text = "";
                txtSoLuong.Text = "";
                txtDonGia.Text = "";
                //load lai du lieu
                HienThi();
                TongSL();
                TongTien();
            }
            
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            ecHD.MaHD = txtMaHD.Text;
            ecHD.MaSP = txtMaSP.Text;
            ecH.MaHDB=txtMaHD.Text;
            busHD.delChiTietHoaDon(ecHD);
            if(busHD.getChiTiet("where MaHD=N'"+txtMaHD.Text+"'")==null)
            {
                busH.delHoaDonBan(ecH);
                MessageBox.Show("Bạn đã xóa hết toàn bộ sản phẩm");
            }
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            HienThi();
            TongSL();
            TongTien();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void txtTaoHD_Click(object sender, EventArgs e)
        {
            TuDanhMaTB();
            txtMaSP.Text = "";
            txtTenKH.Text = "";
            txtTongSoLuong.Text = "";
            txtTongTien.Text = "";
            txtTienThoiLai.Text = "";
            txtTienKhachTra.Text = "";
            txtMaKH.Text = "";
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            DataTable kh;
            kh = busKH.getKhachHang("where TenKH=N'" + txtTenKH.Text + "'");
            txtMaKH.DataBindings.Clear();
            txtMaKH.DataBindings.Add("Text", kh, "MaKH", true);
            if (kh != null)
            {
                btnThemKH.Enabled = false;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienKhachTra_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (txtTienKhachTra.Text != "" || txtTongTien.Text != "")
                txtTienThoiLai.Text = (int.Parse(txtTienKhachTra.Text) - int.Parse(txtTongTien.Text)).ToString();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        private void dgvDanhSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int dong = e.RowIndex;/*biến dòng :kich vào dòng thì chỉ số dòng đc lưu vào biến dòng */
                txtMaSP.Text = dgvDanhSach.Rows[dong].Cells[0].Value.ToString();
                txtSoLuong.Text = dgvDanhSach.Rows[dong].Cells[3].Value.ToString();
            }
            catch
            {

            }
        }

        private void btnSuaSL_Click(object sender, EventArgs e)
        {
            txtMaSP.ReadOnly = true;
            txtTenSP.ReadOnly = true;
            txtDonGia.ReadOnly = true;
            ecHD.MaHD = txtMaHD.Text;
            ecHD.MaSP = txtMaSP.Text;
            ecHD.SoLuong = int.Parse(txtSoLuong.Text);
            ecHD.ThanhTien = int.Parse(txtSoLuong.Text) * int.Parse(txtDonGia.Text);
            busHD.updateChiTietHoaDon(ecHD);
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
            HienThi();
            TongSL();
            TongTien();
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            ecKH.TenKH = txtTenKH.Text;
            ecKH.MaKH = txtMaKH.Text;
            busKH.addKhachHang(ecKH);
        }

    }
}
