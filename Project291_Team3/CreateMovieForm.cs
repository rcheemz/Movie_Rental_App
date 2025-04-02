using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Project291_Team3
{
    public partial class CreateMovieForm : Form
    {
        private SqlConnection myConnection;
        private List<int> selectedActorIDs = new List<int>();
        private bool isEditMode = false;
        private int editMovieID;

        public CreateMovieForm(SqlConnection connection)
        {
            InitializeComponent();
            myConnection = connection;
            LoadDropDownLists();
        }

        public CreateMovieForm(SqlConnection connection, int movieID)
        {
            InitializeComponent();
            myConnection = connection;
            isEditMode = true;
            editMovieID = movieID;
            LoadMovieDetails();
            LoadDropDownLists();
        }

        private void LoadMovieDetails()
        {
            try
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                string query = "SELECT MovieName, MovieType, DistributionFee, NumberOfCopies FROM Movie WHERE MovieID = @MovieID";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@MovieID", editMovieID);

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    movieNameInput.Text = reader["MovieName"].ToString();
                    movieTypeComboBox.SelectedItem = reader["MovieType"].ToString();
                    feeInput.Text = reader["DistributionFee"].ToString();
                    copiesInput.Text = reader["NumberOfCopies"].ToString();
                    
                    // Country ComboBox
                    string type = reader["MovieType"].ToString();
                    if (movieTypeComboBox.Items.Contains(type))
                    {
                        movieTypeComboBox.SelectedItem = type;
                    }
                }
                reader.Close();

                // Load existing actors
                string actorQuery = "SELECT A.ActorID, A.ActorName FROM MovieActor MA JOIN Actor A ON MA.ActorID = A.ActorID WHERE MA.MovieID = @MovieID";
                SqlCommand actorCmd = new SqlCommand(actorQuery, myConnection);
                actorCmd.Parameters.AddWithValue("@MovieID", editMovieID);

                SqlDataReader actorReader = actorCmd.ExecuteReader();
                while (actorReader.Read())
                {
                    int actorID = Convert.ToInt32(actorReader["ActorID"]);
                    string actorName = actorReader["ActorName"].ToString();
                    selectedActorIDs.Add(actorID);

                    FlowLayoutPanel actorPanel = new FlowLayoutPanel();
                    actorPanel.AutoSize = true;
                    actorPanel.FlowDirection = FlowDirection.LeftToRight;
                    actorPanel.Margin = new Padding(3);

                    Label actorLabel = new Label();
                    actorLabel.Text = actorName + " (" + actorID + ")";
                    actorLabel.AutoSize = true;
                    actorLabel.Margin = new Padding(3);

                    Button removeButton = new Button();
                    removeButton.Text = "X";
                    removeButton.Tag = actorID;
                    removeButton.Size = new Size(20, 20);
                    removeButton.Font = new Font("Arial", 7, FontStyle.Bold);
                    removeButton.TextAlign = ContentAlignment.MiddleCenter;
                    removeButton.Padding = new Padding(0);
                    removeButton.Margin = new Padding(3, 0, 3, 0);
                    removeButton.BackColor = Color.LightCoral;
                    removeButton.ForeColor = Color.White;
                    removeButton.FlatStyle = FlatStyle.Flat;
                    removeButton.Click += RemoveButton_Click;

                    actorPanel.Controls.Add(actorLabel);
                    actorPanel.Controls.Add(removeButton);

                    selectedActorList.Controls.Add(actorPanel);
                }
                actorReader.Close();
                myConnection.Close();

                saveButton.Text = "Update Movie";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading movie details: " + ex.Message);
                myConnection.Close();
            }
        }

        private void searchActorButton_Click(object sender, EventArgs e)
        {
            string searchText = actorSearchInput.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter actor name to search.");
                return;
            }

            try
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                string query = "SELECT ActorID, ActorName FROM Actor WHERE ActorName LIKE @SearchText";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                myConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                myConnection.Close();

                actorSearchResults.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                myConnection.Close();
            }
        }

        private void addActorButton_Click(object sender, EventArgs e)
        {
            if (actorSearchResults.SelectedRows.Count > 0)
            {
                int actorID = Convert.ToInt32(actorSearchResults.SelectedRows[0].Cells["ActorID"].Value);
                string actorName = actorSearchResults.SelectedRows[0].Cells["ActorName"].Value.ToString();

                if (!selectedActorIDs.Contains(actorID))
                {
                    selectedActorIDs.Add(actorID);

                    FlowLayoutPanel actorPanel = new FlowLayoutPanel();
                    actorPanel.AutoSize = true;
                    actorPanel.FlowDirection = FlowDirection.LeftToRight;
                    actorPanel.Margin = new Padding(3);

                    Label actorLabel = new Label();
                    actorLabel.Text = actorName + " (" + actorID + ")";
                    actorLabel.AutoSize = true;
                    actorLabel.Margin = new Padding(3);

                    Button removeButton = new Button();
                    removeButton.Text = "X";
                    removeButton.Tag = actorID;
                    removeButton.Size = new Size(20, 20);
                    removeButton.Font = new Font("Arial", 7, FontStyle.Bold);
                    removeButton.TextAlign = ContentAlignment.MiddleCenter;
                    removeButton.Padding = new Padding(0);
                    removeButton.Margin = new Padding(3, 0, 3, 0);
                    removeButton.BackColor = Color.LightCoral;
                    removeButton.ForeColor = Color.White;
                    removeButton.FlatStyle = FlatStyle.Flat;
                    removeButton.Click += RemoveButton_Click;

                    actorPanel.Controls.Add(actorLabel);
                    actorPanel.Controls.Add(removeButton);

                    selectedActorList.Controls.Add(actorPanel);
                }
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Button removeButton = sender as Button;
            int actorID = (int)removeButton.Tag;

            selectedActorIDs.Remove(actorID);
            Control actorPanel = removeButton.Parent;
            selectedActorList.Controls.Remove(actorPanel);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string movieName = movieNameInput.Text.Trim();
            string movieType = movieTypeComboBox.SelectedItem.ToString();
            string feeText = feeInput.Text.Trim();
            string copiesText = copiesInput.Text.Trim();

            if (string.IsNullOrEmpty(movieName) || string.IsNullOrEmpty(movieType) ||
                string.IsNullOrEmpty(feeText) || string.IsNullOrEmpty(copiesText))
            {
                MessageBox.Show("Please fill in all movie details.");
                return;
            }
            // Validate numeric values
            if (!decimal.TryParse(feeText, out decimal fee) || fee <= 0)
            {
                MessageBox.Show("Invalid distribution fee. Please enter a positive number.");
                return;
            }

            if (!int.TryParse(copiesText, out int copies) || copies <= 0)
            {
                MessageBox.Show("Invalid number of copies. Please enter a positive whole number.");
                return;
            }


            if (selectedActorIDs.Count == 0)
            {
                MessageBox.Show("Please add at least one actor.");
                return;
            }

            try
            {
                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();

                int movieID = isEditMode ? editMovieID : new Random().Next(1000, 9999);

                if (isEditMode)
                {
                    // Update Movie
                    string updateMovieQuery = @"
                        UPDATE Movie SET MovieName = @MovieName, MovieType = @MovieType,
                        DistributionFee = @Fee, NumberOfCopies = @Copies WHERE MovieID = @MovieID";

                    SqlCommand updateCmd = new SqlCommand(updateMovieQuery, myConnection);
                    updateCmd.Parameters.AddWithValue("@MovieID", movieID);
                    updateCmd.Parameters.AddWithValue("@MovieName", movieName);
                    updateCmd.Parameters.AddWithValue("@MovieType", movieType);
                    updateCmd.Parameters.AddWithValue("@Fee", Convert.ToDecimal(feeText));
                    updateCmd.Parameters.AddWithValue("@Copies", Convert.ToInt32(copiesText));
                    updateCmd.ExecuteNonQuery();

                    // Delete old MovieActor
                    string deleteQuery = "DELETE FROM MovieActor WHERE MovieID = @MovieID";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, myConnection);
                    deleteCmd.Parameters.AddWithValue("@MovieID", movieID);
                    deleteCmd.ExecuteNonQuery();
                }
                else
                {
                    // Insert Movie
                    string insertMovieQuery = @"
                        INSERT INTO Movie (MovieID, MovieName, MovieType, DistributionFee, NumberOfCopies)
                        VALUES (@MovieID, @MovieName, @MovieType, @Fee, @Copies)";

                    SqlCommand movieCmd = new SqlCommand(insertMovieQuery, myConnection);
                    movieCmd.Parameters.AddWithValue("@MovieID", movieID);
                    movieCmd.Parameters.AddWithValue("@MovieName", movieName);
                    movieCmd.Parameters.AddWithValue("@MovieType", movieType);
                    movieCmd.Parameters.AddWithValue("@Fee", Convert.ToDecimal(feeText));
                    movieCmd.Parameters.AddWithValue("@Copies", Convert.ToInt32(copiesText));
                    movieCmd.ExecuteNonQuery();
                }

                // Insert MovieActor
                foreach (int actorID in selectedActorIDs)
                {
                    string insertMovieActorQuery = "INSERT INTO MovieActor (MovieID, ActorID) VALUES (@MovieID, @ActorID)";
                    SqlCommand maCmd = new SqlCommand(insertMovieActorQuery, myConnection);
                    maCmd.Parameters.AddWithValue("@MovieID", movieID);
                    maCmd.Parameters.AddWithValue("@ActorID", actorID);
                    maCmd.ExecuteNonQuery();
                }

                myConnection.Close();

                MessageBox.Show(isEditMode ? "Movie updated successfully!" : "Movie and actors added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                myConnection.Close();
            }
        }

        // Function to populate the country dropdown
        private void LoadDropDownLists()
        {
            // hardcoded list of genres allowed by the database or else it will crash

            string[] countries = {
            "Action", "Foreign", "Comedy", "Drama"
            };

            movieTypeComboBox.Items.AddRange(countries); // Add list to ComboBox this is the drop down menu list
            movieTypeComboBox.SelectedIndex = 0; // Set the default selection to the first item so we will never have null selection

            
        }

        private void CreateMovieForm_Load(object sender, EventArgs e)
        {

        }

        private void movieTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
