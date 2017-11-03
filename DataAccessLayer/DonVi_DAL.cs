using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using DataObject;

namespace DataAccessLayer
{
    public class DonVi_DAL
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set; }

        public CaNhan_DAL CaNhan { get; set; }
        public HoSoThiDua_DAL HoSoThiDua { get; set; }

        public DonVi_DAL(Database_DAL database_DAL, CaNhan_DAL caNhan_DAL = null, HoSoThiDua_DAL hoSoThiDua_DAL = null)
        {
            DbAccess = database_DAL;
            CaNhan = caNhan_DAL;
            HoSoThiDua = hoSoThiDua_DAL;

            LocalTable = new DataTable("DS_DonVi");

            DataColumn id = new DataColumn("id", typeof(long));
            DataColumn loai = new DataColumn("loai", typeof(string));
            DataColumn tenDonVi = new DataColumn("tenDonVi", typeof(string));
            DataColumn diaDiem = new DataColumn("diaDiem", typeof(string));
            DataColumn email = new DataColumn("email", typeof(string));
            DataColumn phone = new DataColumn("phone", typeof(string));
            DataColumn trangThai = new DataColumn("trangThai", typeof(bool));

            LocalTable.Columns.Add(id);
            LocalTable.Columns.Add(loai);
            LocalTable.Columns.Add(tenDonVi);
            LocalTable.Columns.Add(diaDiem);
            LocalTable.Columns.Add(email);
            LocalTable.Columns.Add(phone);
            LocalTable.Columns.Add(trangThai);

            LocalTable.RowDeleting += LocalTable_RowDeleted;

            if (DbAccess.Database.Tables.Contains(LocalTable.TableName))
            {
                DbAccess.Database.Tables.Remove(LocalTable.TableName);
            }
            DbAccess.Database.Tables.Add(LocalTable);

        }


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
                command.CommandText = "SELECT * FROM " + LocalTable.TableName + " WHERE " + WhereCondition;
            }

            DbAccess.OpenConnection();
            SQLiteDataReader r = command.ExecuteReader();

            while (r.Read())
            {
                DataRow newRow = LocalTable.NewRow();
                for (int i = 0; i < LocalTable.Columns.Count; i++)
                {
                    newRow[i] = r[i];
                }
                LocalTable.Rows.Add(newRow);
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

        public int Insert(Obj_DonVi obj_DonVi)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName +
                " VALUES (" +
                "@id, " +
                "@loai, " +
                "@tenDonVi, " +
                "@diaDiem, " +
                "@email, " +
                "@phone, " +
                "@trangThai)";
            cm.Parameters.Add(new SQLiteParameter("@id", obj_DonVi.ID));
            cm.Parameters.Add(new SQLiteParameter("@loai", obj_DonVi.Loai));
            cm.Parameters.Add(new SQLiteParameter("@tenDonVi", obj_DonVi.TenDonVi));
            cm.Parameters.Add(new SQLiteParameter("@diaDiem", obj_DonVi.DiaDiem));
            cm.Parameters.Add(new SQLiteParameter("@email", obj_DonVi.Email));
            cm.Parameters.Add(new SQLiteParameter("@phone", obj_DonVi.Phone));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_DonVi.TrangThai));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                DataRow item = LocalTable.NewRow();
                item[0] = obj_DonVi.ID;
                item[1] = obj_DonVi.Loai;
                item[2] = obj_DonVi.TenDonVi;
                item[3] = obj_DonVi.DiaDiem;
                item[4] = obj_DonVi.Email;
                item[5] = obj_DonVi.Phone;
                item[6] = obj_DonVi.TrangThai;
                LocalTable.Rows.Add(item);
                LocalTable.AcceptChanges();
            }

            return i;
        }

        public int Update(Obj_DonVi obj_DonVi)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "UPDATE " + LocalTable.TableName +
                " SET " +
                "loai = @loai, " +
                "tenDonVi = @tenDonVi, " +
                "diaDiem = @diaDiem, " +
                "email = @email, " +
                "phone = @phone, " +
                "trangThai = @trangThai" +
                " WHERE id = @id";
            cm.Parameters.Add(new SQLiteParameter("@loai", obj_DonVi.Loai));
            cm.Parameters.Add(new SQLiteParameter("@tenDonVi", obj_DonVi.TenDonVi));
            cm.Parameters.Add(new SQLiteParameter("@diaDiem", obj_DonVi.DiaDiem));
            cm.Parameters.Add(new SQLiteParameter("@email", obj_DonVi.Email));
            cm.Parameters.Add(new SQLiteParameter("@phone", obj_DonVi.Phone));
            cm.Parameters.Add(new SQLiteParameter("@trangThai", obj_DonVi.TrangThai));
            cm.Parameters.Add(new SQLiteParameter("@id", obj_DonVi.ID));

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                foreach (DataRow item in LocalTable.Rows)
                {
                    if ((long)item[0] == obj_DonVi.ID)
                    {
                        item[1] = obj_DonVi.Loai;
                        item[2] = obj_DonVi.TenDonVi;
                        item[3] = obj_DonVi.DiaDiem;
                        item[4] = obj_DonVi.Email;
                        item[5] = obj_DonVi.Phone;
                        item[6] = obj_DonVi.TrangThai;
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

        public int Delete(Obj_DonVi obj_DonVi)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_DonVi.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
            DbAccess.CloseConnection();

            if (i == 1)
            {
                foreach (DataRow item in LocalTable.Rows)
                {
                    if ((long)item[0] == obj_DonVi.ID)
                    {
                        LocalTable.Rows.Remove(item);
                        LocalTable.AcceptChanges();
                        break;
                    }
                }
            }

            return i;
        }

        public Obj_DonVi CreateObjDonVi(DataRow row)
        {
            Obj_DonVi o = new Obj_DonVi()
            {
                ID        = (long)row["id"],
                Loai      = (row["loai"]      == DBNull.Value) ? "" : row["loai"].ToString(),
                TenDonVi  = (row["tenDonVi"]  == DBNull.Value) ? "" : row["tenDonVi"].ToString(),
                DiaDiem   = (row["diaDiem"]   == DBNull.Value) ? "" : row["diaDiem"].ToString(),
                Email     = (row["email"]     == DBNull.Value) ? "" : row["email"].ToString(),
                Phone     = (row["phone"]     == DBNull.Value) ? "" : row["phone"].ToString(),
                TrangThai = (row["trangThai"] == DBNull.Value) ? false : true
            };

            return o;
        }

        public Obj_DonVi CreateObjDonVi(long id)
        {
            foreach (DataRow item in LocalTable.Rows)
            {
                if ((long)item[0] == id)
                {
                    return CreateObjDonVi(item);
                }
            }
            return null;
        }

        //Set CaNhan records to defaul value when delete a record
        private void LocalTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (CaNhan == null) return;
            DataTable DtbCaNhan = CaNhan.LocalTable;
            DataTable DtbHoSoThiDua = HoSoThiDua.LocalTable;

            //handle on relation with CaNhan datatable
            if (DtbCaNhan != null)
            {
                foreach (DataRow item in DtbCaNhan.Rows)
                {
                    if ((long)item["idDonVi"] == (long)e.Row["id"])
                    {
                        var o = CaNhan.CreateObj(item);
                        o.ID_DonVi = 0;
                        CaNhan.Update(o);
                    }
                }
            }

            //handle on relation with HSTD datatable
            if (DtbHoSoThiDua != null)
            {
                foreach (DataRow item in DtbHoSoThiDua.Rows)
                {
                    if ((long)item["idDonVi"] == (long)e.Row["id"])
                    {
                        Obj_HoSoThiDua obj_HSTD = HoSoThiDua.CreateObjHoSoThiDua(item);
                        obj_HSTD.IDDonVi = 0;
                    }
                }
            }

        }
    }
}
