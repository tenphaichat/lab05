using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmGioiThieu : Form
    {
        private Label lblAppTitle;
        private Label lblHocPhan;
        private Label lblGiangVien;
        private Label lblSinhVien;
        private Label lblMSSV;
        private Label lblLop;
        private Label lblTruong;
        private Label lblMoTa;
        private PictureBox picLogo;
        private Button btnDong;

        public frmGioiThieu()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblAppTitle = new Label();
            this.lblHocPhan = new Label();
            this.lblGiangVien = new Label();
            this.lblSinhVien = new Label();
            this.lblMSSV = new Label();
            this.lblLop = new Label();
            this.lblTruong = new Label();
            this.lblMoTa = new Label();
            this.picLogo = new PictureBox();
            this.btnDong = new Button();

            this.Text = "Bài 10: Giới thiệu ứng dụng";
            this.Size = new Size(520, 360);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Logo / Icon
            this.picLogo.Location = new Point(25, 25);
            this.picLogo.Size = new Size(80, 80);
            this.picLogo.BorderStyle = BorderStyle.FixedSingle;
            this.picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            string avatarPath = Path.Combine(Application.StartupPath, "Images", "avatar_thang.png");
            if (!File.Exists(avatarPath))
            {
                avatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Images", "avatar_thang.png");
            }
            if (File.Exists(avatarPath))
            {
                try
                {
                    using (var fs = new FileStream(avatarPath, FileMode.Open, FileAccess.Read))
                    {
                        this.picLogo.Image = Image.FromStream(fs);
                    }
                }
                catch { }
            }

            // Tiêu đề ứng dụng
            this.lblAppTitle.Text = "HỆ THỐNG QUẢN LÝ SINH VIÊN";
            this.lblAppTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblAppTitle.Location = new Point(120, 25);
            this.lblAppTitle.AutoSize = true;

            this.lblHocPhan.Text = "Học phần: Lập trình .NET (IT3212) - Lab 5";
            this.lblHocPhan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblHocPhan.Location = new Point(120, 55);
            this.lblHocPhan.AutoSize = true;

            this.lblTruong.Text = "Khoa Công nghệ Thông tin - Trường Đại học Công nghệ Đông Á";
            this.lblTruong.Location = new Point(120, 80);
            this.lblTruong.AutoSize = true;

            // Thông tin sinh viên
            this.lblSinhVien.Text = "Sinh viên thực hiện: Phan Văn Thắng";
            this.lblSinhVien.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            this.lblSinhVien.Location = new Point(120, 115);
            this.lblSinhVien.AutoSize = true;

            this.lblMSSV.Text = "Mã số sinh viên: 24002545";
            this.lblMSSV.Location = new Point(120, 140);
            this.lblMSSV.AutoSize = true;

            this.lblLop.Text = "Lớp: IT3212 | Ngày sinh: 26/03/2006";
            this.lblLop.Location = new Point(120, 165);
            this.lblLop.AutoSize = true;

            this.lblMoTa.Text = "Chương 3: Xử lý sự kiện, kiểm tra dữ liệu với ErrorProvider\nvà xây dựng ứng dụng đa Form chuyên nghiệp.";
            this.lblMoTa.Location = new Point(120, 195);
            this.lblMoTa.AutoSize = true;

            // Nút Đóng
            this.btnDong.Text = "Đóng";
            this.btnDong.Location = new Point(200, 260);
            this.btnDong.Size = new Size(110, 32);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += (s, e) => this.Close();

            this.Controls.AddRange(new Control[] {
                picLogo, lblAppTitle, lblHocPhan, lblTruong,
                lblSinhVien, lblMSSV, lblLop, lblMoTa, btnDong
            });
        }
    }
}
