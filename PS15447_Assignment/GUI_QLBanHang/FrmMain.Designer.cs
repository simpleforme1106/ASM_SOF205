
namespace PS15447_Assignment
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MnStrHT = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemDN = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemDX = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemHSNV = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MnStrDM = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemSP = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemNV = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemKH = new System.Windows.Forms.ToolStripMenuItem();
            this.MnStrTK = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTKSP = new System.Windows.Forms.ToolStripMenuItem();
            this.MnStrHD = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemHDSD = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemGTPM = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnStrHT,
            this.MnStrDM,
            this.MnStrTK,
            this.MnStrHD});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(888, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "MnuStr";
            // 
            // MnStrHT
            // 
            this.MnStrHT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemDN,
            this.ItemDX,
            this.ItemHSNV,
            this.ItemQuit});
            this.MnStrHT.Name = "MnStrHT";
            this.MnStrHT.Size = new System.Drawing.Size(85, 24);
            this.MnStrHT.Text = "Hệ thống";
            // 
            // ItemDN
            // 
            this.ItemDN.Image = ((System.Drawing.Image)(resources.GetObject("ItemDN.Image")));
            this.ItemDN.Name = "ItemDN";
            this.ItemDN.Size = new System.Drawing.Size(270, 26);
            this.ItemDN.Text = "Đăng Nhập              Ctrl+D";
            this.ItemDN.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // ItemDX
            // 
            this.ItemDX.Image = ((System.Drawing.Image)(resources.GetObject("ItemDX.Image")));
            this.ItemDX.Name = "ItemDX";
            this.ItemDX.Size = new System.Drawing.Size(270, 26);
            this.ItemDX.Text = "Đăng Xuất                Ctrl+X";
            // 
            // ItemHSNV
            // 
            this.ItemHSNV.Image = ((System.Drawing.Image)(resources.GetObject("ItemHSNV.Image")));
            this.ItemHSNV.Name = "ItemHSNV";
            this.ItemHSNV.Size = new System.Drawing.Size(270, 26);
            this.ItemHSNV.Text = "Hồ Sơ Nhân Viên     Ctrl+H";
            // 
            // ItemQuit
            // 
            this.ItemQuit.Image = ((System.Drawing.Image)(resources.GetObject("ItemQuit.Image")));
            this.ItemQuit.Name = "ItemQuit";
            this.ItemQuit.Size = new System.Drawing.Size(270, 26);
            this.ItemQuit.Text = "Thoát                        Alt+F4";
            // 
            // MnStrDM
            // 
            this.MnStrDM.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemSP,
            this.ItemNV,
            this.ItemKH});
            this.MnStrDM.Name = "MnStrDM";
            this.MnStrDM.Size = new System.Drawing.Size(90, 24);
            this.MnStrDM.Text = "Danh mục";
            // 
            // ItemSP
            // 
            this.ItemSP.Image = ((System.Drawing.Image)(resources.GetObject("ItemSP.Image")));
            this.ItemSP.Name = "ItemSP";
            this.ItemSP.Size = new System.Drawing.Size(238, 26);
            this.ItemSP.Text = "Sản Phẩm          Alt+S";
            // 
            // ItemNV
            // 
            this.ItemNV.Image = ((System.Drawing.Image)(resources.GetObject("ItemNV.Image")));
            this.ItemNV.Name = "ItemNV";
            this.ItemNV.Size = new System.Drawing.Size(238, 26);
            this.ItemNV.Text = "Nhân Viên         Alt+N";
            // 
            // ItemKH
            // 
            this.ItemKH.Image = ((System.Drawing.Image)(resources.GetObject("ItemKH.Image")));
            this.ItemKH.Name = "ItemKH";
            this.ItemKH.Size = new System.Drawing.Size(238, 26);
            this.ItemKH.Text = "Khách Hàng      Ctrl+K";
            // 
            // MnStrTK
            // 
            this.MnStrTK.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemTKSP});
            this.MnStrTK.Name = "MnStrTK";
            this.MnStrTK.Size = new System.Drawing.Size(84, 24);
            this.MnStrTK.Text = "Thống kê";
            // 
            // ItemTKSP
            // 
            this.ItemTKSP.Image = ((System.Drawing.Image)(resources.GetObject("ItemTKSP.Image")));
            this.ItemTKSP.Name = "ItemTKSP";
            this.ItemTKSP.Size = new System.Drawing.Size(285, 26);
            this.ItemTKSP.Text = "Thống Kê Sản Phẩm      Alt+P";
            // 
            // MnStrHD
            // 
            this.MnStrHD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemHDSD,
            this.ItemGTPM});
            this.MnStrHD.Name = "MnStrHD";
            this.MnStrHD.Size = new System.Drawing.Size(98, 24);
            this.MnStrHD.Text = "Hướng dẫn";
            // 
            // ItemHDSD
            // 
            this.ItemHDSD.Image = ((System.Drawing.Image)(resources.GetObject("ItemHDSD.Image")));
            this.ItemHDSD.Name = "ItemHDSD";
            this.ItemHDSD.Size = new System.Drawing.Size(290, 26);
            this.ItemHDSD.Text = "Hướng Dẫn Sử Dụng     Alt+H";
            // 
            // ItemGTPM
            // 
            this.ItemGTPM.Image = ((System.Drawing.Image)(resources.GetObject("ItemGTPM.Image")));
            this.ItemGTPM.Name = "ItemGTPM";
            this.ItemGTPM.Size = new System.Drawing.Size(290, 26);
            this.ItemGTPM.Text = "Giới Thiệu Phần Mềm    Alt+G";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(195, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "DỰ ÁN MẪU C# - QUẢN LÝ BÁN HÀNG";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(308, 192);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 380);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(888, 604);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "FrmMain_QLBH";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MnStrHT;
        private System.Windows.Forms.ToolStripMenuItem ItemDN;
        private System.Windows.Forms.ToolStripMenuItem MnStrDM;
        private System.Windows.Forms.ToolStripMenuItem MnStrTK;
        private System.Windows.Forms.ToolStripMenuItem MnStrHD;
        private System.Windows.Forms.ToolStripMenuItem ItemDX;
        private System.Windows.Forms.ToolStripMenuItem ItemHSNV;
        private System.Windows.Forms.ToolStripMenuItem ItemQuit;
        private System.Windows.Forms.ToolStripMenuItem ItemSP;
        private System.Windows.Forms.ToolStripMenuItem ItemNV;
        private System.Windows.Forms.ToolStripMenuItem ItemKH;
        private System.Windows.Forms.ToolStripMenuItem ItemTKSP;
        private System.Windows.Forms.ToolStripMenuItem ItemHDSD;
        private System.Windows.Forms.ToolStripMenuItem ItemGTPM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

