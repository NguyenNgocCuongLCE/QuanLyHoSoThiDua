using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class Database_BLL
    {
        public Database_DAL DbAccess_DAL { get; set; }
        public Database_BLL(string _connectionString)
        {
            DbAccess_DAL = new Database_DAL(_connectionString);
        }

        public bool CheckConnection()
        {
            return DbAccess_DAL.CheckConnection();
        }

        public List<string> GetAllTableName()
        {
            return DbAccess_DAL.GetAllTableName();
        }
    }
}
