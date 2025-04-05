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
    // This Form is Basically just the movie main form replicated, Go there for comments
    public partial class OrderForm : Form
    {
        private SqlConnection myConnection;
        private int customerID;
        private int employeeID;

        // Constructor for Order Form
        public OrderForm(SqlConnection connection, int customerID, int employeeID)
        {
            InitializeComponent();
            myConnection = connection;
            this.customerID = customerID;
            this.employeeID = employeeID;
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            orderDataGridView.ReadOnly = true;
            orderDataGridView.AllowUserToAddRows = false;
            orderDataGridView.AllowUserToDeleteRows = false;
            orderDataGridView.MultiSelect = false;
            orderDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            orderDataGridView.RowHeadersVisible = false;
            orderDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderDataGridView.ColumnHeadersVisible = false;

        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int movieID = Convert.ToInt32(orderDataGridView.Rows[e.RowIndex].Cells["MovieID"].Value);

              
                OrderPlacementForm orderPlacementForm = new OrderPlacementForm(myConnection, customerID, employeeID, movieID);
                orderPlacementForm.ShowDialog();
            }
        }

        private void movieSearchButton_Click(object sender, EventArgs e)
        {
            string movieName = movieNameInput.Text.Trim();

            if (string.IsNullOrEmpty(movieName))
            {
                MessageBox.Show("Please enter a movie name or ID.");
                return;
            }

            string query = @"
                SELECT MovieID, MovieName, MovieType 
                FROM Movie
                WHERE MovieName LIKE @Search
                   OR CAST(MovieID AS VARCHAR) LIKE @Search";

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

                orderDataGridView.DataSource = dt;
            }
        }
    }
}
