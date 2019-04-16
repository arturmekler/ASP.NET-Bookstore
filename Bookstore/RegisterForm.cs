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
            queryRegister(MySQLConnectionStringValue);
        }

        private void queryRegister(string MySQLConnectionStringValue)
        {
            string login = loginRegTextBox.Text;
            string password = passwordRegTextBox.Text;
            string vorname = vornameRegTextBox.Text;
            string name = nameRegTextBox.Text;
            string locality = localityRegTextBox.Text;

            if(TextBoxCheck(MySQLConnectionStringValue,login,password,vorname,name,locality) && 
                LoginCheck(MySQLConnectionStringValue,login))
            {
                using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionStringValue))
                {
                    sqlCon.Open();

                    string queryRegist = "INSERT INTO users (login, haslo, imie, nazwisko, miejscowosc) VALUES("
                        + "'"+ login + "'" + "," + "'"+ password + "'"+"," + "'"+ vorname +"'" + "," 
                        + "'"+ name + "'"+ "," + "'"+ locality + "'" + ")";

                    MySqlCommand commandDatabase = new MySqlCommand(queryRegist, sqlCon);

                    try
                    {
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();
                        
                            StoreForm store = new StoreForm(login, password, MySQLConnectionStringValue);
                            store.Show();

                            this.Hide();

                            store.Closed += (s, args) => this.Close();
                            store.Show();
                    }

                    catch (Exception e)
                    {
                        MessageBox.Show("Query error: " + e.Message);
                    }
                }
            }

            
           
        }

        private bool TextBoxCheck(string MySQLConnectionStringValue, string login, string password, string vorname,
            string name, string locality)
        {
            if (loginRegTextBox.Text == "" || passwordRegTextBox.Text == "" || vornameRegTextBox.Text == ""
                ||nameRegTextBox.Text == "" || localityRegTextBox.Text == "")
            {
                MessageBox.Show("Uzupełnij wszystkie pola", "Błąd");
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool LoginCheck(string MySQLConnectionStringValue, string login)
        {
            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionStringValue))
            {
                sqlCon.Open();

                string queryLogin = "SELECT login FROM users WHERE login = '" + login+"'";

                MySqlCommand commandDatabaseLogin = new MySqlCommand(queryLogin, sqlCon);
                MySqlDataReader myReaderLogin = commandDatabaseLogin.ExecuteReader();
                if (myReaderLogin.Read())
                {
                    if (myReaderLogin.GetString(0) == login)
                    {
                        MessageBox.Show("Dany login już istnieje, proszę zmienić nazwę loginu", "Błąd");
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    
                }
                else
                {
                    return true;
                }
            }

            
        }
    }
}
