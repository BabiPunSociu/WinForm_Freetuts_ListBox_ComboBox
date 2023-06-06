using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoBan_ListBox_ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtHoTen_Enter(object sender, EventArgs e)
        {
            txtHoTen.BackColor = Color.LightPink;
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.BackColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Bạn cần nhập họ tên");
                txtHoTen.Focus();
                return;
            }

            // Kiểm tra Item đã tồn tại
            foreach (string item in lstKetQua.Items)
            {
                if (item.Trim() == txtHoTen.Text.Trim())
                {
                    MessageBox.Show(txtHoTen.Text.Trim() + " đã tồn tại");
                    txtHoTen.Text = "";
                    txtHoTen.Focus();
                    return;
                }
            }

            // Item chưa tồn tại -> Add Item vào listBox
            lstKetQua.Items.Add(txtHoTen.Text.Trim());
            txtHoTen.Text = "";
            txtHoTen.Focus();
            txtSoLuong.Text = lstKetQua.Items.Count.ToString();
        }

        

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.LightPink;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }

        private void txtHoTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)  // ENTER
            {
                e.Handled = true;
                // Kiểm tra rỗng
                if (txtHoTen.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn cần nhập họ tên");
                    txtHoTen.Focus();
                    return;
                }

                // Kiểm tra Item đã tồn tại
                foreach (string item in lstKetQua.Items)
                {
                    if(item.Trim() == txtHoTen.Text.Trim())
                    {
                        MessageBox.Show(txtHoTen.Text.Trim() + " đã tồn tại");
                        txtHoTen.Text = "";
                        txtHoTen.Focus();
                        return;
                    }    
                }    

                // Item chưa tồn tại -> Add Item vào listBox
                lstKetQua.Items.Add(txtHoTen.Text.Trim());
                txtHoTen.Text = "";
                txtHoTen.Focus();
                txtSoLuong.Text = lstKetQua.Items.Count.ToString();
            }    
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lstKetQua.SelectedItems.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn phần tử nào");
                return;
            }
            int index = lstKetQua.SelectedIndex;
            if (MessageBox.Show("Bạn chắc chắn muốn xóa " + lstKetQua.Items[index] + " không?",
                "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                lstKetQua.Items.RemoveAt(index);
            }
            txtSoLuong.Text = lstKetQua.Items.Count.ToString();
        }

        private void btnXoaDau_Click(object sender, EventArgs e)
        {
            if(lstKetQua.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu");
                return;
            }    
            else
            {
                if (MessageBox.Show("Bạn chắc chắn muốn xóa " + lstKetQua.Items[0] + " không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    lstKetQua.Items.RemoveAt(0);
                }
            }
            txtSoLuong.Text = lstKetQua.Items.Count.ToString();
        }

        private void btnXoaCuoi_Click(object sender, EventArgs e)
        {
            if (lstKetQua.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu");
                return;
            }
            else
            {
                int index = lstKetQua.Items.Count - 1;
                if (MessageBox.Show("Bạn chắc chắn muốn xóa " + lstKetQua.Items[index] + " không?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    lstKetQua.Items.RemoveAt(index);
                }
            }
            txtSoLuong.Text = lstKetQua.Items.Count.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstKetQua.Items.Clear();
            txtSoLuong.Text = lstKetQua.Items.Count.ToString();
        }
    }
}
