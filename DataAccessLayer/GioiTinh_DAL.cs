using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DataObject;
namespace DataAccessLayer
{
    public class GioiTinh_DAL
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set; }
        public GioiTinh_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;
            LocalTable = new DataTable("DM_GioiTinh");
            LocalTable.Columns.Add(new DataColumn("id", typeof(byte)));
            LocalTable.Columns.Add(new DataColumn("gioiTinh", typeof(string)));
            LocalTable.Columns.Add(new DataColumn("trangThai", typeof(bool)));
            DbAccess.Database.Tables.Add(LocalTable);
        }

        /// <summary>
        /// Lấy bảng danh mục giới tính
        /// </summary>
        /// <param name="WhereCondition">exp: trangThai = TRUE</param>
        /// <returns></returns>
        public DataTable GetDtb(string WhereCondition = "")
        {
            LocalTable.Rows.Clear();
            SQLiteCommand command = new SQLiteCommand(DbAccess.DatabaseConnection);
            command.CommandType = CommandType.Text;
            if (WhereCondition.Length == 0)
            {
                command.CommandText = "SELECT * FROM " + LocalTable.TableName;
            }
            else
            {
                command.CommandText = "SELECT* FROM " + LocalTable.TableName + " WHERE " + WhereCondition;
            }

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

        public int Insert(Obj_GioiTinh obj_GioiTinh)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName + " VALUES (" +
                "@id, " +
                "@gioiTinh, " +
                "@trangThai)";
            cm.Parameters.Add(new SQLiteParameter("@id", obj_GioiTinh.ID));
            cm.Parameters.Add(new SQLiteParameter("@gioiTinh", obj_GioiTinh.GioiTinh));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_GioiTinh.TrangThai));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }

        public int Update(Obj_GioiTinh obj_GioiTinh)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName + " SET " +
                "gioitinh = @gioiTinh, " +
                "trangThai = @trangThai " +
                " WHERE id = @id";
            cm.Parameters.Add(new SQLiteParameter("@gioiTinh", obj_GioiTinh.GioiTinh));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_GioiTinh.TrangThai));
            cm.Parameters.Add(new SQLiteParameter("@id", obj_GioiTinh.ID));

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

        public int Delete(Obj_GioiTinh obj_GioiTinh)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_GioiTinh.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }
    }
}
