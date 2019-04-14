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
    public partial class StoreForm : Form
    {

        public StoreForm(string login, string password, string MySQLConnectionString)
        {
            InitializeComponent();

            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString))
            {
                sqlCon.Open();

                string queryID = "SELECT idklienta FROM users WHERE login='" + login + "' AND haslo='" + password + "'";
                
                MySqlCommand commandDatabaseID = new MySqlCommand(queryID, sqlCon);
                MySqlDataReader myReaderID = commandDatabaseID.ExecuteReader();

                if (myReaderID.Read())
                {
                    int userID = myReaderID.GetInt32(0);
                    vorNameLabel.Text = userID.ToString();
                }      
            }

            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString))
            {
                sqlCon.Open();

                string queryVorname = "SELECT imie FROM users WHERE login='" + login + "' AND haslo='" + password + "'";

                MySqlCommand commandDatabaseVorname = new MySqlCommand(queryVorname, sqlCon);
                MySqlDataReader myReaderVorname = commandDatabaseVorname.ExecuteReader();

                if (myReaderVorname.Read())
                {
                    string userVorname = myReaderVorname.GetString(0);
                    vorNameLabel.Text = userVorname.ToString();
                }
            }
        }
    }
}
