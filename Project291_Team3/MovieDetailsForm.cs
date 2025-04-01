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

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@MovieID", movieID);

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

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
    }
}
