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
    public partial class OrderForm : Form
    {
        private SqlConnection myConnection;
        private int customerID;
        private int employeeID;
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

                // ⚠️ Later here you will open an "Order Details" screen to actually place the order
                OrderPlacementForm orderPlacementForm = new OrderPlacementForm(myConnection, customerID, employeeID, movieID);
                orderPlacementForm.ShowDialog();
            }
        }

        private void movieSearchButton_Click(object sender, EventArgs e)
        {
            string movieName = movieNameInput.Text.Trim();

            if (string.IsNullOrEmpty(movieName))
            {
                MessageBox.Show("Please enter a movie name.");
                return;
            }

            string query = @"
                SELECT MovieID, MovieName, MovieType 
                FROM Movie
                WHERE MovieName LIKE @MovieName";

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@MovieName", "%" + movieName + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No movies found with this name.");
                    return;
                }

                orderDataGridView.DataSource = dt;
            }
        }
    }
}
