using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Obj_DanhHieu
    {
        public long ID { get; set; }
        public long Nam { get; set; }
        public string DanhHieu { get; set; }
        public bool TrangThai { get; set; }

        public Obj_DanhHieu()
        {
            TrangThai = true;
        }
    }
}
