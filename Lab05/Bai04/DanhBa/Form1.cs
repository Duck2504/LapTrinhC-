using System;
using System.Drawing;
using System.Windows.Forms;

namespace DanhBa
{
    public partial class Form1 : Form
    {
        private TreeView tvDanhBa;
        private TextBox txtFirstName, txtLastName;
        private Button btnAdd, btnExit;

        public Form1()
        {
            SetupUI();
            InitializeData();
        }

        private void SetupUI()
        {
            this.Text = "frmBTVN2";
            this.Size = new Size(550, 450);
            this.Font = new Font("Segoe UI", 9F);

            tvDanhBa = new TreeView() { Location = new Point(20, 20), Size = new Size(200, 370) };
            this.Controls.Add(tvDanhBa);

            Label lblFirstName = new Label() { Text = "First Name", Location = new Point(240, 30), AutoSize = true };
            txtFirstName = new TextBox() { Location = new Point(320, 27), Size = new Size(150, 25) };
            
            Label lblLastName = new Label() { Text = "Last Name", Location = new Point(240, 70), AutoSize = true };
            txtLastName = new TextBox() { Location = new Point(320, 67), Size = new Size(150, 25) };

            btnAdd = new Button() { Text = "Add", Location = new Point(390, 110), Size = new Size(80, 30) };
            btnAdd.Click += BtnAdd_Click;

            btnExit = new Button() { Text = "Exit", Location = new Point(390, 160), Size = new Size(80, 30) };
            btnExit.Click += (s, e) => Application.Exit();

            this.Controls.Add(lblFirstName);
            this.Controls.Add(txtFirstName);
            this.Controls.Add(lblLastName);
            this.Controls.Add(txtLastName);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnExit);
        }

        private void InitializeData()
        {
            for (char c = 'A'; c <= 'Z'; c++)
            {
                tvDanhBa.Nodes.Add(new TreeNode(c.ToString()) { Name = c.ToString() });
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Vui lòng nhập First Name!", "Thông báo");
                return;
            }

            string firstLetter = firstName.Substring(0, 1).ToUpper();
            TreeNode[] foundNodes = tvDanhBa.Nodes.Find(firstLetter, false);
            
            if (foundNodes.Length > 0)
            {
                TreeNode parentNode = foundNodes[0];
                string fullName = string.IsNullOrEmpty(lastName) ? firstName : $"{firstName}, {lastName}";
                parentNode.Nodes.Add(new TreeNode(fullName));
                parentNode.Expand(); 
            }
            else
            {
                MessageBox.Show("Ký tự đầu của First Name phải nằm trong khoảng A-Z.", "Lỗi");
            }

            txtFirstName.Clear();
            txtLastName.Clear();
            txtFirstName.Focus();
        }
    }
}