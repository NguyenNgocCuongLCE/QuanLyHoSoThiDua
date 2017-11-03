using DataAccessLayer;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    class DanhHieu_BLL
    {
        Database_BLL DbAccess;
        DanhHieu_DAL DanhHieu;

        public DanhHieu_BLL(Database_BLL database_BLL)
        {
            DbAccess = database_BLL;
            DanhHieu = new DanhHieu_DAL(DbAccess.DbAccess_DAL);
        }

        public int Insert(Obj_DanhHieu obj)
        {
            return DanhHieu.Insert(obj);
            return 0;
        }

        public int Update(Obj_DanhHieu obj)
        {
            return DanhHieu.Update(obj);
        }

        public int Delete(Obj_DanhHieu obj)
        {
            return DanhHieu.Delete(obj);
        }

        public Obj_DanhHieu CreateObj(byte id)
        {
            return DanhHieu.CreateObj(id);
        }

        public Obj_DanhHieu CreateObj(DataRow dataRow)
        {
            return DanhHieu.CreateObj(dataRow);
        }

        public long GetNextID()
        {
            return DanhHieu.GetNextID();
        }
    
    }
}
