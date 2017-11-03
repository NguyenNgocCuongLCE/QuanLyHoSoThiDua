using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DataAccessLayer
{
    public class DatabaseAccess
    {
        //Fields and properties
        string tmpResult = "";

        string connectionString;
        DataSet database;
        SQLiteDataAdapter dataAdapter;
        SQLiteConnection databaseConnection;
        SQLiteCommandBuilder commandBuilder;

        internal string ConnectionString { get => connectionString; set => connectionString = value; }
        internal DataSet Database { get => database; set => database = value; }
        internal SQLiteDataAdapter DataAdapter { get => dataAdapter; set => dataAdapter = value; }
        internal SQLiteConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        internal SQLiteCommandBuilder CommandBuilder { get => commandBuilder; set => commandBuilder = value; }


        //Constructor
        public DatabaseAccess(string _connectionString)
        {
            ConnectionString = _connectionString;
            DatabaseConnection = new SQLiteConnection(ConnectionString);
            DataAdapter = new SQLiteDataAdapter();
            CommandBuilder = new SQLiteCommandBuilder(DataAdapter);
            Database = new DataSet("QuanLiHoSoThiDua");
        }

        //Methods
        internal SQLiteConnection CreateConnection(string _connectionString)
        {
            try
            {
                return new SQLiteConnection(_connectionString);
            }
            catch (Exception ex)
            {
                tmpResult = "Result create sqlite connection fail!\n" + ex.Message;
                return null;
            }
        }

        internal SQLiteConnection CreateConnection()
        {
            try
            {
                return new SQLiteConnection(ConnectionString);
            }
            catch (Exception ex)
            {
                tmpResult = "Result create sqlite connection fail!\n" + ex.Message;
                return null;
            }
        }

        internal bool OpenConnection(SQLiteConnection connection)
        {
            try
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection(ConnectionString);
                }
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                tmpResult = "Open connection fail!\n" + ex.Message;
                return false;
            }
        }

        internal bool OpenConnection()
        {
            try
            {
                if (DatabaseConnection == null)
                {
                    DatabaseConnection = new SQLiteConnection(ConnectionString);
                }
                if (DatabaseConnection.State == ConnectionState.Closed)
                {
                    DatabaseConnection.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                tmpResult = "Open connection fail!\n" + ex.Message;
                return false;
            }
        }

        internal void CloseConnection(SQLiteConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open) connection.Close();
        }

        internal void CloseConnection()
        {
            if (DatabaseConnection != null && DatabaseConnection.State == ConnectionState.Open) DatabaseConnection.Close();
        }

        internal bool CheckConnection(string _connectionString)
        {
            SQLiteConnection connection = CreateConnection(_connectionString);
            try
            {
                if (connection.State == ConnectionState.Closed) connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                tmpResult = "Check connection fail!\n" + ex.Message;
                return false;
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }
        }

        internal bool CheckConnection()
        {
            if (DatabaseConnection != null) DatabaseConnection = CreateConnection();
            try
            {
                if (DatabaseConnection.State == ConnectionState.Closed) DatabaseConnection.Open();
                return true;
            }
            catch (Exception ex)
            {
                tmpResult = "Check connection fail!\n" + ex.Message;
                return false;
            }
            finally
            {
                DatabaseConnection.Close();
            }
        }




    }
}
