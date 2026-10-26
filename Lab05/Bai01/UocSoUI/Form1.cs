using System;
using System.Windows.Forms;
using UocSoLibrary;

namespace UocSoUI
{
    public partial class Form1 : Form
    {
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

            Label lblNhapSo = new Label() { Text = "Nhập Số", Location = new System.Drawing.Point(50, 30), AutoSize = true };
            Label lblDanhSach = new Label() { Text = "Danh sách các ước số", Location = new System.Drawing.Point(250, 30), AutoSize = true };

            txtNhapSo = new TextBox() { Location = new System.Drawing.Point(50, 60), Width = 100 };
            cboSo = new ComboBox() { Location = new System.Drawing.Point(50, 100), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            lstUocSo = new ListBox() { Location = new System.Drawing.Point(250, 60), Width = 250, Height = 130 };
            btnCapNhat = new Button() { Text = "Cập nhật", Location = new System.Drawing.Point(160, 58), AutoSize = true, Padding = new System.Windows.Forms.Padding(3) };

            btnTong = new Button() { Text = "Tổng các ước số", Location = new System.Drawing.Point(250, 200), AutoSize = true, Padding = new System.Windows.Forms.Padding(3) };
            btnSoChan = new Button() { Text = "Số lượng các ước số chẵn", Location = new System.Drawing.Point(250, 245), AutoSize = true, Padding = new System.Windows.Forms.Padding(3) };
            btnSoNguyenTo = new Button() { Text = "Số lượng các ước số nguyên tố", Location = new System.Drawing.Point(250, 290), AutoSize = true, Padding = new System.Windows.Forms.Padding(3) };

            btnThoat = new Button() { Text = "Thoát", Location = new System.Drawing.Point(150, 290), AutoSize = true, Padding = new System.Windows.Forms.Padding(3) };

            btnCapNhat.Click += btnCapNhat_Click;
            cboSo.SelectedIndexChanged += cboSo_SelectedIndexChanged;
            btnTong.Click += btnTong_Click;
            btnSoChan.Click += btnSoChan_Click;
            btnSoNguyenTo.Click += btnSoNguyenTo_Click;
            btnThoat.Click += btnThoat_Click;

            this.Controls.Add(lblNhapSo);
            this.Controls.Add(lblDanhSach);
            this.Controls.Add(txtNhapSo);
            this.Controls.Add(cboSo);
            this.Controls.Add(lstUocSo);
            this.Controls.Add(btnCapNhat);
            this.Controls.Add(btnTong);
            this.Controls.Add(btnSoChan);
            this.Controls.Add(btnSoNguyenTo);
            this.Controls.Add(btnThoat);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtNhapSo.Text, out int number) && number > 0)
            {
                if (!cboSo.Items.Contains(number))
                {
                    cboSo.Items.Add(number);
                    cboSo.SelectedItem = number;
                }
                else
                {
                    MessageBox.Show("Số này đã tồn tại trong danh sách!");
                }
                txtNhapSo.Clear();
                txtNhapSo.Focus();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số nguyên dương hợp lệ.");
                txtNhapSo.Focus();
            }
        }

        private void cboSo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstUocSo.Items.Clear();
            if (cboSo.SelectedItem != null)
            {
                int selectedNumber = (int)cboSo.SelectedItem;
                // Gọi hàm từ thư viện MathOperation
                var divisors = MathOperations.GetDivisors(selectedNumber);
                foreach (int div in divisors)
                {
                    lstUocSo.Items.Add(div);
                }
            }
        }

        private void btnTong_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (var item in lstUocSo.Items)
            {
                sum += (int)item;
            }
            MessageBox.Show($"Tổng các ước số là: {sum}", "Kết quả");
        }

        private void btnSoChan_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in lstUocSo.Items)
            {
                if ((int)item % 2 == 0) count++;
            }
            MessageBox.Show($"Số lượng ước số chẵn là: {count}", "Kết quả");
        }

        private void btnSoNguyenTo_Click(object sender, EventArgs e)
        {
            int count = 0;
            foreach (var item in lstUocSo.Items)
            {
                if (MathOperations.IsPrime((int)item)) count++;
            }
            MessageBox.Show($"Số lượng ước số nguyên tố là: {count}", "Kết quả");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}