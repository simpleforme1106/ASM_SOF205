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

namespace PS15447_Assignment
{
    public partial class FrmDMK : Form
    {
        string stremail; //nhân email từ FrmMain
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public FrmDMK(string email)
        {
            InitializeComponent();
            stremail = email;
            txtMail.Text = stremail;
            txtMail.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtOld.Text.Trim().Length == 0) //Kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOld.Focus();
                return;
            }
            else if (txtNew.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOld.Focus();
                return;
            }
            else if (txtReNew.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập lại mật khẩu mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOld.Focus();
                return;
            }
            else if (txtReNew.Text.Trim() != txtNew.Text.Trim())
            {
                MessageBox.Show("Bạn phải nhập mật khẩu và nhập lại mật khẩu giống nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOld.Focus();
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật mật khẩu", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //do something if YES
                    string matKhauMoi = busNhanVien.encryption(txtNew.Text);
                    string matKhauCu = busNhanVien.encryption(txtOld.Text);
                    if (busNhanVien.UpdateMatKhau(txtMail.Text, matKhauCu, matKhauMoi))
                    {
                        FrmMain.profile = 1; //Cập nhật pass thành công
                        FrmMain.session = 0; //đưa về tình trạng đăng nhập
                        SendMail(stremail, txtReNew.Text);
                        MessageBox.Show("Cập nhật mật khẩu thành công, bạn cần phải đăng nhập lại");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ không đúng, cập nhật mật khẩu không thành công");
                        txtOld.Text = txtNew.Text = txtReNew.Text = null;
                    }
                }
                else
                {
                    //do something if NO
                    txtOld.Text = txtNew.Text = txtReNew.Text = null;
                }
            }
        }
        public void SendMail(string email, string matKhau)
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
                Msg.Subject = "Ban da su dung tinh nang Doi mat khau";
                //Create the content(body) of our message
                Msg.Body = "Chào anh/chị. Mật khẩu mới truy cập phần mềm là: " + matKhau;
                //Send our account login details to the client.
                client.Credentials = cred;
                //Enabling SSL(Secure Sockets Layer, encryption) is required by most email providers to send mail.
                client.EnableSsl = true;
                client.Send(Msg); //Send our email.
                //Confirmation After Click the Button
                MessageBox.Show("Một Email đổi mật khẩu đã được gửi tới bạn!");
            }
            catch (Exception ex)
            {
                //If Mail Doesn't Send Error Mesage Will Be Displayed
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
