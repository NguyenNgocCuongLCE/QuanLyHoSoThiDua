using DataAccessLayer;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class LoaiDonVi_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public LoaiDonVi_DAL LoaiDonVi { get; set; }

        public LoaiDonVi_BLL(Database_BLL database_BLL)
        {
            DbAccess = database_BLL;
            LoaiDonVi = new LoaiDonVi_DAL(DbAccess.DbAccess_DAL);
        }

        public DataTable GetDtbLoaiDonVi(string whereCondition = "")
        {
            return LoaiDonVi.GetDtbLoaiDonVi(whereCondition);
        }

        public long GetNextID()
        {
            return LoaiDonVi.GetNextID();
        }

        public int Insert(Obj_LoaiDonVi obj_LoaiDonVi)
        {
            return LoaiDonVi.Insert(obj_LoaiDonVi);
        }

        public int UpdateInfo(Obj_LoaiDonVi obj_LoaiDonVi)
        {
            return LoaiDonVi.Update(obj_LoaiDonVi);
        }

        public int Delete(Obj_LoaiDonVi obj_LoaiDonVi)
        {
            return LoaiDonVi.Delete(obj_LoaiDonVi);
        }

        public int Delete(string whereCondition)
        {
            return LoaiDonVi.Delete(whereCondition);
        }

    }
}
