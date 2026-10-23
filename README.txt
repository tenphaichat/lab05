========================================================================
BÁO CÁO KẾT QUẢ THỰC HÀNH LAB 5: XỬ LÝ SỰ KIỆN, KIỂM TRA DỮ LIỆU VÀ ĐA FORM
HỌC PHẦN: LẬP TRÌNH .NET (IT3212) - ĐẠI HỌC CÔNG NGHỆ ĐÔNG Á
SINH VIÊN THỰC HIỆN: PHAN VĂN THẮNG - MSSV: 24002545 - LỚP: IT3212
========================================================================

1. HƯỚNG DẪN BIÊN DỊCH VÀ CHẠY
- Yêu cầu môi trường: Visual Studio 2022 hoặc .NET SDK (>= .NET 8 / .NET 9 hỗ trợ Windows Forms Desktop).
- Mở bằng Visual Studio:
  + Mở file solution: IT3212_Labs.sln
  + Nhấn F5 hoặc Ctrl+F5 để build và khởi chạy ứng dụng Windows Forms.
- Chạy bằng dòng lệnh (CLI):
  + Di chuyển vào thư mục lab5:
      cd lab5
  + Chạy lệnh:
      dotnet run --project lab5/Lab05_MultiForm.csproj

2. CẤU TRÚC VÀ TỔ CHỨC MÃ NGUỒN WINFORMS
Dự án được tổ chức chuẩn theo kiến trúc Windows Forms hướng đối tượng, phân chia form chức năng và lớp dữ liệu rõ ràng, chuẩn basic không màu mè:
- Solution: IT3212_Labs.sln
- Project: lab5/Lab05_MultiForm.csproj
- SinhVien.cs: Lớp thực thể sinh viên (Mã SV, Họ tên, Ngày sinh, Điểm TB, Giới tính, Khoa, Sở thích, Đường dẫn ảnh, TinhTuoi(), XepLoai()).
- frmMain.cs: Form Dashboard đa Form điều hướng trung tâm (MDI Container), quản lý MenuStrip, ToolStrip, StatusStrip, đồng hồ thời gian thực và sự kiện FormClosing.
- frmSinhVien.cs: Form quản lý thông tin sinh viên tích hợp ErrorProvider (Bài 1), sự kiện KeyPress chặn ký tự lạ nhập điểm (Bài 2), TextChanged cập nhật thời gian thực (Bài 3), liên kết mở Form chi tiết (Bài 4), tìm kiếm (Bài 7) và chọn khoa (Bài 8).
- frmChiTietSinhVien.cs: Form hiển thị chi tiết hồ sơ sinh viên nhận đối tượng qua Constructor (Bài 4).
- frmDangNhap.cs: Form đăng nhập có chức năng khóa nút đăng nhập 30 giây khi sai 3 lần liên tiếp bằng Timer đếm ngược (Bài 6).
- frmTimKiem.cs: Hộp thoại tìm kiếm sinh viên theo mã hoặc tên, trả kết quả qua Property (Bài 7).
- frmChonKhoa.cs: Form chọn khoa đào tạo nhận danh sách qua Constructor và trả về khoa được chọn qua Property không dùng biến toàn cục (Bài 8).
- frmGioiThieu.cs: Hộp thoại giới thiệu thông tin tác giả và học phần (Bài 10).
- Thư mục Images/: Chứa ảnh đại diện sinh viên avatar_thang.png và các tài nguyên ảnh mẫu.

3. DANH SÁCH BÀI TẬP ĐÃ HOÀN THÀNH (10/10 BÀI)
* PHẦN 1: BÀI TẬP CÓ HƯỚNG DẪN (1 - 5)
- Bài 1: Kiểm tra bắt buộc bằng ErrorProvider: Không cho phép lưu khi Mã SV hoặc Họ tên trống; hiển thị biểu tượng đỏ cảnh báo lỗi cạnh TextBox qua phương thức ValidateInput().
- Bài 2: Giới hạn ký tự nhập điểm bằng KeyPress: Chỉ cho phép nhập chữ số và duy nhất một dấu chấm thập phân vào txtDiemTB; chặn mọi ký tự chữ cái và ký tự đặc biệt.
- Bài 3: Cập nhật trạng thái theo thời gian thực bằng TextChanged: Khi thay đổi Họ tên hoặc Điểm, tự động cập nhật Label xem trước (Mã - Họ tên) và Label trạng thái hợp lệ của điểm.
- Bài 4: Truyền dữ liệu sang Form chi tiết bằng Constructor: Tạo frmChiTietSinhVien nhận đối tượng SinhVien qua Constructor và hiển thị hồ sơ đầy đủ, không truy cập trực tiếp control private của Form khác.
- Bài 5: MenuStrip mở các Form chức năng và tránh mở trùng: Cài đặt OpenChildForm(Form child) trong MDI Container, nếu Form đã mở thì kích hoạt lại (Activate) và không tạo trùng Form mới.

* PHẦN 2: BÀI TẬP TỰ THỰC HIỆN (6 - 10)
- Bài 6: Form đăng nhập có giới hạn lần thử: Sau 3 lần nhập sai tài khoản/mật khẩu, khóa nút Đăng nhập trong 30 giây và sử dụng Timer đếm ngược hiển thị thời gian còn lại từng giây.
- Bài 7: Hộp thoại tìm kiếm: Tạo frmTimKiem nhận từ khóa và tiêu chí tìm kiếm (theo Mã hoặc theo Họ tên), trả kết quả về Form gọi qua Property TuKhoa và DialogResult.
- Bài 8: Form chọn khoa không dùng biến toàn cục: Truyền danh sách khoa sang frmChonKhoa qua Constructor; trả về khoa được chọn thông qua Property KhoaDuocChon.
- Bài 9: Xác nhận đóng ứng dụng bằng FormClosing: Bắt sự kiện FormClosing của Form chính, hiển thị MessageBox hỏi xác nhận; nếu chọn "No" thì gán e.Cancel = true để hủy đóng.
- Bài 10: Dashboard đa Form: Xây dựng Dashboard hoàn chỉnh trên frmMain có MenuStrip đầy đủ, ToolStrip truy cập nhanh, StatusStrip hiển thị trạng thái, người dùng đăng nhập và đồng hồ thời gian thực (Timer cập nhật liên tục).

4. DỮ LIỆU KIỂM THỬ MẪU (TEST CASES)
- Thông tin sinh viên mẫu: Phan Văn Thắng - MSSV: 24002545 - Ngày sinh: 26/03/2006.
- Bài 1: Bỏ trống Mã SV và Họ tên, nhập điểm 15 -> Bấm Lưu -> ErrorProvider hiện 3 icon đỏ báo lỗi.
- Bài 2: Nhập "8.50" vào txtDiemTB -> Các phím chữ cái hoặc ký tự đặc biệt đều bị chặn hoàn toàn.
- Bài 3: Nhập Mã "24002545", Tên "Phan Văn Thắng", Điểm "8.50" -> Label xem trước hiển thị ngay "24002545 - Phan Văn Thắng", trạng thái: "Dữ liệu điểm hợp lệ".
- Bài 4: Bấm nút "Chi tiết (Bài 4)" -> Mở hồ sơ chi tiết của Phan Văn Thắng, điểm 8.50 (Xếp loại Giỏi), hiển thị ảnh đại diện rõ nét.
- Bài 5: Bấm Menu Danh mục -> Quản lý Sinh viên -> Form mở trong MDI; bấm lại lần 2 -> Kích hoạt lại Form hiện tại, không mở trùng.
- Bài 6: Nhập sai mật khẩu 3 lần -> Nút Đăng nhập bị mờ (Disabled), nhãn thông báo đếm ngược từ 30 giây về 0 giây. Đăng nhập đúng: admin / 123456 -> Thành công.
- Bài 7: Mở Tìm kiếm, nhập "24002545", chọn "Tìm theo Mã SV" -> Form gọi nhận từ khóa và hiển thị sinh viên tương ứng.
- Bài 8: Bấm "Chọn..." cạnh ô Khoa -> Mở frmChonKhoa, chọn "Công nghệ thông tin" -> Cập nhật an toàn vào ComboBox.
- Bài 9: Bấm nút X trên thanh tiêu đề hoặc chọn Hệ thống -> Thoát -> Xuất hiện hộp thoại xác nhận. Chọn "No" ứng dụng tiếp tục chạy bình thường.
- Bài 10: Mở Dashboard chính -> Thanh StatusStrip hiển thị đồng hồ thời gian thực chạy từng giây và thông tin người dùng Phan Văn Thắng (24002545).
