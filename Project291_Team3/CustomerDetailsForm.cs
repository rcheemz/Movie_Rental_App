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
        public CustomerDetailsForm(SqlConnection connection, int customerID)
        {
            InitializeComponent();
            myConnection = connection;
            this.customerID = customerID;
            LoadCustomerDetails();
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
    }
}
