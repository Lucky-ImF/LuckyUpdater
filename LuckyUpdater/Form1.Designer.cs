namespace LuckyUpdater
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            TitlePanel = new Panel();
            TitleVersion = new Label();
            TitleLabel = new Label();
            TitleIcon = new PictureBox();
            CloseButton = new PictureBox();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            ErrorLabel = new Label();
            UpdateInfoMissingPanel = new Panel();
            SupportLinkLL = new LinkLabel();
            UpdatePanel = new Panel();
            UpdateStatus = new Label();
            PromoLink = new LinkLabel();
            UpdateStats = new Label();
            UpdateProgressBar = new ProgressBar();
            UpdateVersion = new Label();
            label3 = new Label();
            UpdateChangelog = new RichTextBox();
            UpdateButton = new Button();
            UpdateLogo = new PictureBox();
            label2 = new Label();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TitleIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CloseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            UpdateInfoMissingPanel.SuspendLayout();
            UpdatePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UpdateLogo).BeginInit();
            SuspendLayout();
            // 
            // TitlePanel
            // 
            TitlePanel.Controls.Add(TitleVersion);
            TitlePanel.Controls.Add(TitleLabel);
            TitlePanel.Location = new Point(1, 1);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(798, 41);
            TitlePanel.TabIndex = 0;
            TitlePanel.MouseDown += TitlePanel_MouseDown;
            TitlePanel.MouseMove += TitlePanel_MouseMove;
            TitlePanel.MouseUp += TitlePanel_MouseUp;
            // 
            // TitleVersion
            // 
            TitleVersion.AutoSize = true;
            TitleVersion.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleVersion.Location = new Point(62, 13);
            TitleVersion.Name = "TitleVersion";
            TitleVersion.Size = new Size(31, 15);
            TitleVersion.TabIndex = 1;
            TitleVersion.Text = "v.0.1";
            // 
            // TitleLabel
            // 
            TitleLabel.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleLabel.Location = new Point(60, 8);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(678, 25);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Lucky Updater - WLMM";
            TitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            TitleLabel.MouseDown += TitleLabel_MouseDown;
            TitleLabel.MouseMove += TitleLabel_MouseMove;
            TitleLabel.MouseUp += TitleLabel_MouseUp;
            // 
            // TitleIcon
            // 
            TitleIcon.Image = Properties.Resources.LuckyUpdaterIcon_512;
            TitleIcon.Location = new Point(5, 5);
            TitleIcon.Name = "TitleIcon";
            TitleIcon.Size = new Size(50, 50);
            TitleIcon.SizeMode = PictureBoxSizeMode.Zoom;
            TitleIcon.TabIndex = 1;
            TitleIcon.TabStop = false;
            TitleIcon.MouseDown += TitleIcon_MouseDown;
            TitleIcon.MouseMove += TitleIcon_MouseMove;
            TitleIcon.MouseUp += TitleIcon_MouseUp;
            // 
            // CloseButton
            // 
            CloseButton.Image = Properties.Resources.Close_Icon;
            CloseButton.Location = new Point(745, 5);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(50, 50);
            CloseButton.SizeMode = PictureBoxSizeMode.Zoom;
            CloseButton.TabIndex = 2;
            CloseButton.TabStop = false;
            CloseButton.Click += CloseButton_Click;
            CloseButton.MouseEnter += CloseButton_MouseEnter;
            CloseButton.MouseLeave += CloseButton_MouseLeave;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(113, 45);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(575, 1);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.LuckyUpdaterIcon_512;
            pictureBox2.Location = new Point(211, 13);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(256, 256);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // ErrorLabel
            // 
            ErrorLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ErrorLabel.Location = new Point(15, 274);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(646, 32);
            ErrorLabel.TabIndex = 5;
            ErrorLabel.Text = "No Update Information Found";
            ErrorLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UpdateInfoMissingPanel
            // 
            UpdateInfoMissingPanel.Controls.Add(SupportLinkLL);
            UpdateInfoMissingPanel.Controls.Add(pictureBox2);
            UpdateInfoMissingPanel.Controls.Add(ErrorLabel);
            UpdateInfoMissingPanel.Location = new Point(61, 76);
            UpdateInfoMissingPanel.Name = "UpdateInfoMissingPanel";
            UpdateInfoMissingPanel.Size = new Size(678, 335);
            UpdateInfoMissingPanel.TabIndex = 6;
            // 
            // SupportLinkLL
            // 
            SupportLinkLL.ActiveLinkColor = Color.White;
            SupportLinkLL.LinkColor = Color.FromArgb(128, 255, 255);
            SupportLinkLL.Location = new Point(3, 310);
            SupportLinkLL.Name = "SupportLinkLL";
            SupportLinkLL.Size = new Size(672, 15);
            SupportLinkLL.TabIndex = 13;
            SupportLinkLL.TabStop = true;
            SupportLinkLL.Text = "SUPPORT LINK";
            SupportLinkLL.TextAlign = ContentAlignment.MiddleCenter;
            SupportLinkLL.Visible = false;
            SupportLinkLL.VisitedLinkColor = Color.FromArgb(128, 255, 255);
            SupportLinkLL.LinkClicked += SupportLink_LinkClicked;
            // 
            // UpdatePanel
            // 
            UpdatePanel.Controls.Add(UpdateStatus);
            UpdatePanel.Controls.Add(PromoLink);
            UpdatePanel.Controls.Add(UpdateStats);
            UpdatePanel.Controls.Add(UpdateProgressBar);
            UpdatePanel.Controls.Add(UpdateVersion);
            UpdatePanel.Controls.Add(label3);
            UpdatePanel.Controls.Add(UpdateChangelog);
            UpdatePanel.Controls.Add(UpdateButton);
            UpdatePanel.Controls.Add(UpdateLogo);
            UpdatePanel.Controls.Add(label2);
            UpdatePanel.Location = new Point(5, 61);
            UpdatePanel.Name = "UpdatePanel";
            UpdatePanel.Size = new Size(790, 377);
            UpdatePanel.TabIndex = 7;
            UpdatePanel.Visible = false;
            // 
            // UpdateStatus
            // 
            UpdateStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpdateStatus.Location = new Point(7, 353);
            UpdateStatus.Name = "UpdateStatus";
            UpdateStatus.Size = new Size(268, 20);
            UpdateStatus.TabIndex = 13;
            UpdateStatus.Text = "Waiting...";
            UpdateStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PromoLink
            // 
            PromoLink.ActiveLinkColor = Color.White;
            PromoLink.LinkColor = Color.FromArgb(128, 255, 255);
            PromoLink.Location = new Point(15, 309);
            PromoLink.Name = "PromoLink";
            PromoLink.Size = new Size(768, 15);
            PromoLink.TabIndex = 12;
            PromoLink.TabStop = true;
            PromoLink.Text = "PROMO LINK";
            PromoLink.TextAlign = ContentAlignment.MiddleCenter;
            PromoLink.VisitedLinkColor = Color.FromArgb(128, 255, 255);
            PromoLink.LinkClicked += PromoLink_LinkClicked;
            // 
            // UpdateStats
            // 
            UpdateStats.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpdateStats.Location = new Point(281, 353);
            UpdateStats.Name = "UpdateStats";
            UpdateStats.Size = new Size(362, 20);
            UpdateStats.TabIndex = 11;
            UpdateStats.Text = "Speed: 0 B/s | 0 B / 0 B | Time Left: 00:00:00";
            UpdateStats.TextAlign = ContentAlignment.MiddleRight;
            // 
            // UpdateProgressBar
            // 
            UpdateProgressBar.Location = new Point(7, 336);
            UpdateProgressBar.Name = "UpdateProgressBar";
            UpdateProgressBar.Size = new Size(636, 14);
            UpdateProgressBar.TabIndex = 10;
            // 
            // UpdateVersion
            // 
            UpdateVersion.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpdateVersion.Location = new Point(321, 44);
            UpdateVersion.Name = "UpdateVersion";
            UpdateVersion.Size = new Size(462, 30);
            UpdateVersion.TabIndex = 9;
            UpdateVersion.Text = "VERSION";
            UpdateVersion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(321, 74);
            label3.Name = "label3";
            label3.Size = new Size(462, 25);
            label3.TabIndex = 8;
            label3.Text = "Changelog:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UpdateChangelog
            // 
            UpdateChangelog.BackColor = Color.FromArgb(64, 64, 64);
            UpdateChangelog.BorderStyle = BorderStyle.FixedSingle;
            UpdateChangelog.ForeColor = Color.White;
            UpdateChangelog.Location = new Point(321, 102);
            UpdateChangelog.Name = "UpdateChangelog";
            UpdateChangelog.ReadOnly = true;
            UpdateChangelog.Size = new Size(462, 201);
            UpdateChangelog.TabIndex = 7;
            UpdateChangelog.Text = "";
            // 
            // UpdateButton
            // 
            UpdateButton.FlatStyle = FlatStyle.Flat;
            UpdateButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UpdateButton.Location = new Point(652, 330);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(131, 39);
            UpdateButton.TabIndex = 6;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // UpdateLogo
            // 
            UpdateLogo.Image = Properties.Resources.LuckyUpdaterIcon_512;
            UpdateLogo.ImageLocation = "";
            UpdateLogo.Location = new Point(15, 8);
            UpdateLogo.Name = "UpdateLogo";
            UpdateLogo.Size = new Size(300, 295);
            UpdateLogo.SizeMode = PictureBoxSizeMode.Zoom;
            UpdateLogo.TabIndex = 4;
            UpdateLogo.TabStop = false;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(321, 12);
            label2.Name = "label2";
            label2.Size = new Size(462, 32);
            label2.TabIndex = 5;
            label2.Text = "New Version Available!";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(800, 443);
            ControlBox = false;
            Controls.Add(UpdatePanel);
            Controls.Add(pictureBox1);
            Controls.Add(CloseButton);
            Controls.Add(TitleIcon);
            Controls.Add(TitlePanel);
            Controls.Add(UpdateInfoMissingPanel);
            DoubleBuffered = true;
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lucky Updater";
            Load += Main_Load;
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TitleIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)CloseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            UpdateInfoMissingPanel.ResumeLayout(false);
            UpdatePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UpdateLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel TitlePanel;
        private Label TitleLabel;
        private PictureBox TitleIcon;
        private PictureBox CloseButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label ErrorLabel;
        private Panel UpdateInfoMissingPanel;
        private Label TitleVersion;
        private Panel UpdatePanel;
        private PictureBox UpdateLogo;
        private Label label2;
        private Label label3;
        private RichTextBox UpdateChangelog;
        private Button UpdateButton;
        private LinkLabel PromoLink;
        private Label UpdateStats;
        private ProgressBar UpdateProgressBar;
        private Label UpdateVersion;
        private Label UpdateStatus;
        private LinkLabel SupportLinkLL;
    }
}
