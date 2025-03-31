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
            username.Text = "Username";
            username.ForeColor = Color.Gray;
            password.Text = "Password";
            password.ForeColor = Color.Gray;
            password.UseSystemPasswordChar = false;

            // Hook up placeholder events
            username.Enter += username_Enter;
            username.Leave += username_Leave;
            password.Enter += password_Enter;
            password.Leave += password_Leave;

        }
        private void username_Enter(object sender, EventArgs e)
        {
            if (username.Text == "Username")
            {
                username.Text = "";
                username.ForeColor = Color.Black;
            }
        }

        private void username_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                username.Text = "Username";
                username.ForeColor = Color.Gray;
            }
        }

        private void password_Enter(object sender, EventArgs e)
        {
            if (password.Text == "Password")
            {
                password.Text = "";
                password.ForeColor = Color.Black;
                password.UseSystemPasswordChar = true;
            }
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(password.Text))
            {
                password.UseSystemPasswordChar = false;
                password.Text = "Password";
                password.ForeColor = Color.Gray;
            }
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
            string usernameInput = username.Text; // rn were just gunna firstname and lastname for the login
            string passwordInput = password.Text; // we want to replace this with hashed password ask dr. pang for help


            if (ValidateLogin(usernameInput, passwordInput))
            {
                // pass the connection to the next page instead of redoing it everytime for new page
                HomePage homepage = new HomePage(myConnection);
                // when button is clicked show the next page and hide this page
                // when making logic for login this code will move into where the creds are met 
                homepage.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        /**
         * This function will validate the login creds of the employee user
         * @parameters username, password
         * @return bool
         */
        private bool ValidateLogin(string username, string password)
        {
            try
            {
                // debug ingore
                //MessageBox.Show($"Entered FirstName: '{username}'\nEntered LastName: '{password}'", "Debug");


                // Query to check if the first & last name exist in the Employee table
                string query = "SELECT COUNT(*) FROM Employee WHERE FirstName = @FirstName AND LastName = @LastName";

                //create a SqlCommand object to execute the SQL query
                // uses my connection insure the command is automatically closed after ecxecution
                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@FirstName", username); //place holders for the SQL query replace with username and password
                    cmd.Parameters.AddWithValue("@LastName", password); // prevents SQL injection

                    int count = (int)cmd.ExecuteScalar(); // executes query SELEC COUNT(*)
                    return count > 0; // Returns true if an employee with matching names exists 
                    // We will need to replace this logic with the password it will be similar
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message);
                return false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
