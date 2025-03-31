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
        private int employeeID;

        public Form2(SqlConnection connection, int employeeID)
        {

            InitializeComponent();

            // get the connection form form1 (previous page)
            myConnection = connection;
            this.employeeID = employeeID;
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

        /**
         * When customer button is click
         */
        private void customerSearchButton_Click(object sender, EventArgs e)
        {
            // tirm the input of the phonenumber to get rid of spaces
            string phoneNumber = customerPhoneInput.Text.Trim();

            // check if empty or null
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

            // create a SqlCommand object to execute the SQL query
            // uses my connection insure the command is automatically closed after ecxecution
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@PhoneNumber", "%" + phoneNumber + "%"); // Allows partial search so if you want to search all numbers with 780 etc

                // a helper class that fetches data from the database and fills the datatable
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable(); // this is the data table in the app
                adapter.Fill(dt); // this will fill the datatable list of found customers on the app

                // if the data table has no lines that means no customer was found
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No customers found with this phone number.");
                    return;
                }

                // bind results to DataGridView
                customerDataGridView.DataSource = dt;
            }

        }

        private void createNewCustomer_Click(object sender, EventArgs e)
        {
            // pass the connection to the next page instead of redoing it
            CreateCustomer createCustomer = new CreateCustomer(myConnection);
            // when button is clicked show the next page and hide this page
            // when making logic for login this code will move into where the creds are met 
            // dialog prevents going back to the other page until this is closed
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
                // pass connection again
                CustomerDetailsForm customerDetailsForm = new CustomerDetailsForm(myConnection, customerID, employeeID);
                customerDetailsForm.ShowDialog();
            }

        }

        private void back_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(myConnection, employeeID);
            homePage.Show();
            this.Hide();
        }
    }
}
