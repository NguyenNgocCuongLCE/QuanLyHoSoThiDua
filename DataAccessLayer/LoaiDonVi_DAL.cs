using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DataObject;

namespace DataAccessLayer
{
    public class LoaiDonVi_DAL
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set; }

        public LoaiDonVi_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;
            LocalTable = new DataTable("DM_LoaiDonVi");
            LocalTable.Columns.Add(new DataColumn("id", typeof(byte)));
            LocalTable.Columns.Add(new DataColumn("tenLoai", typeof(string)));
            LocalTable.Columns.Add(new DataColumn("trangThai", typeof(bool)));
            DbAccess.Database.Tables.Add(LocalTable);
        }

        public DataTable GetDtbLoaiDonVi(string whereCondition = "")
        {
            LocalTable.Rows.Clear();

            SQLiteCommand command = new SQLiteCommand(DbAccess.DatabaseConnection);
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM " + LocalTable.TableName + ((whereCondition.Length ==0)? "":(" WHERE " + whereCondition));

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

        public int Insert(Obj_LoaiDonVi obj_LoaiDonVi)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName + " VALUES (" +
                "@id, " +
                "@tenLoai, " +
                "@trangThai)";
            cm.Parameters.Add(new SQLiteParameter("@id", obj_LoaiDonVi.ID));
            cm.Parameters.Add(new SQLiteParameter("@tenLoai", obj_LoaiDonVi.TenLoai));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_LoaiDonVi.TrangThai));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }

        public int Update(Obj_LoaiDonVi obj_LoaiDonVi)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName + " SET " +
                "tenLoai = @tenLoai, " +
                "trangThai = @trangThai" +
                " WHERE id = @id";
            cm.Parameters.Add(new SQLiteParameter("@id", obj_LoaiDonVi.ID));
            cm.Parameters.Add(new SQLiteParameter("@tenLoai", obj_LoaiDonVi.TenLoai));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_LoaiDonVi.TrangThai));

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

        public int Delete(Obj_LoaiDonVi obj_LoaiDonVi)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_LoaiDonVi.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            return i;
        }
    }
}
