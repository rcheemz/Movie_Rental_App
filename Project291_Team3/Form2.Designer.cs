namespace Project291_Team3
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            createNewCustomer = new Button();
            customerPhoneInput = new TextBox();
            bindingSource1 = new BindingSource(components);
            customerSearchButton = new Button();
            customerDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // createNewCustomer
            // 
            createNewCustomer.Font = new Font("Berlin Sans FB", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createNewCustomer.Location = new Point(551, 569);
            createNewCustomer.Name = "createNewCustomer";
            createNewCustomer.Size = new Size(485, 40);
            createNewCustomer.TabIndex = 0;
            createNewCustomer.Text = "Create New Customer";
            createNewCustomer.UseVisualStyleBackColor = true;
            createNewCustomer.Click += createNewCustomer_Click;
            // 
            // customerPhoneInput
            // 
            customerPhoneInput.Font = new Font("Berlin Sans FB", 14.1428576F);
            customerPhoneInput.Location = new Point(389, 170);
            customerPhoneInput.Name = "customerPhoneInput";
            customerPhoneInput.Size = new Size(667, 44);
            customerPhoneInput.TabIndex = 1;
            customerPhoneInput.TextChanged += customerPhoneInput_TextChanged;
            // 
            // customerSearchButton
            // 
            customerSearchButton.Font = new Font("Berlin Sans FB", 14.1428576F);
            customerSearchButton.Location = new Point(1062, 170);
            customerSearchButton.Name = "customerSearchButton";
            customerSearchButton.Size = new Size(131, 44);
            customerSearchButton.TabIndex = 2;
            customerSearchButton.Text = "Search";
            customerSearchButton.UseVisualStyleBackColor = true;
            customerSearchButton.Click += customerSearchButton_Click;
            // 
            // customerDataGridView
            // 
            customerDataGridView.BackgroundColor = Color.Tan;
            customerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDataGridView.Location = new Point(389, 220);
            customerDataGridView.Name = "customerDataGridView";
            customerDataGridView.RowHeadersWidth = 72;
            customerDataGridView.Size = new Size(804, 330);
            customerDataGridView.TabIndex = 3;
            customerDataGridView.CellContentClick += customerDataGridView_CellDoubleClick;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(customerDataGridView);
            Controls.Add(customerSearchButton);
            Controls.Add(customerPhoneInput);
            Controls.Add(createNewCustomer);
            Name = "Form2";
            Text = "Customer Search Page";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)customerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button createNewCustomer;
        private TextBox customerPhoneInput;
        private BindingSource bindingSource1;
        private Button customerSearchButton;
        private DataGridView customerDataGridView;
    }
}