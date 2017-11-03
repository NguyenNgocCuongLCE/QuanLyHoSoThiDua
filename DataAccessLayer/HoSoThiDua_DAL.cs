using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using DataObject;
namespace DataAccessLayer
{
    public class HoSoThiDua_DAL
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set; }

        public HoSoThiDua_DAL(Database_DAL database_DAL)
        {
            DbAccess = database_DAL;
            LocalTable = new DataTable("DS_HoSoThiDua");

            DataColumn id = new DataColumn("id", typeof(long));
            DataColumn idCaNhan = new DataColumn("idCaNhan", typeof(long));
            DataColumn idDonVi = new DataColumn("idDonVi", typeof(long));
            DataColumn nam = new DataColumn("nam", typeof(long));
            DataColumn danhHieuDangKy = new DataColumn("danhHieuDangKy", typeof(byte));
            DataColumn danhHieuDatDuoc = new DataColumn("danhHieuDatDuoc", typeof(byte));

            LocalTable.Columns.Add(id);
            LocalTable.Columns.Add(idCaNhan);
            LocalTable.Columns.Add(idDonVi);
            LocalTable.Columns.Add(nam);
            LocalTable.Columns.Add(danhHieuDangKy);
            LocalTable.Columns.Add(danhHieuDatDuoc);

            if (DbAccess.Database.Tables.Contains(LocalTable.TableName))
            {
                DbAccess.Database.Tables.Remove(LocalTable.TableName);
            }
            DbAccess.Database.Tables.Add(LocalTable);
        }

        public DataTable GetDtb(string whereCondition = "")
        {
            SQLiteCommand command = new SQLiteCommand(DbAccess.DatabaseConnection);
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT * FROM " + LocalTable.TableName + (whereCondition.Length > 0 ? (" WHERE " + whereCondition) : "");

            LocalTable.Rows.Clear();

            DbAccess.OpenConnection();
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                DataRow nr = LocalTable.NewRow();
                for (int i = 0; i < LocalTable.Columns.Count; i++)
                {
                    nr[i] = r[i];
                }
                LocalTable.Rows.Add(nr);
            }
            DbAccess.CloseConnection();

            return LocalTable;
        }

        public int Insert(Obj_HoSoThiDua obj)
        {

            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName + " VALUES (" +
               "@id, " +
               "@idCaNhan, " +
               "@idDonVi, " +
               "@nam, " +
               "@danhHieuDangKy, " +
               "@danhHieuDatDuoc)";
            cm.Parameters.Add(new SQLiteParameter("@id", obj.ID));
            cm.Parameters.Add(new SQLiteParameter("@idCaNhan", obj.IDCaNhan));
            cm.Parameters.Add(new SQLiteParameter("@idDonVi", obj.IDDonVi));
            cm.Parameters.Add(new SQLiteParameter("@nam", obj.Nam));
            cm.Parameters.Add(new SQLiteParameter("@danhHieuDangKy", obj.DanhHieuDangKy));
            cm.Parameters.Add(new SQLiteParameter("@danhHieuDatDuoc", obj.DanhHieuDatDuoc));

            int i = -1;
            DbAccess.OpenConnection();
            i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                DataRow nr = LocalTable.NewRow();
                nr["id"] = obj.ID;
                nr["idCaNhan"] = obj.IDCaNhan;
                nr["idDonVi"] = obj.IDDonVi;
                nr["nam"] = obj.Nam;
                nr["danhHieuDangKy"] = obj.DanhHieuDangKy;
                nr["danhHieuDatDuoc"] = obj.DanhHieuDatDuoc;
                LocalTable.Rows.Add(nr);
            }

            return i;
        }

        public int Update(Obj_HoSoThiDua obj)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName +
                " SET " +
                "idCaNhan = @idCaNhan                               , " +
                "idDonVi = @idDonVi                                 , " +
                "nam = @nam                                         , " +
                "danhHieuDangKy = @danhHieuDangKy                   , " +
                "danhHieuDatDuoc = @danhHieuDatDuoc " +
                "WHERE id = @id";
            cm.Parameters.Add(new SQLiteParameter("@idCaNhan", obj.IDCaNhan));
            cm.Parameters.Add(new SQLiteParameter("@idDonVi", obj.IDDonVi));
            cm.Parameters.Add(new SQLiteParameter("@nam", obj.Nam));
            cm.Parameters.Add(new SQLiteParameter("@danhHieuDangKy", obj.DanhHieuDangKy));
            cm.Parameters.Add(new SQLiteParameter("@danhHieuDatDuoc", obj.DanhHieuDatDuoc));
            cm.Parameters.Add(new SQLiteParameter("@id", obj.ID));

            int i = -1;
            DbAccess.OpenConnection();
            i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            //update to localtable
            if (i == 1)
            {
                foreach (DataRow r in LocalTable.Rows)
                {
                    if ((long)r[0] == obj.ID)
                    {
                        r["idCaNhan"] = obj.IDCaNhan;
                        r["idDonVi"] = obj.IDDonVi;
                        r["nam"] = obj.Nam;
                        r["danhHieuDangKy"] = obj.DanhHieuDangKy;
                        r["danhHieuDatDuoc"] = obj.DanhHieuDatDuoc;
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

        public int Delete(Obj_HoSoThiDua obj_HSTD)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_HSTD.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                foreach (DataRow item in LocalTable.Rows)
                {
                    if ((long)item[0] == obj_HSTD.ID)
                    {
                        LocalTable.Rows.Remove(item);
                        LocalTable.AcceptChanges();
                        break;
                    }
                }
            }

            return i;
        }

        public Obj_HoSoThiDua CreateObjHoSoThiDua(DataRow dataRow)
        {
            Obj_HoSoThiDua o = new Obj_HoSoThiDua()
            {
                ID = (long)dataRow["id"],
                IDCaNhan = (long)dataRow["idCaNhan"],
                IDDonVi = (long)dataRow["idDonVi"],
                Nam = (long)dataRow["nam"],
                DanhHieuDangKy = (byte)dataRow["danhHieuDangKy"],
                DanhHieuDatDuoc = (byte)dataRow["danhHieuDatDuoc"],
            };
            return o;
        }

        public Obj_HoSoThiDua CreateObjHoSoThiDua(long id)
        {
            foreach (DataRow item in LocalTable.Rows)
            {
                if ((long)item[0] == id)
                {
                    Obj_HoSoThiDua o = CreateObjHoSoThiDua(item);
                    return o;
                }
            }

            return null;
        }

        public bool CheckExisted(long idCaNhan, long nam)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "SELECT COUNT(id) FROM " + LocalTable.TableName + " WHERE idCaNhan = @idCaNhan AND nam = @nam";

            cm.Parameters.Add(new SQLiteParameter("@idCaNhan", idCaNhan));
            cm.Parameters.Add(new SQLiteParameter("@nam", nam));

            int i = -1;
            DbAccess.OpenConnection();
            i = (int)cm.ExecuteScalar();
            DbAccess.CloseConnection();

            return (i>=1);
        }

        public bool CheckExisted(Obj_CaNhan obj, long nam)
        {
            return CheckExisted(obj.ID, nam);
        }

    }
    
}
