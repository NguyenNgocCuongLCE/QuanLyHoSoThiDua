using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class ChiTiet_DAL : IDAL<Obj_ChiTiet, long>
    {
        public Database_DAL DbAccess { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DataTable LocalTable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Obj_ChiTiet CreateObj(DataRow dataRow)
        {
            throw new NotImplementedException();
        }

        public Obj_ChiTiet CreateObj(long id)
        {
            throw new NotImplementedException();
        }

        public int Delete(Obj_ChiTiet obj_CaNhan)
        {
            throw new NotImplementedException();
        }

        public int Delete(string whereCondition)
        {
            throw new NotImplementedException();
        }

        public DataTable GetDtb(string WhereCondition = "")
        {
            throw new NotImplementedException();
        }

        public long GetNextID()
        {
            throw new NotImplementedException();
        }

        public int Insert(Obj_ChiTiet obj)
        {
            throw new NotImplementedException();
        }

        public int Update(Obj_ChiTiet obj)
        {
            throw new NotImplementedException();
        }
    }
}
