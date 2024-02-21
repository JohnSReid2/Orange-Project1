namespace Tangerine_Tournament
{
    partial class CreateTournament
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
            txtTournamentName = new TextBox();
            checkSingleElim = new CheckBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtTournamentName
            // 
            txtTournamentName.Location = new Point(12, 12);
            txtTournamentName.Name = "txtTournamentName";
            txtTournamentName.Size = new Size(160, 31);
            txtTournamentName.TabIndex = 0;
            // 
            // checkSingleElim
            // 
            checkSingleElim.AutoSize = true;
            checkSingleElim.Location = new Point(12, 49);
            checkSingleElim.Name = "checkSingleElim";
            checkSingleElim.Size = new Size(178, 29);
            checkSingleElim.TabIndex = 1;
            checkSingleElim.Text = "Single Elimination";
            checkSingleElim.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(12, 84);
            button1.Name = "button1";
            button1.Size = new Size(160, 34);
            button1.TabIndex = 2;
            button1.Text = "Create";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CreateTournament
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(checkSingleElim);
            Controls.Add(txtTournamentName);
            Name = "CreateTournament";
            Text = "CreateTournament";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTournamentName;
        private CheckBox checkSingleElim;
        private Button button1;
    }
}