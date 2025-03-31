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
                string query1 = "SELECT MovieName FROM Movie WHERE MovieID = @MovieID";
                using (SqlCommand cmd = new SqlCommand(query1, myConnection))
                {
                    cmd.Parameters.AddWithValue("@MovieID", movieID);
                    if (myConnection.State == System.Data.ConnectionState.Open)
                        myConnection.Close();

                    myConnection.Open();
                    object result = cmd.ExecuteScalar();
                    movieName = result != null ? result.ToString() : "Unknown";
                    myConnection.Close();
                }

                // Customer Name
                string query2 = "SELECT FirstName + ' ' + LastName FROM Customer WHERE CustomerID = @CustomerID";
                using (SqlCommand cmd = new SqlCommand(query2, myConnection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    myConnection.Open();
                    object result = cmd.ExecuteScalar();
                    customerName = result != null ? result.ToString() : "Unknown";
                    myConnection.Close();
                }

                // Employee Name
                string query3 = "SELECT FirstName + ' ' + LastName FROM Employee WHERE EmployeeID = @EmployeeID";
                using (SqlCommand cmd = new SqlCommand(query3, myConnection))
                {
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                    myConnection.Open();
                    object result = cmd.ExecuteScalar();
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
                string query = @"
                    INSERT INTO RentalOrder (OrderID, CustomerID, MovieID, EmployeeID, CheckoutDateTime)
                    VALUES (NEXT VALUE FOR RentalOrder_OrderID_Seq, @CustomerID, @MovieID, @EmployeeID, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(query, myConnection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@MovieID", movieID);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeID);

                    if (myConnection.State == System.Data.ConnectionState.Open)
                        myConnection.Close();

                    myConnection.Open();
                    cmd.ExecuteNonQuery();
                    myConnection.Close();

                    MessageBox.Show("Order placed successfully!");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error placing order: " + ex.Message);
            }
       

        }
    }
}
