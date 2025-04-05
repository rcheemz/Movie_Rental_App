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
    public partial class OrderPlacementForm : Form
    {
        private SqlConnection myConnection;
        private int customerID;
        private int employeeID;
        private int movieID;
        private string movieName;
        private string customerName;
        private string employeeName;

        // Constructor for Order Placement Form
        public OrderPlacementForm(SqlConnection sqlConnection, int customerID, int employeeID, int movieID)
        {
            InitializeComponent();
            myConnection = sqlConnection;
            this.customerID = customerID;
            this.employeeID = employeeID;
            this.movieID = movieID;
        }

        private void orderPlacementForm_Load(object sender, EventArgs e)
        {
            LoadNames();
            movieLabel.Text = movieName;
            nameLabel.Text = customerName;
            employeeLabel.Text = employeeName;
        }

        private void firstNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LoadNames()
        {
            try
            {
                // Movie Name
                // Get the movie name based on MovieID
                string query1 = "SELECT MovieName FROM Movie WHERE MovieID = @MovieID";
                using (SqlCommand cmd = new SqlCommand(query1, myConnection))
                {
                    cmd.Parameters.AddWithValue("@MovieID", movieID);
                    if (myConnection.State == System.Data.ConnectionState.Open)
                        myConnection.Close(); // Ensure connection is closed before opening

                    myConnection.Open();
                    object result = cmd.ExecuteScalar(); // Execute query 
                    movieName = result != null ? result.ToString() : "Unknown";
                    myConnection.Close(); // Ensure connection is closed before opening
                }

                // Customer Name
                string query2 = "SELECT FirstName + ' ' + LastName FROM Customer WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query2, myConnection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    myConnection.Open();
                    object result = cmd.ExecuteScalar(); // Execute query 
                    customerName = result != null ? result.ToString() : "Unknown";
                    myConnection.Close();
                }

                // Employee Name
                string query3 = "SELECT FirstName + ' ' + LastName FROM Employee WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query3, myConnection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    myConnection.Open();
                    object result = cmd.ExecuteScalar(); // Execute query 
                    employeeName = result != null ? result.ToString() : "Unknown";
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading names: " + ex.Message);
            }
        }

        private void confirmOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Check Copies Available
                // Query to get number of copies
                string checkQuery = "SELECT NumberOfCopies FROM Movie WHERE MovieID = @MovieID";
                int copiesAvailable = 0;

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, myConnection))
                {
                    checkCmd.Parameters.AddWithValue("@MovieID", movieID);

                    if (myConnection.State == ConnectionState.Open)
                        myConnection.Close();

                    myConnection.Open();
                    object result = checkCmd.ExecuteScalar();
                    myConnection.Close();

                    copiesAvailable = result != null ? Convert.ToInt32(result) : 0;
                }

                if (copiesAvailable <= 0)
                {
                    MessageBox.Show("Sorry, there are no copies available for this movie.");
                    return;
                }

                // 2. Place Order
                string query = @"
            INSERT INTO RentalOrder (OrderID, CustomerID, MovieID, EmployeeID, CheckoutDateTime)
            VALUES (NEXT VALUE FOR RentalOrder_OrderID_Seq, @CustomerID, @MovieID, @EmployeeID, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@MovieID", movieID);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();
                }

                // 3. Reduce Copies by 1
                string updateQuery = @"
                    UPDATE Movie
                    SET NumberOfCopies = NumberOfCopies - 1
                    WHERE MovieID = @MovieID";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, myConnection))
                {
                    updateCmd.Parameters.AddWithValue("@MovieID", movieID);

                    myConnection.Open();
                    updateCmd.ExecuteNonQuery();
                    myConnection.Close();
                }

                // 4. Add to CustomerQueue (FIFO)
                int nextPosition = 1;
                string getPositionQuery = @"
                    SELECT ISNULL(MAX(QueuePosition), 0) + 1
                    FROM CustomerQueue
                    WHERE CustomerID = @CustomerID";

                using (SqlCommand posCmd = new SqlCommand(getPositionQuery, myConnection))
                {
                    posCmd.Parameters.AddWithValue("@CustomerID", customerID);

                    myConnection.Open();
                    object result = posCmd.ExecuteScalar();
                    if (result != null)
                    {
                        nextPosition = Convert.ToInt32(result);
                    }
                    myConnection.Close();
                }

                // 5. Insert into Queue
                string insertQueue = @"
            INSERT INTO CustomerQueue (CustomerID, MovieID, QueuePosition)
            VALUES (@CustomerID, @MovieID, @QueuePosition)";

                using (SqlCommand queueCmd = new SqlCommand(insertQueue, myConnection))
                {
                    queueCmd.Parameters.AddWithValue("@CustomerID", customerID);
                    queueCmd.Parameters.AddWithValue("@MovieID", movieID);
                    queueCmd.Parameters.AddWithValue("@QueuePosition", nextPosition);

                    myConnection.Open();
                    queueCmd.ExecuteNonQuery();
                    myConnection.Close();
                }

                MessageBox.Show("Order placed successfully! Movie added to queue.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
                myConnection.Close();
            }
        }
    }
 }
