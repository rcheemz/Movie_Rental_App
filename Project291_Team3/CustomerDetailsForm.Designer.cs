namespace Project291_Team3
{
    partial class CustomerDetailsForm
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
            phoneNumberLabel = new Label();
            cityLabel = new Label();
            emailLabel = new Label();
            zipLabel = new Label();
            countryLabel = new Label();
            stateLabel = new Label();
            streetLabel = new Label();
            lastNameLabel = new Label();
            firstNameLabel = new Label();
            accountNumberLabel = new Label();
            SuspendLayout();
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Location = new Point(98, 313);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(154, 30);
            phoneNumberLabel.TabIndex = 29;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Location = new Point(570, 144);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(48, 30);
            cityLabel.TabIndex = 28;
            cityLabel.Text = "City";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(425, 231);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(63, 30);
            emailLabel.TabIndex = 27;
            emailLabel.Text = "Email";
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Location = new Point(425, 144);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(43, 30);
            zipLabel.TabIndex = 25;
            zipLabel.Text = "ZIP";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Location = new Point(100, 231);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(86, 30);
            countryLabel.TabIndex = 24;
            countryLabel.Text = "Country";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Location = new Point(267, 231);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(59, 30);
            stateLabel.TabIndex = 23;
            stateLabel.Text = "State";
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Location = new Point(100, 144);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new Size(66, 30);
            streetLabel.TabIndex = 22;
            streetLabel.Text = "Street";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(445, 68);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(112, 30);
            lastNameLabel.TabIndex = 21;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(93, 68);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(113, 30);
            firstNameLabel.TabIndex = 20;
            firstNameLabel.Text = "First Name";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Location = new Point(591, 9);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new Size(172, 30);
            accountNumberLabel.TabIndex = 30;
            accountNumberLabel.Text = "Account Number";
            // 
            // CustomerDetailsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(accountNumberLabel);
            Controls.Add(phoneNumberLabel);
            Controls.Add(cityLabel);
            Controls.Add(emailLabel);
            Controls.Add(zipLabel);
            Controls.Add(countryLabel);
            Controls.Add(stateLabel);
            Controls.Add(streetLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameLabel);
            Name = "CustomerDetailsForm";
            Text = "CustomerDetailsForm";
            Load += CustomerDetailsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label phoneNumberLabel;
        private Label cityLabel;
        private Label emailLabel;
        private Label zipLabel;
        private Label countryLabel;
        private Label stateLabel;
        private Label streetLabel;
        private Label lastNameLabel;
        private Label firstNameLabel;
        private Label accountNumberLabel;
    }
}