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
            editButton = new Button();
            SuspendLayout();
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            phoneNumberLabel.Location = new Point(454, 463);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(227, 37);
            phoneNumberLabel.TabIndex = 29;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            cityLabel.Location = new Point(926, 294);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(71, 37);
            cityLabel.TabIndex = 28;
            cityLabel.Text = "City";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            emailLabel.Location = new Point(781, 381);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(94, 37);
            emailLabel.TabIndex = 27;
            emailLabel.Text = "Email";
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            zipLabel.Location = new Point(781, 294);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(63, 37);
            zipLabel.TabIndex = 25;
            zipLabel.Text = "ZIP";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            countryLabel.Location = new Point(456, 381);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(127, 37);
            countryLabel.TabIndex = 24;
            countryLabel.Text = "Country";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            stateLabel.Location = new Point(623, 381);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(88, 37);
            stateLabel.TabIndex = 23;
            stateLabel.Text = "State";
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            streetLabel.Location = new Point(456, 294);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new Size(97, 37);
            streetLabel.TabIndex = 22;
            streetLabel.Text = "Street";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            lastNameLabel.Location = new Point(801, 218);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(166, 37);
            lastNameLabel.TabIndex = 21;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            firstNameLabel.Location = new Point(449, 218);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(167, 37);
            firstNameLabel.TabIndex = 20;
            firstNameLabel.Text = "First Name";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            accountNumberLabel.Location = new Point(947, 159);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new Size(250, 37);
            accountNumberLabel.TabIndex = 30;
            accountNumberLabel.Text = "Account Number";
            // 
            // editButton
            // 
            editButton.Font = new Font("Berlin Sans FB", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editButton.Location = new Point(713, 601);
            editButton.Name = "editButton";
            editButton.Size = new Size(162, 61);
            editButton.TabIndex = 31;
            editButton.Text = "EDIT";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // CustomerDetailsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.NavajoWhite;
            ClientSize = new Size(1667, 780);
            Controls.Add(editButton);
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
        private Button editButton;
    }
}