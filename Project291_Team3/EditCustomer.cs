using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project291_Team3
{
    public partial class EditCustomer : Form
    {
        private SqlConnection myConnection;
        private int customerID;
        private List<(string PhoneNum, string PhoneType)> phoneNumbers = new List<(string, string)>();
        private List<string> deletedPhoneNumbers = new List<string>();

        public EditCustomer(SqlConnection connection, int customerID)
        {
            InitializeComponent();
            myConnection = connection;
            this.customerID = customerID;
            LoadDropDownLists();
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
            // Load Phone Numbers
            string phoneQuery = "SELECT PhoneNum, PhoneType FROM CustomerPhone WHERE CustomerID = @CustomerID";
            using (SqlCommand cmd = new SqlCommand(phoneQuery, myConnection))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                myConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string phoneNum = reader["PhoneNum"].ToString();
                    string phoneType = reader["PhoneType"].ToString();
                    phoneNumbers.Add((phoneNum, phoneType));
                    AddPhoneToList(phoneNum, phoneType);
                }

                reader.Close();
                myConnection.Close();
            }
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

        private void AddPhoneToList(string phoneNumber, string phoneType)
        {
            FlowLayoutPanel phonePanel = new FlowLayoutPanel();
            phonePanel.AutoSize = true;
            phonePanel.FlowDirection = FlowDirection.LeftToRight;
            phonePanel.Margin = new Padding(3);

            Label phoneLabel = new Label();
            phoneLabel.Text = phoneNumber + " (" + phoneType + ")";
            phoneLabel.AutoSize = true;
            phoneLabel.Margin = new Padding(3);

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

            phonePanel.Controls.Add(phoneLabel);
            phonePanel.Controls.Add(removeButton);

            phoneListPanel.Controls.Add(phonePanel);


        }

        private void addPhoneButton_Click(object sender, EventArgs e)
        {
            string phoneNumber = phoneInput.Text.Trim();
            string phoneType = comboBox2.SelectedItem.ToString();

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
            AddPhoneToList(phoneNumber, phoneType);
            phoneInput.Text = "";
        }

        private void RemovePhoneButton_Click(object sender, EventArgs e)
        {
            Button removeButton = sender as Button;
            string phoneNumber = removeButton.Tag.ToString();

            // Remove from phoneNumbers list
            phoneNumbers.RemoveAll(p => p.PhoneNum == phoneNumber);

            // Track for deletion
            deletedPhoneNumbers.Add(phoneNumber);

            // Remove from UI
            Control phonePanel = removeButton.Parent;
            phoneListPanel.Controls.Remove(phonePanel);
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
            if (!IsValidEmail(emailInput.Text))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email.");
                return;
            }

            try
            {
                // 1. Update Customer Info
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

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();

                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();
                }

                // 2. Delete Removed Phone Numbers
                foreach (string phoneNum in deletedPhoneNumbers)
                {
                    string deleteQuery = "DELETE FROM CustomerPhone WHERE CustomerID = @CustomerID AND PhoneNum = @PhoneNum";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, myConnection))
                    {
                        deleteCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        deleteCmd.Parameters.AddWithValue("@PhoneNum", phoneNum);

                        if (myConnection.State == ConnectionState.Open)
                            myConnection.Close();

                        myConnection.Open();
                        deleteCmd.ExecuteNonQuery();
                        myConnection.Close();
                    }
                }

                // 3. Insert any new phone numbers
                foreach (var phone in phoneNumbers)
                {
                    string checkQuery = "SELECT COUNT(*) FROM CustomerPhone WHERE CustomerID = @CustomerID AND PhoneNum = @PhoneNum";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, myConnection))
                    {
                        checkCmd.Parameters.AddWithValue("@CustomerID", customerID);
                        checkCmd.Parameters.AddWithValue("@PhoneNum", phone.PhoneNum);

                        if (myConnection.State == ConnectionState.Open)
                            myConnection.Close();

                        myConnection.Open();
                        int count = (int)checkCmd.ExecuteScalar();
                        myConnection.Close();

                        if (count == 0)
                        {
                            string insertQuery = "INSERT INTO CustomerPhone (CustomerID, PhoneNum, PhoneType) VALUES (@CustomerID, @PhoneNum, @PhoneType)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, myConnection))
                            {
                                insertCmd.Parameters.AddWithValue("@CustomerID", customerID);
                                insertCmd.Parameters.AddWithValue("@PhoneNum", phone.PhoneNum);
                                insertCmd.Parameters.AddWithValue("@PhoneType", phone.PhoneType);

                                if (myConnection.State == ConnectionState.Open)
                                    myConnection.Close();

                                myConnection.Open();
                                insertCmd.ExecuteNonQuery();
                                myConnection.Close();
                            }
                        }
                    }
                }

                MessageBox.Show("Customer information updated successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                myConnection.Close();
            }
        }

        private void addPhoneButton_Click_1(object sender, EventArgs e)
        {
            string phoneNumber = phoneInput.Text.Trim();
            string phoneType = comboBox2.SelectedItem.ToString();

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
            AddPhoneToList(phoneNumber, phoneType);
            phoneInput.Text = "";

        }

        private void phoneListPanel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
