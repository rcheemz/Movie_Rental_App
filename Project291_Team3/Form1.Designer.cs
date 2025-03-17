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
            usernameLabel = new Label();
            username = new TextBox();
            password = new TextBox();
            passwordLabel = new Label();
            loginButton = new Button();
            SuspendLayout();
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(223, 124);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(135, 30);
            usernameLabel.TabIndex = 0;
            usernameLabel.Text = "Username    :";
            usernameLabel.Click += usernameLabel_Click;
            // 
            // username
            // 
            username.Location = new Point(364, 124);
            username.Name = "username";
            username.Size = new Size(175, 35);
            username.TabIndex = 1;
            username.TextChanged += username_TextChanged;
            // 
            // password
            // 
            password.Location = new Point(364, 165);
            password.Name = "password";
            password.Size = new Size(175, 35);
            password.TabIndex = 3;
            password.TextChanged += password_TextChanged;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(224, 165);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(134, 30);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password     :";
            passwordLabel.Click += passwordLabel_Click;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(387, 217);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(131, 40);
            loginButton.TabIndex = 4;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(loginButton);
            Controls.Add(password);
            Controls.Add(passwordLabel);
            Controls.Add(username);
            Controls.Add(usernameLabel);
            Name = "Form1";
            Text = "Login";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label usernameLabel;
        private TextBox username;
        private TextBox password;
        private Label passwordLabel;
        private Button loginButton;
    }
}
