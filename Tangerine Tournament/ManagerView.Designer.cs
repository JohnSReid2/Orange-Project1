namespace Tangerine_Tournament
{
    partial class ManagerView
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
            btnCreate = new Button();
            btnConnect = new Button();
            btnLoad = new Button();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(12, 12);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(124, 67);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create Tournament";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(142, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(120, 67);
            btnConnect.TabIndex = 1;
            btnConnect.Text = "Connect to Tournament";
            btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(268, 12);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(119, 67);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Load Tournament";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // ManagerView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 91);
            Controls.Add(btnLoad);
            Controls.Add(btnConnect);
            Controls.Add(btnCreate);
            Name = "ManagerView";
            Text = "ManagerView";
            ResumeLayout(false);
        }

        #endregion

        private Button btnCreate;
        private Button btnConnect;
        private Button btnLoad;
    }
}