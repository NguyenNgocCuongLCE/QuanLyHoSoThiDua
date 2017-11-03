using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class TieuChi_DAL : IDAL<Obj_TieuChi, long>
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set ; }

        public TieuChi_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;

            LocalTable = new DataTable("DM_TieuChi");

            DataColumn id = new DataColumn("id", typeof(long));
            DataColumn nam = new DataColumn("nam", typeof(long));
            DataColumn ten = new DataColumn("ten", typeof(string));
            DataColumn moTa = new DataColumn("moTa", typeof(string));
            DataColumn ghiChu = new DataColumn("ghiChu", typeof(string));

            LocalTable.Columns.Add(id);
            LocalTable.Columns.Add(nam);
            LocalTable.Columns.Add(ten);
            LocalTable.Columns.Add(moTa);
            LocalTable.Columns.Add(ghiChu);

            DbAccess.Database.Tables.Add(LocalTable);
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

        public Obj_TieuChi CreateObj(DataRow dataRow)
        {
            Obj_TieuChi o = new Obj_TieuChi()
            {
                ID = (long)dataRow["id"],
                Nam = (long)dataRow["nam"],
                Ten = (dataRow["ten"] != DBNull.Value) ? (string)dataRow["ten"] : "",
                MoTa = (dataRow["ten"] != DBNull.Value) ? (string)dataRow["moTa"] : "",
                GhiChu = (dataRow["ten"] != DBNull.Value) ? (string)dataRow["ghiChu"] : ""
            };

            return o;
        }

        public Obj_TieuChi CreateObj(long id)
        {
            foreach (DataRow row in LocalTable.Rows)
            {
                if ((long)row["id"] == id)
                {
                    Obj_TieuChi o = CreateObj(row);
                    return o;
                }
            }

            return null;
        }

        public int Delete(Obj_TieuChi obj)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = @id";
            cm.Parameters.Add(new SQLiteParameter("@id", obj.ID));

            int i = -1;
            DbAccess.OpenConnection();
            i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                foreach (DataRow r in LocalTable.Rows)
                {
                    if ((long)r["id"] == obj.ID)
                    {
                        LocalTable.Rows.Remove(r);
                        break;
                    }
                }
            }

            return i;
        }

        public int Delete(string whereCondition)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDtb(string WhereCondition = "")
        {
            LocalTable.Rows.Clear();
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "SELECT * FROM " + LocalTable.TableName + ((WhereCondition.Length > 0) ? WhereCondition : "");

            try
            {
                DbAccess.OpenConnection();
                SQLiteDataReader r = cm.ExecuteReader();
                while (r.Read())
                {
                    DataRow dr = LocalTable.NewRow();
                    for (int i = 0; i < LocalTable.Columns.Count; i++)
                    {
                        dr[i] = r[i];
                    }
                    LocalTable.Rows.Add(dr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DbAccess.CloseConnection();
            }

            return LocalTable;
        }

        public int Insert(Obj_TieuChi obj)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName + " VALUES (" +
                "@id, " +
                "@nam, " +
                "@ten, " +
                "@moTa, " +
                "@ghiChu)";
            cm.Parameters.Add(new SQLiteParameter("@id", obj.ID));
            cm.Parameters.Add(new SQLiteParameter("@nam", obj.Nam));
            cm.Parameters.Add(new SQLiteParameter("@ten", obj.Ten));
            cm.Parameters.Add(new SQLiteParameter("@moTa", obj.MoTa));
            cm.Parameters.Add(new SQLiteParameter("@ghiChu", obj.GhiChu));

            int i = -1;

            try
            {
                DbAccess.OpenConnection();
                i = cm.ExecuteNonQuery();
            }
            finally
            {
                DbAccess.CloseConnection();
                if (i == 1)
                {
                    DataRow r = LocalTable.NewRow();
                    r["id"] = obj.ID;
                    r["ten"] = obj.Ten;
                    r["moTa"] = obj.MoTa;
                    r["ghiChu"] = obj.GhiChu;
                    LocalTable.Rows.Add(r);
                }
            }

            return i;
        }

        public int Update(Obj_TieuChi obj)
        {
            SQLiteCommand command = new SQLiteCommand(DbAccess.DatabaseConnection);
            command.CommandType = CommandType.Text;
            command.CommandText = "UPDATE " + LocalTable.TableName + " SET " +
                "ten = @ten, " +
                "moTa = @moTa, " +
                "ghiChu = @ghiChu " +
                "WHERE id = @id";

            command.Parameters.Add(new SQLiteParameter("@ten", obj.Ten));
            command.Parameters.Add(new SQLiteParameter("@moTa", obj.MoTa));
            command.Parameters.Add(new SQLiteParameter("@ghiChu", obj.GhiChu));
            command.Parameters.Add(new SQLiteParameter("@id", obj.ID));

            int i = -1;

            try
            {
                DbAccess.OpenConnection();
                i = command.ExecuteNonQuery();
            }
            finally
            {
                DbAccess.CloseConnection();
                if (i == 1)
                {
                    foreach (DataRow item in LocalTable.Rows)
                    {
                        if ((long)item["id"] == obj.ID)
                        {
                            item["ten"] = obj.Ten;
                            item["moTa"] = obj.MoTa;
                            item["ghiChu"] = obj.GhiChu;
                            break;
                        }
                    }
                }
            }
            return i;
        }
    }
}
