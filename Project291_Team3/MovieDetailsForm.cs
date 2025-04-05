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

namespace Project291_Team3
{
    public partial class MovieDetailsForm : Form
    {
        private SqlConnection myConnection;
        private int movieID;
        public MovieDetailsForm(SqlConnection sqlConnection, int movieID)
        {
            InitializeComponent();
            myConnection = sqlConnection;
            this.movieID = movieID;

        }

        private void MovieDetailsForm_Load(object sender, EventArgs e)
        {
            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {
            // Query to get movie details
            string query = @"
                SELECT 
                    M.MovieID,
                    M.MovieName,
                    M.MovieType,
                    M.Rating,
                    M.NumberOfCopies,
                    STRING_AGG(A.ActorName, ', ') AS ActorList
                FROM Movie M
                LEFT JOIN MovieActor MA ON M.MovieID = MA.MovieID
                LEFT JOIN Actor A ON MA.ActorID = A.ActorID
                WHERE M.MovieID = @MovieID
                GROUP BY M.MovieID, M.MovieName, M.MovieType, M.Rating, M.NumberOfCopies;";

            // Sql command with query
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@MovieID", movieID);

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader(); // Execute the query and get the result set

                if (reader.Read())
                {
                    movieNameLabel.Text = reader["MovieName"].ToString();
                    genreLabel.Text = reader["MovieType"].ToString();
                    movieIDLabel.Text = reader["MovieID"].ToString();
                    ratingLabel.Text = reader["Rating"].ToString();
                    copiesLabel.Text = reader["NumberOfCopies"].ToString();
                    actorList.Text = reader["ActorList"] != DBNull.Value ? reader["ActorList"].ToString() : "N/A";
                }
                else
                {
                    MessageBox.Show("Movie details not found.");
                }

                reader.Close();
                myConnection.Close();
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void emailLabel_Click(object sender, EventArgs e)
        {

        }

        private void lastNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void genreLabel_Click(object sender, EventArgs e)
        {

        }

        private void copiesLabel_Click(object sender, EventArgs e)
        {

        }

        private void movieNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void actorList_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            CreateMovieForm createMovieForm = new CreateMovieForm(myConnection, movieID);
            createMovieForm.ShowDialog();
        }

        private void editButton_Click_1(object sender, EventArgs e)
        {
            CreateMovieForm createMovieForm = new CreateMovieForm(myConnection, movieID);
            createMovieForm.ShowDialog();

        }

        // Button to delete movie (rename button)
        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
        "Are you sure you want to delete this movie and ALL related data (orders, ratings, actors)?",
        "Confirm Delete",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();

                    myConnection.Open();

                    // 1. Delete MovieRate where OrderID belongs to this Movie
                    string deleteMovieRates = @"
                DELETE FROM MovieRate
                WHERE OrderID IN (SELECT OrderID FROM RentalOrder WHERE MovieID = @MovieID)";
                    using (SqlCommand cmd = new SqlCommand(deleteMovieRates, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MovieID", movieID);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Delete ActorRate where OrderID belongs to this Movie
                    string deleteActorRates = @"
                DELETE FROM ActorRate
                WHERE OrderID IN (SELECT OrderID FROM RentalOrder WHERE MovieID = @MovieID)";
                    using (SqlCommand cmd = new SqlCommand(deleteActorRates, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MovieID", movieID);
                        cmd.ExecuteNonQuery();
                    }

                    // Delete CustomerQueue entries where MovieID = @MovieID
                    string deleteQueue = "DELETE FROM CustomerQueue WHERE MovieID = @MovieID";
                    using (SqlCommand cmd = new SqlCommand(deleteQueue, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MovieID", movieID);
                        cmd.ExecuteNonQuery();
                    }


                    // 3. Delete RentalOrder
                    string deleteOrders = "DELETE FROM RentalOrder WHERE MovieID = @MovieID";
                    using (SqlCommand cmd = new SqlCommand(deleteOrders, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MovieID", movieID);
                        cmd.ExecuteNonQuery();
                    }

                    // 4. Delete MovieActor (optional, if you use it)
                    string deleteMovieActors = "DELETE FROM MovieActor WHERE MovieID = @MovieID";
                    using (SqlCommand cmd = new SqlCommand(deleteMovieActors, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MovieID", movieID);
                        cmd.ExecuteNonQuery();
                    }

                    // 5. Delete Movie
                    string deleteMovie = "DELETE FROM Movie WHERE MovieID = @MovieID";
                    using (SqlCommand cmd = new SqlCommand(deleteMovie, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@MovieID", movieID);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Movie and all related data deleted successfully.");
                            myConnection.Close();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. Movie not found.");
                        }
                    }

                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting movie: " + ex.Message);
                    myConnection.Close();
                }
            }
        }
    }
}
