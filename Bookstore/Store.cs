﻿using System;
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
            int userIDValue;

            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString))
            {
                sqlCon.Open();

                string queryID = "SELECT idklienta FROM users WHERE login='" + login + "' AND haslo='" + password + "'";
                
                MySqlCommand commandDatabaseID = new MySqlCommand(queryID, sqlCon);
                MySqlDataReader myReaderID = commandDatabaseID.ExecuteReader();

                if (myReaderID.Read())
                {
                    int userID = myReaderID.GetInt32(0);
                    userIDLabel.Text = userID.ToString();
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

            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString))
            {
                sqlCon.Open();

                string queryName = "SELECT nazwisko FROM users WHERE login='" + login + "' AND haslo='" + password + "'";

                MySqlCommand commandDatabaseName = new MySqlCommand(queryName, sqlCon);
                MySqlDataReader myReaderName = commandDatabaseName.ExecuteReader();

                if (myReaderName.Read())
                {
                    string userName = myReaderName.GetString(0);
                    nameLabel.Text = userName.ToString();
                }
            }

            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString))
            {
                sqlCon.Open();

                string queryName = "SELECT nazwisko FROM users WHERE login='" + login + "' AND haslo='" + password + "'";

                MySqlCommand commandDatabaseName = new MySqlCommand(queryName, sqlCon);
                MySqlDataReader myReaderName = commandDatabaseName.ExecuteReader();

                if (myReaderName.Read())
                {
                    string userName = myReaderName.GetString(0);
                    nameLabel.Text = userName.ToString();
                }
            }

            using (MySqlConnection sqlCon = new MySqlConnection(MySQLConnectionString))
            {
                sqlCon.Open();

                //string queryOrders = "SELECT nazwisko FROM zamowienia WHERE login='" + login + "' AND haslo='" + password + "'";
                string queryOrders = "SELECT ksiazki.tytul AS 'Tytuł', ksiazki.imieautora AS 'Imie autora', ksiazki.nazwiskoautora AS 'Nazwisko autora' FROM ksiazki INNER JOIN zamowienia ON " +
                    "zamowienia.idksiazki = ksiazki.idksiazki WHERE zamowienia.idklienta=" + userIDLabel.Text;
                    
                    

                MySqlCommand commandDatabaseOrders = new MySqlCommand(queryOrders, sqlCon);
                MySqlDataReader myReaderOrders = commandDatabaseOrders.ExecuteReader();

                DataTable dtbl = new DataTable();

                dtbl.Load(myReaderOrders);
                ordersDataGridView.DataSource = dtbl;

            }
        }
    }
}
