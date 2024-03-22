namespace Tangerine_Tournament
{
    partial class MainForm
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
            tabPage1 = new ReaLTaiizor.Controls.TabPage();
            connectionPage = new TabPage();
            btnConnectDatabase = new ReaLTaiizor.Controls.Button();
            txtPassword = new ReaLTaiizor.Controls.TextBoxEdit();
            btnShowPassword = new ReaLTaiizor.Controls.Button();
            btnConnect = new ReaLTaiizor.Controls.Button();
            labelEdit4 = new ReaLTaiizor.Controls.LabelEdit();
            txtUsername = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit3 = new ReaLTaiizor.Controls.LabelEdit();
            txtURL = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit2 = new ReaLTaiizor.Controls.LabelEdit();
            bigLabel2 = new ReaLTaiizor.Controls.BigLabel();
            bigLabel1 = new ReaLTaiizor.Controls.BigLabel();
            labelEdit1 = new ReaLTaiizor.Controls.LabelEdit();
            txtConnectTournament = new ReaLTaiizor.Controls.TextBoxEdit();
            createPage = new TabPage();
            numTournamentSize = new ReaLTaiizor.Controls.CrownNumeric();
            btnCreate = new ReaLTaiizor.Controls.Button();
            labelEdit8 = new ReaLTaiizor.Controls.LabelEdit();
            radioButton3 = new RadioButton();
            labelEdit7 = new ReaLTaiizor.Controls.LabelEdit();
            radioButton2 = new RadioButton();
            rbtnSingleElim = new RadioButton();
            txtTournamentName = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit6 = new ReaLTaiizor.Controls.LabelEdit();
            infoPage = new TabPage();
            btnUpdateInfo = new ReaLTaiizor.Controls.Button();
            btnPopulateInfo = new ReaLTaiizor.Controls.Button();
            labelEdit12 = new ReaLTaiizor.Controls.LabelEdit();
            checkIsLockedInfo = new CheckBox();
            checkIsTeamsInfo = new CheckBox();
            txtSizeInfo = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit11 = new ReaLTaiizor.Controls.LabelEdit();
            txtTypeInfo = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit10 = new ReaLTaiizor.Controls.LabelEdit();
            txtDateInfo = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit9 = new ReaLTaiizor.Controls.LabelEdit();
            txtNameInfo = new ReaLTaiizor.Controls.TextBoxEdit();
            labelEdit5 = new ReaLTaiizor.Controls.LabelEdit();
            Infomation = new ReaLTaiizor.Controls.BigLabel();
            playerPage = new TabPage();
            teamPage = new TabPage();
            matchPage = new TabPage();
            panelHeader = new ReaLTaiizor.Controls.Panel();
            bigLabel3 = new ReaLTaiizor.Controls.BigLabel();
            btnMinimise = new ReaLTaiizor.Controls.Button();
            btnClose = new ReaLTaiizor.Controls.Button();
            tabPage1.SuspendLayout();
            connectionPage.SuspendLayout();
            createPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTournamentSize).BeginInit();
            infoPage.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // tabPage1
            // 
            tabPage1.ActiveForeColor = Color.FromArgb(254, 255, 255);
            tabPage1.ActiveLineTabColor = Color.FromArgb(89, 169, 222);
            tabPage1.ActiveTabColor = Color.FromArgb(35, 36, 38);
            tabPage1.Alignment = TabAlignment.Left;
            tabPage1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            tabPage1.CompositingType = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            tabPage1.ControlBackColor = Color.FromArgb(54, 57, 64);
            tabPage1.Controls.Add(connectionPage);
            tabPage1.Controls.Add(createPage);
            tabPage1.Controls.Add(infoPage);
            tabPage1.Controls.Add(playerPage);
            tabPage1.Controls.Add(teamPage);
            tabPage1.Controls.Add(matchPage);
            tabPage1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabPage1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPage1.FrameColor = Color.FromArgb(50, 63, 74);
            tabPage1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            tabPage1.ItemSize = new Size(50, 120);
            tabPage1.LineColor = Color.Transparent;
            tabPage1.LineTabColor = Color.FromArgb(54, 57, 64);
            tabPage1.Location = new Point(0, 40);
            tabPage1.Margin = new Padding(2);
            tabPage1.Multiline = true;
            tabPage1.Name = "tabPage1";
            tabPage1.NormalForeColor = Color.FromArgb(159, 162, 167);
            tabPage1.PageColor = Color.Transparent;
            tabPage1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            tabPage1.SelectedIndex = 0;
            tabPage1.Size = new Size(800, 460);
            tabPage1.SizeMode = TabSizeMode.Fixed;
            tabPage1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            tabPage1.StringType = StringAlignment.Near;
            tabPage1.TabColor = Color.FromArgb(54, 57, 64);
            tabPage1.TabIndex = 0;
            tabPage1.TextRenderingType = System.Drawing.Text.TextRenderingHint.SystemDefault;
            tabPage1.SelectedIndexChanged += tabPage1_SelectedIndexChanged;
            // 
            // connectionPage
            // 
            connectionPage.BackColor = Color.Transparent;
            connectionPage.Controls.Add(btnConnectDatabase);
            connectionPage.Controls.Add(txtPassword);
            connectionPage.Controls.Add(btnShowPassword);
            connectionPage.Controls.Add(btnConnect);
            connectionPage.Controls.Add(labelEdit4);
            connectionPage.Controls.Add(txtUsername);
            connectionPage.Controls.Add(labelEdit3);
            connectionPage.Controls.Add(txtURL);
            connectionPage.Controls.Add(labelEdit2);
            connectionPage.Controls.Add(bigLabel2);
            connectionPage.Controls.Add(bigLabel1);
            connectionPage.Controls.Add(labelEdit1);
            connectionPage.Controls.Add(txtConnectTournament);
            connectionPage.Location = new Point(124, 4);
            connectionPage.Margin = new Padding(2);
            connectionPage.Name = "connectionPage";
            connectionPage.Padding = new Padding(2);
            connectionPage.Size = new Size(672, 452);
            connectionPage.TabIndex = 0;
            connectionPage.Text = "Connect";
            // 
            // btnConnectDatabase
            // 
            btnConnectDatabase.BackColor = Color.Transparent;
            btnConnectDatabase.BorderColor = Color.FromArgb(32, 34, 37);
            btnConnectDatabase.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnConnectDatabase.EnteredColor = Color.FromArgb(32, 34, 37);
            btnConnectDatabase.Font = new Font("Microsoft Sans Serif", 12F);
            btnConnectDatabase.Image = null;
            btnConnectDatabase.ImageAlign = ContentAlignment.MiddleLeft;
            btnConnectDatabase.InactiveColor = Color.FromArgb(32, 34, 37);
            btnConnectDatabase.Location = new Point(547, 370);
            btnConnectDatabase.Name = "btnConnectDatabase";
            btnConnectDatabase.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnConnectDatabase.PressedColor = Color.FromArgb(165, 37, 37);
            btnConnectDatabase.Size = new Size(120, 43);
            btnConnectDatabase.TabIndex = 18;
            btnConnectDatabase.Text = "Connect";
            btnConnectDatabase.TextAlignment = StringAlignment.Center;
            btnConnectDatabase.Click += btnConnectDatabase_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Transparent;
            txtPassword.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(176, 183, 191);
            txtPassword.Image = null;
            txtPassword.Location = new Point(5, 240);
            txtPassword.MaxLength = 32767;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = false;
            txtPassword.Size = new Size(420, 43);
            txtPassword.TabIndex = 17;
            txtPassword.TextAlignment = HorizontalAlignment.Left;
            txtPassword.UseSystemPasswordChar = false;
            // 
            // btnShowPassword
            // 
            btnShowPassword.BackColor = Color.Transparent;
            btnShowPassword.BorderColor = Color.Transparent;
            btnShowPassword.Cursor = Cursors.Hand;
            btnShowPassword.EnteredBorderColor = Color.Transparent;
            btnShowPassword.EnteredColor = Color.Black;
            btnShowPassword.Font = new Font("Segoe Fluent Icons", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnShowPassword.Image = null;
            btnShowPassword.ImageAlign = ContentAlignment.MiddleCenter;
            btnShowPassword.InactiveColor = Color.Transparent;
            btnShowPassword.Location = new Point(431, 240);
            btnShowPassword.Margin = new Padding(0);
            btnShowPassword.Name = "btnShowPassword";
            btnShowPassword.PressedBorderColor = Color.Transparent;
            btnShowPassword.PressedColor = Color.Transparent;
            btnShowPassword.Size = new Size(43, 43);
            btnShowPassword.TabIndex = 2;
            btnShowPassword.Text = "";
            btnShowPassword.TextAlignment = StringAlignment.Center;
            btnShowPassword.MouseDown += btnShowPassword_MouseDown;
            btnShowPassword.MouseUp += btnShowPassword_MouseUp;
            // 
            // btnConnect
            // 
            btnConnect.BackColor = Color.Transparent;
            btnConnect.BorderColor = Color.FromArgb(32, 34, 37);
            btnConnect.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnConnect.EnteredColor = Color.FromArgb(32, 34, 37);
            btnConnect.Font = new Font("Microsoft Sans Serif", 12F);
            btnConnect.Image = null;
            btnConnect.ImageAlign = ContentAlignment.MiddleLeft;
            btnConnect.InactiveColor = Color.FromArgb(32, 34, 37);
            btnConnect.Location = new Point(547, 240);
            btnConnect.Name = "btnConnect";
            btnConnect.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnConnect.PressedColor = Color.FromArgb(165, 37, 37);
            btnConnect.Size = new Size(120, 43);
            btnConnect.TabIndex = 12;
            btnConnect.Text = "Connect";
            btnConnect.TextAlignment = StringAlignment.Center;
            btnConnect.Click += btnConnect_Click;
            // 
            // labelEdit4
            // 
            labelEdit4.AutoSize = true;
            labelEdit4.BackColor = Color.Transparent;
            labelEdit4.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit4.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit4.Location = new Point(5, 210);
            labelEdit4.Name = "labelEdit4";
            labelEdit4.Size = new Size(97, 24);
            labelEdit4.TabIndex = 10;
            labelEdit4.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.Transparent;
            txtUsername.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsername.ForeColor = Color.FromArgb(176, 183, 191);
            txtUsername.Image = null;
            txtUsername.Location = new Point(5, 160);
            txtUsername.MaxLength = 32767;
            txtUsername.Multiline = false;
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = false;
            txtUsername.Size = new Size(420, 43);
            txtUsername.TabIndex = 9;
            txtUsername.TextAlignment = HorizontalAlignment.Left;
            txtUsername.UseSystemPasswordChar = false;
            // 
            // labelEdit3
            // 
            labelEdit3.AutoSize = true;
            labelEdit3.BackColor = Color.Transparent;
            labelEdit3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit3.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit3.Location = new Point(5, 130);
            labelEdit3.Name = "labelEdit3";
            labelEdit3.Size = new Size(102, 24);
            labelEdit3.TabIndex = 8;
            labelEdit3.Text = "Username:";
            // 
            // txtURL
            // 
            txtURL.BackColor = Color.Transparent;
            txtURL.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtURL.ForeColor = Color.FromArgb(176, 183, 191);
            txtURL.Image = null;
            txtURL.Location = new Point(5, 80);
            txtURL.MaxLength = 32767;
            txtURL.Multiline = false;
            txtURL.Name = "txtURL";
            txtURL.ReadOnly = false;
            txtURL.Size = new Size(420, 43);
            txtURL.TabIndex = 7;
            txtURL.TextAlignment = HorizontalAlignment.Left;
            txtURL.UseSystemPasswordChar = false;
            // 
            // labelEdit2
            // 
            labelEdit2.AutoSize = true;
            labelEdit2.BackColor = Color.Transparent;
            labelEdit2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit2.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit2.Location = new Point(5, 50);
            labelEdit2.Name = "labelEdit2";
            labelEdit2.Size = new Size(51, 24);
            labelEdit2.TabIndex = 6;
            labelEdit2.Text = "URL:";
            // 
            // bigLabel2
            // 
            bigLabel2.AutoSize = true;
            bigLabel2.BackColor = Color.Transparent;
            bigLabel2.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel2.ForeColor = Color.White;
            bigLabel2.ImageAlign = ContentAlignment.MiddleLeft;
            bigLabel2.Location = new Point(0, 0);
            bigLabel2.Name = "bigLabel2";
            bigLabel2.Size = new Size(287, 45);
            bigLabel2.TabIndex = 5;
            bigLabel2.Text = "Server Connection:";
            bigLabel2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // bigLabel1
            // 
            bigLabel1.AutoSize = true;
            bigLabel1.BackColor = Color.Transparent;
            bigLabel1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel1.ForeColor = Color.White;
            bigLabel1.ImageAlign = ContentAlignment.MiddleLeft;
            bigLabel1.Location = new Point(0, 290);
            bigLabel1.Name = "bigLabel1";
            bigLabel1.Size = new Size(330, 45);
            bigLabel1.TabIndex = 4;
            bigLabel1.Text = "Database Connection:";
            bigLabel1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelEdit1
            // 
            labelEdit1.AutoSize = true;
            labelEdit1.BackColor = Color.Transparent;
            labelEdit1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit1.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit1.Location = new Point(5, 340);
            labelEdit1.Name = "labelEdit1";
            labelEdit1.Size = new Size(174, 24);
            labelEdit1.TabIndex = 1;
            labelEdit1.Text = "Tournament Name:";
            // 
            // txtConnectTournament
            // 
            txtConnectTournament.BackColor = Color.Transparent;
            txtConnectTournament.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtConnectTournament.ForeColor = Color.FromArgb(176, 183, 191);
            txtConnectTournament.Image = null;
            txtConnectTournament.Location = new Point(5, 370);
            txtConnectTournament.MaxLength = 32767;
            txtConnectTournament.Multiline = false;
            txtConnectTournament.Name = "txtConnectTournament";
            txtConnectTournament.ReadOnly = false;
            txtConnectTournament.Size = new Size(420, 43);
            txtConnectTournament.TabIndex = 0;
            txtConnectTournament.TextAlignment = HorizontalAlignment.Left;
            txtConnectTournament.UseSystemPasswordChar = false;
            // 
            // createPage
            // 
            createPage.BackColor = Color.Transparent;
            createPage.Controls.Add(numTournamentSize);
            createPage.Controls.Add(btnCreate);
            createPage.Controls.Add(labelEdit8);
            createPage.Controls.Add(radioButton3);
            createPage.Controls.Add(labelEdit7);
            createPage.Controls.Add(radioButton2);
            createPage.Controls.Add(rbtnSingleElim);
            createPage.Controls.Add(txtTournamentName);
            createPage.Controls.Add(labelEdit6);
            createPage.Location = new Point(124, 4);
            createPage.Name = "createPage";
            createPage.Size = new Size(672, 452);
            createPage.TabIndex = 5;
            createPage.Text = "Create";
            // 
            // numTournamentSize
            // 
            numTournamentSize.Location = new Point(5, 230);
            numTournamentSize.Maximum = new decimal(new int[] { 512, 0, 0, 0 });
            numTournamentSize.Name = "numTournamentSize";
            numTournamentSize.Size = new Size(120, 29);
            numTournamentSize.TabIndex = 17;
            // 
            // btnCreate
            // 
            btnCreate.BackColor = Color.Transparent;
            btnCreate.BorderColor = Color.FromArgb(32, 34, 37);
            btnCreate.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnCreate.EnteredColor = Color.FromArgb(32, 34, 37);
            btnCreate.Font = new Font("Microsoft Sans Serif", 12F);
            btnCreate.Image = null;
            btnCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreate.InactiveColor = Color.FromArgb(32, 34, 37);
            btnCreate.Location = new Point(544, 216);
            btnCreate.Name = "btnCreate";
            btnCreate.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnCreate.PressedColor = Color.FromArgb(165, 37, 37);
            btnCreate.Size = new Size(120, 43);
            btnCreate.TabIndex = 10;
            btnCreate.Text = "Create";
            btnCreate.TextAlignment = StringAlignment.Center;
            btnCreate.Click += btnCreate_Click;
            // 
            // labelEdit8
            // 
            labelEdit8.AutoSize = true;
            labelEdit8.BackColor = Color.Transparent;
            labelEdit8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit8.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit8.Location = new Point(0, 200);
            labelEdit8.Name = "labelEdit8";
            labelEdit8.Size = new Size(159, 24);
            labelEdit8.TabIndex = 8;
            labelEdit8.Text = "Tournament Size:";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(5, 169);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(119, 25);
            radioButton3.TabIndex = 7;
            radioButton3.TabStop = true;
            radioButton3.Text = "radioButton3";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // labelEdit7
            // 
            labelEdit7.AutoSize = true;
            labelEdit7.BackColor = Color.Transparent;
            labelEdit7.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit7.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit7.Location = new Point(5, 80);
            labelEdit7.Name = "labelEdit7";
            labelEdit7.Size = new Size(166, 24);
            labelEdit7.TabIndex = 6;
            labelEdit7.Text = "Tournament Type:";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(5, 138);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(119, 25);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.Text = "radioButton2";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // rbtnSingleElim
            // 
            rbtnSingleElim.AutoSize = true;
            rbtnSingleElim.Location = new Point(5, 107);
            rbtnSingleElim.Name = "rbtnSingleElim";
            rbtnSingleElim.Size = new Size(153, 25);
            rbtnSingleElim.TabIndex = 4;
            rbtnSingleElim.TabStop = true;
            rbtnSingleElim.Text = "Single Elimination";
            rbtnSingleElim.UseVisualStyleBackColor = true;
            // 
            // txtTournamentName
            // 
            txtTournamentName.BackColor = Color.Transparent;
            txtTournamentName.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTournamentName.ForeColor = Color.FromArgb(176, 183, 191);
            txtTournamentName.Image = null;
            txtTournamentName.Location = new Point(5, 32);
            txtTournamentName.MaxLength = 32767;
            txtTournamentName.Multiline = false;
            txtTournamentName.Name = "txtTournamentName";
            txtTournamentName.ReadOnly = false;
            txtTournamentName.Size = new Size(420, 43);
            txtTournamentName.TabIndex = 3;
            txtTournamentName.TextAlignment = HorizontalAlignment.Left;
            txtTournamentName.UseSystemPasswordChar = false;
            // 
            // labelEdit6
            // 
            labelEdit6.AutoSize = true;
            labelEdit6.BackColor = Color.Transparent;
            labelEdit6.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit6.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit6.Location = new Point(5, 5);
            labelEdit6.Name = "labelEdit6";
            labelEdit6.Size = new Size(174, 24);
            labelEdit6.TabIndex = 2;
            labelEdit6.Text = "Tournament Name:";
            // 
            // infoPage
            // 
            infoPage.BackColor = Color.Transparent;
            infoPage.Controls.Add(btnUpdateInfo);
            infoPage.Controls.Add(btnPopulateInfo);
            infoPage.Controls.Add(labelEdit12);
            infoPage.Controls.Add(checkIsLockedInfo);
            infoPage.Controls.Add(checkIsTeamsInfo);
            infoPage.Controls.Add(txtSizeInfo);
            infoPage.Controls.Add(labelEdit11);
            infoPage.Controls.Add(txtTypeInfo);
            infoPage.Controls.Add(labelEdit10);
            infoPage.Controls.Add(txtDateInfo);
            infoPage.Controls.Add(labelEdit9);
            infoPage.Controls.Add(txtNameInfo);
            infoPage.Controls.Add(labelEdit5);
            infoPage.Controls.Add(Infomation);
            infoPage.Location = new Point(124, 4);
            infoPage.Margin = new Padding(2);
            infoPage.Name = "infoPage";
            infoPage.Padding = new Padding(2);
            infoPage.Size = new Size(672, 452);
            infoPage.TabIndex = 1;
            infoPage.Text = "Info";
            // 
            // btnUpdateInfo
            // 
            btnUpdateInfo.BackColor = Color.Transparent;
            btnUpdateInfo.BorderColor = Color.FromArgb(32, 34, 37);
            btnUpdateInfo.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnUpdateInfo.EnteredColor = Color.FromArgb(32, 34, 37);
            btnUpdateInfo.Font = new Font("Microsoft Sans Serif", 12F);
            btnUpdateInfo.Image = null;
            btnUpdateInfo.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdateInfo.InactiveColor = Color.FromArgb(32, 34, 37);
            btnUpdateInfo.Location = new Point(544, 240);
            btnUpdateInfo.Name = "btnUpdateInfo";
            btnUpdateInfo.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnUpdateInfo.PressedColor = Color.FromArgb(165, 37, 37);
            btnUpdateInfo.Size = new Size(120, 43);
            btnUpdateInfo.TabIndex = 15;
            btnUpdateInfo.Text = "Update Info";
            btnUpdateInfo.TextAlignment = StringAlignment.Center;
            btnUpdateInfo.Click += btnUpdateInfo_Click;
            // 
            // btnPopulateInfo
            // 
            btnPopulateInfo.BackColor = Color.Transparent;
            btnPopulateInfo.BorderColor = Color.FromArgb(32, 34, 37);
            btnPopulateInfo.EnteredBorderColor = Color.FromArgb(165, 37, 37);
            btnPopulateInfo.EnteredColor = Color.FromArgb(32, 34, 37);
            btnPopulateInfo.Font = new Font("Microsoft Sans Serif", 12F);
            btnPopulateInfo.Image = null;
            btnPopulateInfo.ImageAlign = ContentAlignment.MiddleLeft;
            btnPopulateInfo.InactiveColor = Color.FromArgb(32, 34, 37);
            btnPopulateInfo.Location = new Point(544, 317);
            btnPopulateInfo.Name = "btnPopulateInfo";
            btnPopulateInfo.PressedBorderColor = Color.FromArgb(165, 37, 37);
            btnPopulateInfo.PressedColor = Color.FromArgb(165, 37, 37);
            btnPopulateInfo.Size = new Size(120, 43);
            btnPopulateInfo.TabIndex = 14;
            btnPopulateInfo.Text = "Load Info";
            btnPopulateInfo.TextAlignment = StringAlignment.Center;
            // 
            // labelEdit12
            // 
            labelEdit12.AutoSize = true;
            labelEdit12.BackColor = Color.Transparent;
            labelEdit12.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit12.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit12.Location = new Point(5, 370);
            labelEdit12.Name = "labelEdit12";
            labelEdit12.Size = new Size(62, 24);
            labelEdit12.TabIndex = 13;
            labelEdit12.Text = "Other:";
            // 
            // checkIsLockedInfo
            // 
            checkIsLockedInfo.AutoSize = true;
            checkIsLockedInfo.ForeColor = Color.FromArgb(116, 125, 132);
            checkIsLockedInfo.Location = new Point(5, 400);
            checkIsLockedInfo.Name = "checkIsLockedInfo";
            checkIsLockedInfo.Size = new Size(85, 25);
            checkIsLockedInfo.TabIndex = 12;
            checkIsLockedInfo.Text = "Locked?";
            checkIsLockedInfo.UseVisualStyleBackColor = true;
            // 
            // checkIsTeamsInfo
            // 
            checkIsTeamsInfo.AutoSize = true;
            checkIsTeamsInfo.ForeColor = Color.FromArgb(116, 125, 132);
            checkIsTeamsInfo.Location = new Point(113, 400);
            checkIsTeamsInfo.Name = "checkIsTeamsInfo";
            checkIsTeamsInfo.Size = new Size(79, 25);
            checkIsTeamsInfo.TabIndex = 11;
            checkIsTeamsInfo.Text = "Teams?";
            checkIsTeamsInfo.UseVisualStyleBackColor = true;
            // 
            // txtSizeInfo
            // 
            txtSizeInfo.BackColor = Color.Transparent;
            txtSizeInfo.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSizeInfo.ForeColor = Color.FromArgb(176, 183, 191);
            txtSizeInfo.Image = null;
            txtSizeInfo.Location = new Point(5, 317);
            txtSizeInfo.MaxLength = 32767;
            txtSizeInfo.Multiline = false;
            txtSizeInfo.Name = "txtSizeInfo";
            txtSizeInfo.ReadOnly = false;
            txtSizeInfo.Size = new Size(420, 43);
            txtSizeInfo.TabIndex = 10;
            txtSizeInfo.TextAlignment = HorizontalAlignment.Left;
            txtSizeInfo.UseSystemPasswordChar = false;
            // 
            // labelEdit11
            // 
            labelEdit11.AutoSize = true;
            labelEdit11.BackColor = Color.Transparent;
            labelEdit11.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit11.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit11.Location = new Point(5, 290);
            labelEdit11.Name = "labelEdit11";
            labelEdit11.Size = new Size(159, 24);
            labelEdit11.TabIndex = 9;
            labelEdit11.Text = "Tournament Size:";
            // 
            // txtTypeInfo
            // 
            txtTypeInfo.AllowDrop = true;
            txtTypeInfo.BackColor = Color.Transparent;
            txtTypeInfo.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTypeInfo.ForeColor = Color.FromArgb(176, 183, 191);
            txtTypeInfo.Image = null;
            txtTypeInfo.Location = new Point(5, 240);
            txtTypeInfo.MaxLength = 32767;
            txtTypeInfo.Multiline = false;
            txtTypeInfo.Name = "txtTypeInfo";
            txtTypeInfo.ReadOnly = true;
            txtTypeInfo.Size = new Size(420, 43);
            txtTypeInfo.TabIndex = 8;
            txtTypeInfo.TextAlignment = HorizontalAlignment.Left;
            txtTypeInfo.UseSystemPasswordChar = false;
            // 
            // labelEdit10
            // 
            labelEdit10.AutoSize = true;
            labelEdit10.BackColor = Color.Transparent;
            labelEdit10.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit10.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit10.Location = new Point(5, 210);
            labelEdit10.Name = "labelEdit10";
            labelEdit10.Size = new Size(166, 24);
            labelEdit10.TabIndex = 7;
            labelEdit10.Text = "Tournament Type:";
            // 
            // txtDateInfo
            // 
            txtDateInfo.BackColor = Color.Transparent;
            txtDateInfo.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDateInfo.ForeColor = Color.FromArgb(176, 183, 191);
            txtDateInfo.Image = null;
            txtDateInfo.Location = new Point(5, 160);
            txtDateInfo.MaxLength = 32767;
            txtDateInfo.Multiline = false;
            txtDateInfo.Name = "txtDateInfo";
            txtDateInfo.ReadOnly = false;
            txtDateInfo.Size = new Size(420, 43);
            txtDateInfo.TabIndex = 6;
            txtDateInfo.TextAlignment = HorizontalAlignment.Left;
            txtDateInfo.UseSystemPasswordChar = false;
            // 
            // labelEdit9
            // 
            labelEdit9.AutoSize = true;
            labelEdit9.BackColor = Color.Transparent;
            labelEdit9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit9.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit9.Location = new Point(5, 130);
            labelEdit9.Name = "labelEdit9";
            labelEdit9.Size = new Size(161, 24);
            labelEdit9.TabIndex = 5;
            labelEdit9.Text = "Tournament Date:";
            // 
            // txtNameInfo
            // 
            txtNameInfo.BackColor = Color.Transparent;
            txtNameInfo.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNameInfo.ForeColor = Color.FromArgb(176, 183, 191);
            txtNameInfo.Image = null;
            txtNameInfo.Location = new Point(5, 80);
            txtNameInfo.MaxLength = 32767;
            txtNameInfo.Multiline = false;
            txtNameInfo.Name = "txtNameInfo";
            txtNameInfo.ReadOnly = false;
            txtNameInfo.Size = new Size(420, 43);
            txtNameInfo.TabIndex = 4;
            txtNameInfo.TextAlignment = HorizontalAlignment.Left;
            txtNameInfo.UseSystemPasswordChar = false;
            // 
            // labelEdit5
            // 
            labelEdit5.AutoSize = true;
            labelEdit5.BackColor = Color.Transparent;
            labelEdit5.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelEdit5.ForeColor = Color.FromArgb(116, 125, 132);
            labelEdit5.Location = new Point(5, 50);
            labelEdit5.Name = "labelEdit5";
            labelEdit5.Size = new Size(174, 24);
            labelEdit5.TabIndex = 3;
            labelEdit5.Text = "Tournament Name:";
            // 
            // Infomation
            // 
            Infomation.AutoSize = true;
            Infomation.BackColor = Color.Transparent;
            Infomation.Font = new Font("Segoe UI", 25F);
            Infomation.ForeColor = Color.White;
            Infomation.Location = new Point(0, 0);
            Infomation.Name = "Infomation";
            Infomation.Size = new Size(191, 46);
            Infomation.TabIndex = 0;
            Infomation.Text = "Infomation:";
            // 
            // playerPage
            // 
            playerPage.BackColor = Color.Transparent;
            playerPage.Location = new Point(124, 4);
            playerPage.Name = "playerPage";
            playerPage.Size = new Size(672, 452);
            playerPage.TabIndex = 2;
            playerPage.Text = "Players";
            // 
            // teamPage
            // 
            teamPage.BackColor = Color.Transparent;
            teamPage.Location = new Point(124, 4);
            teamPage.Name = "teamPage";
            teamPage.Size = new Size(672, 452);
            teamPage.TabIndex = 3;
            teamPage.Text = "Teams";
            // 
            // matchPage
            // 
            matchPage.BackColor = Color.Transparent;
            matchPage.Location = new Point(124, 4);
            matchPage.Name = "matchPage";
            matchPage.Size = new Size(672, 452);
            matchPage.TabIndex = 4;
            matchPage.Text = "Matches";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(40, 50, 60);
            panelHeader.Controls.Add(bigLabel3);
            panelHeader.Controls.Add(btnMinimise);
            panelHeader.Controls.Add(btnClose);
            panelHeader.EdgeColor = Color.FromArgb(40, 50, 60);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(5);
            panelHeader.Size = new Size(800, 40);
            panelHeader.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.Default;
            panelHeader.TabIndex = 1;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // bigLabel3
            // 
            bigLabel3.AutoSize = true;
            bigLabel3.BackColor = Color.Transparent;
            bigLabel3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            bigLabel3.ForeColor = Color.White;
            bigLabel3.ImageAlign = ContentAlignment.MiddleLeft;
            bigLabel3.Location = new Point(0, 0);
            bigLabel3.Name = "bigLabel3";
            bigLabel3.Size = new Size(220, 30);
            bigLabel3.TabIndex = 13;
            bigLabel3.Text = "Tangerine Tournament";
            bigLabel3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnMinimise
            // 
            btnMinimise.BackColor = Color.Transparent;
            btnMinimise.BorderColor = Color.Transparent;
            btnMinimise.EnteredBorderColor = Color.Transparent;
            btnMinimise.EnteredColor = SystemColors.ControlDarkDark;
            btnMinimise.Font = new Font("Segoe Fluent Icons", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimise.Image = null;
            btnMinimise.ImageAlign = ContentAlignment.MiddleCenter;
            btnMinimise.InactiveColor = Color.Transparent;
            btnMinimise.Location = new Point(720, 0);
            btnMinimise.Margin = new Padding(0);
            btnMinimise.Name = "btnMinimise";
            btnMinimise.PressedBorderColor = Color.Transparent;
            btnMinimise.PressedColor = Color.Transparent;
            btnMinimise.Size = new Size(40, 40);
            btnMinimise.TabIndex = 1;
            btnMinimise.Text = "";
            btnMinimise.TextAlignment = StringAlignment.Center;
            btnMinimise.Click += btnMinimise_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BorderColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.EnteredBorderColor = Color.Transparent;
            btnClose.EnteredColor = Color.Red;
            btnClose.Font = new Font("Segoe Fluent Icons", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Image = null;
            btnClose.ImageAlign = ContentAlignment.MiddleCenter;
            btnClose.InactiveColor = Color.Transparent;
            btnClose.Location = new Point(760, 0);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.PressedBorderColor = Color.Transparent;
            btnClose.PressedColor = Color.Transparent;
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 0;
            btnClose.Text = "";
            btnClose.TextAlignment = StringAlignment.Center;
            btnClose.Click += btnClose_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(panelHeader);
            Controls.Add(tabPage1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            tabPage1.ResumeLayout(false);
            connectionPage.ResumeLayout(false);
            connectionPage.PerformLayout();
            createPage.ResumeLayout(false);
            createPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTournamentSize).EndInit();
            infoPage.ResumeLayout(false);
            infoPage.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.TabPage tabPage1;
        private TabPage connectionPage;
        private TabPage infoPage;
        private ReaLTaiizor.Controls.Panel panelHeader;
        private ReaLTaiizor.Controls.Button btnClose;
        private TabPage playerPage;
        private TabPage teamPage;
        private TabPage matchPage;
        private ReaLTaiizor.Controls.Button btnMinimise;
        private ReaLTaiizor.Controls.Button btnOpenFile;
        private ReaLTaiizor.Controls.LabelEdit labelEdit1;
        private ReaLTaiizor.Controls.TextBoxEdit txtConnectTournament;
        private ReaLTaiizor.Controls.BigLabel bigLabel1;
        private ReaLTaiizor.Controls.Button btnConnect;     
        private ReaLTaiizor.Controls.LabelEdit labelEdit4;
        private ReaLTaiizor.Controls.LabelEdit labelEdit3;
        private ReaLTaiizor.Controls.TextBoxEdit txtURL;
        private ReaLTaiizor.Controls.LabelEdit labelEdit2;
        private ReaLTaiizor.Controls.BigLabel bigLabel2;
        private ReaLTaiizor.Controls.Button btnShowPassword;
        private ReaLTaiizor.Controls.BigLabel bigLabel3;
        private RadioButton rbtnRemoteFile;
        private RadioButton rbtnLocalFile;
        private ReaLTaiizor.Controls.TextBoxEdit txtPassword;
        private ReaLTaiizor.Controls.TextBoxEdit txtUsername;
        private TabPage createPage;
        private ReaLTaiizor.Controls.TextBoxEdit txtTournamentName;
        private ReaLTaiizor.Controls.LabelEdit labelEdit6;
        private ReaLTaiizor.Controls.TextBoxEdit txtSize;
        private ReaLTaiizor.Controls.LabelEdit labelEdit8;
        private RadioButton radioButton3;
        private ReaLTaiizor.Controls.LabelEdit labelEdit7;
        private RadioButton radioButton2;
        private RadioButton rbtnSingleElim;
        private ReaLTaiizor.Controls.Button btnCreate;
        private ReaLTaiizor.Controls.CrownNumeric numTournamentSize;
        private ReaLTaiizor.Controls.Button btnConnectDatabase;
        private ReaLTaiizor.Controls.BigLabel Infomation;
        private ReaLTaiizor.Controls.TextBoxEdit txtSizeInfo;
        private ReaLTaiizor.Controls.LabelEdit labelEdit11;
        private ReaLTaiizor.Controls.TextBoxEdit txtTypeInfo;
        private ReaLTaiizor.Controls.LabelEdit labelEdit10;
        private ReaLTaiizor.Controls.TextBoxEdit txtDateInfo;
        private ReaLTaiizor.Controls.LabelEdit labelEdit9;
        private ReaLTaiizor.Controls.TextBoxEdit txtNameInfo;
        private ReaLTaiizor.Controls.LabelEdit labelEdit5;
        private ReaLTaiizor.Controls.LabelEdit labelEdit12;
        private CheckBox checkIsLockedInfo;
        private CheckBox checkIsTeamsInfo;
        private ReaLTaiizor.Controls.Button btnUpdateInfo;
        private ReaLTaiizor.Controls.Button btnPopulateInfo;
    }
}