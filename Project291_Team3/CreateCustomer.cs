using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Project291_Team3
{
    public partial class CreateCustomer : Form
    {
        private SqlConnection myConnection;
        public CreateCustomer(SqlConnection connection)
        {
            InitializeComponent();
            // get the connection form form1 (previous page)
            myConnection = connection;
        }

        private void CreateCustomer_Load(object sender, EventArgs e)
        {

        }

        private void firstNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void lastNameInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void streetInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (myConnection == null)
                {
                    MessageBox.Show("Database connection is not established.");
                    return;
                }

                // Ensure the connection is closed before opening
                if (myConnection.State == System.Data.ConnectionState.Open)
                {
                    myConnection.Close();
                }


                // Test connection
                myConnection.Open();
                myConnection.Close();
                // Get user input
                string firstName = firstNameInput.Text.Trim();
                string lastName = lastNameInput.Text.Trim();
                string street = streetInput.Text.Trim();
                string city = cityInput.Text.Trim();
                string state = stateInput.Text.Trim();
                string country = countryInput.Text.Trim();
                string zip = zipInput.Text.Trim();
                string email = emailInput.Text.Trim();
                string phoneNumber = phoneInput.Text.Trim();
                string creditCardNumber = creditInput.Text.Trim();

                // Validate required fields
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(state) || string.IsNullOrEmpty(country) ||
                    string.IsNullOrEmpty(zip) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                // Validation: Check email format
                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email.");
                    return;
                }

                // Validation: Check phone number format (if entered)
                if (!string.IsNullOrEmpty(phoneNumber) && !IsValidPhoneNumber(phoneNumber))
                {
                    MessageBox.Show("Invalid phone number. It must be exactly 10 digits.");
                    return;
                }

                // Generate a unique AccountNumber (for example, based on timestamp)
                int accountNumber = new Random().Next(100000, 999999);

                // Insert into Customer table
                string insertCustomerQuery = @"
                    INSERT INTO Customer (CustomerID, FirstName, LastName, StreetAddress, City, StateOrProvince, Country, ZipCode, Email, AccountNumber, CreditCardNumber)
                    VALUES (@CustomerID, @FirstName, @LastName, @Street, @City, @State, @Country, @Zip, @Email, @AccountNumber, @CreditCardNumber)";

                using (SqlCommand cmd = new SqlCommand(insertCustomerQuery, myConnection))
                {
                    // Generate a unique CustomerID
                    int customerID = new Random().Next(10000, 99999);

                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@Street", street);
                    cmd.Parameters.AddWithValue("@City", city);
                    cmd.Parameters.AddWithValue("@State", state);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Parameters.AddWithValue("@Zip", zip);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@AccountNumber", accountNumber);
                    cmd.Parameters.AddWithValue("@CreditCardNumber", string.IsNullOrEmpty(creditCardNumber) ? (object)DBNull.Value : creditCardNumber);

                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                    // Insert phone number if provided
                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        string insertPhoneQuery = "INSERT INTO CustomerPhone (CustomerID, PhoneNum, PhoneType) VALUES (@CustomerID, @PhoneNum, 'Mobile')";
                        using (SqlCommand phoneCmd = new SqlCommand(insertPhoneQuery, myConnection))
                        {
                            phoneCmd.Parameters.AddWithValue("@CustomerID", customerID);
                            phoneCmd.Parameters.AddWithValue("@PhoneNum", phoneNumber);

                            myConnection.Open();
                            phoneCmd.ExecuteNonQuery();
                            myConnection.Close();
                        }
                    }

                    MessageBox.Show("Customer created successfully!");
                    this.Close(); // Close form after creation
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                myConnection.Close();
            }

        }

        // Function to validate email format
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email regex
            return Regex.IsMatch(email, pattern);
        }

        // Function to validate phone number format
        private bool IsValidPhoneNumber(string phone)
        {
            string pattern = @"^\d{10}$"; // Exactly 10 digits
            return Regex.IsMatch(phone, pattern);
        }
    }
}
