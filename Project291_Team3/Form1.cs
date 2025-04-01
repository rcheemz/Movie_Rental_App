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
                //MessageBox.Show("Connected Successfully");
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
            string hashedPassword = ComputeSHA256Hash(passwordInput);

            int employeeID = GetEmployeeID(usernameInput, hashedPassword);

            if (employeeID != -1)
            {
                HomePage homepage = new HomePage(myConnection, employeeID);
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
       

        private int GetEmployeeID(string username, string password)
        {
            try
            {
                string query = "SELECT EmployeeID FROM Employee WHERE Username = @Username AND PasswordHash = @PasswordHash";

                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@PasswordHash", password);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking login: " + ex.Message);
                return -1;
            }
        }
        public static string ComputeSHA256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a hex string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // "x2" = lower-case hex
                }
                return builder.ToString();
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
