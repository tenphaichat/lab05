using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmTimKiem : Form
    {
        private Label lblHuongDan;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private GroupBox grpTieuChi;
        private RadioButton radTheoMa;
        private RadioButton radTheoTen;
        private Button btnTimKiem;
        private Button btnDong;

        public string TuKhoa => txtTuKhoa.Text.Trim();
        public bool TimTheoMa => radTheoMa.Checked;
        public bool TimTheoTen => radTheoTen.Checked;

        public frmTimKiem()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblHuongDan = new Label();
            this.lblTuKhoa = new Label();
            this.txtTuKhoa = new TextBox();
            this.grpTieuChi = new GroupBox();
            this.radTheoMa = new RadioButton();
            this.radTheoTen = new RadioButton();
            this.btnTimKiem = new Button();
            this.btnDong = new Button();

            this.Text = "Bài 7: Hộp thoại tìm kiếm";
            this.Size = new Size(420, 260);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.lblHuongDan.Text = "Nhập thông tin sinh viên cần tìm kiếm:";
            this.lblHuongDan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblHuongDan.Location = new Point(25, 20);
            this.lblHuongDan.AutoSize = true;

            this.lblTuKhoa.Text = "Từ khóa:";
            this.lblTuKhoa.Location = new Point(25, 60);
            this.lblTuKhoa.AutoSize = true;

            this.txtTuKhoa.Location = new Point(100, 57);
            this.txtTuKhoa.Size = new Size(275, 23);
            this.txtTuKhoa.Text = "24002545";

            this.grpTieuChi.Text = "Tiêu chí tìm kiếm";
            this.grpTieuChi.Location = new Point(25, 95);
            this.grpTieuChi.Size = new Size(350, 65);

            this.radTheoMa.Text = "Tìm theo Mã sinh viên";
            this.radTheoMa.Location = new Point(20, 25);
            this.radTheoMa.AutoSize = true;
            this.radTheoMa.Checked = true;

            this.radTheoTen.Text = "Tìm theo Họ và tên";
            this.radTheoTen.Location = new Point(180, 25);
            this.radTheoTen.AutoSize = true;

            this.grpTieuChi.Controls.Add(radTheoMa);
            this.grpTieuChi.Controls.Add(radTheoTen);

            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Location = new Point(105, 175);
            this.btnTimKiem.Size = new Size(95, 30);
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += BtnTimKiem_Click;

            this.btnDong.Text = "Đóng";
            this.btnDong.Location = new Point(220, 175);
            this.btnDong.Size = new Size(95, 30);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.AddRange(new Control[] {
                lblHuongDan, lblTuKhoa, txtTuKhoa,
                grpTieuChi, btnTimKiem, btnDong
            });
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTuKhoa.Text))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTuKhoa.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
