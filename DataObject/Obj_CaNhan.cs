using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Obj_CaNhan
    {
        public long ID           { get; set; }
        public long ID_DonVi     { get; set; }
        public string HoTen      { get; set; }
        public string GioiTinh   { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucDanh   { get; set; }
        public string ChucVu     { get; set; }
        public string Email      { get; set; }
        public string Phone      { get; set; }
    }
}
