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
    public partial class frmCaNhanTapThe : Form
    {
        public MainForm MyMainForm { get; set; }

        public frmCaNhanTapThe(MainForm mainForm)
        {
            InitializeComponent();
            MyMainForm = mainForm;
        }

        //Methods-------------------------------------------------------------------------------------------------
        public void RefreshTreeNode(TreeView treeView, DataTable dtbDonVi, DataTable dtbCaNhan)
        {
            treeView.Nodes.Clear();
            treeView.Nodes.AddRange(GenerateGroupNodes(dtbDonVi));
            foreach (TreeNode item in treeView.Nodes)
            {
                item.Nodes.Clear();
                item.Nodes.AddRange(GeneratePersonNodes(((long)item.Tag), dtbCaNhan));
            }
        }

        public void RefreshTreeNode()
        {
            trvDonVi.Nodes.Clear();
            trvDonVi.Nodes.AddRange(GenerateGroupNodes(MyMainForm.DtbDonVi));
            foreach (TreeNode item in trvDonVi.Nodes)
            {
                item.Nodes.Clear();
                item.Nodes.AddRange(GeneratePersonNodes(((long)item.Tag), MyMainForm.DtbCaNhan));
                //item.Expand();
            }
        }

        public void RefreshTreeNode(string nodeName)
        {
            RefreshTreeNode();
            TreeNode sn = trvDonVi.Nodes.Find(nodeName, true).FirstOrDefault();
            if (sn != null)
            {
                trvDonVi.SelectedNode = sn;
            }
        }

        private TreeNode[] GenerateGroupNodes(DataTable dtbDonVi)
        {
            List<TreeNode> list = new List<TreeNode>();
            foreach (DataRow item in dtbDonVi.Rows)
            {
                TreeNode tn0 = new TreeNode(item[1].ToString() + " " + item[2].ToString())
                {
                    Name = "G" + item[0].ToString(),
                    Tag = item[0],
                    ImageKey = "group24.png",
                    SelectedImageKey = "group24s.png"
                };
                list.Add(tn0);
            }
            return list.ToArray();
        }

        private TreeNode[] GeneratePersonNodes(long id, DataTable DtbCaNhan)
        {
            List<TreeNode> list = new List<TreeNode>();

            foreach (DataRow item in DtbCaNhan.Rows)
            {
                if ((long)item[1] == id)
                {
                    TreeNode tn1 = new TreeNode((string)item[2])
                    {
                        Name = "P" + item[0].ToString(),
                        Tag = item[0],
                        ImageKey = "user24.png",
                        SelectedImageKey = "user24s.png"
                    };
                    list.Add(tn1);
                }
            }

            return list.ToArray();
        }


        //Events--------------------------------------------------------------------------------------------------
        private void frmCaNhanTapThe_Load(object sender, EventArgs e)
        {
            RefreshTreeNode(trvDonVi, MyMainForm.DtbDonVi, MyMainForm.DtbCaNhan);
        }

        private void frmCaNhanTapThe_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyMainForm.Show();
            this.Close();
            if (MyMainForm.FormCaNhan != null && !MyMainForm.IsDisposed)
            {
                MyMainForm.FormCaNhan.Close();
            }
            if (MyMainForm.FormDonVi != null && !MyMainForm.IsDisposed)
            {
                MyMainForm.FormDonVi.Close();
            }
        }

        private void trvDonVi_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode tn = trvDonVi.GetNodeAt(e.Location);
            if (tn != null)
            {
                trvDonVi.SelectedNode = tn;
            }

            contextMenu.Enabled = (trvDonVi.SelectedNode != null);
            if (contextMenu.Enabled)
            {
                ctmnXoa.Text = "Xóa: " + trvDonVi.SelectedNode.Text;
                ctmnSuaThongTin.Text = "Sửa thông tin: " + trvDonVi.SelectedNode.Text;
                ctmnThemDonVi.Text = "Thêm đơn vị mới";
                ctmnThemCaNhan.Text = "Thêm cán bộ mới";
            }
        }

        private void trvDonVi_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            dynamic o;
            if (e.Node.Level == 0)
            {
                o = MyMainForm.CreateObjDonVi((long)e.Node.Tag);
                if (MyMainForm.FormDonVi != null && !MyMainForm.FormDonVi.IsDisposed && (long)e.Node.Tag != 0)
                {
                    MyMainForm.FormDonVi.ObjDonVi = o;
                    MyMainForm.FormDonVi.IsEditMode = true;
                }
            }
            else
            {
                o = MyMainForm.CreateObjCaNhan((long)e.Node.Tag);
                if (MyMainForm.FormCaNhan != null && !MyMainForm.FormCaNhan.IsDisposed)
                {
                    MyMainForm.FormCaNhan.ObjCaNhan = o;
                    MyMainForm.FormCaNhan.IsEditMode = true;
                }
                Obj_DonVi p = MyMainForm.CreateObjDonVi((long)e.Node.Parent.Tag);
                if (MyMainForm.FormDonVi != null && !MyMainForm.FormDonVi.IsDisposed && (long)e.Node.Parent.Tag != 0)
                {
                    MyMainForm.FormDonVi.ObjDonVi = p;
                    MyMainForm.FormDonVi.IsEditMode = true;
                }
            }

            StringBuilder s = new StringBuilder();
            s.Append((e.Node.Level == 0) ? "[ID: G-" : "[ID: P-");
            s.Append(string.Format("{0:000}", o.ID) + "] ");
            s.Append("[Phone: " + o.Phone + "] " + "[Email:" + o.Email + "]");
            lbl_CaNhanTapThe.Text = s.ToString();
        }

        private void ctmnThemDonVi_Click(object sender, EventArgs e)
        {
            if (MyMainForm.FormDonVi == null || MyMainForm.FormDonVi.IsDisposed)
            {
                MyMainForm.FormDonVi = new frmDonVi(MyMainForm);
                MyMainForm.FormDonVi.Location = new Point(this.Location.X + this.Width - MyMainForm.FormDonVi.Width, this.Location.Y);
            }
            MyMainForm.FormDonVi.IsEditMode = false;
            MyMainForm.FormDonVi.Show();
            MyMainForm.FormDonVi.Activate();
            
        }

        private void ctmnThemCaNhan_Click(object sender, EventArgs e)
        {
            if (MyMainForm.FormCaNhan == null || MyMainForm.FormCaNhan.IsDisposed)
            {
                MyMainForm.FormCaNhan = new frmCaNhan(MyMainForm);
                MyMainForm.FormCaNhan.Location = new Point(this.Location.X + this.Width - MyMainForm.FormCaNhan.Width, this.Location.Y);
            }
            MyMainForm.FormCaNhan.IsEditMode = false;
            MyMainForm.FormCaNhan.Show();
            MyMainForm.FormCaNhan.Activate();
            
        }

        private void ctmnSuaThongTin_Click(object sender, EventArgs e)
        {
            if (trvDonVi.SelectedNode.Level == 0)
            {
                if (MyMainForm.FormDonVi == null || MyMainForm.FormDonVi.IsDisposed)
                {
                    MyMainForm.FormDonVi = new frmDonVi(MyMainForm);
                    MyMainForm.FormDonVi.Location = new Point(this.Location.X + this.Width - MyMainForm.FormDonVi.Width, this.Location.Y);
                }
                MyMainForm.FormDonVi.ObjDonVi = MyMainForm.CreateObjDonVi((long)trvDonVi.SelectedNode.Tag);
                MyMainForm.FormDonVi.IsEditMode = true;
                MyMainForm.FormDonVi.Show();
                MyMainForm.FormDonVi.Activate();
            }
            else
            {
                if (MyMainForm.FormCaNhan == null || MyMainForm.FormCaNhan.IsDisposed)
                {
                    MyMainForm.FormCaNhan = new frmCaNhan(MyMainForm);
                    MyMainForm.FormCaNhan.Location = new Point(this.Location.X + this.Width -MyMainForm.FormCaNhan.Width, this.Location.Y);
                }
                MyMainForm.FormCaNhan.ObjCaNhan = MyMainForm.CreateObjCaNhan((long)trvDonVi.SelectedNode.Tag);
                MyMainForm.FormCaNhan.IsEditMode = true;
                MyMainForm.FormCaNhan.Show();
                MyMainForm.FormCaNhan.Activate();
            }
        }

        private void ctmnXoa_Click(object sender, EventArgs e)
        {
            string i = trvDonVi.SelectedNode.Text;
            {
                if (trvDonVi.SelectedNode.Level == 0)
                {
                    if (MessageBox.Show("Xóa: " + i + " ?" + ((trvDonVi.SelectedNode.Level == 0) ? "\nCác cá nhân thuộc đơn vị này sẽ chuyển vào nhóm chưa phân loại [...]" : ""),
                        "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Obj_DonVi o = MyMainForm.CreateObjDonVi((long)trvDonVi.SelectedNode.Tag);
                        int c = MyMainForm.DonVi.Delete(o);
                        RefreshTreeNode();
                    }
                }
                else
                {
                    if (MessageBox.Show("Xóa: " + i + " ?" + ((trvDonVi.SelectedNode.Level == 0) ? "\nHồ sơ thi đua của thành viên này cũng sẽ bị xóa!" : ""),
                        "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Obj_CaNhan o = MyMainForm.CreateObjCaNhan((long)trvDonVi.SelectedNode.Tag);
                        int c = MyMainForm.CaNhan.Delete(o);
                        if (c==1)
                        {
                            trvDonVi.SelectedNode.Remove();
                        }
                        //RefreshTreeNode();
                    }
                }
            }
        }

        private void contextMenu_Opened(object sender, EventArgs e)
        {
            if (trvDonVi.SelectedNode == null) return;
            if (trvDonVi.SelectedNode.Name == "G0")
            {
                ctmnSuaThongTin.Enabled = false;
                ctmnXoa.Enabled = false;
            }
            else
            {
                ctmnSuaThongTin.Enabled = true;
                ctmnXoa.Enabled = true;
            }
        }
    }
}

