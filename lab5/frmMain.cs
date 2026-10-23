using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmMain : Form
    {
        private MenuStrip menuStripMain;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuDangNhap;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripSeparator sepHeThong;
        private ToolStripMenuItem mnuThoat;

        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuSinhVien;
        private ToolStripMenuItem mnuChonKhoa;

        private ToolStripMenuItem mnuNghiepVu;
        private ToolStripMenuItem mnuChiTietSV;
        private ToolStripMenuItem mnuTimKiem;

        private ToolStripMenuItem mnuTroGiup;
        private ToolStripMenuItem mnuGioiThieu;

        private ToolStrip toolStripQuick;
        private ToolStripButton btnToolSinhVien;
        private ToolStripButton btnToolChiTiet;
        private ToolStripButton btnToolTimKiem;
        private ToolStripButton btnToolChonKhoa;
        private ToolStripSeparator sepTool;
        private ToolStripButton btnToolDangNhap;
        private ToolStripButton btnToolGioiThieu;

        private StatusStrip statusStripMain;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel lblSpringSpacer;
        private ToolStripStatusLabel lblNguoiDung;
        private ToolStripStatusLabel lblDongHo;
        private System.Windows.Forms.Timer timerDongHo;

        public frmMain()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.menuStripMain = new MenuStrip();
            this.mnuHeThong = new ToolStripMenuItem();
            this.mnuDangNhap = new ToolStripMenuItem();
            this.mnuDangXuat = new ToolStripMenuItem();
            this.sepHeThong = new ToolStripSeparator();
            this.mnuThoat = new ToolStripMenuItem();

            this.mnuDanhMuc = new ToolStripMenuItem();
            this.mnuSinhVien = new ToolStripMenuItem();
            this.mnuChonKhoa = new ToolStripMenuItem();

            this.mnuNghiepVu = new ToolStripMenuItem();
            this.mnuChiTietSV = new ToolStripMenuItem();
            this.mnuTimKiem = new ToolStripMenuItem();

            this.mnuTroGiup = new ToolStripMenuItem();
            this.mnuGioiThieu = new ToolStripMenuItem();

            this.toolStripQuick = new ToolStrip();
            this.btnToolSinhVien = new ToolStripButton();
            this.btnToolChiTiet = new ToolStripButton();
            this.btnToolTimKiem = new ToolStripButton();
            this.btnToolChonKhoa = new ToolStripButton();
            this.sepTool = new ToolStripSeparator();
            this.btnToolDangNhap = new ToolStripButton();
            this.btnToolGioiThieu = new ToolStripButton();

            this.statusStripMain = new StatusStrip();
            this.lblTrangThai = new ToolStripStatusLabel();
            this.lblSpringSpacer = new ToolStripStatusLabel();
            this.lblNguoiDung = new ToolStripStatusLabel();
            this.lblDongHo = new ToolStripStatusLabel();
            this.timerDongHo = new System.Windows.Forms.Timer();

            // Form Properties: generous size so child forms never overflow
            this.Text = "LAB 5: XỬ LÝ SỰ KIỆN, KIỂM TRA DỮ LIỆU VÀ ỨNG DỤNG ĐA FORM";
            this.Size = new Size(1020, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.IsMdiContainer = true;

            // 1. MenuStrip (Bài 5)
            // Hệ thống
            this.mnuHeThong.Text = "&Hệ thống";
            this.mnuDangNhap.Text = "&Đăng nhập...";
            this.mnuDangNhap.ShortcutKeys = Keys.Control | Keys.L;
            this.mnuDangNhap.Click += (s, e) => MoDangNhap();

            this.mnuDangXuat.Text = "Đăng &xuất";
            this.mnuDangXuat.Click += (s, e) => DangXuat();

            this.mnuThoat.Text = "T&hoát";
            this.mnuThoat.ShortcutKeys = Keys.Alt | Keys.F4;
            this.mnuThoat.Click += (s, e) => this.Close();

            this.mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] {
                mnuDangNhap, mnuDangXuat, sepHeThong, mnuThoat
            });

            // Danh mục
            this.mnuDanhMuc.Text = "&Danh mục";
            this.mnuSinhVien.Text = "Quản lý &Sinh viên";
            this.mnuSinhVien.ShortcutKeys = Keys.Control | Keys.S;
            this.mnuSinhVien.Click += (s, e) => OpenChildForm(new frmSinhVien());

            this.mnuChonKhoa.Text = "Danh mục &Khoa";
            this.mnuChonKhoa.Click += (s, e) => MoChonKhoa();

            this.mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] {
                mnuSinhVien, mnuChonKhoa
            });

            // Nghiệp vụ
            this.mnuNghiepVu.Text = "&Nghiệp vụ";
            this.mnuChiTietSV.Text = "Xem &chi tiết sinh viên";
            this.mnuChiTietSV.Click += (s, e) => MoChiTietSinhVien();

            this.mnuTimKiem.Text = "&Tìm kiếm sinh viên";
            this.mnuTimKiem.ShortcutKeys = Keys.Control | Keys.F;
            this.mnuTimKiem.Click += (s, e) => MoTimKiem();

            this.mnuNghiepVu.DropDownItems.AddRange(new ToolStripItem[] {
                mnuChiTietSV, mnuTimKiem
            });

            // Trợ giúp
            this.mnuTroGiup.Text = "Trợ &giúp";
            this.mnuGioiThieu.Text = "&Giới thiệu ứng dụng (Bài 10)";
            this.mnuGioiThieu.ShortcutKeys = Keys.F1;
            this.mnuGioiThieu.Click += (s, e) => new frmGioiThieu().ShowDialog(this);

            this.mnuTroGiup.DropDownItems.Add(mnuGioiThieu);

            this.menuStripMain.Items.AddRange(new ToolStripItem[] {
                mnuHeThong, mnuDanhMuc, mnuNghiepVu, mnuTroGiup
            });

            // 2. ToolStrip
            this.btnToolSinhVien.Text = " Sinh viên ";
            this.btnToolSinhVien.Click += (s, e) => OpenChildForm(new frmSinhVien());

            this.btnToolChiTiet.Text = " Chi tiết ";
            this.btnToolChiTiet.Click += (s, e) => MoChiTietSinhVien();

            this.btnToolTimKiem.Text = " Tìm kiếm ";
            this.btnToolTimKiem.Click += (s, e) => MoTimKiem();

            this.btnToolChonKhoa.Text = " Khoa ";
            this.btnToolChonKhoa.Click += (s, e) => MoChonKhoa();

            this.btnToolDangNhap.Text = " Đăng nhập ";
            this.btnToolDangNhap.Click += (s, e) => MoDangNhap();

            this.btnToolGioiThieu.Text = " Giới thiệu ";
            this.btnToolGioiThieu.Click += (s, e) => new frmGioiThieu().ShowDialog(this);

            this.toolStripQuick.Items.AddRange(new ToolStripItem[] {
                btnToolSinhVien, btnToolChiTiet, btnToolTimKiem, btnToolChonKhoa,
                sepTool,
                btnToolDangNhap, btnToolGioiThieu
            });

            // 3. StatusStrip (Bài 10)
            this.lblTrangThai.Text = "Hệ thống sẵn sàng";
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;

            this.lblSpringSpacer.Spring = true;

            this.lblNguoiDung.Text = "Người dùng: Phan Văn Thắng (24002545)";
            this.lblNguoiDung.AutoSize = true;
            this.lblNguoiDung.BorderSides = ToolStripStatusLabelBorderSides.Left;
            this.lblNguoiDung.BorderStyle = Border3DStyle.Etched;

            this.lblDongHo.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            this.lblDongHo.AutoSize = true;
            this.lblDongHo.BorderSides = ToolStripStatusLabelBorderSides.Left;
            this.lblDongHo.BorderStyle = Border3DStyle.Etched;

            this.statusStripMain.Items.AddRange(new ToolStripItem[] {
                lblTrangThai, lblSpringSpacer, lblNguoiDung, lblDongHo
            });

            // Đồng hồ thời gian thực
            this.timerDongHo.Interval = 1000;
            this.timerDongHo.Tick += (s, e) =>
            {
                this.lblDongHo.Text = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            };
            this.timerDongHo.Start();

            // Sự kiện FormClosing (Bài 9)
            this.FormClosing += frmMain_FormClosing;

            this.Controls.Add(this.toolStripQuick);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
        }

        // Bài 5: Quản lý Form con trong MDI, tránh mở trùng
        public void OpenChildForm(Form child)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == child.GetType())
                {
                    f.WindowState = FormWindowState.Normal;
                    f.Activate();
                    child.Dispose();
                    lblTrangThai.Text = $"Kích hoạt lại: {f.Text}";
                    return;
                }
            }

            child.MdiParent = this;
            child.StartPosition = FormStartPosition.Manual;
            child.Location = new Point(20, 15);
            child.Show();
            lblTrangThai.Text = $"Đang mở: {child.Text}";
        }

        private void MoDangNhap()
        {
            using (frmDangNhap f = new frmDangNhap())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    lblNguoiDung.Text = $"Người dùng: {f.TenNguoiDung} (Quản trị viên)";
                    lblTrangThai.Text = "Đăng nhập thành công";
                }
            }
        }

        private void DangXuat()
        {
            lblNguoiDung.Text = "Người dùng: Khách (Chưa đăng nhập)";
            lblTrangThai.Text = "Đã đăng xuất khỏi hệ thống";
            MessageBox.Show("Bạn đã đăng xuất thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MoChonKhoa()
        {
            List<string> ds = new List<string> {
                "Công nghệ thông tin",
                "Công nghệ kỹ thuật ô tô",
                "Kinh tế",
                "Điện - Điện tử",
                "Ngôn ngữ Anh",
                "Quản trị kinh doanh"
            };
            using (frmChonKhoa f = new frmChonKhoa(ds))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    lblTrangThai.Text = $"Khoa đang chọn: {f.KhoaDuocChon}";
                    MessageBox.Show($"Khoa được chọn: {f.KhoaDuocChon}", "Bài 8: Form chọn khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void MoChiTietSinhVien()
        {
            SinhVien sv = new SinhVien("24002545", "Phan Văn Thắng", new DateTime(2006, 3, 26), 8.5, "Nam", "Công nghệ thông tin", "Lập trình, Đọc sách");
            using (frmChiTietSinhVien f = new frmChiTietSinhVien(sv))
            {
                f.ShowDialog(this);
            }
        }

        private void MoTimKiem()
        {
            using (frmTimKiem f = new frmTimKiem())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    string tieuChi = f.TimTheoMa ? "Mã sinh viên" : "Họ và tên";
                    lblTrangThai.Text = $"Tìm kiếm theo {tieuChi}: {f.TuKhoa}";
                    MessageBox.Show($"Đã tìm kiếm với từ khóa: \"{f.TuKhoa}\" (Tiêu chí: {tieuChi})", "Bài 7: Tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Bài 9: Xác nhận đóng ứng dụng bằng FormClosing
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát khỏi ứng dụng không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dr == DialogResult.No)
            {
                e.Cancel = true;
                lblTrangThai.Text = "Đã hủy thao tác thoát ứng dụng";
            }
            else
            {
                if (timerDongHo != null)
                {
                    timerDongHo.Stop();
                    timerDongHo.Dispose();
                }
            }
        }
    }
}
