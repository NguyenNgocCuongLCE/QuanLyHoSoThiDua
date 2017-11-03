using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DataObject;

namespace DataAccessLayer
{
    public class ChucDanh_DAL
    {
        public Database_DAL DbAccess {get; set;}
        public DataTable LocalTable { get; set; }

        public ChucDanh_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;
            LocalTable = new DataTable("DM_ChucDanh");
            LocalTable.Columns.Add(new DataColumn("id", typeof(byte)));
            LocalTable.Columns.Add(new DataColumn("chucDanh", typeof(string)));
            LocalTable.Columns.Add(new DataColumn("trangThai", typeof(bool)));

            if (DbAccess.Database.Tables.Contains(LocalTable.TableName))
            {
                DbAccess.Database.Tables.Remove(LocalTable.TableName);
            }
            DbAccess.Database.Tables.Add(LocalTable);
        }

        public DataTable GetDtbChucDanh()
        {
            LocalTable.Rows.Clear();

            SQLiteCommand command = new SQLiteCommand(DbAccess.DatabaseConnection);
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM " + LocalTable.TableName;

            DbAccess.OpenConnection();
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                DataRow dataRow = LocalTable.NewRow();
                for (int i = 0; i < LocalTable.Columns.Count; i++)
                {
                    dataRow[i] = r[i];
                }
                LocalTable.Rows.Add(dataRow);
            }
            DbAccess.CloseConnection();

            return LocalTable;
        }

        public long GetNextID()
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "SELECT IFNULL(MAX(id), -1) FROM " + LocalTable.TableName;

            DbAccess.OpenConnection();
            long i = (long)cm.ExecuteScalar();
            DbAccess.CloseConnection();

            return i + 1;
        }

        public int Update(Obj_ChucDanh obj_ChucDanh)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName +
                " SET " +
                "chucDanh = @chucDanh, " +
                "trangThai = @trangThai " +
                "WHERE id = @id";

            cm.Parameters.Add(new SQLiteParameter("@chucDanh", obj_ChucDanh.ChucDanh));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_ChucDanh.TrangThai));
            cm.Parameters.Add(new SQLiteParameter("@id", obj_ChucDanh.ID));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }

        public int Insert(Obj_ChucDanh obj_ChucDanh)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName +
                " VALUES (" +
                "@id, " +
                "@chucDanh, " +
                "@trangThai " +
                ")";
            cm.Parameters.Add(new SQLiteParameter("@id", obj_ChucDanh.ID));
            cm.Parameters.Add(new SQLiteParameter("@chucDanh", obj_ChucDanh.ChucDanh));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_ChucDanh.TrangThai));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }

        public int Delete(string whereCondition)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE " + whereCondition;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }

        public int Delete(Obj_ChucDanh obj_ChucDanh)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_ChucDanh.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }
    }
}
