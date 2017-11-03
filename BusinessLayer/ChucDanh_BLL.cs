using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataObject;

namespace BusinessLogicLayer
{
    public class ChucDanh_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public ChucDanh_DAL ChucDanh { get; set; }

        public ChucDanh_BLL(Database_BLL database_BLL)
        {
            DbAccess = database_BLL;
            ChucDanh = new ChucDanh_DAL(DbAccess.DbAccess_DAL);
        }

        public DataTable GetDtbChucDanh()
        {
            return ChucDanh.GetDtbChucDanh();
        }

        public long GetNextID()
        {
            return ChucDanh.GetNextID();
        }

        public int UpdateInfo(Obj_ChucDanh obj_ChucDanh)
        {
            return ChucDanh.Update(obj_ChucDanh);
        }

        public int Insert(Obj_ChucDanh obj_ChucDanh)
        {
            return ChucDanh.Update(obj_ChucDanh);
        }

        public int Delete(Obj_ChucDanh obj_ChucDanh)
        {
            return ChucDanh.Delete(obj_ChucDanh);
        }

        public int Delete(string whereCondition)
        {
            return ChucDanh.Delete(whereCondition);
        }

    }
}
