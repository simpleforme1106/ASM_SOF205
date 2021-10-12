using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace PS15447_Assignment
{
    public partial class FrmQLNV : Form
    {
        public FrmQLNV()
        {
            InitializeComponent();
        }
        BUS_NhanVien busNhanVien = new BUS_QLBanHang.BUS_NhanVien();
        private void btnSkip_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_NhanVien();
        }

        private void FrmQLNV_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_NhanVien();
        }
        private void LoadGridview_NhanVien()
        {
            grdView.DataSource = busNhanVien.getNhanVien();
            grdView.Columns[0].HeaderText = "Email";
            grdView.Columns[1].HeaderText = "Tên Nhân Viên";
            grdView.Columns[2].HeaderText = "Địa Chỉ";
            grdView.Columns[3].HeaderText = "Vai Trò";
            grdView.Columns[4].HeaderText = "Tình Trạng";
            grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ResetValues()
        {
            txtSearch.Text = "Nhập tên nhân viên";
            txtMail.Text = txtName.Text = txtAddress.Text = null;
            txtMail.Enabled = txtName.Enabled = txtAddress.Enabled = false;
            rdoNV.Enabled = rdoQT.Enabled =
            rdoOn.Enabled = rdoOff.Enabled = false;
            btnAdd.Enabled = btnClose.Enabled = true;
            btnSave.Enabled = btnFix.Enabled = btnDelete.Enabled = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tenNhanvien = txtSearch.Text; //Search by name
            DataTable ds = busNhanVien.SearchNhanVien(tenNhanvien);
            if (ds.Rows.Count > 0) //Tìm thấy kết quả
            {
                grdView.DataSource = ds;
                grdView.Columns[0].HeaderText = "Email";
                grdView.Columns[1].HeaderText = "Tên Nhân Viên";
                grdView.Columns[2].HeaderText = "Địa Chỉ";
                grdView.Columns[3].HeaderText = "Vai Trò";
                grdView.Columns[4].HeaderText = "Tình Trạng";
                grdView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtSearch.Text = "Nhập tên nhân viên";
            txtSearch.BackColor = Color.LightGray;
            ResetValues();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMail.Text = txtName.Text = txtAddress.Text = null;
            txtMail.Enabled = txtName.Enabled = txtAddress.Enabled = true;
            rdoNV.Enabled = rdoQT.Enabled =
            rdoOn.Enabled = rdoOff.Enabled = true;
            btnAdd.Enabled = btnClose.Enabled = true;
            btnSave.Enabled = true;
            btnFix.Enabled = btnDelete.Enabled = false;
            rdoNV.Checked = rdoQT.Checked =
            rdoOn.Checked = rdoOff.Checked = false;
            txtMail.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string email = txtMail.Text;
            if (MessageBox.Show("Bạn có muốn xóa dữ liệu", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Do something if YES
                if (busNhanVien.DeleteNhanVien(email))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    ResetValues();
                    LoadGridview_NhanVien(); //refresh datagridview
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
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            else if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }
            else
            {
                int role = 0; //Vai trò nhân viên
                if (rdoQT.Checked)
                    role = 1; //Quản trị
                int tinhtrang = 0; //Ngừng hoạt động
                if (rdoOn.Checked)
                    tinhtrang = 1; //Hoạt động
                //Tạo DTO
                DTO_NhanVien nv = new DTO_NhanVien(txtMail.Text, txtName.Text, txtAddress.Text, role, tinhtrang);
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Do something if YES
                    if (busNhanVien.UpdateNhanVien(nv))
                    {
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGridview_NhanVien(); //Refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int role = 0; //Vai trò nhân viên
            if (rdoQT.Checked)
                role = 1; //Quản trị
            int tinhtrang = 0; //Ngừng hoạt động
            if (rdoOn.Checked)
                tinhtrang = 1; //Hoạt động
            if (txtMail.Text.Trim().Length == 0) //Kiểm tra phải nhập email
            {
                MessageBox.Show("Bạn phải nhập email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMail.Focus();
                return;
            }
            else if (!IsValid(txtMail.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập đúng định dạng email", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMail.Focus();
                return;
            }
            if (txtName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            else if (txtAddress.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtAddress.Focus();
                return;
            }
            if (rdoQT.Checked == false && rdoNV.Checked == false) //Kiểm tra phải check chức vụ
            {
                MessageBox.Show("Bạn phải chọn vai trò nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            if (rdoOn.Checked == false && rdoOff.Checked == false) //Kiểm tra phải check tình trạng
            {
                MessageBox.Show("Bạn phải chọn tình trạng nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return;
            }
            else
            {
                //Tạo DTO
                DTO_NhanVien nv = new DTO_NhanVien(txtMail.Text, txtName.Text, txtAddress.Text, role, tinhtrang);
                if (busNhanVien.insertNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công");
                    ResetValues();
                    LoadGridview_NhanVien();
                    string email = txtMail.Text;
                    SendMail(nv.Email);
                }
                else
                {
                    MessageBox.Show("Thêm không thành công");
                }
            }
        }
        public void SendMail(string email)
        {
            try
            {
                //Now we must create a new Smtp client to send our email
                SmtpClient client = new SmtpClient("smtp.gmail.com", 25); //smtp.gmail.com //For Gmail
                //Authetication
                //This is where the valid email account comes into play. You must have a valid email
                //account(with password) to give our program a place to send the email from.
                NetworkCredential cred = new NetworkCredential("sender@gmail.com", "chonduoi");
                //To send an email we must first create a new mailMessage(an email) to send.
                MailMessage Msg = new MailMessage();
                //Sender email address
                Msg.From = new MailAddress("sender@gmail.com"); //Nothing But Above Crendentials or your crendentials(********@gmail.com)
                //Recipient email address
                Msg.To.Add(email);
                //Assign the subject of our message.
                Msg.Subject = "Chào mừng thành viên mới";
                //Create the content(body) of our message
                Msg.Body = "Chào anh/chị. Mật khẩu truy cập phần mềm là 1234, anh/chị vui lòng đăng nhập vào phần mềm và đổi mật khẩu";
                //Send our account login details to the client.
                client.Credentials = cred;
                //Enabling SSL(Secure Sockets Layer, encryption) is required by most email providers to send mail.
                client.EnableSsl = true;
                client.Send(Msg); //Send our email.
                //Confirmation After Click the Button
                MessageBox.Show("Your Mail is sent!");
            }
            catch (Exception ex)
            {
                //If Mail Doesn't Send Error Mesage Will Be Displayed
                MessageBox.Show(ex.Message);
            }
        }
        public bool IsValid(string emailaddress) //check rule email
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_NhanVien();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdView_Click(object sender, EventArgs e)
        {
            if (grdView.Rows.Count > 1)
            {
                btnSave.Enabled = false;
                txtName.Enabled = txtAddress.Enabled = true;
                rdoQT.Enabled = rdoNV.Enabled =
                rdoOn.Enabled = rdoOff.Enabled = true;
                btnFix.Enabled = btnDelete.Enabled = true;
                //Show data from selected row to controls
                txtMail.Text = grdView.CurrentRow.Cells["email"].Value.ToString();
                txtName.Text = grdView.CurrentRow.Cells["tenNv"].Value.ToString();
                txtAddress.Text = grdView.CurrentRow.Cells["diaChi"].Value.ToString();
                if (int.Parse(grdView.CurrentRow.Cells["vaiTro"].Value.ToString()) == 1)
                    rdoQT.Checked = true;
                else
                    rdoNV.Checked = true;
                if (int.Parse(grdView.CurrentRow.Cells["tinhTrang"].Value.ToString()) == 1)
                    rdoOn.Checked = true;
                else
                    rdoOff.Checked = true;
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = null;
            txtSearch.BackColor = Color.White;
        }
    }
}
