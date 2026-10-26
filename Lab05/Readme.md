# BÁO CÁO THỰC HÀNH LAB 05: LẬP TRÌNH WINDOWS FORMS
**Họ và tên sinh viên:** Dư Gia Đức
**Mã số sinh viên:** 3124411072
**Lớp:** DCT124C5

## BÀI 1: ỨNG DỤNG TÍNH ƯỚC SỐ (KIẾN TRÚC 3 LỚP)

### 1. Nội dung yêu cầu
Xây dựng ứng dụng cho phép người dùng nhập một số nguyên dương. Giao diện sẽ tự động cập nhật số này vào ComboBox. Khi chọn một số trong ComboBox, chương trình liệt kê các ước số lên ListBox và cung cấp các chức năng thống kê: tính tổng, đếm số lượng ước số chẵn, đếm số lượng ước số nguyên tố.

### 2. Code bài làm có ghi chú

**File `MathOperations.cs` (Project Class Library - Xử lý logic tính toán)**
```csharp
using System;
using System.Windows.Forms;
using UocSoLibrary;

namespace UocSoUI
{
    public partial class Form1 : Form
    {
        // Khai báo các Control ở cấp độ class để truy xuất toàn cục
        private TextBox txtNhapSo;
        private ComboBox cboSo;
        private ListBox lstUocSo;
        private Button btnCapNhat, btnTong, btnSoChan, btnSoNguyenTo, btnThoat;

        public Form1()
        {
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Combobox - Ước Số";
            this.Size = new System.Drawing.Size(550, 450);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);

            // Khởi tạo và căn chỉnh tọa độ cho TextBox, ComboBox, ListBox
            txtNhapSo = new TextBox() { Location = new System.Drawing.Point(50, 60), Width = 100 };
            cboSo = new ComboBox() { Location = new System.Drawing.Point(50, 100), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            lstUocSo = new ListBox() { Location = new System.Drawing.Point(250, 60), Width = 250, Height = 130 };

            // Sử dụng AutoSize và Padding để chữ trên nút bấm không bị cắt xén
            btnCapNhat = new Button() { Text = "Cập nhật", Location = new System.Drawing.Point(160, 58), AutoSize = true, Padding = new Padding(3) };
            btnTong = new Button() { Text = "Tổng các ước số", Location = new System.Drawing.Point(250, 200), AutoSize = true, Padding = new Padding(3) };
            btnSoChan = new Button() { Text = "Số lượng các ước số chẵn", Location = new System.Drawing.Point(250, 245), AutoSize = true, Padding = new Padding(3) };
            btnSoNguyenTo = new Button() { Text = "Số lượng các ước số nguyên tố", Location = new System.Drawing.Point(250, 290), AutoSize = true, Padding = new Padding(3) };
            btnThoat = new Button() { Text = "Thoát", Location = new System.Drawing.Point(150, 290), AutoSize = true, Padding = new Padding(3) };

            // Đăng ký sự kiện
            btnCapNhat.Click += BtnCapNhat_Click;
            cboSo.SelectedIndexChanged += CboSo_SelectedIndexChanged;
            btnTong.Click += BtnTong_Click;
            btnSoChan.Click += BtnSoChan_Click;
            btnSoNguyenTo.Click += BtnSoNguyenTo_Click;
            btnThoat.Click += (s, e) => Application.Exit();

            // Gắn các Control vào Form
            this.Controls.AddRange(new Control[] { txtNhapSo, cboSo, lstUocSo, btnCapNhat, btnTong, btnSoChan, btnSoNguyenTo, btnThoat });
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            // Ép kiểu và xác thực dữ liệu đầu vào
            if (int.TryParse(txtNhapSo.Text, out int number) && number > 0)
            {
                if (!cboSo.Items.Contains(number))
                {
                    cboSo.Items.Add(number);
                    cboSo.SelectedItem = number; 
                }
                else MessageBox.Show("Số này đã tồn tại!");
                txtNhapSo.Clear();
            }
        }

        private void CboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear();
            if (cboSo.SelectedItem != null)
            {
                // Gọi hàm từ thư viện Class Library ngoài
                var divisors = MathOperations.GetDivisors((int)cboSo.SelectedItem);
                foreach (int div in divisors) lstUocSo.Items.Add(div);
            }
        }

        private void BtnTong_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (var item in lstUocSo.Items) sum += (int)item;
            MessageBox.Show($"Tổng các ước số: {sum}");
        }

        private void BtnSoChan_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in lstUocSo.Items)
                if ((int)item % 2 == 0) count++;
            MessageBox.Show($"Số lượng ước số chẵn: {count}");
        }

        private void BtnSoNguyenTo_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in lstUocSo.Items)
                if (MathOperations.IsPrime((int)item)) count++;
            MessageBox.Show($"Số lượng ước số nguyên tố: {count}");
        }
    }
}
```
### 3. Kết quả
### Kết quả: 
Ứng dụng biên dịch thành công. Các nút bấm hiển thị đầy đủ văn bản (không bị khuất chữ), dữ liệu tính toán chính xác

### BÀI 2: QUẢN LÝ SINH VIÊN (TREEVIEW)
### 1. Nội dung yêu cầu
Xây dựng giao diện sử dụng TreeView để hiển thị danh sách lớp và sinh viên theo dạng phân cấp. Bao gồm tính năng thêm lớp học mới, thêm sinh viên vào lớp cụ thể, đảm bảo mã sinh viên không trùng lặp và liên kết thông tin ngược từ TreeView sang TextBox khi click.

### 2. Code bài làm có ghi chú
```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLySinhVien
{
    public partial class Form1 : Form
    {
        private TreeView tvDanhSachLop;
        private ComboBox cboChonLop;
        private TextBox txtMaSV, txtHoTen, txtDiaChi, txtTenLop;
        private CheckBox chkThemLop;
        private GroupBox gbSinhVien, gbThemLop;
        private Button btnCapNhat, btnXoa, btnThemLop;

        public Form1()
        {
            SetupUI();
            InitializeData();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý sinh viên";
            this.Size = new Size(700, 500);

            // Thiết lập TreeView và ComboBox
            tvDanhSachLop = new TreeView() { Location = new Point(20, 30), Size = new Size(200, 400) };
            tvDanhSachLop.AfterSelect += TvDanhSachLop_AfterSelect;
            
            cboChonLop = new ComboBox() { Location = new Point(330, 27), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };

            // Phân vùng thông tin sinh viên
            gbSinhVien = new GroupBox() { Text = "Thông tin sinh viên", Location = new Point(250, 70), Size = new Size(400, 220) };
            txtMaSV = new TextBox() { Location = new Point(100, 37), Size = new Size(250, 25) };
            txtHoTen = new TextBox() { Location = new Point(100, 77), Size = new Size(250, 25) };
            txtDiaChi = new TextBox() { Location = new Point(100, 117), Size = new Size(250, 25) };
            
            btnCapNhat = new Button() { Text = "Cập Nhật", Location = new Point(100, 160) };
            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa = new Button() { Text = "Xóa", Location = new Point(220, 160) };
            btnXoa.Click += BtnXoa_Click;
            
            gbSinhVien.Controls.AddRange(new Control[] { txtMaSV, txtHoTen, txtDiaChi, btnCapNhat, btnXoa });

            // Phân vùng thêm lớp (ẩn mặc định)
            chkThemLop = new CheckBox() { Text = "Thêm lớp", Location = new Point(250, 300) };
            chkThemLop.CheckedChanged += (s, e) => gbThemLop.Visible = chkThemLop.Checked;

            gbThemLop = new GroupBox() { Text = "Thông tin lớp", Location = new Point(250, 330), Size = new Size(400, 80), Visible = false };
            txtTenLop = new TextBox() { Location = new Point(100, 32), Size = new Size(150, 25) };
            btnThemLop = new Button() { Text = "Thêm lớp", Location = new Point(270, 30) };
            btnThemLop.Click += BtnThemLop_Click;
            gbThemLop.Controls.AddRange(new Control[] { txtTenLop, btnThemLop });

            this.Controls.AddRange(new Control[] { tvDanhSachLop, cboChonLop, gbSinhVien, chkThemLop, gbThemLop });
        }

        private void InitializeData()
        {
            // Tải dữ liệu mặc định lúc khởi động form
            TreeNode root = new TreeNode("Danh sách lớp");
            string[] defaultClasses = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (var cls in defaultClasses)
            {
                root.Nodes.Add(new TreeNode(cls));
                cboChonLop.Items.Add(cls);
            }
            tvDanhSachLop.Nodes.Add(root);
            tvDanhSachLop.ExpandAll();
        }

        private void BtnThemLop_Click(object sender, EventArgs e)
        {
            string newClass = txtTenLop.Text.Trim();
            if (string.IsNullOrEmpty(newClass)) return;
            if (cboChonLop.Items.Contains(newClass)) { MessageBox.Show("Lớp đã tồn tại!"); return; }

            // Gắn node lớp mới vào nhánh root
            tvDanhSachLop.Nodes[0].Nodes.Add(new TreeNode(newClass));
            cboChonLop.Items.Add(newClass);
            txtTenLop.Clear();
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string selectedClass = cboChonLop.SelectedItem?.ToString();

            // Tìm Node lớp tương ứng để nạp sinh viên vào
            TreeNode classNode = null;
            foreach (TreeNode node in tvDanhSachLop.Nodes[0].Nodes)
                if (node.Text == selectedClass) classNode = node;

            if (classNode != null)
            {
                TreeNode studentNode = new TreeNode($"{maSV}, {hoTen}");
                // Kỹ thuật lưu ẩn mảng dữ liệu vào Tag
                studentNode.Tag = new string[] { maSV, hoTen, diaChi }; 
                studentNode.Nodes.Add(new TreeNode(diaChi));
                classNode.Nodes.Add(studentNode);
                classNode.ExpandAll();
            }
        }

        private void TvDanhSachLop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Đổ ngược dữ liệu từ Tag lên TextBox khi người dùng click
            if (e.Node != null && e.Node.Tag is string[] studentData)
            {
                txtMaSV.Text = studentData[0];
                txtHoTen.Text = studentData[1];
                txtDiaChi.Text = studentData[2];
                cboChonLop.SelectedItem = e.Node.Parent.Text;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            TreeNode selected = tvDanhSachLop.SelectedNode;
            if (selected != null && selected.Tag is string[])
            {
                if (MessageBox.Show("Xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    selected.Remove();
            }
        }
    }
}
```
### 3. Kết quả
Kết quả: Dữ liệu được hiển thị theo cấp bậc chuẩn xác. Giao diện thay đổi tự động dựa vào sự kiện CheckedChanged của Checkbox để hiện/ẩn Form thêm lớp.
### BÀI 3: TỪ ĐIỂN ANH - VIỆT
### 1. Nội dung yêu cầu
Thiết kế phần mềm từ điển song ngữ bằng cách sử dụng ComboBox làm thanh tìm kiếm từ khóa với tính năng SuggestAppend (dò ký tự) và TabControl để quản lý hai không gian dịch (Anh-Việt, Việt-Anh).

### 2. Code bài làm có ghi chú
``` csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TuDien
{
    public partial class Form1 : Form
    {
        private TabControl tabControl;
        private ComboBox cboAnh, cboViet;
        private TextBox txtNghiaViet, txtNghiaAnh;
        private Dictionary<string, string> dictAnhViet, dictVietAnh;

        public Form1()
        {
            InitializeData();
            SetupUI();
        }

        private void InitializeData()
        {
            // Xây dựng bộ nhớ từ điển với độ phức tạp tìm kiếm O(1)
            dictAnhViet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"student", "Sinh viên, học sinh"},
                {"teacher", "Giáo viên"},
                {"worker", "Công nhân"},
                {"mouse", "Con chuột"}
            };

            // Tự động đảo dữ liệu tạo từ điển Việt - Anh
            dictVietAnh = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in dictAnhViet)
                if (!dictVietAnh.ContainsKey(kvp.Value))
                    dictVietAnh.Add(kvp.Value, kvp.Key);
        }

        private void SetupUI()
        {
            this.Text = "TỪ ĐIỂN";
            this.Size = new Size(500, 450);

            tabControl = new TabControl() { Location = new Point(20, 20), Size = new Size(440, 330) };

            // Cấu hình Tab Anh-Việt
            TabPage tabAnhViet = new TabPage("ANH - VIỆT");
            // Kích hoạt DropDownStyle = Simple để hiển thị dạng danh sách phẳng
            cboAnh = new ComboBox() { Location = new Point(20, 40), Size = new Size(180, 250), DropDownStyle = ComboBoxStyle.Simple };
            // Kích hoạt tính năng gợi ý thông minh
            cboAnh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAnh.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboAnh.Items.AddRange(new List<string>(dictAnhViet.Keys).ToArray());
            
            cboAnh.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) TraTuAnhViet(); };
            
            txtNghiaViet = new TextBox() { Location = new Point(220, 40), Size = new Size(190, 250), Multiline = true };
            tabAnhViet.Controls.AddRange(new Control[] { cboAnh, txtNghiaViet });

            // Tương tự cho Tab Việt-Anh
            TabPage tabVietAnh = new TabPage("VIỆT - ANH");
            cboViet = new ComboBox() { Location = new Point(20, 40), Size = new Size(180, 250), DropDownStyle = ComboBoxStyle.Simple };
            cboViet.Items.AddRange(new List<string>(dictVietAnh.Keys).ToArray());
            cboViet.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) TraTuVietAnh(); };
            
            txtNghiaAnh = new TextBox() { Location = new Point(220, 40), Size = new Size(190, 250), Multiline = true };
            tabVietAnh.Controls.AddRange(new Control[] { cboViet, txtNghiaAnh });

            tabControl.TabPages.Add(tabAnhViet);
            tabControl.TabPages.Add(tabVietAnh);
            this.Controls.Add(tabControl);
        }

        private void TraTuAnhViet()
        {
            string tu = cboAnh.Text.Trim();
            txtNghiaViet.Text = dictAnhViet.ContainsKey(tu) ? dictAnhViet[tu] : "Không tìm thấy.";
        }

        private void TraTuVietAnh()
        {
            string tu = cboViet.Text.Trim();
            txtNghiaAnh.Text = dictVietAnh.ContainsKey(tu) ? dictVietAnh[tu] : "Không tìm thấy.";
        }
    }
}
```
### 3. Kết quả
Kết quả: ComboBox ở trạng thái luôn xổ xuống danh sách nhờ thuộc tính Simple. Khi người dùng gõ phím, từ khóa tự động được gợi ý nối đuôi chính xác theo danh sách.

### BÀI 4: DANH BẠ
### 1. Nội dung yêu cầu
Phát triển sổ danh bạ. Khi khởi động, hệ thống tự động sinh 26 Node gốc tương ứng với các chữ cái từ A đến Z. Khi thêm một người liên hệ mới, ứng dụng bóc tách chữ cái đầu tiên của First Name và đẩy node con vào đúng nhánh bảng chữ cái đó.

### 2. Code bài làm có ghi chú
``` csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanhBa
{
    public partial class Form1 : Form
    {
        private TreeView tvDanhBa;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd;

        public Form1()
        {
            SetupUI();
            InitializeData();
        }

        private void SetupUI()
        {
            this.Text = "frmBTVN2";
            this.Size = new Size(550, 450);

            tvDanhBa = new TreeView() { Location = new Point(20, 20), Size = new Size(200, 370) };
            txtFirstName = new TextBox() { Location = new Point(320, 27), Size = new Size(150, 25) };
            txtLastName = new TextBox() { Location = new Point(320, 67), Size = new Size(150, 25) };

            btnAdd = new Button() { Text = "Add", Location = new Point(390, 110) };
            btnAdd.Click += BtnAdd_Click;

            this.Controls.AddRange(new Control[] { tvDanhBa, txtFirstName, txtLastName, btnAdd });
        }

        private void InitializeData()
        {
            // Tự động sinh danh sách bảng chữ cái A -> Z
            for (char c = 'A'; c <= 'Z'; c++)
            {
                // Gắn Name bằng chính ký tự để phục vụ truy xuất
                tvDanhBa.Nodes.Add(new TreeNode(c.ToString()) { Name = c.ToString() });
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (string.IsNullOrEmpty(firstName)) return;

            // Xử lý chuỗi: Cắt ký tự đầu tiên và In hoa
            string firstLetter = firstName.Substring(0, 1).ToUpper();
            
            // Tìm kiếm đích danh node cha thông qua thuộc tính Name
            TreeNode[] foundNodes = tvDanhBa.Nodes.Find(firstLetter, false);
            
            if (foundNodes.Length > 0)
            {
                TreeNode parentNode = foundNodes[0];
                string fullName = string.IsNullOrEmpty(lastName) ? firstName : $"{firstName}, {lastName}";
                
                parentNode.Nodes.Add(new TreeNode(fullName));
                // Tự động mở rộng (xổ xuống) nhánh vừa được thêm dữ liệu
                parentNode.Expand(); 
            }
            else
            {
                MessageBox.Show("First Name phải bắt đầu bằng chữ cái A-Z.");
            }

            txtFirstName.Clear(); txtLastName.Clear();
        }
    }
}
```
### 3. Kết quả
Kết quả: Ứng dụng tự động điều hướng dữ liệu người dùng nạp vào đúng vị trí cây thư mục, tối ưu hóa giao diện.

