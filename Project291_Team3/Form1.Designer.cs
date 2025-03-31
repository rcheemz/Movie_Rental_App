namespace Project291_Team3
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            username = new TextBox();
            password = new TextBox();
            loginButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // username
            // 
            username.Location = new Point(647, 270);
            username.Margin = new Padding(6, 5, 6, 5);
            username.Name = "username";
            username.Size = new Size(360, 59);
            username.TabIndex = 1;
            username.TextChanged += username_TextChanged;
            // 
            // password
            // 
            password.Location = new Point(647, 341);
            password.Margin = new Padding(6, 5, 6, 5);
            password.Name = "password";
            password.Size = new Size(360, 59);
            password.TabIndex = 3;
            password.TextChanged += password_TextChanged;
            // 
            // loginButton
            // 
            loginButton.ForeColor = Color.FromArgb(0, 192, 0);
            loginButton.Location = new Point(695, 431);
            loginButton.Margin = new Padding(6, 5, 6, 5);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(273, 69);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.NavajoWhite;
            label1.Font = new Font("Berlin Sans FB", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(191, 141);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(1252, 92);
            label1.TabIndex = 5;
            label1.Text = "Welcome to The Movie Rental App";
            label1.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(25F, 52F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(label1);
            Controls.Add(loginButton);
            Controls.Add(password);
            Controls.Add(username);
            Font = new Font("Berlin Sans FB", 20.1428585F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(6, 5, 6, 5);
            Name = "Form1";
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox username;
        private TextBox password;
        private Button loginButton;
        private Label label1;
    }
}
