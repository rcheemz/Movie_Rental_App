using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Project291_Team3
{
    public partial class Form1 : Form
    {
        public SqlConnection myConnection;
        public SqlCommand myCommand;
        public SqlDataReader myDataReader;
        public Form1()
        {
            InitializeComponent();

            // ** IMPORTANT**
            // since we are using our local servers you need to change this to you your server name and whatever you named the database
            // you can check the server name under the connect or when connecting it will show server name
            String connectionString = "Server = ZENBOOK; Database = MovieRentalProject; Trusted_Connection = yes;";

            myConnection = new SqlConnection(connectionString);

            try
            {
                myConnection.Open();
                myCommand = new SqlCommand();
                myCommand.Connection = myConnection; // Link the connection

                // we can get rid of this but this is to show that we connected successfully to the database
                MessageBox.Show("Connected Successfully");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error");
                this.Close();


            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void usernameLabel_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string usernameInput = username.Text; //rn were just gunna firstname and lastname for the login
            string passwordInput = password.Text; //


            if (ValidateLogin(usernameInput, passwordInput))
            {
                // pass the connection to the next page instead of redoing it
                Form2 form2 = new Form2(myConnection);
                // when button is clicked show the next page and hide this page
                // when making logic for login this code will move into where the creds are met 
                form2.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private bool ValidateLogin(string username, string password)
        {
            try
            {
                // debug ingore
                //MessageBox.Show($"Entered FirstName: '{username}'\nEntered LastName: '{password}'", "Debug");


                // Query to check if the first & last name exist in the Employee table
                string query = "SELECT COUNT(*) FROM Employee WHERE FirstName = @FirstName AND LastName = @LastName";

                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", username);
                    cmd.Parameters.AddWithValue("@LastName", password);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Returns true if an employee with matching names exists
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message);
                return false;
            }
        }
    }
}
