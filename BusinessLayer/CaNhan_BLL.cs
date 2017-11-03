using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer;
using DataObject;

namespace BusinessLogicLayer
{
    public class CaNhan_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public CaNhan_DAL CaNhan { get; set; }
        public HoSoThiDua_DAL HoSo { get; set; }

        public CaNhan_BLL(Database_BLL _DbAccess)
        {
            DbAccess = _DbAccess;
            CaNhan = new CaNhan_DAL(DbAccess.DbAccess_DAL, HoSo);
        }

        public DataTable GetDtbCaNhan()
        {
            return CaNhan.GetDtb();
        }

        public long GetNextID()
        {
            return CaNhan.GetNextID();
        }

        public int UpdateInfo(Obj_CaNhan obj_CaNhan)
        {
            return CaNhan.Update(obj_CaNhan);
        }

        public int Insert(Obj_CaNhan obj_CaNhan)
        {
            return CaNhan.Insert(obj_CaNhan);
        }

        public int Delete(Obj_CaNhan obj_CaNhan)
        {
            return CaNhan.Delete(obj_CaNhan);
        }

        public int Delete(string whereCondition)
        {
            return CaNhan.Delete(whereCondition);
        }

        public Obj_CaNhan CreateObjCaNhan(DataRow row)
        {
            return CaNhan.CreateObj(row);
        }

        public Obj_CaNhan CreateObjCaNhan(long id)
        {
            return CaNhan.CreateObj(id);
        }
    }
}
