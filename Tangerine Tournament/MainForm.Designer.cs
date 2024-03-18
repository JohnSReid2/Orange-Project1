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
            infoPage = new TabPage();
            playerPage = new TabPage();
            teamPage = new TabPage();
            matchPage = new TabPage();
            panelHeader = new ReaLTaiizor.Controls.Panel();
            btnMinimise = new ReaLTaiizor.Controls.Button();
            btnClose = new ReaLTaiizor.Controls.Button();
            tabPage1.SuspendLayout();
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
            tabPage1.Location = new Point(0, 67);
            tabPage1.Multiline = true;
            tabPage1.Name = "tabPage1";
            tabPage1.NormalForeColor = Color.FromArgb(159, 162, 167);
            tabPage1.PageColor = Color.Transparent;
            tabPage1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            tabPage1.SelectedIndex = 0;
            tabPage1.Size = new Size(1143, 767);
            tabPage1.SizeMode = TabSizeMode.Fixed;
            tabPage1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            tabPage1.StringType = StringAlignment.Near;
            tabPage1.TabColor = Color.FromArgb(54, 57, 64);
            tabPage1.TabIndex = 0;
            tabPage1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            tabPage1.SelectedIndexChanged += tabPage1_SelectedIndexChanged;
            // 
            // connectionPage
            // 
            connectionPage.BackColor = Color.Transparent;
            connectionPage.Location = new Point(124, 4);
            connectionPage.Name = "connectionPage";
            connectionPage.Padding = new Padding(3, 3, 3, 3);
            connectionPage.Size = new Size(1015, 759);
            connectionPage.TabIndex = 0;
            connectionPage.Text = "Connect";
            // 
            // infoPage
            // 
            infoPage.BackColor = Color.Transparent;
            infoPage.Location = new Point(124, 4);
            infoPage.Name = "infoPage";
            infoPage.Padding = new Padding(3, 3, 3, 3);
            infoPage.Size = new Size(1015, 759);
            infoPage.TabIndex = 1;
            infoPage.Text = "Info";
            // 
            // playerPage
            // 
            playerPage.BackColor = Color.Transparent;
            playerPage.Location = new Point(124, 4);
            playerPage.Margin = new Padding(4, 5, 4, 5);
            playerPage.Name = "playerPage";
            playerPage.Size = new Size(1015, 759);
            playerPage.TabIndex = 2;
            playerPage.Text = "Players";
            // 
            // teamPage
            // 
            teamPage.BackColor = Color.Transparent;
            teamPage.Location = new Point(124, 4);
            teamPage.Margin = new Padding(4, 5, 4, 5);
            teamPage.Name = "teamPage";
            teamPage.Size = new Size(1015, 759);
            teamPage.TabIndex = 3;
            teamPage.Text = "Teams";
            // 
            // matchPage
            // 
            matchPage.BackColor = Color.Transparent;
            matchPage.Location = new Point(124, 4);
            matchPage.Margin = new Padding(4, 5, 4, 5);
            matchPage.Name = "matchPage";
            matchPage.Size = new Size(1015, 759);
            matchPage.TabIndex = 4;
            matchPage.Text = "Matches";
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(40, 50, 60);
            panelHeader.Controls.Add(btnMinimise);
            panelHeader.Controls.Add(btnClose);
            panelHeader.EdgeColor = Color.FromArgb(40, 50, 60);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(7, 8, 7, 8);
            panelHeader.Size = new Size(1143, 67);
            panelHeader.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.Default;
            panelHeader.TabIndex = 1;
            panelHeader.MouseDown += panelHeader_MouseDown;
            panelHeader.MouseMove += panelHeader_MouseMove;
            panelHeader.MouseUp += panelHeader_MouseUp;
            // 
            // btnMinimise
            // 
            btnMinimise.BackColor = Color.Transparent;
            btnMinimise.BorderColor = Color.Transparent;
            btnMinimise.EnteredBorderColor = Color.Transparent;
            btnMinimise.EnteredColor = Color.Transparent;
            btnMinimise.Font = new Font("Segoe Fluent Icons", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMinimise.Image = null;
            btnMinimise.ImageAlign = ContentAlignment.MiddleCenter;
            btnMinimise.InactiveColor = Color.Transparent;
            btnMinimise.Location = new Point(1029, 0);
            btnMinimise.Margin = new Padding(0);
            btnMinimise.Name = "btnMinimise";
            btnMinimise.PressedBorderColor = Color.Transparent;
            btnMinimise.PressedColor = Color.Transparent;
            btnMinimise.Size = new Size(57, 67);
            btnMinimise.TabIndex = 1;
            btnMinimise.Text = "";
            btnMinimise.TextAlignment = StringAlignment.Center;
            btnMinimise.Click += btnMinimise_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.BorderColor = Color.Transparent;
            btnClose.EnteredBorderColor = Color.Transparent;
            btnClose.EnteredColor = Color.Transparent;
            btnClose.Font = new Font("Segoe Fluent Icons", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClose.Image = null;
            btnClose.ImageAlign = ContentAlignment.MiddleCenter;
            btnClose.InactiveColor = Color.Transparent;
            btnClose.Location = new Point(1086, 0);
            btnClose.Margin = new Padding(0);
            btnClose.Name = "btnClose";
            btnClose.PressedBorderColor = Color.Transparent;
            btnClose.PressedColor = Color.Transparent;
            btnClose.Size = new Size(57, 67);
            btnClose.TabIndex = 0;
            btnClose.Text = "";
            btnClose.TextAlignment = StringAlignment.Center;
            btnClose.Click += btnClose_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 833);
            Controls.Add(panelHeader);
            Controls.Add(tabPage1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            tabPage1.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
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
    }
}