using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Module3_06_NguyenHoangKhanhGiang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Please enter an ID student.");
                textBox1.Focus();
            }
            else
            {
                errorProvider1.SetError(textBox1, "");
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Please enter a name.");
                textBox2.Focus();
            }
            else
            {
                errorProvider1.SetError(textBox2, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string HocKy = ChonHocKy(radioButton1, radioButton2, radioButton3,radioButton4);
            string MonHoc = CacMonHocDangChon(checkedListBox1);
            MessageBox.Show("Sinh viên" + textBox2.Text + "\n Lớp: " + comboBox1.Text + "\n Niên khóa: " + comboBox2.Text + "\n Đã đăng ký " + HocKy + " với các môn học sau: " + "\n" + MonHoc, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private string ChonHocKy(RadioButton radioButton1, RadioButton radioButton2, RadioButton radioButton3, RadioButton radioButton4)
        {
            if (radioButton1.Checked)
            {
                return "Học kỳ 1";
            }
            else if (radioButton2.Checked)
            {
                return "Học kỳ 2";
            }
            else if (radioButton3.Checked)
            {
                return "Học kỳ 3";
            }
            else if (radioButton4.Checked)
            {
                return "Học kỳ 4";
            }
            return "";
        }
        private string CacMonHocDangChon(CheckedListBox checkedListBox1)
        {
            int count = 0;
            string str = "";
            foreach (string item in checkedListBox1.CheckedItems)
            {
                count++;
                str += count.ToString() + ". " + item + "\n";
            }
            return str;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string HuyDangKy = HuyCheckedListBox(checkedListBox1);
            MessageBox.Show("Bạn đã hủy đăng ký môn học: " + HuyDangKy, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
            textBox2.Focus();
        }
        private string HuyCheckedListBox(CheckedListBox listBox)
        {
            while (listBox.CheckedIndices.Count > 0)
            {
                listBox.SetItemChecked(listBox.CheckedIndices[0], false);
            }
            return "All selected items have been unchecked.";
            // Ensure a return value is provided
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if ( r == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
