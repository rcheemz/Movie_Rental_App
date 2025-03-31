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
        public HomePage(SqlConnection connection)
        {
            InitializeComponent();
            myConnection = connection;
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            // pass the connection to the next page instead of redoing it everytime for new page
            Form2 form2 = new Form2(myConnection);
            // when button is clicked show the next page and hide this page
            // when making logic for login this code will move into where the creds are met 
            form2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
