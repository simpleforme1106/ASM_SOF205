using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace PS15447_Assignment
{
    public partial class FrmQLKH : Form
    {
        public FrmQLKH()
        {
            InitializeComponent();
        }
        BUS_Khach busKhach = new BUS_QLBanHang.BUS_Khach();
        string stremail = FrmMain.mail; //Nhận mail từ FrmMain
        private void FrmQLKH_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_Khach();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            float intDienThoai;
            bool isInt = float.TryParse(txtPhone.Text.Trim().ToString(), out intDienThoai);
            string phai = "Nam";
            if (rdoNu.Checked == true)
                phai = "Nữ";
            if (!isInt || float.Parse(txtPhone.Text) < 0) //Kiem tra so dien thoai
            {
                MessageBox.Show("Bạn phải nhập số điện thoai > 0, số nguyên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Focus();
                return;
            }
            else
            {
                DTO_Khach kh = new DTO_Khach(txtPhone.Text, txtName.Text, txtAddress.Text, phai, stremail);
                if (busKhach.insertKhach(kh))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    LoadGridview_Khach(); //refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }
        private void ResetValues()
        {
            txtSearch.Text = "Nhập số điện thoại khách hàng";
            txtPhone.Text = txtName.Text = txtAddress.Text = null;
            txtPhone.Enabled = txtName.Enabled = txtAddress.Enabled = false;
            rdoNam.Enabled = rdoNu.Enabled = false;
            btnAdd.Enabled = btnClose.Enabled = true;
            btnSave.Enabled = btnFix.Enabled = btnDelete.Enabled = false;
        }
        private void LoadGridview_Khach()
        {
            grdView.DataSource = busKhach.getKhach();
            grdView.Columns[0].HeaderText = "Điện Thoại";
            grdView.Columns[1].HeaderText = "Họ và tên";
            grdView.Columns[2].HeaderText = "Địa Chỉ";
            grdView.Columns[3].HeaderText = "Giới tính";
            grdView.Columns[4].Visible = false;
            grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void grdView_Click(object sender, EventArgs e)
        {
            if (grdView.Rows.Count > 1)
            {
                btnSave.Enabled = false;
                txtAddress.Enabled = txtPhone.Enabled = txtName.Enabled = true;
                rdoNam.Enabled = rdoNu.Enabled = true;
                txtPhone.Focus();
                btnFix.Enabled = btnDelete.Enabled = true;
                txtPhone.Text = grdView.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = grdView.CurrentRow.Cells[1].Value.ToString();
                txtAddress.Text = grdView.CurrentRow.Cells[2].Value.ToString();
                string phai = grdView.CurrentRow.Cells[3].Value.ToString();
                if (phai == "Nam")
                    rdoNam.Checked = true;
                else
                    rdoNu.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtPhone.Text = txtName.Text = txtAddress.Text = null;
            txtPhone.Enabled = txtName.Enabled = txtAddress.Enabled = true;
            rdoNam.Enabled = rdoNu.Enabled = true;
            btnAdd.Enabled = btnClose.Enabled = true;
            btnSave.Enabled = true;
            btnFix.Enabled = btnDelete.Enabled = false;
            rdoNam.Checked = rdoNu.Checked = false;
            txtPhone.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string soDT = txtPhone.Text;
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Do something if YES
                if (busKhach.DeleteKhach(soDT))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridview_Khach(); //refresh datagridview
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
            float intDienThoai;
            bool isInt = float.TryParse(txtPhone.Text.Trim().ToString(), out intDienThoai);
            string phai = "Nam";
            if (rdoNu.Checked == true)
                phai = "Nữ";
            if (!isInt || float.Parse(txtPhone.Text) < 0) //Kiem tra so dien thoai
            {
                MessageBox.Show("Bạn phải nhập số điện thoai > 0, số nguyên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPhone.Focus();
                return;
            }
            else
            {
                DTO_Khach kh = new DTO_Khach(txtPhone.Text, txtName.Text, txtAddress.Text, phai);
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busKhach.UpdateKhach(kh))
                    {
                        MessageBox.Show("Cập nhật khách hàng thành công");
                        ResetValues();
                        LoadGridview_Khach(); //refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật khách hàng không thành công");
                    }
                }
                else
                {
                    //do something if NO
                    ResetValues();
                }
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_Khach();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_Khach();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string soDT = txtSearch.Text; //Search by phone
            DataTable ds = busKhach.SearchKhach(soDT);
            if (ds.Rows.Count > 0) //Tìm thấy kết quả
            {
                grdView.DataSource = ds;
                grdView.Columns[0].HeaderText = "Điện Thoại";
                grdView.Columns[1].HeaderText = "Họ và tên";
                grdView.Columns[2].HeaderText = "Địa Chỉ";
                grdView.Columns[3].HeaderText = "Giới tính";
                grdView.Columns[4].Visible = false;
                grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSearch.Text = "Nhập số điện thoại khách hàng";
            txtSearch.BackColor = Color.LightGray;
            ResetValues();
        }
    }
}
