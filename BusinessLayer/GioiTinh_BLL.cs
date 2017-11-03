using DataAccessLayer;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class GioiTinh_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public GioiTinh_DAL GioiTinh { get; set; }

        public GioiTinh_BLL(Database_BLL database_BLL)
        {
            DbAccess = database_BLL;
            GioiTinh = new GioiTinh_DAL(DbAccess.DbAccess_DAL);
        }

        public DataTable GetDtbGioiTinh()
        {
            return GioiTinh.GetDtb();
        }

        public long GetNextID()
        {
            return GioiTinh.GetNextID();
        }

        public int Insert(Obj_GioiTinh obj_GioiTinh)
        {
            return GioiTinh.Insert(obj_GioiTinh);
        }

        public int UpdateInfo(Obj_GioiTinh obj_GioiTinh)
        {
            return GioiTinh.Update(obj_GioiTinh);
        }
    }
}
