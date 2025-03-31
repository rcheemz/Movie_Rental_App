namespace Project291_Team3
{
    partial class OrderPlacementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPlacementForm));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            pictureBox1 = new PictureBox();
            nameLabel = new Label();
            lastNameLabel = new Label();
            movieLabel = new Label();
            employeeLabel = new Label();
            confirmOrderButton = new Button();
            label3 = new Label();
            label5 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.NavajoWhite;
            pictureBox1.Location = new Point(431, 87);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(768, 619);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.BackColor = Color.NavajoWhite;
            nameLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nameLabel.Location = new Point(750, 313);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(180, 38);
            nameLabel.TabIndex = 22;
            nameLabel.Text = "First Name";
            nameLabel.Click += firstNameLabel_Click;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastNameLabel.Location = new Point(1006, 255);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(0, 38);
            lastNameLabel.TabIndex = 23;
            // 
            // movieLabel
            // 
            movieLabel.AutoSize = true;
            movieLabel.BackColor = Color.NavajoWhite;
            movieLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            movieLabel.Location = new Point(750, 215);
            movieLabel.Name = "movieLabel";
            movieLabel.Size = new Size(204, 38);
            movieLabel.TabIndex = 24;
            movieLabel.Text = "Movie Name\r\n";
            // 
            // employeeLabel
            // 
            employeeLabel.AutoSize = true;
            employeeLabel.BackColor = Color.NavajoWhite;
            employeeLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            employeeLabel.Location = new Point(750, 427);
            employeeLabel.Name = "employeeLabel";
            employeeLabel.Size = new Size(164, 38);
            employeeLabel.TabIndex = 25;
            employeeLabel.Text = "Employee";
            // 
            // confirmOrderButton
            // 
            confirmOrderButton.Font = new Font("Berlin Sans FB", 14.1428576F);
            confirmOrderButton.Location = new Point(646, 611);
            confirmOrderButton.Name = "confirmOrderButton";
            confirmOrderButton.Size = new Size(322, 44);
            confirmOrderButton.TabIndex = 26;
            confirmOrderButton.Text = "Confirm Order";
            confirmOrderButton.UseVisualStyleBackColor = true;
            confirmOrderButton.Click += confirmOrderButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.NavajoWhite;
            label3.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(476, 427);
            label3.Name = "label3";
            label3.Size = new Size(172, 38);
            label3.TabIndex = 29;
            label3.Text = "Employee:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.NavajoWhite;
            label5.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(476, 313);
            label5.Name = "label5";
            label5.Size = new Size(166, 38);
            label5.TabIndex = 27;
            label5.Text = "Customer:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.NavajoWhite;
            label4.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(476, 215);
            label4.Name = "label4";
            label4.Size = new Size(114, 38);
            label4.TabIndex = 30;
            label4.Text = "Movie:";
            // 
            // OrderPlacementForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(confirmOrderButton);
            Controls.Add(employeeLabel);
            Controls.Add(movieLabel);
            Controls.Add(nameLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(pictureBox1);
            Name = "OrderPlacementForm";
            Text = "orderPlacementForm";
            Load += orderPlacementForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private PictureBox pictureBox1;
        private Label nameLabel;
        private Label lastNameLabel;
        private Label movieLabel;
        private Label employeeLabel;
        private Button confirmOrderButton;
        private Label label3;
        private Label label5;
        private Label label4;
    }
}