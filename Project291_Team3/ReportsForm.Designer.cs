namespace Project291_Team3
{
    partial class ReportsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportsForm));
            yearInput = new ComboBox();
            monthInput = new ComboBox();
            generateButton = new Button();
            monthlySalesGrid = new DataGridView();
            topCustomersGrid = new DataGridView();
            topMoviesGrid = new DataGridView();
            rentalsByTypeGrid = new DataGridView();
            employeeOfMonthGrid = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            back = new Button();
            ((System.ComponentModel.ISupportInitialize)monthlySalesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)topCustomersGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)topMoviesGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rentalsByTypeGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)employeeOfMonthGrid).BeginInit();
            SuspendLayout();
            // 
            // yearInput
            // 
            yearInput.Font = new Font("Berlin Sans FB", 9.857143F);
            yearInput.FormattingEnabled = true;
            yearInput.Location = new Point(433, 56);
            yearInput.Name = "yearInput";
            yearInput.Size = new Size(212, 34);
            yearInput.TabIndex = 0;
            // 
            // monthInput
            // 
            monthInput.Font = new Font("Berlin Sans FB", 9.857143F);
            monthInput.FormattingEnabled = true;
            monthInput.Location = new Point(674, 56);
            monthInput.Name = "monthInput";
            monthInput.Size = new Size(212, 34);
            monthInput.TabIndex = 1;
            // 
            // generateButton
            // 
            generateButton.Font = new Font("Berlin Sans FB", 9.857143F);
            generateButton.Location = new Point(922, 56);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(131, 40);
            generateButton.TabIndex = 2;
            generateButton.Text = "Generate";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click_1;
            // 
            // monthlySalesGrid
            // 
            monthlySalesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            monthlySalesGrid.Location = new Point(69, 156);
            monthlySalesGrid.Name = "monthlySalesGrid";
            monthlySalesGrid.RowHeadersWidth = 72;
            monthlySalesGrid.Size = new Size(685, 155);
            monthlySalesGrid.TabIndex = 3;
            // 
            // topCustomersGrid
            // 
            topCustomersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            topCustomersGrid.Location = new Point(863, 156);
            topCustomersGrid.Name = "topCustomersGrid";
            topCustomersGrid.RowHeadersWidth = 72;
            topCustomersGrid.Size = new Size(685, 155);
            topCustomersGrid.TabIndex = 4;
            // 
            // topMoviesGrid
            // 
            topMoviesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            topMoviesGrid.Location = new Point(863, 386);
            topMoviesGrid.Name = "topMoviesGrid";
            topMoviesGrid.RowHeadersWidth = 72;
            topMoviesGrid.Size = new Size(685, 155);
            topMoviesGrid.TabIndex = 5;
            topMoviesGrid.CellContentClick += topMoviesGrid_CellContentClick;
            // 
            // rentalsByTypeGrid
            // 
            rentalsByTypeGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rentalsByTypeGrid.Location = new Point(69, 386);
            rentalsByTypeGrid.Name = "rentalsByTypeGrid";
            rentalsByTypeGrid.RowHeadersWidth = 72;
            rentalsByTypeGrid.Size = new Size(685, 155);
            rentalsByTypeGrid.TabIndex = 6;
            // 
            // employeeOfMonthGrid
            // 
            employeeOfMonthGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeeOfMonthGrid.Location = new Point(321, 595);
            employeeOfMonthGrid.Name = "employeeOfMonthGrid";
            employeeOfMonthGrid.RowHeadersWidth = 72;
            employeeOfMonthGrid.Size = new Size(1039, 155);
            employeeOfMonthGrid.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Berlin Sans FB", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(69, 123);
            label1.Name = "label1";
            label1.Size = new Size(221, 26);
            label1.TabIndex = 8;
            label1.Text = "Monthly Sales Report";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Berlin Sans FB", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(69, 353);
            label2.Name = "label2";
            label2.Size = new Size(182, 26);
            label2.TabIndex = 9;
            label2.Text = "Rentals by Genre";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Berlin Sans FB", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(863, 123);
            label3.Name = "label3";
            label3.Size = new Size(240, 26);
            label3.TabIndex = 10;
            label3.Text = "Customer of the Month";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Berlin Sans FB", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(863, 353);
            label4.Name = "label4";
            label4.Size = new Size(206, 26);
            label4.TabIndex = 11;
            label4.Text = "Movie of the Month";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Berlin Sans FB", 9.857143F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(321, 562);
            label5.Name = "label5";
            label5.Size = new Size(244, 26);
            label5.TabIndex = 12;
            label5.Text = "Employee of the Month";
            label5.Click += label5_Click;
            // 
            // back
            // 
            back.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back.Location = new Point(12, 26);
            back.Name = "back";
            back.Size = new Size(131, 40);
            back.TabIndex = 13;
            back.Text = "BACK";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(back);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(employeeOfMonthGrid);
            Controls.Add(rentalsByTypeGrid);
            Controls.Add(topMoviesGrid);
            Controls.Add(topCustomersGrid);
            Controls.Add(monthlySalesGrid);
            Controls.Add(generateButton);
            Controls.Add(monthInput);
            Controls.Add(yearInput);
            Name = "ReportsForm";
            Text = "ReportsForm";
            Load += ReportsForm_Load;
            ((System.ComponentModel.ISupportInitialize)monthlySalesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)topCustomersGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)topMoviesGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)rentalsByTypeGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)employeeOfMonthGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox yearInput;
        private ComboBox monthInput;
        private Button generateButton;
        private DataGridView monthlySalesGrid;
        private DataGridView topCustomersGrid;
        private DataGridView topMoviesGrid;
        private DataGridView rentalsByTypeGrid;
        private DataGridView employeeOfMonthGrid;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button back;
    }
}