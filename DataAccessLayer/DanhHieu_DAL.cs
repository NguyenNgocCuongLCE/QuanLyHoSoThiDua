using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace DataAccessLayer
{
    public class DanhHieu_DAL : IDAL<Obj_DanhHieu, long>
    {
        public Database_DAL DbAccess { get ; set; }
        public DataTable LocalTable { get ; set ; }

        public ChiTiet_DAL ChiTiet;

        public DanhHieu_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;

            LocalTable = new DataTable();
            LocalTable.Columns.Add(new DataColumn("id", typeof(long)));
            LocalTable.Columns.Add(new DataColumn("nam", typeof(long)));
            LocalTable.Columns.Add(new DataColumn("danhHieu", typeof(string)));
            LocalTable.Columns.Add(new DataColumn("trangThai", typeof(bool)));


        }

        public void CreateDataByYear(long baseYear = 0)
        {
            long y = DateTime.Now.Year;
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "SELECT COUNT(nam) FROM " + LocalTable.TableName + " WHERE nam =" + y;

            DbAccess.OpenConnection();
            long count = (long)cm.ExecuteScalar();
            DbAccess.CloseConnection();

            if (count > 0)
            {
                return;
            }

            var d = from DataRow x in LocalTable.Rows
                    where (long)x["nam"] == baseYear orderby (long)x["id"]
                    select x;

            foreach (var item in d)
            {
                Obj_DanhHieu o = CreateObj(item);
                o.Nam = y;
                o.ID = GetNextID();
                Insert(o);
            }
            
        }

        public void ResetDataOfYear(long year)
        {
            Delete("nam = " + year);
            CreateDataByYear();

        }

        public Obj_DanhHieu CreateObj(DataRow dataRow)
        {
            Obj_DanhHieu o = new Obj_DanhHieu();
            o.ID = (long)dataRow["id"];
            o.Nam = (long)dataRow["nam"];
            o.DanhHieu = (string)dataRow["danhHieu"];
            o.TrangThai = (bool)dataRow["trangThai"];
            return o;
        }

        public Obj_DanhHieu CreateObj(long id)
        {
            foreach (DataRow item in LocalTable.Rows)
            {
                if ((long)item["id"] == id)
                {
                    return CreateObj(item);
                }
            }
            return null;
        }

        public int Delete(Obj_DanhHieu obj_CaNhan)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = @id";

            cm.Parameters.Add(new SQLiteParameter("@id", obj_CaNhan.ID));

            int i = -1;
            DbAccess.OpenConnection();
            i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                foreach (DataRow item in LocalTable.Rows)
                {
                    if ((long)item[0] == obj_CaNhan.ID)
                    {
                        LocalTable.Rows.Remove(item);
                        LocalTable.AcceptChanges();
                        break;
                    }
                }
            }

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

        public DataTable GetDtb(string WhereCondition = "")
        {
            LocalTable.Rows.Clear();

            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "SELECT * FROM " + LocalTable.TableName + (WhereCondition.Length >0? (" WHERE " + WhereCondition ): "");

            DbAccess.OpenConnection();
            SQLiteDataReader r = cm.ExecuteReader();
            while (r.Read())
            {
                DataRow dr = LocalTable.NewRow();
                dr["id"] = r["id"];
                dr["nam"] = r["nam"];
                dr["danhHieu"] = r["danhhieu"];
                dr["trangThai"] = r["trangThai"];
                LocalTable.Rows.Add(dr);
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

            return (long)(i + 1);
        }

        public int Insert(Obj_DanhHieu obj)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName + " VALUES (" +
                "id = @id, " +
                "nam = @nam, " +
                "danhHieu = @danhHieu, " +
                "trangThai = @trangThai)";
            cm.Parameters.Add(new SQLiteParameter("@id", typeof(long)));
            cm.Parameters.Add(new SQLiteParameter("@nam", typeof(long)));
            cm.Parameters.Add(new SQLiteParameter("@danhHieu", typeof(string)));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", typeof(bool)));

            int i = -1;
            DbAccess.OpenConnection();
            i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                DataRow item           = LocalTable.NewRow();
                item["id"]             = obj.ID;
                item["nam"]            = obj.Nam;
                item["danhHieu"]       = obj.DanhHieu;
                item["trangThai"]      = obj.TrangThai;
                LocalTable.Rows.Add(item);
                LocalTable.AcceptChanges();
            }

            return i;
        }

        public int Update(Obj_DanhHieu obj)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName + " SET " +
                "nam = @nam, " +
                "danhHieu = @danhHieu, " +
                "trangThai = @trangThai " +
                "WHERE id = @id";
            cm.Parameters.Add(new SQLiteParameter("@nam", obj.Nam));
            cm.Parameters.Add(new SQLiteParameter("@danhHieu", obj.DanhHieu));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj.TrangThai));
            cm.Parameters.Add(new SQLiteParameter("@id", obj.ID));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                foreach (DataRow item in LocalTable.Rows)
                {
                    if ((long)item["id"]==obj.ID)
                    {
                        item["nam"] = obj.Nam;
                        item["danhHieu"] = obj.DanhHieu;
                        item["trangThai"] = obj.TrangThai;
                        break;
                    }
                }
            }

            return i;
        }
    }
}
