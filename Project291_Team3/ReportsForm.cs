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
    public partial class ReportsForm : Form
    {
        private SqlConnection myConnection;
       
        private int employeeID;
        public ReportsForm(SqlConnection connection, int employeeID)
        {
            InitializeComponent();
            myConnection = connection;
            this.employeeID = employeeID;
            
            LoadYearMonthDropdowns();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {

        }
        private void LoadYearMonthDropdowns()
        {
            for (int year = 2022; year <= DateTime.Now.Year; year++)
            {
                yearInput.Items.Add(year);
            }
            yearInput.SelectedIndex = yearInput.Items.Count - 1;

            for (int month = 1; month <= 12; month++)
            {
                monthInput.Items.Add(month);
            }
            monthInput.SelectedIndex = DateTime.Now.Month - 1;
        }



        private void LoadMonthlySalesReport()
        {
            try
            {
                string query = "EXEC GetMonthlySalesReport";
                SqlDataAdapter adapter = new SqlDataAdapter(query, myConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                monthlySalesGrid.DataSource = dt;
                monthlySalesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadTopCustomers(int year, int month)
        {
            try
            {
                string query = "EXEC GetTopCustomersByMonth @Year, @Month";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);


                topCustomersGrid.DataSource = dt;
                topCustomersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadTopMovies(int year, int month)
        {
            try
            {
                string query = "EXEC GetTopMoviesByMonth @Year, @Month";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                topMoviesGrid.DataSource = dt;
                topMoviesGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadRentalsByType(int year, int month)
        {
            try
            {
                string query = "EXEC GetRentalsByMovieTypePerMonth @Year, @Month";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                rentalsByTypeGrid.DataSource = dt;
                rentalsByTypeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadEmployeeOfTheMonth(int year, int month)
        {
            try
            {
                string query = "EXEC GetEmployeeOfTheMonth @Year, @Month";
                SqlCommand cmd = new SqlCommand(query, myConnection);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                employeeOfMonthGrid.DataSource = dt;
                employeeOfMonthGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void generateButton_Click_1(object sender, EventArgs e)
        {
            int year = Convert.ToInt32(yearInput.SelectedItem);
            int month = Convert.ToInt32(monthInput.SelectedItem);

            LoadMonthlySalesReport();
            LoadTopCustomers(year, month);
            LoadTopMovies(year, month);
            LoadRentalsByType(year, month);
            LoadEmployeeOfTheMonth(year, month);
        }

        private void topMoviesGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void back_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage(myConnection, employeeID);
            homePage.Show();
            this.Close();

        }
    }
}
