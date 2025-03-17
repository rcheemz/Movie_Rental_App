using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Project291_Team3
{
    public partial class Form2 : Form
    {
        private SqlConnection myConnection;
       
        public Form2(SqlConnection connection)
        {

            InitializeComponent();

            // get the connection form form1 (previous page)
            myConnection = connection;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void customerSearchButton_Click(object sender, EventArgs e)
        {

        }

        private void createNewCustomer_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
