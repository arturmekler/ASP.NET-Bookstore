using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Bookstore
{
    public partial class RegisterForm : Form
    {
        public string MySQLConnectionStringValue;

        public RegisterForm(string MySQLConnectionString)
        {
            InitializeComponent();
            MySQLConnectionStringValue = MySQLConnectionString;
        }

        private void regButton_Click(object sender, EventArgs e)
        {

        }

        private void queryRegister(string MySQLConnectionStringValue)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionStringValue))
            {
                sqlCon.Open();

                string login = loginRegTextBox.Text;
                string password = passwordRegTextBox.Text;
               

                string query = "SELECT * FROM users WHERE login='" + login + "' AND haslo='" + password + "'";


                MySqlCommand commandDatabase = new MySqlCommand(query, sqlCon);

                try
                {
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        MessageBox.Show("Dziala");


                        StoreForm store = new StoreForm(login, password, MySQLConnectionStringValue);
                        store.Show();

                        this.Hide();

                        store.Closed += (s, args) => this.Close();
                        store.Show();

                    }
                    else
                    {
                        MessageBox.Show("Nie poprawny login lub hasło", "Błąd logowania");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Query error: " + e.Message);
                }
            }

        }
    }
}
