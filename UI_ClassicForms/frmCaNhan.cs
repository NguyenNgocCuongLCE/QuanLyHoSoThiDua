using DataObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI_ClassicForms
{
    public partial class frmCaNhan : Form
    {
        private bool isEditMode;
        public event ValueChangedEventHandler<bool> EditModeChanged;

        public MainForm MyMainform;

        public Obj_CaNhan ObjCaNhan;

        public List<char> AcceptChars { get; set; }

        public bool IsEditMode
        {
            get => isEditMode;
            set
            {
                ValueChangedEventArg<bool> e = new ValueChangedEventArg<bool>()
                {
                    OldValue = isEditMode,
                    NewValue = value,
                };
                isEditMode = value;
                EditModeChanged?.Invoke(this, e);
            }
        }

        public frmCaNhan(MainForm mainForm)
        {
            InitializeComponent();
            MyMainform = mainForm;
            ObjCaNhan = new Obj_CaNhan();
            dtpNgaySinh.CustomFormat = "dd/MM/yyyy";

            SetDatasourceForControls();

            EditModeChanged = FrmCaNhan_EditModeChanged;
            btnOK.Enabled = (txbHoTen.Text.Trim().Length > 0);
        }

        //Methods----------------------------------------------------------------------------------------------------
        public void SetDatasourceForControls()
        {
            cmbGioiTinh.DataSource = MyMainform.DtbGioiTinh;
            cmbGioiTinh.DisplayMember = "gioiTinh";
            cmbGioiTinh.ValueMember = "id";

            //cmbDonVi.Items.Clear();
            DataTable lsvDonVi = new DataTable();
            lsvDonVi.Columns.Add(new DataColumn("id", typeof(long)));
            lsvDonVi.Columns.Add(new DataColumn("ten", typeof(string)));
            foreach (DataRow item in MyMainform.DtbDonVi.Rows)
            {
                string name = ((item["loai"] != DBNull.Value) ? (item["loai"].ToString() + " ") : "") + ((item["tenDonVi"] != DBNull.Value) ? item["tenDonVi"].ToString() : "");
                long x = (item["id"] != DBNull.Value) ? (long)item["id"] : -1;
                DataRow r = lsvDonVi.NewRow();
                r["id"] = x;
                r["ten"] = name;
                lsvDonVi.Rows.Add(r);
            }
            cmbDonVi.DataSource = lsvDonVi;
            cmbDonVi.DisplayMember = "ten";
            cmbDonVi.ValueMember = "id";


            cmbChucDanh.DataSource = MyMainform.DtbChucDanh;
            cmbChucDanh.DisplayMember = "chucDanh";
            cmbChucDanh.ValueMember = "id";

            cmbChucVu.DataSource = MyMainform.DtbChucVu;
            cmbChucVu.DisplayMember = "chucVu";
            cmbChucVu.ValueMember = "id";

            AcceptChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ';', ',', ' ', '.'
            };
        }

        public void ApplyInfoFromObj(Obj_CaNhan obj_CaNhan)
        {

            lblID.Text = obj_CaNhan.ID.ToString();
            txbHoTen.Text = obj_CaNhan.HoTen;
            txbEmail.Text = obj_CaNhan.Email;
            txbPhone.Text = obj_CaNhan.Phone;
            dtpNgaySinh.Value = obj_CaNhan.NgaySinh;
            foreach (var item in cmbGioiTinh.Items)
            {
                if (((DataRowView)item)["gioiTinh"].ToString() == obj_CaNhan.GioiTinh)
                {
                    cmbGioiTinh.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cmbDonVi.Items)
            {
                if ((long)((DataRowView)item)["id"] == obj_CaNhan.ID_DonVi)
                {
                    cmbDonVi.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cmbChucVu.Items)
            {
                if (((DataRowView)item)["chucVu"].ToString() == obj_CaNhan.ChucVu)
                {
                    cmbChucVu.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cmbChucDanh.Items)
            {
                if (((DataRowView)item)["chucDanh"].ToString() == obj_CaNhan.ChucDanh)
                {
                    cmbChucDanh.SelectedItem = item;
                    break;
                }
            }

        }

        public void ApplyInfoToObj(Obj_CaNhan obj_CaNhan)
        {
            if (!IsEditMode)
            {
                ObjCaNhan.ID = MyMainform.CaNhan.GetNextID();
            }
            obj_CaNhan.ID_DonVi = (long)(cmbDonVi.SelectedValue);
            obj_CaNhan.HoTen = txbHoTen.Text.Trim();
            obj_CaNhan.NgaySinh = dtpNgaySinh.Value;
            obj_CaNhan.GioiTinh = cmbGioiTinh.Text.Trim();
            obj_CaNhan.Email = txbEmail.Text.Trim();
            obj_CaNhan.Phone = txbPhone.Text.Trim();
            obj_CaNhan.ChucDanh = cmbChucDanh.Text;
            obj_CaNhan.ChucVu = cmbChucVu.Text;
        }
        private void ClearInfo()
        {
            lblID.Text = "[...]";
            txbHoTen.Text = "";
            txbEmail.Text = "";
            txbPhone.Text = "";
        }

        //Events------------------------------------------------------------------------------------------------------
        private void FrmCaNhan_EditModeChanged(object sender, ValueChangedEventArg<bool> e)
        {
            if (IsEditMode)
            {
                if (ObjCaNhan != null) ApplyInfoFromObj(ObjCaNhan);
                btnOK.Text = "Lưu thay đổi";
            }
            else
            {
                ClearInfo();
                btnOK.Text = "Thêm";
            }
        }

        private void txbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!AcceptChars.Contains(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyInfoToObj(ObjCaNhan);
            if (IsEditMode)
            {
                if (MyMainform.CaNhan.UpdateInfo(ObjCaNhan) == 1)
                {
                    MyMainform.FormCaNhanTapThe.RefreshTreeNode("P" + ObjCaNhan.ID);

                    MessageBox.Show("Đã cập nhật thông tin thành viên " + ObjCaNhan.HoTen, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thay đổi được thông tin thành viên:" + ObjCaNhan.HoTen, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (MyMainform.CaNhan.Insert(ObjCaNhan) == 1)
                {
                    MyMainform.FormCaNhanTapThe.RefreshTreeNode("P" + ObjCaNhan.ID);
                    MessageBox.Show("Đã thêm thành viên " + ObjCaNhan.HoTen, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.IsEditMode = false;
                }
                else
                {
                    MessageBox.Show("Không thêm được thành viên:" + ObjCaNhan.HoTen, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbHoTen_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = !(txbHoTen.Text.Trim().Length == 0);
        }
    }
}
