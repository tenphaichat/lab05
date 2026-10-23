using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmSinhVien : Form
    {
        private Label lblTitle;
        private Label lblMaSV, lblHoTen, lblNgaySinh, lblGioiTinh, lblKhoa, lblDiemTB;
        private TextBox txtMaSV, txtHoTen, txtDiemTB;
        private DateTimePicker dtpNgaySinh;
        private RadioButton radNam, radNu;
        private ComboBox cboKhoa;
        private Button btnChonKhoa;

        private GroupBox grpSoThich;
        private CheckBox chkDocSach, chkTheThao, chkLapTrinh, chkDuLich;

        private GroupBox grpAnh;
        private PictureBox picAnh;
        private Button btnChonAnh;
        private string duongDanAnh = "";

        private GroupBox grpTrangThai;
        private Label lblXemTruocTitle, lblXemTruoc;
        private Label lblTrangThaiDiemTitle, lblTrangThaiDiem;

        private Button btnLuu, btnXemChiTiet, btnTimKiem, btnLamMoi, btnDong;
        private ErrorProvider errorProvider1;

        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblMaSV = new Label();
            this.txtMaSV = new TextBox();
            this.lblHoTen = new Label();
            this.txtHoTen = new TextBox();
            this.lblNgaySinh = new Label();
            this.dtpNgaySinh = new DateTimePicker();
            this.lblGioiTinh = new Label();
            this.radNam = new RadioButton();
            this.radNu = new RadioButton();
            this.lblKhoa = new Label();
            this.cboKhoa = new ComboBox();
            this.btnChonKhoa = new Button();
            this.lblDiemTB = new Label();
            this.txtDiemTB = new TextBox();

            this.grpSoThich = new GroupBox();
            this.chkDocSach = new CheckBox();
            this.chkTheThao = new CheckBox();
            this.chkLapTrinh = new CheckBox();
            this.chkDuLich = new CheckBox();

            this.grpAnh = new GroupBox();
            this.picAnh = new PictureBox();
            this.btnChonAnh = new Button();

            this.grpTrangThai = new GroupBox();
            this.lblXemTruocTitle = new Label();
            this.lblXemTruoc = new Label();
            this.lblTrangThaiDiemTitle = new Label();
            this.lblTrangThaiDiem = new Label();

            this.btnLuu = new Button();
            this.btnXemChiTiet = new Button();
            this.btnTimKiem = new Button();
            this.btnLamMoi = new Button();
            this.btnDong = new Button();
            this.errorProvider1 = new ErrorProvider();

            this.Text = "Quản lý thông tin sinh viên (Bài 1 - 5)";
            this.Size = new Size(780, 540);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Title
            this.lblTitle.Text = "QUẢN LÝ THÔNG TIN SINH VIÊN";
            this.lblTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.lblTitle.Location = new Point(250, 15);
            this.lblTitle.AutoSize = true;

            // Mã sinh viên
            this.lblMaSV.Text = "Mã sinh viên:";
            this.lblMaSV.Location = new Point(25, 60);
            this.lblMaSV.AutoSize = true;

            this.txtMaSV.Location = new Point(135, 57);
            this.txtMaSV.Size = new Size(220, 23);
            this.txtMaSV.Text = "24002545";
            this.txtMaSV.TextChanged += Input_TextChanged;

            // Họ tên
            this.lblHoTen.Text = "Họ và tên:";
            this.lblHoTen.Location = new Point(25, 95);
            this.lblHoTen.AutoSize = true;

            this.txtHoTen.Location = new Point(135, 92);
            this.txtHoTen.Size = new Size(220, 23);
            this.txtHoTen.Text = "Phan Văn Thắng";
            this.txtHoTen.TextChanged += Input_TextChanged;

            // Ngày sinh
            this.lblNgaySinh.Text = "Ngày sinh:";
            this.lblNgaySinh.Location = new Point(25, 130);
            this.lblNgaySinh.AutoSize = true;

            this.dtpNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgaySinh.Format = DateTimePickerFormat.Custom;
            this.dtpNgaySinh.Location = new Point(135, 127);
            this.dtpNgaySinh.Size = new Size(220, 23);
            this.dtpNgaySinh.Value = new DateTime(2006, 3, 26);

            // Giới tính
            this.lblGioiTinh.Text = "Giới tính:";
            this.lblGioiTinh.Location = new Point(25, 165);
            this.lblGioiTinh.AutoSize = true;

            this.radNam.Text = "Nam";
            this.radNam.Location = new Point(135, 163);
            this.radNam.Size = new Size(65, 20);
            this.radNam.Checked = true;

            this.radNu.Text = "Nữ";
            this.radNu.Location = new Point(225, 163);
            this.radNu.Size = new Size(65, 20);

            // Khoa
            this.lblKhoa.Text = "Khoa:";
            this.lblKhoa.Location = new Point(25, 200);
            this.lblKhoa.AutoSize = true;

            this.cboKhoa.Location = new Point(135, 197);
            this.cboKhoa.Size = new Size(220, 23);
            this.cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboKhoa.Items.AddRange(new object[] {
                "Công nghệ thông tin",
                "Công nghệ kỹ thuật ô tô",
                "Kinh tế",
                "Điện - Điện tử",
                "Ngôn ngữ Anh",
                "Quản trị kinh doanh"
            });
            this.cboKhoa.SelectedIndex = 0;

            // Nút chọn khoa (Bài 8)
            this.btnChonKhoa.Text = "Chọn...";
            this.btnChonKhoa.Location = new Point(365, 195);
            this.btnChonKhoa.Size = new Size(70, 27);
            this.btnChonKhoa.UseVisualStyleBackColor = true;
            this.btnChonKhoa.Click += BtnChonKhoa_Click;

            // Điểm trung bình (Bài 2 KeyPress)
            this.lblDiemTB.Text = "Điểm TB:";
            this.lblDiemTB.Location = new Point(25, 235);
            this.lblDiemTB.AutoSize = true;

            this.txtDiemTB.Location = new Point(135, 232);
            this.txtDiemTB.Size = new Size(220, 23);
            this.txtDiemTB.Text = "8.50";
            this.txtDiemTB.KeyPress += txtDiemTB_KeyPress;
            this.txtDiemTB.TextChanged += Input_TextChanged;

            // GroupBox Sở thích
            this.grpSoThich.Text = "Sở thích cá nhân";
            this.grpSoThich.Location = new Point(25, 275);
            this.grpSoThich.Size = new Size(420, 75);

            this.chkDocSach.Text = "Đọc sách";
            this.chkDocSach.Location = new Point(15, 28);
            this.chkDocSach.AutoSize = true;
            this.chkDocSach.Checked = true;

            this.chkTheThao.Text = "Thể thao";
            this.chkTheThao.Location = new Point(115, 28);
            this.chkTheThao.AutoSize = true;

            this.chkLapTrinh.Text = "Lập trình";
            this.chkLapTrinh.Location = new Point(210, 28);
            this.chkLapTrinh.AutoSize = true;
            this.chkLapTrinh.Checked = true;

            this.chkDuLich.Text = "Du lịch";
            this.chkDuLich.Location = new Point(310, 28);
            this.chkDuLich.AutoSize = true;

            this.grpSoThich.Controls.AddRange(new Control[] {
                chkDocSach, chkTheThao, chkLapTrinh, chkDuLich
            });

            // GroupBox Ảnh đại diện
            this.grpAnh.Text = "Ảnh sinh viên";
            this.grpAnh.Location = new Point(470, 50);
            this.grpAnh.Size = new Size(270, 230);

            this.picAnh.Location = new Point(25, 25);
            this.picAnh.Size = new Size(220, 150);
            this.picAnh.BorderStyle = BorderStyle.FixedSingle;
            this.picAnh.SizeMode = PictureBoxSizeMode.Zoom;
            LoadDefaultAvatar();

            this.btnChonAnh.Text = "Chọn ảnh...";
            this.btnChonAnh.Location = new Point(80, 185);
            this.btnChonAnh.Size = new Size(110, 30);
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += BtnChonAnh_Click;

            this.grpAnh.Controls.Add(picAnh);
            this.grpAnh.Controls.Add(btnChonAnh);

            // GroupBox Trạng thái thời gian thực (Bài 3)
            this.grpTrangThai.Text = "Cập nhật thời gian thực (Bài 3)";
            this.grpTrangThai.Location = new Point(25, 360);
            this.grpTrangThai.Size = new Size(715, 80);

            this.lblXemTruocTitle.Text = "Xem trước:";
            this.lblXemTruocTitle.Location = new Point(15, 25);
            this.lblXemTruocTitle.AutoSize = true;

            this.lblXemTruoc.Text = "24002545 - Phan Văn Thắng";
            this.lblXemTruoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblXemTruoc.Location = new Point(110, 25);
            this.lblXemTruoc.AutoSize = true;

            this.lblTrangThaiDiemTitle.Text = "Trạng thái:";
            this.lblTrangThaiDiemTitle.Location = new Point(15, 50);
            this.lblTrangThaiDiemTitle.AutoSize = true;

            this.lblTrangThaiDiem.Text = "Dữ liệu điểm hợp lệ";
            this.lblTrangThaiDiem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblTrangThaiDiem.Location = new Point(110, 50);
            this.lblTrangThaiDiem.AutoSize = true;

            this.grpTrangThai.Controls.AddRange(new Control[] {
                lblXemTruocTitle, lblXemTruoc,
                lblTrangThaiDiemTitle, lblTrangThaiDiem
            });

            // Action Buttons
            this.btnLuu.Text = "Lưu (Bài 1)";
            this.btnLuu.Location = new Point(35, 455);
            this.btnLuu.Size = new Size(120, 34);
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += BtnLuu_Click;

            this.btnXemChiTiet.Text = "Chi tiết (Bài 4)";
            this.btnXemChiTiet.Location = new Point(175, 455);
            this.btnXemChiTiet.Size = new Size(135, 34);
            this.btnXemChiTiet.UseVisualStyleBackColor = true;
            this.btnXemChiTiet.Click += BtnXemChiTiet_Click;

            this.btnTimKiem.Text = "Tìm kiếm (Bài 7)";
            this.btnTimKiem.Location = new Point(330, 455);
            this.btnTimKiem.Size = new Size(135, 34);
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += BtnTimKiem_Click;

            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Location = new Point(485, 455);
            this.btnLamMoi.Size = new Size(110, 34);
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.Click += BtnLamMoi_Click;

            this.btnDong.Text = "Đóng";
            this.btnDong.Location = new Point(615, 455);
            this.btnDong.Size = new Size(115, 34);
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += (s, e) => this.Close();

            // ErrorProvider config
            this.errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            this.Controls.AddRange(new Control[] {
                lblTitle,
                lblMaSV, txtMaSV,
                lblHoTen, txtHoTen,
                lblNgaySinh, dtpNgaySinh,
                lblGioiTinh, radNam, radNu,
                lblKhoa, cboKhoa, btnChonKhoa,
                lblDiemTB, txtDiemTB,
                grpSoThich, grpAnh, grpTrangThai,
                btnLuu, btnXemChiTiet, btnTimKiem, btnLamMoi, btnDong
            });

            Input_TextChanged(this, EventArgs.Empty);
        }

        private void LoadDefaultAvatar()
        {
            string defaultImg = Path.Combine(Application.StartupPath, "Images", "avatar_thang.png");
            if (!File.Exists(defaultImg))
            {
                defaultImg = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Images", "avatar_thang.png");
            }
            if (File.Exists(defaultImg))
            {
                try
                {
                    using (var fs = new FileStream(defaultImg, FileMode.Open, FileAccess.Read))
                    {
                        picAnh.Image = Image.FromStream(fs);
                        duongDanAnh = defaultImg;
                    }
                }
                catch { }
            }
        }

        public bool ValidateInput()
        {
            errorProvider1.Clear();
            bool valid = true;

            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                errorProvider1.SetError(txtMaSV, "Nhập mã sinh viên");
                valid = false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                errorProvider1.SetError(txtHoTen, "Nhập họ tên");
                valid = false;
            }

            if (!double.TryParse(txtDiemTB.Text.Trim(), out double diem) || diem < 0 || diem > 10)
            {
                errorProvider1.SetError(txtDiemTB, "Điểm trung bình phải từ 0.0 đến 10.0");
                valid = false;
            }

            return valid;
        }

        private void txtDiemTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (char.IsDigit(e.KeyChar)) return;
            if (e.KeyChar == '.' && !txtDiemTB.Text.Contains(".")) return;
            e.Handled = true;
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            double diem;
            bool hopLe = double.TryParse(txtDiemTB.Text.Trim(), out diem) && diem >= 0 && diem <= 10;
            lblXemTruoc.Text = $"{txtMaSV.Text.Trim()} - {txtHoTen.Text.Trim()}";
            lblTrangThaiDiem.Text = hopLe ? "Dữ liệu điểm hợp lệ" : "Kiểm tra điểm (0.0 - 10.0)";
        }

        private string GetSoThich()
        {
            List<string> ds = new List<string>();
            if (chkDocSach.Checked) ds.Add("Đọc sách");
            if (chkTheThao.Checked) ds.Add("Thể thao");
            if (chkLapTrinh.Checked) ds.Add("Lập trình");
            if (chkDuLich.Checked) ds.Add("Du lịch");
            return ds.Count == 0 ? "Chưa chọn" : string.Join(", ", ds);
        }

        public SinhVien LayThongTinSinhVien()
        {
            double.TryParse(txtDiemTB.Text.Trim(), out double diem);
            return new SinhVien(
                txtMaSV.Text.Trim(),
                txtHoTen.Text.Trim(),
                dtpNgaySinh.Value,
                diem,
                radNam.Checked ? "Nam" : "Nữ",
                cboKhoa.Text,
                GetSoThich(),
                duongDanAnh
            );
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SinhVien sv = LayThongTinSinhVien();
                string thongTin = $"LƯU THÀNH CÔNG THÔNG TIN SINH VIÊN!\n\n" +
                                  $"Mã SV: {sv.MaSV}\n" +
                                  $"Họ tên: {sv.HoTen}\n" +
                                  $"Ngày sinh: {sv.NgaySinh:dd/MM/yyyy} (Tuổi: {sv.TinhTuoi()})\n" +
                                  $"Giới tính: {sv.GioiTinh}\n" +
                                  $"Khoa: {sv.Khoa}\n" +
                                  $"Điểm TB: {sv.DiemTB:N2} ({sv.XepLoai()})\n" +
                                  $"Sở thích: {sv.SoThich}";
                MessageBox.Show(thongTin, "Thông báo lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Dữ liệu nhập vào chưa hợp lệ! Vui lòng kiểm tra các vị trí báo lỗi màu đỏ cạnh ô nhập.", "Cảnh báo lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                SinhVien sv = LayThongTinSinhVien();
                using (frmChiTietSinhVien f = new frmChiTietSinhVien(sv))
                {
                    f.ShowDialog(this);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng hoàn thiện dữ liệu hợp lệ trước khi xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            using (frmTimKiem f = new frmTimKiem())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    string kieu = f.TimTheoMa ? "Mã SV" : "Họ và tên";
                    string ketQua = $"KẾT QUẢ TÌM KIẾM SINH VIÊN:\n\n" +
                                    $"Từ khóa: \"{f.TuKhoa}\"\n" +
                                    $"Tiêu chí: {kieu}\n\n" +
                                    $"Đã tìm thấy sinh viên:\n" +
                                    $"- Mã SV: {txtMaSV.Text}\n" +
                                    $"- Họ tên: {txtHoTen.Text}\n" +
                                    $"- Khoa: {cboKhoa.Text}\n" +
                                    $"- Điểm TB: {txtDiemTB.Text}";
                    MessageBox.Show(ketQua, "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnChonKhoa_Click(object sender, EventArgs e)
        {
            List<string> ds = new List<string>();
            foreach (var item in cboKhoa.Items)
            {
                ds.Add(item.ToString());
            }

            using (frmChonKhoa f = new frmChonKhoa(ds, cboKhoa.Text))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cboKhoa.SelectedItem = f.KhoaDuocChon;
                    MessageBox.Show($"Bạn đã chọn khoa: {f.KhoaDuocChon}", "Thông báo chọn khoa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Tệp hình ảnh|*.jpg;*.jpeg;*.png;*.bmp";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read))
                        {
                            picAnh.Image = Image.FromStream(fs);
                            duongDanAnh = dlg.FileName;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            dtpNgaySinh.Value = new DateTime(2006, 3, 26);
            radNam.Checked = true;
            cboKhoa.SelectedIndex = 0;
            chkDocSach.Checked = false;
            chkTheThao.Checked = false;
            chkLapTrinh.Checked = false;
            chkDuLich.Checked = false;
            txtMaSV.Focus();
        }
    }
}
