using DataAccessLayer;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class TieuChi_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public TieuChi_DAL TieuChi { get; set; }
        public TieuChi_BLL(Database_BLL database_BLL)
        {
            DbAccess = database_BLL;
            TieuChi = new TieuChi_DAL(DbAccess.DbAccess_DAL);
        }

        public DataTable GetDtb()
        {
            return TieuChi.GetDtb();
        }

        public int  Insert(Obj_TieuChi obj_TieuChi)
        {
            return TieuChi.Insert(obj_TieuChi);
        }

        public int Update(Obj_TieuChi obj_TieuChi)
        {
            return TieuChi.Update(obj_TieuChi);
        }

        public int Delete(Obj_TieuChi obj_TieuChi)
        {
            return TieuChi.Delete(obj_TieuChi);
        }

        public Obj_TieuChi CreateObj(DataRow dataRow)
        {
            return TieuChi.CreateObj(dataRow);
        }

        public Obj_TieuChi CreateObj(long id)
        {
            return TieuChi.CreateObj(id);
        }

    }
}
