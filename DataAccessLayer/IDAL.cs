using System.Data;
using DataObject;

namespace DataAccessLayer
{
    public interface IDAL<TObject, TID>
    {
        Database_DAL DbAccess { get; set; }
        DataTable LocalTable { get; set; }
        TID GetNextID();
        DataTable GetDtb(string WhereCondition = "");
        int Insert(TObject obj);
        int Update(TObject obj);
        int Delete(TObject obj_CaNhan);
        int Delete(string whereCondition);
        TObject CreateObj(DataRow dataRow);
        TObject CreateObj(TID id);
    }
}