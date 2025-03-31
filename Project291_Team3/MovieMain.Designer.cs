namespace Project291_Team3
{
    partial class MovieMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MovieMain));
            movieDataGridView = new DataGridView();
            movieSearchButton = new Button();
            movieNameInput = new TextBox();
            addNewMovie = new Button();
            back = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)movieDataGridView).BeginInit();
            SuspendLayout();
            // 
            // movieDataGridView
            // 
            movieDataGridView.BackgroundColor = Color.Tan;
            movieDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movieDataGridView.Location = new Point(428, 262);
            movieDataGridView.Name = "movieDataGridView";
            movieDataGridView.RowHeadersWidth = 72;
            movieDataGridView.Size = new Size(804, 330);
            movieDataGridView.TabIndex = 7;
            movieDataGridView.CellContentClick += movieDataGridView_CellContentClick;
            // 
            // movieSearchButton
            // 
            movieSearchButton.Font = new Font("Berlin Sans FB", 14.1428576F);
            movieSearchButton.Location = new Point(1101, 212);
            movieSearchButton.Name = "movieSearchButton";
            movieSearchButton.Size = new Size(131, 44);
            movieSearchButton.TabIndex = 6;
            movieSearchButton.Text = "Search";
            movieSearchButton.UseVisualStyleBackColor = true;
            movieSearchButton.Click += movieSearchButton_Click;
            // 
            // movieNameInput
            // 
            movieNameInput.Font = new Font("Berlin Sans FB", 14.1428576F);
            movieNameInput.Location = new Point(428, 212);
            movieNameInput.Name = "movieNameInput";
            movieNameInput.Size = new Size(667, 44);
            movieNameInput.TabIndex = 5;
            // 
            // addNewMovie
            // 
            addNewMovie.Font = new Font("Berlin Sans FB", 14.1428576F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addNewMovie.Location = new Point(590, 611);
            addNewMovie.Name = "addNewMovie";
            addNewMovie.Size = new Size(485, 40);
            addNewMovie.TabIndex = 4;
            addNewMovie.Text = "Add New Movie";
            addNewMovie.UseVisualStyleBackColor = true;
            // 
            // back
            // 
            back.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            back.Location = new Point(208, 82);
            back.Name = "back";
            back.Size = new Size(131, 40);
            back.TabIndex = 8;
            back.Text = "BACK";
            back.UseVisualStyleBackColor = true;
            back.Click += back_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Tan;
            label1.Font = new Font("Berlin Sans FB", 27.8571434F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(590, 94);
            label1.Name = "label1";
            label1.Size = new Size(453, 72);
            label1.TabIndex = 15;
            label1.Text = "Manage Movies";
            // 
            // MovieMain
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.NavajoWhite;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1667, 780);
            Controls.Add(label1);
            Controls.Add(back);
            Controls.Add(movieDataGridView);
            Controls.Add(movieSearchButton);
            Controls.Add(movieNameInput);
            Controls.Add(addNewMovie);
            Name = "MovieMain";
            Text = "MovieMain";
            ((System.ComponentModel.ISupportInitialize)movieDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView movieDataGridView;
        private Button movieSearchButton;
        private TextBox movieNameInput;
        private Button addNewMovie;
        private Button back;
        private Label label1;
    }
}