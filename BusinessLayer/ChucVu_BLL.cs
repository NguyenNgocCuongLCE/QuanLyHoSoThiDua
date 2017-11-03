using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataObject;
namespace BusinessLogicLayer
{
    public class ChucVu_BLL
    {
        Database_BLL DbAccess { get; set; }
        ChucVu_DAL ChucVu { get; set; }
        public ChucVu_BLL(Database_BLL database_DAL)
        {
            DbAccess = database_DAL;
            ChucVu = new ChucVu_DAL(DbAccess.DbAccess_DAL);

        }

        public DataTable GetDtbChucVu()
        {
            return ChucVu.GetDtbChucVu();
        }

        public int Insert(Obj_ChucVu obj_ChucVu)
        {
            return ChucVu.Insert(obj_ChucVu);
        }

        public int UpdateInfo(Obj_ChucVu obj_ChucVu)
        {
            return ChucVu.Update(obj_ChucVu);
        }

        public int Delete(Obj_ChucVu obj_ChucVu)
        {
            return ChucVu.Delete(obj_ChucVu);
        }
        public int Delete(string whereCondition)
        {
            return ChucVu.Delete(whereCondition);
        }
        public long GetNextID()
        {
            return ChucVu.GetNextID();
        }
    }
}
