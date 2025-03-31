namespace Project291_Team3
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            orderDataGridView = new DataGridView();
            movieSearchButton = new Button();
            movieNameInput = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)orderDataGridView).BeginInit();
            SuspendLayout();
            // 
            // orderDataGridView
            // 
            orderDataGridView.BackgroundColor = Color.Tan;
            orderDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderDataGridView.Location = new Point(445, 308);
            orderDataGridView.Name = "orderDataGridView";
            orderDataGridView.RowHeadersWidth = 72;
            orderDataGridView.Size = new Size(804, 330);
            orderDataGridView.TabIndex = 11;
            orderDataGridView.CellContentClick += orderDataGridView_CellContentClick;
            // 
            // movieSearchButton
            // 
            movieSearchButton.Font = new Font("Berlin Sans FB", 14.1428576F);
            movieSearchButton.Location = new Point(1118, 258);
            movieSearchButton.Name = "movieSearchButton";
            movieSearchButton.Size = new Size(131, 44);
            movieSearchButton.TabIndex = 10;
            movieSearchButton.Text = "Search";
            movieSearchButton.UseVisualStyleBackColor = true;
            movieSearchButton.Click += movieSearchButton_Click;
            // 
            // movieNameInput
            // 
            movieNameInput.Font = new Font("Berlin Sans FB", 14.1428576F);
            movieNameInput.Location = new Point(445, 258);
            movieNameInput.Name = "movieNameInput";
            movieNameInput.Size = new Size(667, 44);
            movieNameInput.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Tan;
            label1.Font = new Font("Berlin Sans FB", 27.8571434F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(606, 137);
            label1.Name = "label1";
            label1.Size = new Size(479, 72);
            label1.TabIndex = 13;
            label1.Text = "Search for Movie";
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(label1);
            Controls.Add(orderDataGridView);
            Controls.Add(movieSearchButton);
            Controls.Add(movieNameInput);
            Name = "OrderForm";
            Text = "OrderForm";
            Load += OrderForm_Load;
            ((System.ComponentModel.ISupportInitialize)orderDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView orderDataGridView;
        private Button movieSearchButton;
        private TextBox movieNameInput;
        private Label label1;
    }
}