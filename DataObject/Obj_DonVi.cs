using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataObject
{
    public class Obj_DonVi
    {
        public long ID { get; set; }
        public string Loai { get; set; }
        public string TenDonVi { get; set; }
        public string DiaDiem { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool TrangThai { get; set; }

        public Obj_DonVi()
        {
            TrangThai = true;
        }
    }
}
