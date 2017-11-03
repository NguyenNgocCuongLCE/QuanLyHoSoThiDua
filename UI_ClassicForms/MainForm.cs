using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer;
using DataObject;

namespace UI_ClassicForms
{
    public partial class MainForm : Form
    {
        public frmCaNhanTapThe FormCaNhanTapThe { get; set; }
        public frmCaNhan FormCaNhan { get; set; }
        public frmDonVi FormDonVi { get; set; }

        public Database_BLL DbAccess { get; set; }
        public CaNhan_BLL CaNhan { get; set; }
        public DonVi_BLL DonVi { get; set; }
        public ChucDanh_BLL ChucDanh { get; set; }
        public ChucVu_BLL ChucVu { get; set; }
        public GioiTinh_BLL GioiTinh { get; set; }
        public LoaiDonVi_BLL LoaiDonVi { get; set; }
        public TieuChi_BLL TieuChi { get; set; }


        public DataTable DtbCaNhan { get; set; }
        public DataTable DtbDonVi { get; set; }
        public DataTable DtbChucDanh { get; set; }
        public DataTable DtbChucVu { get; set; }
        public DataTable DtbGioiTinh { get; set; }
        public DataTable DtbLoaiDonVi { get; set; }
        public DataTable DtbTieuChi { get; set; }



        public List<string> TableNames { get; set; }

        public MainForm()
        {

            InitializeComponent();
            string dbPath = Application.StartupPath + @"\" + "Database.db";
            string cntString = @"Data Source = " + dbPath + "; Version = 3; UseUTF16Encoding = True;";
            DbAccess = new Database_BLL(cntString);
            TableNames = DbAccess.GetAllTableName();

            CaNhan = new CaNhan_BLL(DbAccess);
            DonVi = new DonVi_BLL(DbAccess, CaNhan);
            ChucDanh = new ChucDanh_BLL(DbAccess);
            ChucVu = new ChucVu_BLL(DbAccess);
            GioiTinh = new GioiTinh_BLL(DbAccess);
            LoaiDonVi = new LoaiDonVi_BLL(DbAccess);

            RefreshDataTables();

        }

        private void DtbDonVi_RowDeleted(object sender, DataRowChangeEventArgs e)
        {
            if (DtbCaNhan != null)
            {
                foreach (DataRow item in DtbCaNhan.Rows)
                {
                    if ((long)item["idDonVi"] == (long)e.Row["id"])
                    {
                        Obj_CaNhan o = CreateObjCaNhan(item);
                        o.ID_DonVi = 0;
                        int i = CaNhan.UpdateInfo(o);
                        break;
                    }
                }
            }
        }

        public void RefreshDataTables()
        {
            DtbDonVi = DonVi.GetDtbDonVi();
            DtbCaNhan = CaNhan.GetDtbCaNhan();
            DtbChucDanh = ChucDanh.GetDtbChucDanh();
            DtbChucVu = ChucVu.GetDtbChucVu();
            DtbGioiTinh = GioiTinh.GetDtbGioiTinh();
            DtbLoaiDonVi = LoaiDonVi.GetDtbLoaiDonVi("id > 0");
        }

        private void btnQuanLiCaNhanTapThe_Click(object sender, EventArgs e)
        {
            if (FormCaNhanTapThe == null || FormCaNhanTapThe.IsDisposed)
            {
                FormCaNhanTapThe = new frmCaNhanTapThe(this);
                
            }
            this.Hide();
            FormCaNhanTapThe.ShowDialog();
        }

        internal Obj_DonVi CreateObjDonVi(DataRow dataRow)
        {
            return DonVi.CreateObjDonVi(dataRow);
        }

        internal Obj_DonVi CreateObjDonVi(long id)
        {
            return DonVi.CreateObjDonVi(id);
        }

        internal Obj_CaNhan CreateObjCaNhan(DataRow dataRow)
        {
            return CaNhan.CreateObjCaNhan(dataRow);
        }

        internal Obj_CaNhan CreateObjCaNhan(long id)
        {
            return CaNhan.CreateObjCaNhan(id);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
