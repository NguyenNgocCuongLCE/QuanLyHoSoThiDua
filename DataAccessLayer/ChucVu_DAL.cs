using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DataObject;
namespace DataAccessLayer
{
    public class ChucVu_DAL
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set; }

        public ChucVu_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;
            LocalTable = new DataTable("DM_ChucVu");
            LocalTable.Columns.Add(new DataColumn("id", typeof(byte)));
            LocalTable.Columns.Add(new DataColumn("chucVu", typeof(string)));
            LocalTable.Columns.Add(new DataColumn("trangThai", typeof(bool)));

            if (DbAccess.Database.Tables.Contains(LocalTable.TableName))
            {
                DbAccess.Database.Tables.Remove(LocalTable.TableName);
            }
            DbAccess.Database.Tables.Add(LocalTable);
        }

        public DataTable GetDtbChucVu()
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

        public int Insert(Obj_ChucVu obj_ChucVu)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName +
                " VALUES (" +
                "@id, @chucVu, @trangThai)";

            cm.Parameters.Add(new SQLiteParameter("@id", obj_ChucVu.ID));
            cm.Parameters.Add(new SQLiteParameter("@chucVu", obj_ChucVu.ChucVu));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_ChucVu.TrangThai));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }

        public int Update(Obj_ChucVu obj_ChucVu)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName +
                " SET " +
                "chucVu = @chucVu, " +
                "trangThai = @trangThai " +
                "WHERE id = @id";

            cm.Parameters.Add(new SQLiteParameter("@chucVu", obj_ChucVu.ChucVu));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_ChucVu.TrangThai));
            cm.Parameters.Add(new SQLiteParameter("@id", obj_ChucVu.ID));

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

        public int Delete(Obj_ChucVu obj_ChucVu)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_ChucVu.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }
    }

}
