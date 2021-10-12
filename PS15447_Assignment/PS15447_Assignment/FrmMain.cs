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

namespace PS15447_Assignment
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public static int session = 0; //Kiểm tra tình trạng login
        public static int profile = 0; //
        public static string mail; //Truyển email từ FrmMain cho các form khác thông qua biến static
        public void FrmMain_Load(object sender, EventArgs e)
        {
            ResetValue();
            if (profile == 1) //Nếu vừa cập nhật mật khẩu thì
                               //phải login lại, mục 'thong tin nhan vien' ẩn
            {
                ItemHSNV.Text = null;
                profile = 0; //ẩn mục 'thong tin nhan vien'
            }
        }
        //CheckExistForm để kiểm tra xem 1 Form với tên nào đó đã hiển thị trong Form Cha(FrmMain) chưa?
        //=> Trả về True(đã hiển thị) hoặc False(Chưa hiển thị).
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        //ActiveChildForm dùng để "Kích hoạt" hiển thị lên trên cùng
        //trong số các Form con nếu nó đã hiện mà không phải tạo thể hiện mới. 
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void ItemHDSD_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "SOF205_Du an mau (UDPM.NET)_Assignment.pdf");
                System.Diagnostics.Process.Start(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file is not found in the specified location");
            }
        }

        private void ItemDX_Click(object sender, EventArgs e)
        {

        }

        private void ItemHSNV_Click(object sender, EventArgs e)
        {
            FrmDMK profilenv = new FrmDMK(FrmMain.mail); //Khởi tạo FrmDMK với email nv
            if (!CheckExistForm("FrmDMK"))
            {
                profilenv.MdiParent = this;
                profilenv.FormClosed += new FormClosedEventHandler(FrmDMK_FormClosed);
                pictureBox1.Visible = false;
                profilenv.Show();
            }
            else
                ActiveChildForm("FrmDMK");
        }

        private void FrmDMK_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void ItemQuit_Click(object sender, EventArgs e)
        {

        }

        private void ItemSP_Click(object sender, EventArgs e)
        {

        }

        private void ItemNV_Click(object sender, EventArgs e)
        {

        }

        private void ItemKH_Click(object sender, EventArgs e)
        {

        }

        private void ItemTKSP_Click(object sender, EventArgs e)
        {

        }

        private void ItemGTPM_Click(object sender, EventArgs e)
        {

        }
        private void VaiTroNV()
        {
            ItemNV.Visible = false;
            ItemTKSP.Visible = false;
        }
        private void ResetValue()
        {
            FrmDN dn = new FrmDN();
            if (session == 1)
            {
                thongtinnvToolStripMenuItem.Text = "Chào" + FrmMain.mail;
                ItemNV.Visible = true;
                MnStrDM.Visible = true;
                ItemDX.Enabled = true;
                MnStrTK.Visible = true;
                ItemTKSP.Visible = true;
                ItemHSNV.Visible = true;
                ItemDN.Enabled = false;
                if (Convert.ToInt32(dn.vaiTro) == 0) //Neu vai tro la nhan vien
                {
                    VaiTroNV();
                }
            }
            else
            {
                ItemNV.Visible = false;
                MnStrDM.Visible = false;
                ItemDX.Enabled = false;
                MnStrTK.Visible = false;
                ItemTKSP.Visible = false;
                ItemHSNV.Visible = false;
                ItemDN.Enabled = true;
            }
        }
        //Show form đăng nhập
        private void ItemDN_Click(object sender, EventArgs e)
        {
            FrmDN dn = new FrmDN();
            if (!CheckExistForm("FrmDN"))
            {
                dn.MdiParent = this;
                pictureBox1.Visible = false;
                dn.Show();
                dn.FormClosed += new FormClosedEventHandler(FrmDN_FormClosed);
            }
            else
            {
                ActiveChildForm("FrmDN");
            }
        }
        private void FrmDN_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
