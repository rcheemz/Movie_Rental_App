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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            newOrder = new Button();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            phoneNumberLabel.Location = new Point(485, 440);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(227, 37);
            phoneNumberLabel.TabIndex = 29;
            phoneNumberLabel.Text = "Phone Number";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            cityLabel.Location = new Point(1094, 258);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(71, 37);
            cityLabel.TabIndex = 28;
            cityLabel.Text = "City";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            emailLabel.Location = new Point(1094, 345);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(94, 37);
            emailLabel.TabIndex = 27;
            emailLabel.Text = "Email";
            // 
            // zipLabel
            // 
            zipLabel.AutoSize = true;
            zipLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            zipLabel.Location = new Point(848, 258);
            zipLabel.Name = "zipLabel";
            zipLabel.Size = new Size(63, 37);
            zipLabel.TabIndex = 25;
            zipLabel.Text = "ZIP";
            // 
            // countryLabel
            // 
            countryLabel.AutoSize = true;
            countryLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            countryLabel.Location = new Point(485, 345);
            countryLabel.Name = "countryLabel";
            countryLabel.Size = new Size(127, 37);
            countryLabel.TabIndex = 24;
            countryLabel.Text = "Country";
            // 
            // stateLabel
            // 
            stateLabel.AutoSize = true;
            stateLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            stateLabel.Location = new Point(848, 345);
            stateLabel.Name = "stateLabel";
            stateLabel.Size = new Size(88, 37);
            stateLabel.TabIndex = 23;
            stateLabel.Text = "State";
            // 
            // streetLabel
            // 
            streetLabel.AutoSize = true;
            streetLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            streetLabel.Location = new Point(485, 258);
            streetLabel.Name = "streetLabel";
            streetLabel.Size = new Size(97, 37);
            streetLabel.TabIndex = 22;
            streetLabel.Text = "Street";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastNameLabel.Location = new Point(485, 173);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(176, 38);
            lastNameLabel.TabIndex = 21;
            lastNameLabel.Text = "Last Name";
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            firstNameLabel.Location = new Point(485, 109);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(180, 38);
            firstNameLabel.TabIndex = 20;
            firstNameLabel.Text = "First Name";
            // 
            // accountNumberLabel
            // 
            accountNumberLabel.AutoSize = true;
            accountNumberLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            accountNumberLabel.Location = new Point(1218, 57);
            accountNumberLabel.Name = "accountNumberLabel";
            accountNumberLabel.Size = new Size(250, 37);
            accountNumberLabel.TabIndex = 30;
            accountNumberLabel.Text = "Account Number";
            // 
            // editButton
            // 
            editButton.Font = new Font("Berlin Sans FB", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editButton.Location = new Point(749, 556);
            editButton.Name = "editButton";
            editButton.Size = new Size(162, 61);
            editButton.TabIndex = 31;
            editButton.Text = "EDIT";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(-6, -1);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1679, 782);
            tabControl1.TabIndex = 32;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.NavajoWhite;
            tabPage1.Controls.Add(accountNumberLabel);
            tabPage1.Controls.Add(editButton);
            tabPage1.Controls.Add(firstNameLabel);
            tabPage1.Controls.Add(lastNameLabel);
            tabPage1.Controls.Add(phoneNumberLabel);
            tabPage1.Controls.Add(streetLabel);
            tabPage1.Controls.Add(cityLabel);
            tabPage1.Controls.Add(stateLabel);
            tabPage1.Controls.Add(emailLabel);
            tabPage1.Controls.Add(countryLabel);
            tabPage1.Controls.Add(zipLabel);
            tabPage1.Location = new Point(4, 39);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1671, 739);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.Click += tabPage1_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.NavajoWhite;
            tabPage2.Controls.Add(newOrder);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 39);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1671, 739);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.Click += tabPage2_Click;
            // 
            // newOrder
            // 
            newOrder.Font = new Font("Berlin Sans FB", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            newOrder.Location = new Point(518, 517);
            newOrder.Name = "newOrder";
            newOrder.Size = new Size(480, 66);
            newOrder.TabIndex = 2;
            newOrder.Text = "Place Order";
            newOrder.UseVisualStyleBackColor = true;
            newOrder.Click += newOrder_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(359, 161);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.Size = new Size(796, 314);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Berlin Sans FB", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(325, 112);
            label1.Name = "label1";
            label1.Size = new Size(253, 46);
            label1.TabIndex = 0;
            label1.Text = "Order History";
            // 
            // CustomerDetailsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.NavajoWhite;
            ClientSize = new Size(1667, 780);
            Controls.Add(tabControl1);
            Name = "CustomerDetailsForm";
            Text = "CustomerDetailsForm";
            Load += CustomerDetailsForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private DataGridView dataGridView1;
        private Button newOrder;
    }
}