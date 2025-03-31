namespace Project291_Team3
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            customerButton = new Button();
            movieButton = new Button();
            orderButton = new Button();
            reportsButton = new Button();
            logoutButton = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // customerButton
            // 
            customerButton.Font = new Font("Berlin Sans FB", 20.1428585F);
            customerButton.Location = new Point(505, 168);
            customerButton.Name = "customerButton";
            customerButton.Size = new Size(688, 106);
            customerButton.TabIndex = 0;
            customerButton.Text = "Manage Customers";
            customerButton.UseVisualStyleBackColor = true;
            customerButton.Click += customerButton_Click;
            // 
            // movieButton
            // 
            movieButton.Font = new Font("Berlin Sans FB", 20.1428585F);
            movieButton.Location = new Point(505, 282);
            movieButton.Name = "movieButton";
            movieButton.Size = new Size(688, 106);
            movieButton.TabIndex = 1;
            movieButton.Text = "Manage Movies";
            movieButton.UseVisualStyleBackColor = true;
            // 
            // orderButton
            // 
            orderButton.Font = new Font("Berlin Sans FB", 20.1428585F);
            orderButton.Location = new Point(505, 394);
            orderButton.Name = "orderButton";
            orderButton.Size = new Size(688, 106);
            orderButton.TabIndex = 2;
            orderButton.Text = "Rentals";
            orderButton.UseVisualStyleBackColor = true;
            // 
            // reportsButton
            // 
            reportsButton.Font = new Font("Berlin Sans FB", 20.1428585F);
            reportsButton.Location = new Point(505, 506);
            reportsButton.Name = "reportsButton";
            reportsButton.Size = new Size(688, 106);
            reportsButton.TabIndex = 3;
            reportsButton.Text = "View Reports";
            reportsButton.UseVisualStyleBackColor = true;
            // 
            // logoutButton
            // 
            logoutButton.BackColor = Color.White;
            logoutButton.Font = new Font("Berlin Sans FB", 20.1428585F);
            logoutButton.ForeColor = Color.Red;
            logoutButton.Location = new Point(634, 618);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(448, 106);
            logoutButton.TabIndex = 4;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.NavajoWhite;
            label1.Font = new Font("Berlin Sans FB", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(587, 27);
            label1.Name = "label1";
            label1.Size = new Size(561, 124);
            label1.TabIndex = 5;
            label1.Text = "Dashboard";
            label1.Click += label1_Click;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.AntiqueWhite;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(label1);
            Controls.Add(logoutButton);
            Controls.Add(reportsButton);
            Controls.Add(orderButton);
            Controls.Add(movieButton);
            Controls.Add(customerButton);
            Name = "HomePage";
            Text = "HomePage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button customerButton;
        private Button movieButton;
        private Button orderButton;
        private Button reportsButton;
        private Button logoutButton;
        private Label label1;
    }
}