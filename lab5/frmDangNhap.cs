using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmDangNhap : Form
    {
        private Label lblTitle;
        private Label lblTenDangNhap;
        private TextBox txtTenDangNhap;
        private Label lblMatKhau;
        private TextBox txtMatKhau;
        private CheckBox chkHienMatKhau;
        private Label lblThongBao;
        private Button btnDangNhap;
        private Button btnThoat;

        private System.Windows.Forms.Timer timerKhoa;
        private int soLanSai = 0;
        private int giayConLai = 30;

        public bool DaDangNhapThanhCong { get; private set; } = false;
        public string TenNguoiDung { get; private set; } = "";

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblTenDangNhap = new Label();
            this.txtTenDangNhap = new TextBox();
            this.lblMatKhau = new Label();
            this.txtMatKhau = new TextBox();
            this.chkHienMatKhau = new CheckBox();
            this.lblThongBao = new Label();
            this.btnDangNhap = new Button();
            this.btnThoat = new Button();

            this.timerKhoa = new System.Windows.Forms.Timer();
            this.timerKhoa.Interval = 1000;
            this.timerKhoa.Tick += TimerKhoa_Tick;

            this.Text = "Bài 6: Đăng nhập hệ thống";
            this.Size = new Size(480, 320);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Title
            this.lblTitle.Text = "ĐĂNG NHẬP HỆ THỐNG";
            this.lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(140, 20);
            this.lblTitle.AutoSize = true;

            // Tên đăng nhập: labels at x=35, inputs at x=160
            this.lblTenDangNhap.Text = "Tên đăng nhập:";
            this.lblTenDangNhap.Location = new Point(35, 65);
            this.lblTenDangNhap.AutoSize = true;

            this.txtTenDangNhap.Location = new Point(160, 62);
            this.txtTenDangNhap.Size = new Size(260, 23);
            this.txtTenDangNhap.Text = "admin";

            // Mật khẩu
            this.lblMatKhau.Text = "Mật khẩu:";
            this.lblMatKhau.Location = new Point(35, 105);
            this.lblMatKhau.AutoSize = true;

            this.txtMatKhau.Location = new Point(160, 102);
            this.txtMatKhau.Size = new Size(260, 23);
            this.txtMatKhau.UseSystemPasswordChar = true;
            this.txtMatKhau.Text = "123456";

            // Checkbox hiển thị mật khẩu
            this.chkHienMatKhau.Text = "Hiển thị mật khẩu";
            this.chkHienMatKhau.Location = new Point(160, 135);
            this.chkHienMatKhau.AutoSize = true;
            this.chkHienMatKhau.CheckedChanged += (s, e) =>
            {
                this.txtMatKhau.UseSystemPasswordChar = !this.chkHienMatKhau.Checked;
            };

            // Thông báo lỗi / đếm ngược
            this.lblThongBao.Text = "";
            this.lblThongBao.Location = new Point(25, 168);
            this.lblThongBao.Size = new Size(415, 35);
            this.lblThongBao.TextAlign = ContentAlignment.MiddleCenter;

            // Buttons
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.Location = new Point(125, 215);
            this.btnDangNhap.Size = new Size(110, 34);
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += BtnDangNhap_Click;

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Location = new Point(255, 215);
            this.btnThoat.Size = new Size(110, 34);
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.AcceptButton = this.btnDangNhap;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblTenDangNhap, txtTenDangNhap,
                lblMatKhau, txtMatKhau, chkHienMatKhau,
                lblThongBao, btnDangNhap, btnThoat
            });
        }

        private void BtnDangNhap_Click(object sender, EventArgs e)
        {
            string user = txtTenDangNhap.Text.Trim();
            string pass = txtMatKhau.Text.Trim();

            if (user == "admin" && pass == "123456")
            {
                DaDangNhapThanhCong = true;
                TenNguoiDung = user;
                soLanSai = 0;
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("Đăng nhập hệ thống thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                soLanSai++;
                if (soLanSai >= 3)
                {
                    btnDangNhap.Enabled = false;
                    giayConLai = 30;
                    lblThongBao.Text = $"Bạn đã nhập sai 3 lần! Nút đăng nhập bị khóa trong {giayConLai} giây.";
                    timerKhoa.Start();
                    MessageBox.Show("Bạn đã nhập sai 3 lần liên tiếp.\nNút Đăng nhập sẽ bị khóa trong 30 giây!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int conLai = 3 - soLanSai;
                    lblThongBao.Text = $"Sai thông tin đăng nhập! Còn lại {conLai} lần thử.";
                }
            }
        }

        private void TimerKhoa_Tick(object sender, EventArgs e)
        {
            giayConLai--;
            if (giayConLai > 0)
            {
                lblThongBao.Text = $"Nút đăng nhập đang bị khóa! Thử lại sau {giayConLai} giây...";
            }
            else
            {
                timerKhoa.Stop();
                btnDangNhap.Enabled = true;
                soLanSai = 0;
                lblThongBao.Text = "Bạn có thể thử đăng nhập lại.";
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (timerKhoa != null)
            {
                timerKhoa.Stop();
                timerKhoa.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}
