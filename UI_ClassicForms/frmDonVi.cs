using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataObject;

namespace UI_ClassicForms
{
    public partial class frmDonVi : Form
    {
        public event ValueChangedEventHandler<bool> EditModeChanged;
        bool isEditMode;

        public MainForm MyMainForms { get; set; }
        public Obj_DonVi ObjDonVi { get; set; }
        public List<char> AcceptChars { get; set; }

        public bool IsEditMode
        {
            get => isEditMode;
            set
            {
                ValueChangedEventArg<bool> e = new ValueChangedEventArg<bool>()
                {
                    OldValue = isEditMode,
                    NewValue = value
                };
                isEditMode = value;
                EditModeChanged?.Invoke(this, e);
            }
        }

        public frmDonVi(MainForm mainForm)
        {
            InitializeComponent();
            MyMainForms = mainForm;
            ObjDonVi = new Obj_DonVi();
            this.EditModeChanged += FrmDonVi_EditModeChanged;
            AcceptChars = new List<char>()
            {
                '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', ';', ',', ' ', '.'
            };

            cmbLoai.DataSource = MyMainForms.DtbLoaiDonVi;
            cmbLoai.DisplayMember = "tenLoai";
            cmbLoai.ValueMember = "id";

            btnOK.Enabled = (txbTen.Text.Trim().Length > 0);
        }

        private void FrmDonVi_EditModeChanged(object sender, ValueChangedEventArg<bool> e)
        {
            if (e.NewValue)
            {
                ApplyInfoFromObj(ObjDonVi);
                btnOK.Text = "Lưu thay đổi";
            }
            else
            {
                ClearInfo();
                btnOK.Text = "Thêm đơn vị mới";
                lbl_ID.Text = "...";
            }
        }

        private void ClearInfo()
        {
            txbPhone.Clear();
            txbDiaDiem.Clear();
            txbEmail.Clear();
            txbTen.Clear();
        }

        internal void ApplyInfoFromObj(Obj_DonVi objDonVi)
        {
            foreach (var item in cmbLoai.Items)
            {
                DataRowView drv = item as DataRowView;
                if ((string)drv.Row[1] == objDonVi.Loai)
                {
                    cmbLoai.SelectedItem = item;
                    break;
                }
            }

            txbTen.Text = objDonVi.TenDonVi;
            txbDiaDiem.Text = objDonVi.DiaDiem;
            txbEmail.Text = objDonVi.Email;
            txbPhone.Text = objDonVi.Phone;
            lbl_ID.Text = objDonVi.ID.ToString();

        }

        private void ApplyInfoToObj(Obj_DonVi obj_DonVi)
        {
            obj_DonVi.TenDonVi = txbTen.Text.Trim();
            obj_DonVi.DiaDiem = txbDiaDiem.Text.Trim();
            obj_DonVi.Email = txbEmail.Text.Trim();
            obj_DonVi.Phone = txbPhone.Text.Trim();

            DataRowView dataRow = (DataRowView)cmbLoai.SelectedItem;
            obj_DonVi.Loai = (dataRow[1] == DBNull.Value) ? "" : dataRow[1].ToString();

            if (!IsEditMode) obj_DonVi.ID = MyMainForms.DonVi.GetNextID();
        }

        private void txbDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!AcceptChars.Contains(e.KeyChar) && Convert.ToInt32(e.KeyChar) != 8)
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (IsEditMode)
            {
                ApplyInfoToObj(ObjDonVi);
                int i = MyMainForms.DonVi.UpdateInfo(ObjDonVi);
                if (i > 0)
                {
                    MessageBox.Show("Đã cập nhật thông đơn vị: " + ObjDonVi.TenDonVi, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MyMainForms.FormCaNhanTapThe.RefreshTreeNode("G" + ObjDonVi.ID);

            }
            else
            {
                ApplyInfoToObj(ObjDonVi);
                int i = MyMainForms.DonVi.Insert(ObjDonVi);
                if (i > 0)
                {
                    MessageBox.Show("Đã thêm đơn vị mới: " + ObjDonVi.TenDonVi, "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                MyMainForms.FormCaNhanTapThe.RefreshTreeNode("G" + ObjDonVi.ID);
            }
            MyMainForms.FormCaNhan.SetDatasourceForControls();
            MyMainForms.FormCaNhan.ApplyInfoFromObj(MyMainForms.FormCaNhan.ObjCaNhan);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyMainForms.FormCaNhanTapThe.Show();
        }

        private void txbTen_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = !(txbTen.Text.Trim().Length == 0);
        }
    }
}
