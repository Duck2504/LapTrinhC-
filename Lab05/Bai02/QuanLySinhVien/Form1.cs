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
            this.Font = new Font("Segoe UI", 9F);

            tvDanhSachLop = new TreeView() { Location = new Point(20, 30), Size = new Size(200, 400) };
            tvDanhSachLop.AfterSelect += TvDanhSachLop_AfterSelect;
            this.Controls.Add(tvDanhSachLop);

            Label lblChonLop = new Label() { Text = "Chọn Lớp", Location = new Point(250, 30), AutoSize = true };
            cboChonLop = new ComboBox() { Location = new Point(330, 27), Size = new Size(200, 25), DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(lblChonLop);
            this.Controls.Add(cboChonLop);

            gbSinhVien = new GroupBox() { Text = "Thông tin sinh viên", Location = new Point(250, 70), Size = new Size(400, 220) };
            
            gbSinhVien.Controls.Add(new Label() { Text = "Mã SV:", Location = new Point(30, 40), AutoSize = true });
            txtMaSV = new TextBox() { Location = new Point(100, 37), Size = new Size(250, 25) };
            gbSinhVien.Controls.Add(txtMaSV);

            gbSinhVien.Controls.Add(new Label() { Text = "Họ Tên:", Location = new Point(30, 80), AutoSize = true });
            txtHoTen = new TextBox() { Location = new Point(100, 77), Size = new Size(250, 25) };
            gbSinhVien.Controls.Add(txtHoTen);

            gbSinhVien.Controls.Add(new Label() { Text = "Địa Chỉ:", Location = new Point(30, 120), AutoSize = true });
            txtDiaChi = new TextBox() { Location = new Point(100, 117), Size = new Size(250, 25) };
            gbSinhVien.Controls.Add(txtDiaChi);

            btnCapNhat = new Button() { Text = "Cập Nhật", Location = new Point(100, 160), Size = new Size(100, 30) };
            btnCapNhat.Click += BtnCapNhat_Click;
            gbSinhVien.Controls.Add(btnCapNhat);

            btnXoa = new Button() { Text = "Xóa", Location = new Point(220, 160), Size = new Size(100, 30) };
            btnXoa.Click += BtnXoa_Click;
            gbSinhVien.Controls.Add(btnXoa);

            this.Controls.Add(gbSinhVien);

            chkThemLop = new CheckBox() { Text = "Thêm lớp", Location = new Point(250, 300), AutoSize = true };
            chkThemLop.CheckedChanged += ChkThemLop_CheckedChanged;
            this.Controls.Add(chkThemLop);

            gbThemLop = new GroupBox() { Text = "Thông tin lớp", Location = new Point(250, 330), Size = new Size(400, 80), Visible = false }; // Ẩn mặc định theo yêu cầu
            gbThemLop.Controls.Add(new Label() { Text = "Tên lớp:", Location = new Point(30, 35), AutoSize = true });
            txtTenLop = new TextBox() { Location = new Point(100, 32), Size = new Size(150, 25) };
            gbThemLop.Controls.Add(txtTenLop);

            btnThemLop = new Button() { Text = "Thêm lớp", Location = new Point(270, 30), Size = new Size(100, 30) };
            btnThemLop.Click += BtnThemLop_Click;
            gbThemLop.Controls.Add(btnThemLop);

            this.Controls.Add(gbThemLop);
        }

        private void InitializeData()
        {
            TreeNode root = new TreeNode("Danh sách lớp");
            string[] defaultClasses = { "05DHTH1", "05DHTH2", "05DHTH3", "05DHTH4" };
            foreach (var cls in defaultClasses)
            {
                root.Nodes.Add(new TreeNode(cls) { Tag = "ClassNode" });
                cboChonLop.Items.Add(cls);
            }
            tvDanhSachLop.Nodes.Add(root);
            tvDanhSachLop.ExpandAll();
            if (cboChonLop.Items.Count > 0) cboChonLop.SelectedIndex = 0;
        }

        private void ChkThemLop_CheckedChanged(object sender, EventArgs e)
        {
            gbThemLop.Visible = chkThemLop.Checked;
        }

        private void BtnThemLop_Click(object sender, EventArgs e)
        {
            string newClass = txtTenLop.Text.Trim();
            if (string.IsNullOrEmpty(newClass)) return;

            if (cboChonLop.Items.Contains(newClass))
            {
                MessageBox.Show("Lớp này đã tồn tại!", "Cảnh báo");
                return;
            }

            tvDanhSachLop.Nodes[0].Nodes.Add(new TreeNode(newClass) { Tag = "ClassNode" });
            cboChonLop.Items.Add(newClass);
            txtTenLop.Clear();
            tvDanhSachLop.ExpandAll();
        }


        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string selectedClass = cboChonLop.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(maSV) || string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(selectedClass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin sinh viên!", "Lỗi");
                return;
            }

            if (IsMaSVDuplicated(tvDanhSachLop.Nodes[0], maSV))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi");
                return;
            }
            TreeNode classNode = null;
            foreach (TreeNode node in tvDanhSachLop.Nodes[0].Nodes)
            {
                if (node.Text == selectedClass)
                {
                    classNode = node;
                    break;
                }
            }

            if (classNode != null)
            {
                TreeNode studentNode = new TreeNode($"{maSV}, {hoTen}");
                
                studentNode.Tag = new string[] { maSV, hoTen, diaChi }; 
                
                studentNode.Nodes.Add(new TreeNode(diaChi) { Tag = "AddressNode" });
                
                classNode.Nodes.Add(studentNode);
                classNode.ExpandAll();
                
                txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
            }
        }
        private bool IsMaSVDuplicated(TreeNode rootNode, string maSV)
        {
            foreach (TreeNode classNode in rootNode.Nodes)
            {
                foreach (TreeNode studentNode in classNode.Nodes)
                {
                    string[] data = studentNode.Tag as string[];
                    if (data != null && data[0] == maSV) return true;
                }
            }
            return false;
        }
        private void TvDanhSachLop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selected = e.Node;
            if (selected != null && selected.Tag is string[] studentData)
            {
                txtMaSV.Text = studentData[0];
                txtHoTen.Text = studentData[1];
                txtDiaChi.Text = studentData[2];
                cboChonLop.SelectedItem = selected.Parent.Text;
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            TreeNode selected = tvDanhSachLop.SelectedNode;
            if (selected != null && selected.Tag is string[])
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    selected.Remove();
                    txtMaSV.Clear(); txtHoTen.Clear(); txtDiaChi.Clear();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sinh viên để xóa!", "Thông báo");
            }
        }
    }
}