using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using DataObject;

namespace DataAccessLayer
{
    public class CaNhan_DAL : IDAL<Obj_CaNhan, long>
    {
        public Database_DAL DbAccess { get; set; }
        public DataTable LocalTable { get; set; }
        public HoSoThiDua_DAL HoSoThiDua { get; set; }

        public CaNhan_DAL(Database_DAL _databaseAccess = null, HoSoThiDua_DAL hoSoThiDua_DAL = null)
        {
            DbAccess = _databaseAccess;
            HoSoThiDua = hoSoThiDua_DAL;
            LocalTable = new DataTable("DS_CaNhan");
            DataColumn id = new DataColumn("id", typeof(long));
            DataColumn idDonVi = new DataColumn("idDonVi", typeof(long));
            DataColumn hoTen = new DataColumn("hoTen", typeof(string));
            DataColumn gioiTinh = new DataColumn("gioiTinh", typeof(string));
            DataColumn ngaySinh = new DataColumn("ngaySinh", typeof(DateTime));
            DataColumn chucDanh = new DataColumn("chucDanh", typeof(string));
            DataColumn chucVu = new DataColumn("chucVu", typeof(string));
            DataColumn email = new DataColumn("email", typeof(string));
            DataColumn phone = new DataColumn("phone", typeof(string));

            LocalTable.Columns.Add(id);
            LocalTable.Columns.Add(idDonVi);
            LocalTable.Columns.Add(hoTen);
            LocalTable.Columns.Add(gioiTinh);
            LocalTable.Columns.Add(ngaySinh);
            LocalTable.Columns.Add(chucDanh);
            LocalTable.Columns.Add(chucVu);
            LocalTable.Columns.Add(email);
            LocalTable.Columns.Add(phone);

            LocalTable.RowDeleted += LocalTable_RowDeleted;

            if (DbAccess.Database.Tables.Contains(LocalTable.TableName))
            {
                DbAccess.Database.Tables.Remove(LocalTable.TableName);
            }
            DbAccess.Database.Tables.Add(LocalTable);
        }

        private void LocalTable_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (HoSoThiDua == null)
            {
                return;
            }

            foreach (DataRow item in HoSoThiDua.LocalTable.Rows)
            {
                long i = (long)e.Row["id"];
                if ((long)item["idCaNhan"] == i)
                {
                    Obj_HoSoThiDua obj_HSTD = HoSoThiDua.CreateObjHoSoThiDua(item);
                    HoSoThiDua.Delete(obj_HSTD);
                }
            }
        }

        public DataTable GetDtb(string WhereCondition = "")
        {
            LocalTable.Rows.Clear();

            SQLiteCommand command = new SQLiteCommand();
            command.CommandType = CommandType.Text;
            if (WhereCondition.Length == 0)
            {
                command.CommandText = "SELECT * FROM " + LocalTable.TableName;
            }
            else
            {
                command.CommandText = "SELECT * FROM " + LocalTable.TableName + " WHERE " + WhereCondition;
            }
            command.Connection = DbAccess.DatabaseConnection;

            DbAccess.OpenConnection();
            SQLiteDataReader r = command.ExecuteReader();
            while (r.Read())
            {
                DataRow newRow = LocalTable.NewRow();
                for (int i = 0; i < 9; i++)
                {
                    newRow[i] = r[i];
                }
                LocalTable.Rows.Add(newRow);
            }
            DbAccess.CloseConnection();

            return LocalTable;
        }

        public int Insert(Obj_CaNhan obj_CaNhan)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "INSERT INTO " + LocalTable.TableName + " VALUES (" +
                "@id, " +
                "@idDonVi, " +
                "@hoTen, " +
                "@gioiTinh, " +
                "@ngaySinh, " +
                "@chucDanh, " +
                "@chucVu, " +
                "@email, " +
                "@phone)";

            cm.Parameters.Add(new SQLiteParameter("@id", obj_CaNhan.ID));
            cm.Parameters.Add(new SQLiteParameter("@idDonVi", obj_CaNhan.ID_DonVi));
            cm.Parameters.Add(new SQLiteParameter("@hoTen", obj_CaNhan.HoTen));
            cm.Parameters.Add(new SQLiteParameter("@gioiTinh", obj_CaNhan.GioiTinh));
            cm.Parameters.Add(new SQLiteParameter("@ngaySinh", obj_CaNhan.NgaySinh));
            cm.Parameters.Add(new SQLiteParameter("@chucDanh", obj_CaNhan.ChucDanh));
            cm.Parameters.Add(new SQLiteParameter("@chucVu", obj_CaNhan.ChucVu));
            cm.Parameters.Add(new SQLiteParameter("@email", obj_CaNhan.Email));
            cm.Parameters.Add(new SQLiteParameter("@phone", obj_CaNhan.Phone));

            int i = -1;
            if (DbAccess.OpenConnection())
            {
                i = cm.ExecuteNonQuery();
                DbAccess.CloseConnection();
            }

            if (i == 1)
            {
                DataRow item = LocalTable.NewRow();
                item[0] = obj_CaNhan.ID;
                item[1] = obj_CaNhan.ID_DonVi;
                item[2] = obj_CaNhan.HoTen;
                item[3] = obj_CaNhan.GioiTinh;
                item[4] = obj_CaNhan.NgaySinh;
                item[5] = obj_CaNhan.ChucDanh;
                item[6] = obj_CaNhan.ChucVu;
                item[7] = obj_CaNhan.Email;
                item[8] = obj_CaNhan.Phone;
                LocalTable.Rows.Add(item);
                LocalTable.AcceptChanges();
            }

            return i;
        }

        public int Update(Obj_CaNhan obj_CaNhan)
        {
            SQLiteCommand command = new SQLiteCommand(DbAccess.DatabaseConnection)
            {
                CommandType = CommandType.Text,
                CommandText =
                "UPDATE " + LocalTable.TableName +
                " SET " +
                "idDonVi = @idDonVi, " +
                "hoTen = @hoTen, " +
                "gioiTinh = @gioiTinh, " +
                "ngaySinh = @ngaySinh, " +
                "chucDanh = @chucDanh, " +
                "chucVu = @chucVu, " +
                "email = @email, " +
                "phone = @phone " +
                "WHERE id = @id "
            };

            command.Parameters.Add(new SQLiteParameter("@idDonVi", obj_CaNhan.ID_DonVi));
            command.Parameters.Add(new SQLiteParameter("@hoTen", obj_CaNhan.HoTen));
            command.Parameters.Add(new SQLiteParameter("@gioiTinh", obj_CaNhan.GioiTinh));
            command.Parameters.Add(new SQLiteParameter("@ngaySinh", obj_CaNhan.NgaySinh));
            command.Parameters.Add(new SQLiteParameter("@chucDanh", obj_CaNhan.ChucDanh));
            command.Parameters.Add(new SQLiteParameter("@chucVu", obj_CaNhan.ChucVu));
            command.Parameters.Add(new SQLiteParameter("@email", obj_CaNhan.Email));
            command.Parameters.Add(new SQLiteParameter("@phone", obj_CaNhan.Phone));
            command.Parameters.Add(new SQLiteParameter("@id", obj_CaNhan.ID));

            DbAccess.OpenConnection();
            int i = command.ExecuteNonQuery();
            DbAccess.CloseConnection();

            //update to localtable
            if (i == 1)
            {
                foreach (DataRow item in LocalTable.Rows)
                {
                    if ((long)item[0] == obj_CaNhan.ID)
                    {
                        item[1] = obj_CaNhan.ID_DonVi;
                        item[2] = obj_CaNhan.HoTen;
                        item[3] = obj_CaNhan.GioiTinh;
                        item[4] = obj_CaNhan.NgaySinh;
                        item[5] = obj_CaNhan.ChucDanh;
                        item[6] = obj_CaNhan.ChucVu;
                        item[7] = obj_CaNhan.Email;
                        item[8] = obj_CaNhan.Phone;
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

        public int Delete(Obj_CaNhan obj_CaNhan)
        {
            SQLiteCommand cm = new SQLiteCommand(DbAccess.DatabaseConnection);
            cm.CommandType = CommandType.Text;
            cm.CommandText = "DELETE FROM " + LocalTable.TableName + " WHERE id = " + obj_CaNhan.ID;

            DbAccess.OpenConnection();
            int i = cm.ExecuteNonQuery();
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

        public Obj_CaNhan CreateObj(DataRow dataRow)
        {
            Obj_CaNhan o = new Obj_CaNhan()
            {
                ID = (long)dataRow["id"],
                ID_DonVi = (long)dataRow["idDonVi"],
                HoTen = (dataRow["hoten"] == DBNull.Value) ? "" : dataRow["hoTen"].ToString(),
                ChucDanh = (dataRow["chucDanh"] == DBNull.Value) ? "" : dataRow["chucDanh"].ToString(),
                ChucVu = (dataRow["chucVu"] == DBNull.Value) ? "" : dataRow["chucVu"].ToString(),
                NgaySinh = (DateTime)dataRow["ngaySinh"],
                GioiTinh = (dataRow["gioiTinh"] == DBNull.Value) ? "" : dataRow["gioiTinh"].ToString(),
                Email = (dataRow["email"] == DBNull.Value) ? "" : dataRow["email"].ToString(),
                Phone = (dataRow["phone"] == DBNull.Value) ? "" : dataRow["phone"].ToString(),
            };

            return o;
        }

        public Obj_CaNhan CreateObj(long id)
        {
            foreach (DataRow item in LocalTable.Rows)
            {
                if ((long)item[0] == id)
                {
                    Obj_CaNhan o = CreateObj(item);
                    return o;
                }

            }

            return null;
        }
    }
}
