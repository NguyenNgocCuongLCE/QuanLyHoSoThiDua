using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using DataObject;
using System.Data;

namespace BusinessLogicLayer
{
    public class DonVi_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public CaNhan_BLL CaNhan { get; set; }
        public DonVi_DAL DonVi { get; set; }

        public DonVi_BLL(Database_BLL database_BLL, CaNhan_BLL caNhan_BLL)
        {
            DbAccess = database_BLL;
            DonVi = new DonVi_DAL(DbAccess.DbAccess_DAL, caNhan_BLL.CaNhan) ;
        }

        public DataTable GetDtbDonVi(string WhereConditon = "")
        {
            return DonVi.GetDtb(WhereConditon);
        }


        public long GetNextID()
        {
            return DonVi.GetNextID();
        }

        public int Insert(Obj_DonVi obj_DonVi)
        {
            return DonVi.Insert(obj_DonVi);
        }

        public int UpdateInfo(Obj_DonVi obj_DonVi)
        {
            return DonVi.Update(obj_DonVi);
        }

        public int Delete(Obj_DonVi obj_DonVi)
        {
            if (obj_DonVi.ID == 0)
            {
                return -1;
            }
            return DonVi.Delete(obj_DonVi);
        }

        public int Delete(string whereCondition)
        {
            return DonVi.Delete(whereCondition);
        }

        public Obj_DonVi CreateObjDonVi(DataRow row)
        {
            return DonVi.CreateObjDonVi(row);
        }

        public Obj_DonVi CreateObjDonVi(long id)
        {
            return DonVi.CreateObjDonVi(id);
        }

    }
}
