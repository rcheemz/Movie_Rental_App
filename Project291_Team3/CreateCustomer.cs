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
        private List<(string PhoneNum, string PhoneType)> phoneNumbers = new List<(string, string)>();
        public CreateCustomer(SqlConnection connection)
        {
            InitializeComponent();
            LoadDropDownLists();
            // get the connection form form1 (previous page)
            myConnection = connection;
            stateInput.KeyPress += new KeyPressEventHandler(stateInput_KeyPress);
            zipInput.KeyPress += new KeyPressEventHandler(zipInput_KeyPress);
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
        private void zipInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters, numbers, spaces, and limit input to 10 characters
            if (!char.IsLetterOrDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Block invalid input
            }

            if (zipInput.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block input after 10 characters
            }
        }

        private void stateInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only letters (A-Z, a-z) and limit input to 2 characters
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block non-letter input
            }

            if (stateInput.Text.Length >= 2 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block input after 2 characters
            }
        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            
        }

        private void RemovePhoneButton_Click(object sender, EventArgs e)
        {
            Button removeButton = sender as Button;
            string phoneNumber = removeButton.Tag.ToString();

            // Remove from phoneNumbers list
            phoneNumbers.RemoveAll(p => p.PhoneNum == phoneNumber);

            // Remove from UI
            Control phonePanel = removeButton.Parent;
            phoneListPanel.Controls.Remove(phonePanel); ;
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

                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }

                myConnection.Open();
                myConnection.Close();

                string firstName = firstNameInput.Text.Trim();
                string lastName = lastNameInput.Text.Trim();
                string street = streetInput.Text.Trim();
                string city = cityInput.Text.Trim();
                string state = stateInput.Text.Trim();
                string country = comboBox1.SelectedItem.ToString();
                string zip = zipInput.Text.Trim();
                string email = emailInput.Text.Trim();
                string creditCardNumber = creditInput.Text.Trim();

                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) ||
                    string.IsNullOrEmpty(street) || string.IsNullOrEmpty(city) ||
                    string.IsNullOrEmpty(state) || string.IsNullOrEmpty(country) ||
                    string.IsNullOrEmpty(zip) || string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please fill in all required fields.");
                    return;
                }

                if (!IsValidEmail(email))
                {
                    MessageBox.Show("Invalid email format. Please enter a valid email.");
                    return;
                }

                int accountNumber = new Random().Next(100000, 999999);

                string insertCustomerQuery = @"
                    INSERT INTO Customer (CustomerID, FirstName, LastName, StreetAddress, City, StateOrProvince, Country, ZipCode, Email, AccountNumber, CreditCardNumber)
                    VALUES (@CustomerID, @FirstName, @LastName, @Street, @City, @State, @Country, @Zip, @Email, @AccountNumber, @CreditCardNumber)";

                using (SqlCommand cmd = new SqlCommand(insertCustomerQuery, myConnection))
                {
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

                    foreach (var phone in phoneNumbers)
                    {
                        string insertPhoneQuery = "INSERT INTO CustomerPhone (CustomerID, PhoneNum, PhoneType) VALUES (@CustomerID, @PhoneNum, @PhoneType)";
                        using (SqlCommand phoneCmd = new SqlCommand(insertPhoneQuery, myConnection))
                        {
                            phoneCmd.Parameters.AddWithValue("@CustomerID", customerID);
                            phoneCmd.Parameters.AddWithValue("@PhoneNum", phone.PhoneNum);
                            phoneCmd.Parameters.AddWithValue("@PhoneType", phone.PhoneType);

                            myConnection.Open();
                            phoneCmd.ExecuteNonQuery();
                            myConnection.Close();
                        }
                    }

                    MessageBox.Show("Customer created successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                myConnection.Close();
            }
        }

        /**
         * This function returns a bool to check proper email formatting
         */
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$"; // Simple email regex xxx@yyy.zzz
            return Regex.IsMatch(email, pattern);
        }

        /**
         * This function returns a bool to check proper phonenumber
         */
        private bool IsValidPhoneNumber(string phone)
        {
            string pattern = @"^\d{10}$"; // Exactly 10 digits
            return Regex.IsMatch(phone, pattern);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string phoneNumber = phoneInput.Text.Trim();
            string phoneType = comboBox2.SelectedItem?.ToString();

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Invalid phone number. It must be exactly 10 digits.");
                return;
            }

            if (phoneNumbers.Any(p => p.PhoneNum == phoneNumber))
            {
                MessageBox.Show("This phone number is already added.");
                return;
            }

            phoneNumbers.Add((phoneNumber, phoneType));

            // Create Panel
            FlowLayoutPanel phonePanel = new FlowLayoutPanel();
            phonePanel.AutoSize = true;
            phonePanel.FlowDirection = FlowDirection.LeftToRight;
            phonePanel.Margin = new Padding(3);

            // Create Label
            Label phoneLabel = new Label();
            phoneLabel.Text = $"{phoneNumber} ({phoneType})";
            phoneLabel.AutoSize = true;
            phoneLabel.Margin = new Padding(3);

            // Create Remove Button
            Button removeButton = new Button();
            removeButton.Text = "X";
            removeButton.Tag = phoneNumber;
            removeButton.Size = new Size(20, 20);
            removeButton.Font = new Font("Arial", 7, FontStyle.Bold);
            removeButton.TextAlign = ContentAlignment.MiddleCenter;
            removeButton.Padding = new Padding(0);
            removeButton.Margin = new Padding(3, 0, 3, 0);
            removeButton.BackColor = Color.LightCoral;
            removeButton.ForeColor = Color.White;
            removeButton.FlatStyle = FlatStyle.Flat;
            removeButton.Click += RemovePhoneButton_Click;

            // Add to panel
            phonePanel.Controls.Add(phoneLabel);
            phonePanel.Controls.Add(removeButton);

            // Add panel to phone list panel
            phoneListPanel.Controls.Add(phonePanel);

            // Reset input
            phoneInput.Text = "";

        }
    }
}
