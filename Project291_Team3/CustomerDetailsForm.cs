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
    public partial class CustomerDetailsForm : Form
    {
        private SqlConnection myConnection;
        private int customerID;
        private int employeeID;
        public CustomerDetailsForm(SqlConnection connection, int customerID, int employeeID)
        {
            InitializeComponent();
            myConnection = connection;
            this.customerID = customerID;
            this.employeeID = employeeID;
            LoadCustomerDetails();
            tabPage1.Text = "Customer Info";
            tabPage2.Text = "Orders and Queue";
            LoadCustomerQueue();
            LoadOrderHistory();
        }

        private void CustomerDetailsForm_Load(object sender, EventArgs e)
        {

        }

        /**
         * This will load the customer details by fetching from database server
         */
        private void LoadCustomerDetails()
        {

            // Just in case connection is lost to the database
            if (myConnection == null)
            {
                MessageBox.Show("Database connection is not established.");
                return;
            }

            // Ensure the connection is closed before opening this is very important or else it doesnt load for somereason kept getting error
            if (myConnection.State == System.Data.ConnectionState.Open)
            {
                myConnection.Close();
            }

            // SQL query
            string query = @"
                SELECT c.FirstName, c.LastName, c.StreetAddress, c.City, c.StateOrProvince, 
                       c.Country, c.ZipCode, c.Email, c.AccountNumber, c.CreditCardNumber, 
                       STRING_AGG(p.PhoneNum, ', ') AS PhoneNumbers
                FROM Customer c
                LEFT JOIN CustomerPhone p ON c.CustomerID = p.CustomerID
                WHERE c.CustomerID = @CustomerID
                GROUP BY c.FirstName, c.LastName, c.StreetAddress, c.City, c.StateOrProvince, 
                         c.Country, c.ZipCode, c.Email, c.AccountNumber, c.CreditCardNumber";


            // create a SqlCommand object to execute the SQL query
            // uses my connection insure the command is automatically closed after ecxecution
            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // read data
                if (reader.Read())
                {
                    // Display Customer Data in Labels
                    firstNameLabel.Text = reader["FirstName"].ToString();
                    lastNameLabel.Text = reader["LastName"].ToString();
                    streetLabel.Text = reader["StreetAddress"].ToString();
                    cityLabel.Text = reader["City"].ToString();
                    stateLabel.Text = reader["StateOrProvince"].ToString();
                    countryLabel.Text = reader["Country"].ToString();
                    zipLabel.Text = reader["ZipCode"].ToString();
                    emailLabel.Text = reader["Email"].ToString();
                    accountNumberLabel.Text = reader["AccountNumber"].ToString();

                    phoneNumberLabel.Text = reader["PhoneNumbers"].ToString();
                }
                else
                {
                    MessageBox.Show("Customer details not found.");
                }

                reader.Close();
                myConnection.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditCustomer editForm = new EditCustomer(myConnection, customerID);
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadCustomerDetails(); // Reload with updated info
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadOrderHistory()
        {
            string query = @"
                    SELECT 
                        R.OrderID AS [Order Number],
                        M.MovieName AS [Movie Name],
                        E.FirstName + ' ' + E.LastName AS [Employee Name],
                        R.CheckoutDateTime AS [Checkout Date],
                        R.ReturnDateTime AS [Return Date]
                    FROM RentalOrder R
                    JOIN Movie M ON R.MovieID = M.MovieID
                    JOIN Employee E ON R.EmployeeID = E.EmployeeID
                    WHERE R.CustomerID = @CustomerID";

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                myConnection.Close();

                dataGridView1.DataSource = dataTable;
                dataGridView1.ReadOnly = true;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
        private void LoadCustomerQueue()
        {
            string query = @"
        SELECT 
            Q.QueuePosition AS [Position],
            M.MovieName AS [Movie Name]
        FROM CustomerQueue Q
        JOIN Movie M ON Q.MovieID = M.MovieID
        WHERE Q.CustomerID = @CustomerID
        ORDER BY Q.QueuePosition"; // FIFO Order

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                myConnection.Close();

                dataGridViewQueue.DataSource = dataTable;
                dataGridViewQueue.ReadOnly = true;
                dataGridViewQueue.AllowUserToAddRows = false;
                dataGridViewQueue.AllowUserToDeleteRows = false;
                dataGridViewQueue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }


        private void newOrder_Click(object sender, EventArgs e)
        {
            OrderForm form = new OrderForm(myConnection, customerID, employeeID);
            form.ShowDialog();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
        "Are you sure you want to delete this customer and ALL related data (phones, orders, queue, ratings)?",
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

                    // 1. Delete MovieRate where OrderID is from this Customer
                    string deleteRates = @"
                DELETE FROM MovieRate
                WHERE OrderID IN (SELECT OrderID FROM RentalOrder WHERE CustomerID = @CustomerID)";
                    using (SqlCommand rateCmd = new SqlCommand(deleteRates, myConnection))
                    {
                        rateCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        rateCmd.ExecuteNonQuery();
                    }

                    // 2. Delete ActorRate where OrderID belongs to this Customer
                    string deleteActorRates = @"
                DELETE FROM ActorRate
                WHERE OrderID IN (SELECT OrderID FROM RentalOrder WHERE CustomerID = @CustomerID)";
                    using (SqlCommand cmd = new SqlCommand(deleteActorRates, myConnection))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Delete CustomerQueue
                    string deleteQueue = "DELETE FROM CustomerQueue WHERE CustomerID = @CustomerID";
                    using (SqlCommand queueCmd = new SqlCommand(deleteQueue, myConnection))
                    {
                        queueCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        queueCmd.ExecuteNonQuery();
                    }

                    // 3. Delete RentalOrder
                    string deleteOrders = "DELETE FROM RentalOrder WHERE CustomerID = @CustomerID";
                    using (SqlCommand orderCmd = new SqlCommand(deleteOrders, myConnection))
                    {
                        orderCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        orderCmd.ExecuteNonQuery();
                    }

                    // 4. Delete CustomerPhone
                    string deletePhones = "DELETE FROM CustomerPhone WHERE CustomerID = @CustomerID";
                    using (SqlCommand phoneCmd = new SqlCommand(deletePhones, myConnection))
                    {
                        phoneCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        phoneCmd.ExecuteNonQuery();
                    }

                    // 5. Delete Customer
                    string deleteCustomer = "DELETE FROM Customer WHERE CustomerID = @CustomerID";
                    using (SqlCommand customerCmd = new SqlCommand(deleteCustomer, myConnection))
                    {
                        customerCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        int rowsAffected = customerCmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer and all related data deleted successfully.");
                            myConnection.Close();
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Delete failed. Customer not found.");
                        }
                    }

                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting customer: " + ex.Message);
                    myConnection.Close();
                }
            }
        }
    }
}
