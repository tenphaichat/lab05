using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmChiTietSinhVien : Form
    {
        private readonly SinhVien _sinhVien;

        private Label lblTitle;
        private GroupBox grpThongTin;
        private Label lblMaTitle, lblMa;
        private Label lblHoTenTitle, lblHoTen;
        private Label lblNgaySinhTitle, lblNgaySinh;
        private Label lblGioiTinhTitle, lblGioiTinh;
        private Label lblKhoaTitle, lblKhoa;
        private Label lblDiemTitle, lblDiem;
        private Label lblXepLoaiTitle, lblXepLoai;
        private Label lblSoThichTitle, lblSoThich;

        private GroupBox grpAnh;
        private PictureBox picAnh;
        private Button btnDong;

        public frmChiTietSinhVien() : this(new SinhVien())
        {
        }

        public frmChiTietSinhVien(SinhVien sinhVien)
        {
            _sinhVien = sinhVien ?? new SinhVien();
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.grpThongTin = new GroupBox();
            this.lblMaTitle = new Label();
            this.lblMa = new Label();
            this.lblHoTenTitle = new Label();
            this.lblHoTen = new Label();
            this.lblNgaySinhTitle = new Label();
            this.lblNgaySinh = new Label();
            this.lblGioiTinhTitle = new Label();
            this.lblGioiTinh = new Label();
            this.lblKhoaTitle = new Label();
            this.lblKhoa = new Label();
            this.lblDiemTitle = new Label();
            this.lblDiem = new Label();
            this.lblXepLoaiTitle = new Label();
            this.lblXepLoai = new Label();
            this.lblSoThichTitle = new Label();
            this.lblSoThich = new Label();

            this.grpAnh = new GroupBox();
            this.picAnh = new PictureBox();
            this.btnDong = new Button();

            this.Text = "Bài 4: Chi tiết sinh viên";
            this.Size = new Size(640, 430);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Form Title
            this.lblTitle.Text = "HỒ SƠ CHI TIẾT SINH VIÊN";
            this.lblTitle.Font = new Font("Segoe UI", 12.5F, FontStyle.Bold);
            this.lblTitle.Location = new Point(210, 15);
            this.lblTitle.AutoSize = true;

            // GroupBox Thông tin
            this.grpThongTin.Text = "Thông tin cá nhân & học tập";
            this.grpThongTin.Location = new Point(20, 50);
            this.grpThongTin.Size = new Size(380, 300);

            // Mã SV
            this.lblMaTitle.Text = "Mã sinh viên:";
            this.lblMaTitle.Location = new Point(15, 28);
            this.lblMaTitle.AutoSize = true;

            this.lblMa.Text = _sinhVien.MaSV;
            this.lblMa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblMa.Location = new Point(125, 28);
            this.lblMa.AutoSize = true;

            // Họ tên
            this.lblHoTenTitle.Text = "Họ và tên:";
            this.lblHoTenTitle.Location = new Point(15, 60);
            this.lblHoTenTitle.AutoSize = true;

            this.lblHoTen.Text = _sinhVien.HoTen;
            this.lblHoTen.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblHoTen.Location = new Point(125, 60);
            this.lblHoTen.AutoSize = true;

            // Ngày sinh
            this.lblNgaySinhTitle.Text = "Ngày sinh:";
            this.lblNgaySinhTitle.Location = new Point(15, 92);
            this.lblNgaySinhTitle.AutoSize = true;

            this.lblNgaySinh.Text = $"{_sinhVien.NgaySinh:dd/MM/yyyy} (Tuổi: {_sinhVien.TinhTuoi()})";
            this.lblNgaySinh.Location = new Point(125, 92);
            this.lblNgaySinh.AutoSize = true;

            // Giới tính
            this.lblGioiTinhTitle.Text = "Giới tính:";
            this.lblGioiTinhTitle.Location = new Point(15, 124);
            this.lblGioiTinhTitle.AutoSize = true;

            this.lblGioiTinh.Text = _sinhVien.GioiTinh;
            this.lblGioiTinh.Location = new Point(125, 124);
            this.lblGioiTinh.AutoSize = true;

            // Khoa
            this.lblKhoaTitle.Text = "Khoa:";
            this.lblKhoaTitle.Location = new Point(15, 156);
            this.lblKhoaTitle.AutoSize = true;

            this.lblKhoa.Text = _sinhVien.Khoa;
            this.lblKhoa.Location = new Point(125, 156);
            this.lblKhoa.AutoSize = true;

            // Điểm TB
            this.lblDiemTitle.Text = "Điểm TB:";
            this.lblDiemTitle.Location = new Point(15, 188);
            this.lblDiemTitle.AutoSize = true;

            this.lblDiem.Text = _sinhVien.DiemTB.ToString("N2");
            this.lblDiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblDiem.Location = new Point(125, 188);
            this.lblDiem.AutoSize = true;

            // Xếp loại
            this.lblXepLoaiTitle.Text = "Xếp loại:";
            this.lblXepLoaiTitle.Location = new Point(15, 220);
            this.lblXepLoaiTitle.AutoSize = true;

            this.lblXepLoai.Text = _sinhVien.XepLoai();
            this.lblXepLoai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblXepLoai.Location = new Point(125, 220);
            this.lblXepLoai.AutoSize = true;

            // Sở thích
            this.lblSoThichTitle.Text = "Sở thích:";
            this.lblSoThichTitle.Location = new Point(15, 252);
            this.lblSoThichTitle.AutoSize = true;

            this.lblSoThich.Text = string.IsNullOrEmpty(_sinhVien.SoThich) ? "Chưa chọn" : _sinhVien.SoThich;
            this.lblSoThich.Location = new Point(125, 252);
            this.lblSoThich.AutoSize = true;

            this.grpThongTin.Controls.AddRange(new Control[] {
                lblMaTitle, lblMa,
                lblHoTenTitle, lblHoTen,
                lblNgaySinhTitle, lblNgaySinh,
                lblGioiTinhTitle, lblGioiTinh,
                lblKhoaTitle, lblKhoa,
                lblDiemTitle, lblDiem,
                lblXepLoaiTitle, lblXepLoai,
                lblSoThichTitle, lblSoThich
            });

            // GroupBox Ảnh
            this.grpAnh.Text = "Ảnh đại diện";
            this.grpAnh.Location = new Point(420, 50);
            this.grpAnh.Size = new Size(185, 230);

            this.picAnh.Location = new Point(20, 25);
            this.picAnh.Size = new Size(145, 180);
            this.picAnh.BorderStyle = BorderStyle.FixedSingle;
            this.picAnh.SizeMode = PictureBoxSizeMode.Zoom;

            string imgPath = _sinhVien.DuongDanAnh;
            if (string.IsNullOrEmpty(imgPath) || !File.Exists(imgPath))
            {
                imgPath = Path.Combine(Application.StartupPath, "Images", "avatar_thang.png");
                if (!File.Exists(imgPath))
                {
                    imgPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Images", "avatar_thang.png");
                }
            }
            if (File.Exists(imgPath))
            {
                try
                {
                    using (var fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read))
                    {
                        this.picAnh.Image = Image.FromStream(fs);
                    }
                }
                catch { }
            }

            this.grpAnh.Controls.Add(this.picAnh);

            // Nút Đóng
            this.btnDong.Text = "Đóng";
            this.btnDong.Location = new Point(455, 305);
            this.btnDong.Size = new Size(115, 34);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                lblTitle, grpThongTin, grpAnh, btnDong
            });
        }
    }
}
