using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab05_MultiForm
{
    public class frmChonKhoa : Form
    {
        private Label lblHuongDan;
        private ListBox lstKhoa;
        private Button btnChon;
        private Button btnHuy;

        public string KhoaDuocChon { get; private set; } = "";

        public frmChonKhoa() : this(null, "")
        {
        }

        public frmChonKhoa(List<string> dsKhoa, string khoaHienTai = "")
        {
            InitializeComponent();

            if (dsKhoa == null || dsKhoa.Count == 0)
            {
                dsKhoa = new List<string>
                {
                    "Công nghệ thông tin",
                    "Công nghệ kỹ thuật ô tô",
                    "Kinh tế",
                    "Điện - Điện tử",
                    "Ngôn ngữ Anh",
                    "Quản trị kinh doanh"
                };
            }

            lstKhoa.Items.Clear();
            foreach (var k in dsKhoa)
            {
                lstKhoa.Items.Add(k);
            }

            if (!string.IsNullOrEmpty(khoaHienTai) && lstKhoa.Items.Contains(khoaHienTai))
            {
                lstKhoa.SelectedItem = khoaHienTai;
            }
            else if (lstKhoa.Items.Count > 0)
            {
                lstKhoa.SelectedIndex = 0;
            }
        }

        private void InitializeComponent()
        {
            this.lblHuongDan = new Label();
            this.lstKhoa = new ListBox();
            this.btnChon = new Button();
            this.btnHuy = new Button();

            this.Text = "Bài 8: Chọn khoa đào tạo";
            this.Size = new Size(420, 340);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.lblHuongDan.Text = "Chọn một khoa từ danh sách bên dưới:";
            this.lblHuongDan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            this.lblHuongDan.Location = new Point(25, 20);
            this.lblHuongDan.AutoSize = true;

            this.lstKhoa.Location = new Point(25, 50);
            this.lstKhoa.Size = new Size(355, 170);
            this.lstKhoa.Font = new Font("Segoe UI", 9.5F);
            this.lstKhoa.DoubleClick += (s, e) => BtnChon_Click(s, e);

            this.btnChon.Text = "Chọn khoa";
            this.btnChon.Location = new Point(95, 245);
            this.btnChon.Size = new Size(105, 32);
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += BtnChon_Click;

            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.Location = new Point(220, 245);
            this.btnHuy.Size = new Size(105, 32);
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            };

            this.Controls.AddRange(new Control[] {
                lblHuongDan, lstKhoa, btnChon, btnHuy
            });
        }

        private void BtnChon_Click(object sender, EventArgs e)
        {
            if (lstKhoa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một khoa trong danh sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.KhoaDuocChon = lstKhoa.SelectedItem.ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
