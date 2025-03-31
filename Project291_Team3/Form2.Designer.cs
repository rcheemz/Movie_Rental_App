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
            back = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)customerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // createNewCustomer
            // 
            createNewCustomer.Font = new Font("Berlin Sans FB", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createNewCustomer.Location = new Point(580, 612);
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
            customerPhoneInput.Location = new Point(418, 213);
            customerPhoneInput.Name = "customerPhoneInput";
            customerPhoneInput.Size = new Size(667, 44);
            customerPhoneInput.TabIndex = 1;
            customerPhoneInput.TextChanged += customerPhoneInput_TextChanged;
            // 
            // customerSearchButton
            // 
            customerSearchButton.Font = new Font("Berlin Sans FB", 14.1428576F);
            customerSearchButton.Location = new Point(1091, 213);
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
            customerDataGridView.Location = new Point(418, 263);
            customerDataGridView.Name = "customerDataGridView";
            customerDataGridView.RowHeadersWidth = 72;
            customerDataGridView.Size = new Size(804, 330);
            customerDataGridView.TabIndex = 3;
            customerDataGridView.CellContentClick += customerDataGridView_CellDoubleClick;
            // 
            // back
            // 
            back.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back.Location = new Point(168, 61);
            back.Name = "back";
            back.Size = new Size(131, 40);
            back.TabIndex = 4;
            back.Text = "BACK";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Tan;
            label1.Font = new Font("Berlin Sans FB", 27.8571434F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(584, 95);
            label1.Name = "label1";
            label1.Size = new Size(481, 72);
            label1.TabIndex = 14;
            label1.Text = "Customer Search";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(label1);
            Controls.Add(back);
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
        private Button back;
        private Label label1;
    }
}