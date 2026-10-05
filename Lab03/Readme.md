# BÁO CÁO BÀI TẬP THỰC HÀNH LINQ CƠ BẢN

**Môn học:** Lập trình C# 
**Sinh viên thực hiện:** Dư Gia Đức
**Mã sinh viên:** 3124411072
**Lớp:** DCT124C5  

## NỘI DUNG VÀ GIẢI THÍCH BÀI LÀM

### Bài 2.1 - Truy vấn mảng số nguyên
**Giải thích phương pháp giải quyết:**
* **Câu a & b (Lọc dữ liệu):** Sử dụng phương thức `.Where()` để duyệt qua mảng và giữ lại các phần tử thỏa mãn điều kiện logic (dùng phép chia lấy dư `%` cho câu a, và phép so sánh `<=` cho câu b).
* **Câu c (Biến đổi dữ liệu):** Vì yêu cầu thay đổi giá trị của phần tử dựa trên tính chẵn lẻ để tạo thành một dãy số hoàn toàn mới (cùng số lượng phần tử), phương thức `.Select()` được sử dụng kết hợp với toán tử ba ngôi `(điều kiện) ? đúng : sai` để ánh xạ lại từng giá trị.

### Bài 2.2 - Truy vấn mảng chuỗi
**Giải thích phương pháp giải quyết:**
* **Câu a:** Lọc độ dài bằng `.Where(s => s.Length == 4)`, sau đó dùng `.OrderBy(s => s[0])` để lấy ký tự tại vị trí index 0 của mỗi chuỗi làm tiêu chí sắp xếp theo bảng chữ cái.
* **Câu b:** Sử dụng `.Select()` kết hợp với String Interpolation (`$"{...}"`) và các hàm `.ToLower()`, `.ToUpper()` để định dạng lại từng chuỗi theo đúng mẫu yêu cầu.
* **Câu c:** Dùng `.Where()` kết hợp hàm `.Contains("u")` để kiểm tra sự tồn tại của chuỗi con.
* **Câu d:** Sử dụng hàm tích hợp `char.IsUpper(s[0])` bên trong `.Where()` để kiểm tra xem ký tự đầu tiên có viết hoa hay không, từ đó lọc ra các danh từ riêng chính xác.

### Bài tập mảng mở rộng (Thống kê & Nhóm)
**Giải thích phương pháp giải quyết:**
* **Thống kê cơ bản:** Các hàm `.Count()`, `.Sum()`, `.Max()`, `.Min()` của LINQ được gọi trực tiếp để xử lý mảng mà không cần dùng vòng lặp `for`/`foreach` truyền thống. Để đếm các phần tử không trùng lặp, chuỗi phương thức `.Distinct().Count()` được áp dụng.
* **Phân nhóm (GroupBy) mảng số:** Nhóm theo số dư cho 5 bằng `.GroupBy(n => n % 5)`. Khóa (Key) tự động sinh ra cho các nhóm sẽ là tập hợp các số dư {0, 1, 2, 3, 4}.
* **Phân nhóm (GroupBy) mảng chuỗi:** Để lấy từ đầu tiên của tên món ăn làm nhóm, phương thức `.Split(' ')` được dùng để tách chuỗi thành mảng các từ đơn lẻ dựa trên khoảng trắng, sau đó lấy phần tử `[0]` làm Key định danh cho nhóm đó.

### Bài 4.1 - Xây dựng lớp Đối tượng và Dữ liệu
**Giải thích phương pháp giải quyết:**
* Xây dựng lớp `MonHoc` đóng vai trò là một cấu trúc dữ liệu (Data Model) chứa 4 thuộc tính (Properties) cơ bản: Mã môn, Tên môn, Hệ, và Số tiết.
* Xây dựng lớp `DuLieu` chứa một phương thức tĩnh (static) trả về một `List<MonHoc>`. Việc tạo dữ liệu giả lập (mock data) này giúp có nguồn dữ liệu đối tượng đồng nhất để thực hiện các bài truy vấn phức tạp ở phần sau.

### Bài 5.1 - Truy vấn cơ bản trên List
**Giải thích phương pháp giải quyết:**
* **Sắp xếp nhiều tiêu chí (Câu b):** Khi danh sách được sắp xếp bằng `.OrderByDescending()` (giảm dần theo số tiết), sẽ có hiện tượng trùng lặp số tiết giữa nhiều môn. Lệnh `.ThenBy()` được nối tiếp ngay sau đó để cung cấp tiêu chí phụ (tăng dần theo mã môn) nhằm giải quyết các trường hợp trùng lặp này.
* **Trích xuất một phần dữ liệu (Câu c):** Để tìm kiếm không phân biệt chữ hoa/thường, chuỗi được chuẩn hóa bằng `.ToLower()` trước khi dùng `.Contains("web")`. Sau khi lọc xong, thay vì lấy toàn bộ đối tượng `MonHoc`, hàm `.Select()` được dùng để tạo ra một Anonymous Type (kiểu ẩn danh) chỉ chứa đúng 2 thuộc tính cần thiết là Tên môn và Hệ.

### Bài 5.2 - Thống kê trên List<MonHoc>
**Giải thích phương pháp giải quyết:**
* **Xử lý chuỗi làm khóa phân nhóm (Câu j):** Thay vì phân nhóm dựa trên toàn bộ thuộc tính Mã môn, hàm `.Substring(0, 3)` được sử dụng để trích xuất 3 ký tự đầu tiên (ví dụ: `HP2`, `HP3`). Kết quả này trở thành khóa (Key) để nhóm các môn học cùng một học phần lại với nhau chính xác.
* **Cấu trúc nhóm lồng sắp xếp (Câu j & k):** Khi thực hiện gom nhóm phức tạp, phương thức `.Select()` được sử dụng để tái cấu trúc lại đối tượng trả về. Trong đó, `g.Key` đại diện cho tiêu chí của nhóm (Hệ hoặc Mã học phần), và danh sách các phần tử con bên trong nhóm đó tiếp tục được gọi `.OrderBy(...).ToList()` để đảm bảo dữ liệu trong từng nhóm đều được sắp xếp theo đúng quy luật trước khi xuất ra.