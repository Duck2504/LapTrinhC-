using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TuDien
{
    public partial class Form1 : Form
    {
        private TabControl tabControl;
        private TabPage tabAnhViet, tabVietAnh;
        private ComboBox cboAnh, cboViet;
        private TextBox txtNghiaViet, txtNghiaAnh;
        private Button btnThoat;

        private Dictionary<string, string> dictAnhViet;
        private Dictionary<string, string> dictVietAnh;

        public Form1()
        {
            InitializeData();
            SetupUI();
        }

        private void InitializeData()
        {
            dictAnhViet = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"student", "Sinh viên, học sinh"},
                {"teacher", "Giáo viên"},
                {"worker", "Công nhân"},
                {"hat", "Cái mũ"},
                {"head", "Cái đầu"},
                {"mouse", "Con chuột"},
                {"cat", "Con mèo"},
                {"dog", "Con chó"},
                {"snake", "Con rắn"},
                {"lumb", "Khối, cục"},
                {"loan", "Khoản vay"},
                {"frog", "Con ếch"},
                {"sheep", "Con cừu"}
            };

            dictVietAnh = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (var kvp in dictAnhViet)
            {
                if (!dictVietAnh.ContainsKey(kvp.Value))
                    dictVietAnh.Add(kvp.Value, kvp.Key);
            }
        }

        private void SetupUI()
        {
            this.Text = "TỪ ĐIỂN ANH VIỆT - VIỆT ANH";
            this.Size = new Size(500, 450);
            this.Font = new Font("Segoe UI", 9F);

            tabControl = new TabControl() { Location = new Point(20, 20), Size = new Size(440, 330) };
            tabAnhViet = new TabPage("ANH - VIỆT"); //[cite: 8]
            tabAnhViet.Controls.Add(new Label() { Text = "Tiếng Anh", Location = new Point(20, 15), AutoSize = true }); //[cite: 8]
            tabAnhViet.Controls.Add(new Label() { Text = "Tiếng Việt", Location = new Point(220, 15), AutoSize = true }); //[cite: 8]
            cboAnh = new ComboBox() { Location = new Point(20, 40), Size = new Size(180, 250), DropDownStyle = ComboBoxStyle.Simple };
            cboAnh.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAnh.AutoCompleteSource = AutoCompleteSource.ListItems;
            
            cboAnh.Items.AddRange(new List<string>(dictAnhViet.Keys).ToArray());
            cboAnh.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) TraTuAnhViet(); };
            cboAnh.DoubleClick += (s, e) => TraTuAnhViet();

            txtNghiaViet = new TextBox() { Location = new Point(220, 40), Size = new Size(190, 250), Multiline = true, ReadOnly = true };
            
            tabAnhViet.Controls.Add(cboAnh);
            tabAnhViet.Controls.Add(txtNghiaViet);
            tabVietAnh = new TabPage("VIỆT - ANH"); //[cite: 8]
            tabVietAnh.Controls.Add(new Label() { Text = "Tiếng Việt", Location = new Point(20, 15), AutoSize = true });
            tabVietAnh.Controls.Add(new Label() { Text = "Tiếng Anh", Location = new Point(220, 15), AutoSize = true });

            cboViet = new ComboBox() { Location = new Point(20, 40), Size = new Size(180, 250), DropDownStyle = ComboBoxStyle.Simple };
            cboViet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboViet.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboViet.Items.AddRange(new List<string>(dictVietAnh.Keys).ToArray());
            
            cboViet.KeyDown += (s, e) => { if (e.KeyCode == Keys.Enter) TraTuVietAnh(); };
            cboViet.DoubleClick += (s, e) => TraTuVietAnh();

            txtNghiaAnh = new TextBox() { Location = new Point(220, 40), Size = new Size(190, 250), Multiline = true, ReadOnly = true };

            tabVietAnh.Controls.Add(cboViet);
            tabVietAnh.Controls.Add(txtNghiaAnh);

            tabControl.TabPages.Add(tabAnhViet);
            tabControl.TabPages.Add(tabVietAnh);
            this.Controls.Add(tabControl);
            btnThoat = new Button() { Text = "Thoát", Location = new Point(380, 360), Size = new Size(80, 30) }; //[cite: 8]
            btnThoat.Click += (s, e) => Application.Exit();
            this.Controls.Add(btnThoat);
        }

        private void TraTuAnhViet()
        {
            string tu = cboAnh.Text.Trim();
            if (dictAnhViet.ContainsKey(tu))
            {
                txtNghiaViet.Text = dictAnhViet[tu];
            }
            else
            {
                txtNghiaViet.Text = "Không tìm thấy từ này.";
            }
        }

        private void TraTuVietAnh()
        {
            string tu = cboViet.Text.Trim();
            if (dictVietAnh.ContainsKey(tu))
            {
                txtNghiaAnh.Text = dictVietAnh[tu];
            }
            else
            {
                txtNghiaAnh.Text = "Không tìm thấy từ này.";
            }
        }
    }
}