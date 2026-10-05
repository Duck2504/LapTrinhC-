## MSSV:3124411072
## Tên: Dư Gia Đức
## BÀI 2: THAO TÁC NHẬP XUẤT DỮ LIỆU CƠ BẢN
**1. Vấn đề:**
Làm quen với lớp "Console" để nhận dữ liệu đầu vào từ bàn phím và hiển thị kết quả ra màn hình.

**2. Giải pháp:**
- Sử dụng "Console.Write()" để hiển thị thông báo mời nhập liệu trên cùng một dòng.
- Sử dụng "Console.ReadLine()" để đọc luồng dữ liệu từ bàn phím và lưu trữ vào biến kiểu "string".
- Sử dụng "Console.WriteLine()" kết hợp với tính năng nội suy chuỗi (String Interpolation "$""") 

---

## BÀI 3 & 4: TÍNH LŨY THỪA VÀ KIỂM SOÁT LỖI NHẬP LIỆU
**1. Vấn đề:**
Thực hiện tính biểu thức lũy thừa $x^y$. Xử lý ngoại lệ trong trường hợp người dùng nhập sai định dạng dữ liệu (nhập ký tự chữ thay vì số nguyên), nhằm ngăn chặn tình trạng chương trình bị lỗi và dừng đột ngột (runtime error).

**2. Giải pháp:**
- **Tính toán:** Sử dụng phương thức toán học tĩnh "Math.Pow(x, y)" thuộc thư viện System.
- **Xử lý ngoại lệ:** Thay thế phương thức ép kiểu thông thường "Convert.ToInt32()" bằng phương thức an toàn "int.TryParse(input, out int result)". Phương thức này sẽ trả về giá trị "boolean" ("false" nếu ép kiểu thất bại), cho phép lập trình viên chủ động in ra thông báo lỗi và dùng lệnh "return;" để kết thúc quy trình một cách an toàn.

---

## BÀI 5: XÂY DỰNG MENU ĐIỀU HƯỚNG VÀ QUẢN LÝ TRẠNG THÁI
**1. Vấn đề:**
Thiết kế một Menu chức năng hoạt động liên tục. Đặt ràng buộc logic: người dùng phải thực hiện chức năng nhập dữ liệu (chức năng 1) trước khi có thể gọi các chức năng tính toán (chức năng 2 và 3).

**2. Giải pháp:**
- **Cấu trúc vòng lặp:** Đặt hệ thống Menu trong khối "while" kết hợp cấu trúc rẽ nhánh "switch-case" để phân luồng điều khiển.
- **Bảo toàn trạng thái:** Khai báo các biến $x, y$ và cờ trạng thái "bool daNhapDuLieu = false" ở phạm vi **bên ngoài** khối lệnh "while". Việc này đảm bảo dữ liệu không bị khởi tạo lại sau mỗi chu kỳ vòng lặp.
- **Ràng buộc logic:** Tại các khối "case" thực hiện phép tính, sử dụng lệnh "if (!daNhapDuLieu)" để kiểm tra trạng thái. Nếu cờ chưa được bật, chương trình sẽ hiển thị cảnh báo và từ chối thực hiện phép tính. Áp dụng vòng lặp "while(!double.TryParse(...))" để bắt buộc người dùng nhập đúng định dạng số thực.

---

## BÀI 6 & 7: XÂY DỰNG PHƯƠNG THỨC TRẢ VỀ GIÁ TRỊ (RETURN TYPE)
**1. Vấn đề:**
Đóng gói logic xử lý thành các phương thức độc lập, trả về kết quả cụ thể (kiểu "int" hoặc "bool") để tái sử dụng, thay vì xử lý và in trực tiếp ra Console (kiểu "void").

**2. Giải pháp:**
- **Bài 6 (Tìm Max):** Xây dựng phương thức có kiểu trả về là "int". Khởi tạo biến cục bộ "max = a". Lần lượt thực hiện so sánh và cập nhật "max" với các biến "b" và "c". Sử dụng từ khóa "return" để kết thúc và trả về giá trị lớn nhất.
- **Bài 7 (Kiểm tra số nguyên tố):** Xây dựng phương thức có kiểu trả về là "bool". Xử lý ngoại lệ ($n < 2 \rightarrow$ "return false"). Sử dụng vòng lặp từ 2 đến $\sqrt{n}$ để tối ưu hóa hiệu suất thuật toán; nếu $n$ chia hết cho bất kỳ giá trị lặp nào, lập tức "return false". Nếu vòng lặp kết thúc mà không thỏa điều kiện, "return true".

---

## BÀI 8 & 9: TRUYỀN THAM SỐ BẰNG THAM CHIẾU ("REF" VÀ "OUT")
**1. Vấn đề:**
Hàm thông thường thao tác trên bản sao của tham số (truyền tham trị). Khi cần thay đổi trực tiếp vùng nhớ của đối số bên ngoài, hoặc khi một phương thức cần trả về nhiều hơn một giá trị cùng lúc (ví dụ: trả về cả Max và Min), cần sử dụng kỹ thuật truyền tham chiếu.

**2. Giải pháp:**
- **Bài 8 (Sử dụng "ref"):** Áp dụng trong thuật toán hoán vị hai số. Biến truyền vào thông qua từ khóa "ref" **bắt buộc** phải được khởi tạo giá trị từ trước. Phương thức tác động trực tiếp lên vùng nhớ và sử dụng biến tạm "temp" để hoán đổi giá trị.
- **Bài 9 (Sử dụng "out"):** Áp dụng để trả về cả hai giá trị lớn nhất và nhỏ nhất từ một phương thức. Đối số truyền qua từ khóa "out" không cần gán giá trị trước khi gọi hàm, nhưng bên trong thân hàm **bắt buộc** phải cấp phát giá trị cho các tham số này trước khi kết thúc tiến trình.

---

## BÀI 10, 11, 12: CÁC KỸ THUẬT XỬ LÝ CHUỖI CƠ BẢN
**1. Vấn đề:**
Trong C#, kiểu "string" có tính chất bất biến (immutable). Việc phân tích và biến đổi chuỗi (kiểm tra tính đối xứng, đảo ngược chuỗi, chuẩn hóa văn bản) đòi hỏi việc sử dụng các phương thức có sẵn của lớp "String" hoặc mảng ký tự.

**2. Giải pháp:**
- **Bài 10 (Kiểm tra chuỗi đối xứng):** Áp dụng thuật toán hai con trỏ, chỉ số "left" bắt đầu từ 0 và "right" bắt đầu từ cuối chuỗi. Hai con trỏ di chuyển ngược chiều nhau để kiểm tra từng cặp ký tự. Nếu có bất kỳ cặp ký tự nào không đồng nhất, phương thức trả về "false".
- **Bài 11 (Đảo ngược chuỗi):** Chuyển đổi chuỗi thành một mảng ký tự thông qua phương thức ".ToCharArray()". Gọi phương thức "Array.Reverse()" để lật ngược thứ tự phần tử trong mảng, sau đó khởi tạo đối tượng "string" mới từ mảng này.
- **Bài 12 (Chuẩn hóa và phân tích chuỗi):** 
  - Sử dụng ".ToLower()" và ".ToUpper()" để đồng bộ chữ hoa/chữ thường.
  - Sử dụng phương thức ".Split(' ', StringSplitOptions.RemoveEmptyEntries)" để phân tách chuỗi thành các phần tử mảng dựa trên ký tự khoảng trắng, đồng thời tự động loại bỏ các khoảng trắng thừa. Số lượng từ trong chuỗi chính là độ dài (".Length") của mảng kết quả.

---

## BÀI 13: XÂY DỰNG LỚP ĐỐI TƯỢNG CƠ BẢN (CLASS)
**1. Vấn đề:**
Áp dụng tính Đóng gói (Encapsulation) của Lập trình Hướng đối tượng để gom nhóm các thuộc tính dữ liệu rời rạc (Mã sinh viên, Họ tên, Địa chỉ, Năm học) vào một thực thể duy nhất, giúp mã nguồn có cấu trúc rõ ràng và dễ bảo trì.

**2. Giải pháp:**
- Định nghĩa lớp "SinhVien".
- Khai báo các thuộc tính sử dụng cú pháp Properties chuẩn của C# (ví dụ: "public string HoTen { get; set; }").
- Xây dựng các phương thức hành vi "Nhap()" và "Xuat()" bên trong nội bộ lớp để thao tác trực tiếp với các thuộc tính của lớp đó.
- Tại phương thức "Main", tiến hành cấp phát bộ nhớ khởi tạo đối tượng bằng từ khóa "new" (ví dụ: "SinhVien sv = new SinhVien();") và tiến hành gọi các phương thức thông qua đối tượng.

---

## BÀI 14: XỬ LÝ NGHIỆP VỤ VÀ ĐỊNH DẠNG HIỂN THỊ DỮ LIỆU
**1. Vấn đề:**
Giải quyết bài toán tính lương nhân viên thực tế: xây dựng cơ chế nhập liệu chặt chẽ, xử lý logic trừ lương dựa trên số ngày vắng mặt, ngăn chặn các lỗi logic nghiêm trọng (ví dụ: lương âm), và xuất dữ liệu tài chính theo chuẩn định dạng.

**2. Giải pháp:**
- **Kiểm soát tính toàn vẹn của dữ liệu đầu vào:** Vận dụng kết hợp phương thức "TryParse", cấu trúc lặp "while" và biểu thức điều kiện "> 0" để đảm bảo mức lương cơ bản và số ngày vắng mặt luôn là các giá trị số học hợp lệ.
- **Thực thi logic nghiệp vụ:** Tính toán theo biểu thức "Lương thực lãnh = Lương gốc - (Số ngày vắng * Tiền phạt)". Bổ sung mệnh đề điều kiện "if (luongThucLanh < 0) luongThucLanh = 0;" nhằm đảm bảo số dư tiền lương không vượt quá mức giới hạn dưới.
- **Định dạng hiển thị:** Sử dụng ký pháp nội suy chuỗi (String Interpolation "$") kết hợp bộ định dạng chuỗi số học ":N0" (ví dụ: "{luongThucLanh:N0}"). Thao tác này giúp chương trình tự động chèn dấu phân cách hàng nghìn, đáp ứng các tiêu chuẩn hiển thị cho dữ liệu tiền tệ.