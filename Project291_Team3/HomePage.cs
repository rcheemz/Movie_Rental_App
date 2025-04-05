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

namespace Project291_Team3
{
    public partial class HomePage : Form
    {
        private SqlConnection myConnection;
        private int employeeID;
        public HomePage(SqlConnection connection, int employeeID)
        {
            InitializeComponent();
            myConnection = connection;
            this.employeeID = employeeID;
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            // pass the connection to the next page instead of redoing it everytime for new page
            Form2 form2 = new Form2(myConnection, employeeID);
            // when button is clicked show the next page and hide this page
            // when making logic for login this code will move into where the creds are met 
            form2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        // Take to movie form
        private void movieButton_Click(object sender, EventArgs e)
        {
            MovieMain movieMain = new MovieMain(myConnection, employeeID);
            movieMain.Show();
            this.Hide();
        }

        // Take to reports form
        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportsForm reportsform = new ReportsForm(myConnection, employeeID);
            reportsform.Show();
            this.Hide();
        }

        // Exit application
        private void logoutButton_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }
    }
}
