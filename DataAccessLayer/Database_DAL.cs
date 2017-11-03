using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DataAccessLayer
{
    public class Database_DAL
    {
        #region Fields and properties-----------------------------------------------------------------------------------------
        public string tmpResult = "";

        string connectionString;
        DataSet database;
        SQLiteConnection databaseConnection;
        //public SQLiteDataAdapter dataAdapter;
        //public SQLiteCommandBuilder commandBuilder;

        public string ConnectionString { get => connectionString; set => connectionString = value; }
        public DataSet Database { get => database; set => database = value; }
        public SQLiteConnection DatabaseConnection { get => databaseConnection; set => databaseConnection = value; }
        //public SQLiteDataAdapter DataAdapter { get => dataAdapter; set => dataAdapter = value; }
        //public SQLiteCommandBuilder CommandBuilder { get => commandBuilder; set => commandBuilder = value; }
        #endregion-------------------------------------------------------------------------------------------------------------

        //Constructor----------------------------------------------------------------------------------------------------------
        public Database_DAL(string _connectionString)
        {
            ConnectionString = _connectionString;
            DatabaseConnection = new SQLiteConnection(ConnectionString);
            //DataAdapter = new SQLiteDataAdapter();
            //CommandBuilder = new SQLiteCommandBuilder(DataAdapter);
            Database = new DataSet("QuanLiHoSoThiDua");
        }

        #region Methods--------------------------------------------------------------------------------------------------------

        public SQLiteConnection CreateConnection(string _connectionString)
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

        public SQLiteConnection CreateConnection()
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

        public bool OpenConnection(SQLiteConnection connection)
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

        public bool OpenConnection()
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

        public void CloseConnection(SQLiteConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open) connection.Close();
        }

        public void CloseConnection()
        {
            if (DatabaseConnection != null && DatabaseConnection.State == ConnectionState.Open) DatabaseConnection.Close();
        }

        public bool CheckConnection(string _connectionString)
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

        public bool CheckConnection()
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

        public List<string> GetAllTableName()
        {
            List<string> tbl = new List<string>();

            SQLiteCommand cm = new SQLiteCommand(DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "select name from sqlite_master where type = 'table'";

            OpenConnection();
            SQLiteDataReader r = cm.ExecuteReader();
            while (r.Read())
            {
                tbl.Add(r[0].ToString());
            }
            CloseConnection();

            return tbl;
        }

        public void CreateTable(string tableName)
        {
            if (GetAllTableName().Contains(tableName))
            {
                throw new Exception("Đã có bảng:\"" + tableName + "\"");
            }





        }
        #endregion-------------------------------------------------------------------------------------------------------------

    }
}
