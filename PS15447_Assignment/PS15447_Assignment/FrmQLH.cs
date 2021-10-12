using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace PS15447_Assignment
{
    public partial class FrmQLH : Form
    {
        BUS_Hang busHang = new BUS_QLBanHang.BUS_Hang();
        string stremail = FrmMain.mail; //Nhận email từ FrmMain
        string checkUrlImage; //Kiểm tra hình khi cập nhật
        string fileName; //Tên file
        string fileSavePath; //Url store image
        string fileAddress; //Url load images
        public FrmQLH()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh họa cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                picBox.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 59));
                fileSavePath = saveDirectory + "\\Images\\" + fileName; //Combine with file name*/
                txtImg.Text = "\\Images\\" + fileName;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tenHang = txtSearch.Text;
            DataTable ds = busHang.SearchHang(tenHang);
            if (ds.Rows.Count > 0)
            {
                grdView.DataSource = ds;
                grdView.Columns[0].HeaderText = "Mã Sản Phẩm";
                grdView.Columns[1].HeaderText = "Tên Sản Phẩm";
                grdView.Columns[2].HeaderText = "Số Lượng";
                grdView.Columns[3].HeaderText = "Đơn Giá Nhập";
                grdView.Columns[4].HeaderText = "Đơn Giá Bán";
                grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSearch.Text = "Nhập tên sản phẩm";
            txtSearch.BackColor = Color.LightGray;
            ResetValues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnFix.Enabled = btnDelete.Enabled = btnAdd.Enabled = false;
            btnSkip.Enabled = btnSave.Enabled = btnOpen.Enabled = true;
            txtMa.Enabled = txtImg.Enabled =
            txtName.Enabled = txtQua.Enabled = 
            txtNote.Enabled = txtDGN.Enabled =
            txtDGB.Enabled = true;
            txtMa.Text = txtName.Text = 
            txtQua.Text = txtNote.Text =
            txtDGN.Text = txtDGB.Text = 
            txtImg.Text = null;
            picBox.Image = null;
            txtName.Focus();
        }
        private void LoadGridView_Hang()
        {
            grdView.DataSource = busHang.getHang();
            grdView.Columns[0].HeaderText = "Mã Sản Phẩm";
            grdView.Columns[1].HeaderText = "Tên Sản Phẩm";
            grdView.Columns[2].HeaderText = "Số Lượng";
            grdView.Columns[3].HeaderText = "Đơn Giá Nhập";
            grdView.Columns[4].HeaderText = "Đơn Giá Bán";
            grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ResetValues()
        {
            txtSearch.Text = "Nhập tên sản phẩm";
            btnOpen.Enabled = btnFix.Enabled = btnDelete.Enabled = btnSave.Enabled = false;
            btnSkip.Enabled = btnAdd.Enabled = true;
            txtMa.Enabled = txtImg.Enabled =
            txtName.Enabled = txtQua.Enabled =
            txtNote.Enabled = txtDGN.Enabled =
            txtDGB.Enabled = false;
            txtMa.Text = txtName.Text =
            txtQua.Text = txtNote.Text =
            txtDGN.Text = txtDGB.Text =
            txtImg.Text = null;
            picBox.Image = null;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int maHang = int.Parse(txtMa.Text);
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Do something if YES
                if (busHang.DeleteHang(maHang))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridView_Hang(); //refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                //Do something if NO
                ResetValues();
            }
        }

        private void btnFix_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtQua.Text.Trim().ToString(), out intSoLuong); //Ép kiểu để kiếm tra là số hay chữ
            float donGiaNhap;
            bool isFloatNhap = float.TryParse(txtDGN.Text.Trim().ToString(), out donGiaNhap);
            float donGiaBan;
            bool isFloatBan = float.TryParse(txtDGB.Text.Trim().ToString(), out donGiaBan);
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtQua.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng là số nguyên >= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQua.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDGN.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập là số >= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDGN.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txtDGB.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán là số >= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDGB.Focus();
                return;
            }
            else if (txtImg.Text.Trim().Length == 0) //Kiểm tra phải nhập hình
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            else
            {
                DTO_Hang h = new DTO_Hang(int.Parse(txtMa.Text), txtName.Text, int.Parse(txtQua.Text), float.Parse(txtDGN.Text),
                    float.Parse(txtDGB.Text), txtImg.Text, txtNote.Text);
                if (busHang.UpdateHang(h))
                {
                    if (txtImg.Text != checkUrlImage) //Nếu có thay đổi hình
                        File.Copy(fileAddress, fileSavePath, true); //Copy file hình vào ứng dụng
                    MessageBox.Show("Sửa thành công");
                    ResetValues();
                    LoadGridView_Hang(); //Refresh datagridview
                }
                else
                {
                    MessageBox.Show("Sửa không thành công");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtQua.Text.Trim().ToString(), out intSoLuong); //Ép kiểu để kiếm tra là số hay chữ
            float donGiaNhap;
            bool isFloatNhap = float.TryParse(txtDGN.Text.Trim().ToString(), out donGiaNhap);
            float donGiaBan;
            bool isFloatBan = float.TryParse(txtDGB.Text.Trim().ToString(), out donGiaBan);
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtQua.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập số lượng là số nguyên >= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQua.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDGN.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập là số >= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDGN.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txtDGB.Text) < 0)
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán là số >= 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDGB.Focus();
                return;
            }
            else if (txtImg.Text.Trim().Length == 0) //Kiểm tra phải nhập hình
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOpen.Focus();
                return;
            }
            else
            {
                DTO_Hang h = new DTO_Hang(txtName.Text, int.Parse(txtQua.Text), float.Parse(txtDGN.Text),
                    float.Parse(txtDGB.Text), "\\Images\\" + fileName, txtNote.Text, stremail);
                if (busHang.InsertHang(h))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    File.Copy(fileAddress, fileSavePath, true); //Copy file hinh vao ung dung
                    ResetValues();
                    LoadGridView_Hang(); //Refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công");
                }
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_Hang();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_Hang();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmQLH_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridView_Hang();
        }

        private void grdView_Click(object sender, EventArgs e)
        {
            string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 59));
            if (grdView.Rows.Count > 1)
            {
                btnOpen.Enabled = btnFix.Enabled = btnDelete.Enabled = true;
                btnSave.Enabled = false;
                txtName.Enabled = txtQua.Enabled = txtNote.Enabled =
                txtDGN.Enabled = txtDGB.Enabled = true;
                txtName.Focus();
                txtMa.Text = grdView.CurrentRow.Cells["MaHang"].Value.ToString();
                txtName.Text = grdView.CurrentRow.Cells["TenHang"].Value.ToString();
                txtQua.Text = grdView.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtDGN.Text = grdView.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
                txtDGB.Text = grdView.CurrentRow.Cells["DonGiaBan"].Value.ToString();
                txtImg.Text = grdView.CurrentRow.Cells["HinhAnh"].Value.ToString();
                checkUrlImage = txtImg.Text; //Giữ đường dẫn file hình
                picBox.Image = Image.FromFile(saveDirectory + grdView.CurrentRow.Cells["HinhAnh"].Value.ToString());
                txtNote.Text = grdView.CurrentRow.Cells["GhiChu"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
