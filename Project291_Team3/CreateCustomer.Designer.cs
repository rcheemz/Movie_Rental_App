namespace Project291_Team3
{
    partial class CreateCustomer
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            firstNameInput = new TextBox();
            lastNameInput = new TextBox();
            streetInput = new TextBox();
            zipInput = new TextBox();
            cityInput = new TextBox();
            stateInput = new TextBox();
            emailInput = new TextBox();
            phoneInput = new TextBox();
            creditInput = new TextBox();
            createButton = new Button();
            comboBox1 = new ComboBox();
            label11 = new Label();
            comboBox2 = new ComboBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(159, 121);
            label1.Name = "label1";
            label1.Size = new Size(113, 30);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(512, 121);
            label2.Name = "label2";
            label2.Size = new Size(112, 30);
            label2.TabIndex = 1;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(393, 309);
            label3.Name = "label3";
            label3.Size = new Size(59, 30);
            label3.TabIndex = 3;
            label3.Text = "State";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(160, 222);
            label4.Name = "label4";
            label4.Size = new Size(66, 30);
            label4.TabIndex = 2;
            label4.Text = "Street";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(160, 309);
            label5.Name = "label5";
            label5.Size = new Size(86, 30);
            label5.TabIndex = 4;
            label5.Text = "Country";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(485, 222);
            label6.Name = "label6";
            label6.Size = new Size(43, 30);
            label6.TabIndex = 5;
            label6.Text = "ZIP";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(160, 473);
            label7.Name = "label7";
            label7.Size = new Size(199, 30);
            label7.TabIndex = 6;
            label7.Text = "Credit Card Number";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(485, 309);
            label8.Name = "label8";
            label8.Size = new Size(63, 30);
            label8.TabIndex = 7;
            label8.Text = "Email";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(630, 222);
            label9.Name = "label9";
            label9.Size = new Size(48, 30);
            label9.TabIndex = 8;
            label9.Text = "City";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(158, 391);
            label10.Name = "label10";
            label10.Size = new Size(160, 30);
            label10.TabIndex = 9;
            label10.Text = "Phone Number ";
            label10.Click += label10_Click;
            // 
            // firstNameInput
            // 
            firstNameInput.Location = new Point(158, 83);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.Size = new Size(294, 35);
            firstNameInput.TabIndex = 10;
            firstNameInput.TextChanged += firstNameInput_TextChanged;
            // 
            // lastNameInput
            // 
            lastNameInput.Location = new Point(512, 83);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.Size = new Size(294, 35);
            lastNameInput.TabIndex = 11;
            lastNameInput.TextChanged += lastNameInput_TextChanged;
            // 
            // streetInput
            // 
            streetInput.Location = new Point(160, 171);
            streetInput.Name = "streetInput";
            streetInput.Size = new Size(294, 35);
            streetInput.TabIndex = 12;
            streetInput.TextChanged += streetInput_TextChanged;
            // 
            // zipInput
            // 
            zipInput.Location = new Point(485, 171);
            zipInput.Name = "zipInput";
            zipInput.Size = new Size(123, 35);
            zipInput.TabIndex = 13;
            // 
            // cityInput
            // 
            cityInput.Location = new Point(630, 171);
            cityInput.Name = "cityInput";
            cityInput.Size = new Size(176, 35);
            cityInput.TabIndex = 14;
            // 
            // stateInput
            // 
            stateInput.Location = new Point(395, 271);
            stateInput.Name = "stateInput";
            stateInput.Size = new Size(59, 35);
            stateInput.TabIndex = 16;
            // 
            // emailInput
            // 
            emailInput.Location = new Point(485, 271);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(321, 35);
            emailInput.TabIndex = 17;
            // 
            // phoneInput
            // 
            phoneInput.Location = new Point(158, 353);
            phoneInput.Name = "phoneInput";
            phoneInput.Size = new Size(321, 35);
            phoneInput.TabIndex = 18;
            // 
            // creditInput
            // 
            creditInput.Location = new Point(160, 435);
            creditInput.Name = "creditInput";
            creditInput.Size = new Size(321, 35);
            creditInput.TabIndex = 19;
            // 
            // createButton
            // 
            createButton.Location = new Point(393, 532);
            createButton.Name = "createButton";
            createButton.Size = new Size(131, 40);
            createButton.TabIndex = 20;
            createButton.Text = "Create";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(158, 271);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(212, 38);
            comboBox1.TabIndex = 21;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(499, 391);
            label11.Name = "label11";
            label11.Size = new Size(56, 30);
            label11.TabIndex = 22;
            label11.Text = "Type";
            label11.Click += label11_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(499, 350);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(109, 38);
            comboBox2.TabIndex = 23;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(630, 348);
            button1.Name = "button1";
            button1.Size = new Size(36, 40);
            button1.TabIndex = 24;
            button1.Text = "+";
            button1.UseVisualStyleBackColor = true;
            // 
            // CreateCustomer
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 657);
            Controls.Add(button1);
            Controls.Add(comboBox2);
            Controls.Add(label11);
            Controls.Add(comboBox1);
            Controls.Add(createButton);
            Controls.Add(creditInput);
            Controls.Add(phoneInput);
            Controls.Add(emailInput);
            Controls.Add(stateInput);
            Controls.Add(cityInput);
            Controls.Add(zipInput);
            Controls.Add(streetInput);
            Controls.Add(lastNameInput);
            Controls.Add(firstNameInput);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CreateCustomer";
            Text = "Create Customer";
            Load += CreateCustomer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox firstNameInput;
        private TextBox lastNameInput;
        private TextBox streetInput;
        private TextBox zipInput;
        private TextBox cityInput;
        private TextBox stateInput;
        private TextBox emailInput;
        private TextBox phoneInput;
        private TextBox creditInput;
        private Button createButton;
        private ComboBox comboBox1;
        private Label label11;
        private ComboBox comboBox2;
        private Button button1;
    }
}