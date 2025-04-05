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
    public partial class MovieMain : Form
    {
        private SqlConnection myConnection;
        private int employeeID;

        // Constructor for Movie Main
        public MovieMain(SqlConnection connection, int employeeID)
        {

            InitializeComponent();
            myConnection = connection;
            this.employeeID = employeeID;
        }

        private void MovieMain_Load(object sender, EventArgs e)
        {
            // Set up Datagirdview properties
            movieDataGridView.ReadOnly = true;
            movieDataGridView.AllowUserToAddRows = false;
            movieDataGridView.AllowUserToDeleteRows = false;
            movieDataGridView.MultiSelect = false;
            movieDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            movieDataGridView.RowHeadersVisible = false;
            movieDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            movieDataGridView.ColumnHeadersVisible = false;

        }

        // Method for when selected movie from grid
        private void movieDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int movieID = Convert.ToInt32(movieDataGridView.Rows[e.RowIndex].Cells["MovieID"].Value);


                MovieDetailsForm movieDetailsForm = new MovieDetailsForm(myConnection, movieID);
                movieDetailsForm.ShowDialog();
            }
        }

        // Movie search method
        private void movieSearchButton_Click(object sender, EventArgs e)
        {
            string movieName = movieNameInput.Text.Trim();

            if (string.IsNullOrEmpty(movieName))
            {
                MessageBox.Show("Please enter a movie name or ID.");
                return;
            }

            // SQL query to search by MovieName OR MovieID
            string query = @"
                SELECT MovieID, MovieName, MovieType 
                FROM Movie
                WHERE MovieName LIKE @Search
                   OR CAST(MovieID AS VARCHAR) LIKE @Search";

            // Sql command for query 
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@Search", "%" + movieName + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No movies found with this name or ID.");
                    return;
                }

                movieDataGridView.DataSource = dt;
            }
        }

        // Button to go back to home page
        private void back_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(myConnection, employeeID);
            homePage.Show();
            this.Hide();
        }

        private void MovieMain_Load_1(object sender, EventArgs e)
        {

        }

        // Button to go to add new movie form
        private void addNewMovie_Click(object sender, EventArgs e)
        {
            CreateMovieForm createMovieForm = new CreateMovieForm(myConnection);
            createMovieForm.ShowDialog();
        }
    }
}
