namespace Project291_Team3
{
    partial class MovieDetailsForm
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
            editButton = new Button();
            ratingLabel = new Label();
            actorList = new Label();
            movieNameLabel = new Label();
            lastNameLabel = new Label();
            phoneNumberLabel = new Label();
            movieIDLabel = new Label();
            cityLabel = new Label();
            genreLabel = new Label();
            emailLabel = new Label();
            copiesLabel = new Label();
            SuspendLayout();
            // 
            // editButton
            // 
            editButton.Location = new Point(781, 611);
            editButton.Name = "editButton";
            editButton.Size = new Size(131, 40);
            editButton.TabIndex = 52;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click_1;
            // 
            // ratingLabel
            // 
            ratingLabel.AutoSize = true;
            ratingLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            ratingLabel.Location = new Point(530, 224);
            ratingLabel.Name = "ratingLabel";
            ratingLabel.Size = new Size(115, 37);
            ratingLabel.TabIndex = 51;
            ratingLabel.Text = "Rating ";
            // 
            // actorList
            // 
            actorList.AutoSize = true;
            actorList.Font = new Font("Berlin Sans FB", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            actorList.Location = new Point(865, 474);
            actorList.Name = "actorList";
            actorList.Size = new Size(86, 31);
            actorList.TabIndex = 50;
            actorList.Text = "label2";
            // 
            // movieNameLabel
            // 
            movieNameLabel.AutoSize = true;
            movieNameLabel.Font = new Font("Berlin Sans FB Demi", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            movieNameLabel.Location = new Point(519, 162);
            movieNameLabel.Name = "movieNameLabel";
            movieNameLabel.Size = new Size(342, 63);
            movieNameLabel.TabIndex = 42;
            movieNameLabel.Text = "Movie Name";
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Font = new Font("Berlin Sans FB Demi", 14.1428576F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lastNameLabel.Location = new Point(683, 307);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(114, 38);
            lastNameLabel.TabIndex = 43;
            lastNameLabel.Text = "Genre:";
            // 
            // phoneNumberLabel
            // 
            phoneNumberLabel.AutoSize = true;
            phoneNumberLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            phoneNumberLabel.Location = new Point(683, 395);
            phoneNumberLabel.Name = "phoneNumberLabel";
            phoneNumberLabel.Size = new Size(113, 37);
            phoneNumberLabel.TabIndex = 49;
            phoneNumberLabel.Text = "Copies:";
            // 
            // movieIDLabel
            // 
            movieIDLabel.AutoSize = true;
            movieIDLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            movieIDLabel.Location = new Point(1183, 139);
            movieIDLabel.Name = "movieIDLabel";
            movieIDLabel.Size = new Size(131, 37);
            movieIDLabel.TabIndex = 44;
            movieIDLabel.Text = "MovieID";
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            cityLabel.Location = new Point(964, 345);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(0, 37);
            cityLabel.TabIndex = 48;
            // 
            // genreLabel
            // 
            genreLabel.AutoSize = true;
            genreLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            genreLabel.Location = new Point(865, 308);
            genreLabel.Name = "genreLabel";
            genreLabel.Size = new Size(99, 37);
            genreLabel.TabIndex = 45;
            genreLabel.Text = "Genre";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            emailLabel.Location = new Point(683, 468);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(159, 37);
            emailLabel.TabIndex = 47;
            emailLabel.Text = "Actor List: ";
            // 
            // copiesLabel
            // 
            copiesLabel.AutoSize = true;
            copiesLabel.Font = new Font("Berlin Sans FB", 14.1428576F);
            copiesLabel.Location = new Point(865, 395);
            copiesLabel.Name = "copiesLabel";
            copiesLabel.Size = new Size(106, 37);
            copiesLabel.TabIndex = 46;
            copiesLabel.Text = "Copies";
            // 
            // MovieDetailsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.NavajoWhite;
            ClientSize = new Size(1667, 780);
            Controls.Add(editButton);
            Controls.Add(ratingLabel);
            Controls.Add(actorList);
            Controls.Add(movieNameLabel);
            Controls.Add(lastNameLabel);
            Controls.Add(phoneNumberLabel);
            Controls.Add(movieIDLabel);
            Controls.Add(cityLabel);
            Controls.Add(genreLabel);
            Controls.Add(emailLabel);
            Controls.Add(copiesLabel);
            Name = "MovieDetailsForm";
            Text = "MovieDetailsForm";
            Load += MovieDetailsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button editButton;
        private Label ratingLabel;
        private Label actorList;
        private Label movieNameLabel;
        private Label lastNameLabel;
        private Label phoneNumberLabel;
        private Label movieIDLabel;
        private Label cityLabel;
        private Label genreLabel;
        private Label emailLabel;
        private Label copiesLabel;
    }
}