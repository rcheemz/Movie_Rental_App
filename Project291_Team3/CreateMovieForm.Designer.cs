namespace Project291_Team3
{
    partial class CreateMovieForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            movieNameInput = new TextBox();
            feeInput = new TextBox();
            copiesInput = new TextBox();
            actorSearchInput = new TextBox();
            searchActorButton = new Button();
            actorSearchResults = new DataGridView();
            addActorButton = new Button();
            selectedActorList = new FlowLayoutPanel();
            saveButton = new Button();
            movieTypeComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)actorSearchResults).BeginInit();
            SuspendLayout();
            // 
            // movieNameInput
            // 
            movieNameInput.Font = new Font("Berlin Sans FB", 12F);
            movieNameInput.Location = new Point(435, 166);
            movieNameInput.Margin = new Padding(3, 4, 3, 4);
            movieNameInput.Name = "movieNameInput";
            movieNameInput.PlaceholderText = "Movie Name";
            movieNameInput.Size = new Size(300, 38);
            movieNameInput.TabIndex = 0;
            // 
            // feeInput
            // 
            feeInput.Font = new Font("Berlin Sans FB", 12F);
            feeInput.Location = new Point(435, 286);
            feeInput.Margin = new Padding(3, 4, 3, 4);
            feeInput.Name = "feeInput";
            feeInput.PlaceholderText = "Distribution Fee";
            feeInput.Size = new Size(300, 38);
            feeInput.TabIndex = 2;
            // 
            // copiesInput
            // 
            copiesInput.Font = new Font("Berlin Sans FB", 12F);
            copiesInput.Location = new Point(435, 346);
            copiesInput.Margin = new Padding(3, 4, 3, 4);
            copiesInput.Name = "copiesInput";
            copiesInput.PlaceholderText = "Number of Copies";
            copiesInput.Size = new Size(300, 38);
            copiesInput.TabIndex = 3;
            // 
            // actorSearchInput
            // 
            actorSearchInput.Font = new Font("Berlin Sans FB", 9.857143F);
            actorSearchInput.Location = new Point(785, 166);
            actorSearchInput.Margin = new Padding(3, 4, 3, 4);
            actorSearchInput.Name = "actorSearchInput";
            actorSearchInput.PlaceholderText = "Search Actor";
            actorSearchInput.Size = new Size(300, 33);
            actorSearchInput.TabIndex = 4;
            // 
            // searchActorButton
            // 
            searchActorButton.Font = new Font("Berlin Sans FB", 9.857143F);
            searchActorButton.Location = new Point(1105, 166);
            searchActorButton.Margin = new Padding(3, 4, 3, 4);
            searchActorButton.Name = "searchActorButton";
            searchActorButton.Size = new Size(100, 37);
            searchActorButton.TabIndex = 5;
            searchActorButton.Text = "Search";
            searchActorButton.UseVisualStyleBackColor = true;
            searchActorButton.Click += searchActorButton_Click;
            // 
            // actorSearchResults
            // 
            actorSearchResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            actorSearchResults.Location = new Point(785, 226);
            actorSearchResults.Margin = new Padding(3, 4, 3, 4);
            actorSearchResults.Name = "actorSearchResults";
            actorSearchResults.RowHeadersWidth = 72;
            actorSearchResults.RowTemplate.Height = 31;
            actorSearchResults.Size = new Size(420, 240);
            actorSearchResults.TabIndex = 6;
            // 
            // addActorButton
            // 
            addActorButton.Font = new Font("Berlin Sans FB", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            addActorButton.Location = new Point(1235, 226);
            addActorButton.Margin = new Padding(3, 4, 3, 4);
            addActorButton.Name = "addActorButton";
            addActorButton.Size = new Size(120, 37);
            addActorButton.TabIndex = 7;
            addActorButton.Text = "Add Actor";
            addActorButton.UseVisualStyleBackColor = true;
            addActorButton.Click += addActorButton_Click;
            // 
            // selectedActorList
            // 
            selectedActorList.AutoScroll = true;
            selectedActorList.BorderStyle = BorderStyle.FixedSingle;
            selectedActorList.Location = new Point(785, 490);
            selectedActorList.Margin = new Padding(3, 4, 3, 4);
            selectedActorList.Name = "selectedActorList";
            selectedActorList.Size = new Size(420, 180);
            selectedActorList.TabIndex = 8;
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Berlin Sans FB", 12F);
            saveButton.Location = new Point(435, 430);
            saveButton.Margin = new Padding(3, 4, 3, 4);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(300, 60);
            saveButton.TabIndex = 9;
            saveButton.Text = "Save Movie";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // movieTypeComboBox
            // 
            movieTypeComboBox.FormattingEnabled = true;
            movieTypeComboBox.Location = new Point(435, 225);
            movieTypeComboBox.Name = "movieTypeComboBox";
            movieTypeComboBox.Size = new Size(300, 38);
            movieTypeComboBox.TabIndex = 10;
            movieTypeComboBox.SelectedIndexChanged += movieTypeComboBox_SelectedIndexChanged;
            // 
            // CreateMovieForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PeachPuff;
            ClientSize = new Size(1667, 780);
            Controls.Add(movieTypeComboBox);
            Controls.Add(saveButton);
            Controls.Add(selectedActorList);
            Controls.Add(addActorButton);
            Controls.Add(actorSearchResults);
            Controls.Add(searchActorButton);
            Controls.Add(actorSearchInput);
            Controls.Add(copiesInput);
            Controls.Add(feeInput);
            Controls.Add(movieNameInput);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CreateMovieForm";
            Text = "Create Movie";
            Load += CreateMovieForm_Load;
            ((System.ComponentModel.ISupportInitialize)actorSearchResults).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox movieNameInput;
        private System.Windows.Forms.TextBox feeInput;
        private System.Windows.Forms.TextBox copiesInput;
        private System.Windows.Forms.TextBox actorSearchInput;
        private System.Windows.Forms.Button searchActorButton;
        private System.Windows.Forms.DataGridView actorSearchResults;
        private System.Windows.Forms.Button addActorButton;
        private System.Windows.Forms.FlowLayoutPanel selectedActorList;
        private System.Windows.Forms.Button saveButton;
        private ComboBox movieTypeComboBox;
    }
}
