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
    public partial class EditCustomer : Form
    {
        private SqlConnection myConnection;
        private int customerID;
        public EditCustomer(SqlConnection connection, int customerID)
        {
            InitializeComponent();
            LoadDropDownLists();
            myConnection = connection;
            this.customerID = customerID;
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            string query = @"
                SELECT FirstName, LastName, StreetAddress, City, StateOrProvince, 
                       Country, ZipCode, Email, AccountNumber, CreditCardNumber
                FROM Customer
                WHERE CustomerID = @CustomerID";

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                if (myConnection.State == System.Data.ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    firstNameInput.Text = reader["FirstName"].ToString();
                    lastNameInput.Text = reader["LastName"].ToString();
                    streetInput.Text = reader["StreetAddress"].ToString();
                    cityInput.Text = reader["City"].ToString();
                    stateInput.Text = reader["StateOrProvince"].ToString();

                    zipInput.Text = reader["ZipCode"].ToString();
                    emailInput.Text = reader["Email"].ToString();
                    creditInput.Text = reader["CreditCardNumber"].ToString();

                    // Country ComboBox
                    string country = reader["Country"].ToString();
                    if (comboBox1.Items.Contains(country))
                    {
                        comboBox1.SelectedItem = country;
                    }
                }

                reader.Close();
                myConnection.Close();
            }
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {

        }

        // Function to populate the country dropdown
        private void LoadDropDownLists()
        {
            // hardcoded list of common countries
            // i think theres something in vs that has this list already will look into later just for now
            string[] countries = {
            "Canada", "United States", "United Kingdom", "Australia", "Germany", "France", "Italy", "Spain", "Mexico",
            "Brazil", "India", "China", "Japan", "South Korea", "South Africa", "New Zealand", "Russia"
            };

            comboBox1.Items.AddRange(countries); // Add list to ComboBox this is the drop down menu list
            comboBox1.SelectedIndex = 0; // Set the default selection to the first item so we will never have null selection

            string[] phoneNumbersTypes = { "Moblue", "Home", "Work" }; // leave as is
            comboBox2.Items.AddRange(phoneNumbersTypes);
            comboBox2.SelectedIndex = 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstNameInput.Text) ||
                string.IsNullOrWhiteSpace(lastNameInput.Text) ||
                string.IsNullOrWhiteSpace(streetInput.Text) ||
                string.IsNullOrWhiteSpace(cityInput.Text) ||
                string.IsNullOrWhiteSpace(stateInput.Text) ||
                string.IsNullOrWhiteSpace(zipInput.Text) ||
                string.IsNullOrWhiteSpace(emailInput.Text) ||
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            string query = @"
    UPDATE Customer
    SET FirstName = @FirstName, LastName = @LastName, StreetAddress = @StreetAddress,
        City = @City, StateOrProvince = @State, Country = @Country, ZipCode = @Zip,
        Email = @Email, CreditCardNumber = @Credit
    WHERE CustomerID = @CustomerID";

            using (SqlCommand cmd = new SqlCommand(query, myConnection))
            {
                cmd.Parameters.AddWithValue("@FirstName", firstNameInput.Text.Trim());
                cmd.Parameters.AddWithValue("@LastName", lastNameInput.Text.Trim());
                cmd.Parameters.AddWithValue("@StreetAddress", streetInput.Text.Trim());
                cmd.Parameters.AddWithValue("@City", cityInput.Text.Trim());
                cmd.Parameters.AddWithValue("@State", stateInput.Text.Trim());
                cmd.Parameters.AddWithValue("@Country", comboBox1.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Zip", zipInput.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", emailInput.Text.Trim());
                cmd.Parameters.AddWithValue("@Credit", creditInput.Text.Trim());
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                if (myConnection.State == System.Data.ConnectionState.Open)
                    myConnection.Close();

                myConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                myConnection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Customer information updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Update failed. No changes were made.");
                }
            }
        }

    }
}
