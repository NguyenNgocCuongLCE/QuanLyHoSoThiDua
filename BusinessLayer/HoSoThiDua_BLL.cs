using DataAccessLayer;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    class HoSoThiDua_BLL
    {
        public Database_BLL DbAccess { get; set; }
        public HoSoThiDua_DAL HoSoThiDua { get; set; }

        public HoSoThiDua_BLL(Database_BLL database_BLL)
        {
            DbAccess = database_BLL;
            HoSoThiDua = new HoSoThiDua_DAL(DbAccess.DbAccess_DAL);
        }

        public int Insert(Obj_HoSoThiDua obj)
        {
            return HoSoThiDua.Insert(obj);
        }

        public int Update(Obj_HoSoThiDua obj)
        {
            return HoSoThiDua.Update(obj);
        }

        public int Delete(Obj_HoSoThiDua obj)
        {
            return HoSoThiDua.Delete(obj);
        }

        public Obj_HoSoThiDua CreateObj(DataRow dataRow)
        {
            return HoSoThiDua.CreateObjHoSoThiDua(dataRow);
        }

        public Obj_HoSoThiDua CreateObj(long id)
        {
            return HoSoThiDua.CreateObjHoSoThiDua(id);
        }

        public bool CheckExisted(Obj_CaNhan obj_CaNhan, long nam)
        {
            return HoSoThiDua.CheckExisted(obj_CaNhan, nam);
        }

        public bool CheckExisted(long idCaNhan, long nam)
        {
            return HoSoThiDua.CheckExisted(idCaNhan, nam);
        }

    }
}
