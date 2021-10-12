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
    public partial class FrmDN : Form
    {
        //Sử dụng các thành phần từ BUS_NhanVien class
        //Các giá trị pass cho FrmMain phân quyền
        public string vaiTro { get; set; }
        public string matKhau { get; set; }
        BUS_NhanVien busNhanVien = new BUS_QLBanHang.BUS_NhanVien();
        public FrmDN()
        {
            InitializeComponent();
        }
        private void btnLog_Click(object sender, EventArgs e)
        {
            DTO_NhanVien nv = new DTO_NhanVien();
            nv.Email = txtMail.Text;
            nv.MatKhau = busNhanVien.encryption(txtPass.Text); //ma hoa mat khau de so sanh voi mat khau da ma hoa
            if (busNhanVien.NhanVienDangNhap(nv)) //successfull login
            {
                //login = true;
                FrmMain.mail = nv.Email; //truyen email dang nhap cho FrmMain
                DataTable dt = busNhanVien.VaiTroNhanVien(nv.Email);
                vaiTro = dt.Rows[0][0].ToString(); //Lay vai tro cua nhan vien, hien
                MessageBox.Show("Đăng nhập thành công");
                FrmMain.session = 1; //Cap nhat trang thai da dang nhap thanh cong
                this.Close();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công, kiểm tra lại email hoặc mật khẩu");
                txtMail.Text = txtPass.Text = null;
                txtMail.Focus();
            }
        }
        //Tao chuoi ngau nhien
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        //Tao so ngau nhien
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
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
                Msg.Subject = "Ban da su dung tinh nang Quen Mat khau";
                //Create the content(body) of our message
                Msg.Body = "Chào anh/chị. Mật khẩu mới truy cập phần mềm là: " + matKhau;
                //Send our account login details to the client.
                client.Credentials = cred;
                //Enabling SSL(Secure Sockets Layer, encryption) is required by most email providers to send mail.
                client.EnableSsl = true;
                client.Send(Msg); //Send our email.
                //Confirmation After Click the Button
                MessageBox.Show("Một Email khôi phục mật khẩu đã được gửi tới bạn!");
            }
            catch(Exception ex)
            {
                //If Mail Doesn't Send Error Mesage Will Be Displayed
                MessageBox.Show(ex.Message);
            }
        }

        private void btnForgot_Click(object sender, EventArgs e)
        {
            if (txtMail.Text != "")
            {
                if (busNhanVien.NhanVienQuenMatKhau(txtMail.Text))
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append(RandomString(4, true));
                    builder.Append(RandomNumber(1000, 9999));
                    builder.Append(RandomString(2, false));
                    MessageBox.Show(builder.ToString());
                    string matKhauMoi = busNhanVien.encryption(builder.ToString());
                    busNhanVien.TaoMatKhau(txtMail.Text, matKhauMoi); //Update new pass to database
                    SendMail(txtMail.Text, builder.ToString());
                }
                else
                {
                    MessageBox.Show("Email khong ton tai, vui long nhap lai email!");
                }
            }
            else
            {
                MessageBox.Show("Ban can nhap email nhan thong tin khoi phuc mat khau!");
                txtMail.Focus();
            }
        }

        private void FrmDN_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void FrmDN_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is excuted
            this.Refresh();
                FrmMain_Load(sender, e);//Load form main again
        }

        private void FrmMain_Load(object sender, FormClosedEventArgs e)
        {
            FrmMain main = new FrmMain();
            main.Show();
        }
    }
}
