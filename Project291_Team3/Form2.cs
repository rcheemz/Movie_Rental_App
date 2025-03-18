using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Project291_Team3
{
    public partial class Form2 : Form
    {
        private SqlConnection myConnection;

        public Form2(SqlConnection connection)
        {

            InitializeComponent();

            // get the connection form form1 (previous page)
            myConnection = connection;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Set up DataGridView properties
            customerDataGridView.ReadOnly = true;  // Prevent editing
            customerDataGridView.AllowUserToAddRows = false;  // Disable adding rows
            customerDataGridView.AllowUserToDeleteRows = false; // Prevent deletion
            customerDataGridView.MultiSelect = false; // Allow only single row selection
            customerDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Select entire row
            customerDataGridView.RowHeadersVisible = false; // Hide row headers
            customerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Auto-size columns
            customerDataGridView.ColumnHeadersVisible = false; // Hide column headers to make it look like a simple list

        }

        private void customerSearchButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = customerPhoneInput.Text.Trim();

            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

            // SQL Query to find customers by phone number
            string query = @"
        SELECT c.CustomerID, c.FirstName, c.LastName, p.PhoneNum 
        FROM Customer c
        INNER JOIN CustomerPhone p ON c.CustomerID = p.CustomerID
        WHERE p.PhoneNum LIKE @PhoneNumber";

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@PhoneNumber", "%" + phoneNumber + "%"); // Allows partial search

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No customers found with this phone number.");
                    return;
                }

                // Bind results to DataGridView
                customerDataGridView.DataSource = dt;
            }

        }

        private void createNewCustomer_Click(object sender, EventArgs e)
        {
            // pass the connection to the next page instead of redoing it
            CreateCustomer createCustomer = new CreateCustomer(myConnection);
            // when button is clicked show the next page and hide this page
            // when making logic for login this code will move into where the creds are met 
            createCustomer.ShowDialog();
        }

        private void customerPhoneInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void customerDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a row is selected
            {
                // Get selected CustomerID
                int customerID = Convert.ToInt32(customerDataGridView.Rows[e.RowIndex].Cells["CustomerID"].Value);

                // Open full customer details form
                CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(myConnection, customerID);
                customerDetailsForm.ShowDialog();
            }

        }
    }
}
