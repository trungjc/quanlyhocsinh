using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;
using BSO;
using System.Globalization;
using System.Drawing;

namespace CMS.Client.Admin
{
    public partial class Medi_QLXetNghiem : System.Web.UI.UserControl
    {
        public string CaseChucNang
        {
            get
            {
                return ViewState["CaseChucNang"] != null ? ViewState["CaseChucNang"].ToString() : "";
            }
            set { ViewState["CaseChucNang"] = value; }
        }

        readonly Medi_LoaiXNBSO _pxnBso = new Medi_LoaiXNBSO();
        enum PageAction { Default, Edit, AddChild, AddBefore, AddAffter }

        #region initialize
        protected void initialize_form()
        {
            LoadTree();
        }

        #endregion

        #region events
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                initialize_form();
                ShowControl(PageAction.Default);
                txtSearch.Focus();
                EventEnter();
            }
        }

        protected void treeView1_NodeMouseClick(object sender, RadTreeNodeEventArgs e)
        {
            lblThongbao.Text = "";
            DataTable dt_Item_LXN = new DataTable();
            int id = Convert.ToInt32(rtvCtChung.SelectedNode.Value);
            dt_Item_LXN = _pxnBso.Get_Item_LXN(id);
            txtTenLXN.Text = dt_Item_LXN.Rows[0]["TenLoaiXN"].ToString().Trim();
            txtIndex.Text = dt_Item_LXN.Rows[0]["Index"].ToString().Trim();
            hdfId_Cha.Value = dt_Item_LXN.Rows[0]["ID_Cha"].ToString().Trim();
            hdfID.Value = dt_Item_LXN.Rows[0]["ID"].ToString().Trim();


            if (hdfId_Cha.Value.Trim() == "0")
            {
                hpl_AddChild.Visible = true;
            }
            else
            {
                hpl_AddChild.Visible = false;
            }
        }

        protected void rtvCtChung_OnNodeDrop(object sender, RadTreeNodeDragDropEventArgs e)
        {
            PerformUpdateIndex(e.DropPosition, e.SourceDragNode, e.DestDragNode);
            PerformDragAndDrop(e.DropPosition, e.SourceDragNode, e.DestDragNode);
        }

        protected void btn_AddChild_Click(object sender, EventArgs e)
        {
            if (txtTenLXN.Text.Trim() == "")
            {
                lblThongbao.ForeColor = Color.Red;
                txtTenLXN_add.Text = "";
                lblThongbao.Text = "Yêu cầu chọn loại xét nghiệm";
            }
            else
            {
                ShowControl(PageAction.AddChild);
            }
        }
        protected void btn_AddBefore_Click(object sender, EventArgs e)
        {
            if (txtTenLXN.Text.Trim() == "")
            {
                lblThongbao.ForeColor = Color.Red;
                txtTenLXN_add.Text = "";
                lblThongbao.Text = "Yêu cầu chọn loại xét nghiệm";
            }
            else
            {
                ShowControl(PageAction.AddBefore);
            }

        }
        protected void btn_AddAffter_Click(object sender, EventArgs e)
        {
            if (txtTenLXN.Text.Trim() == "")
            {
                lblThongbao.ForeColor = Color.Red;
                txtTenLXN_add.Text = "";
                lblThongbao.Text = "Yêu cầu chọn loại xét nghiệm";
            }
            else
            {
                ShowControl(PageAction.AddAffter);
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            ETO.Medi_LoaiXN Medi_lxn = new ETO.Medi_LoaiXN();
            DataTable dt = new DataTable();
            float kq;
            float index = float.Parse(txtIndex.Text.Trim(), CultureInfo.InvariantCulture.NumberFormat);
            string tenLXN = txtTenLXN_add.Text.Trim();
            int id_cha = Convert.ToInt32(hdfId_Cha.Value.Trim());
            int id = Convert.ToInt32(hdfID.Value.Trim());
            if (tenLXN == "")
            {
                lblThongbao.ForeColor = Color.Red;
                lblThongbao.Text = "Chưa nhập tên xét nghiệm";
            }
            else
            {
                lblThongbao.Text = "";
                switch (CaseChucNang)
                {
                    case "addChild":
                        {
                            //dt = pxnBSO.Get_Affter_Data_NodeChild(id);
                            dt = _pxnBso.Get_Affter_Data_NodeChild(id);
                            if (dt.Rows.Count > 0)
                            {
                                Medi_lxn.TenLoaiXN = tenLXN;
                                Medi_lxn.Id_Cha = id;
                                Medi_lxn.Index = float.Parse(dt.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat) + 1;
                                //CHECK TRÙNG TÊN
                                int idTrungTen = Convert.ToInt32(Check_trungTen(id, tenLXN).ToString());
                                if (idTrungTen == 0)
                                {
                                    _pxnBso.Createlxn(Medi_lxn);
                                    LoadTree();
                                    SelectNode(_pxnBso.Get_ID_LXN_New());
                                    lblThongbao.ForeColor = Color.Blue;
                                    lblThongbao.Text = "Thêm mới thành công";
                                    lblTrangThaiChucNang.Text = "";
                                    pnSearch.Enabled = true;
                                    pnTree.Enabled = true;
                                    pnThongTin.Visible = true;
                                    pnAddChild.Visible = false;
                                }
                                else
                                {
                                    lblThongbao.Text = "loại xét nghiệm cùng cấp đã tồn tại";
                                }
                            }
                            else
                            {
                                Medi_lxn.TenLoaiXN = tenLXN;
                                Medi_lxn.Id_Cha = id;
                                Medi_lxn.Index = 1;
                                _pxnBso.Createlxn(Medi_lxn);
                                LoadTree();
                                SelectNode(_pxnBso.Get_ID_LXN_New());
                                lblThongbao.ForeColor = Color.Blue;
                                lblThongbao.Text = "Thêm mới thành công";
                                lblTrangThaiChucNang.Text = "";
                                pnSearch.Enabled = true;
                                pnTree.Enabled = true;
                                pnThongTin.Visible = true;
                                pnAddChild.Visible = false;
                            }
                            break;
                        }
                    case "addBefore":
                        {
                            // phần lấy giá trị index lưu vào db 
                            float trunggian = index - (float)1;
                            dt = _pxnBso.Get_Before_Data(index, id_cha);
                            if (dt.Rows.Count > 0)
                            {
                                float index_before = float.Parse(dt.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
                                kq = (index + index_before) / 2;
                            }
                            else
                            {
                                kq = trunggian;
                            }
                            Medi_lxn.TenLoaiXN = tenLXN;
                            Medi_lxn.Id_Cha = id_cha;
                            Medi_lxn.Index = kq;

                            int idTrungTen = Convert.ToInt32(Check_trungTen(id_cha, tenLXN).ToString());
                            if (idTrungTen == 0)
                            {
                                _pxnBso.Createlxn(Medi_lxn);
                                LoadTree();
                                SelectNode(_pxnBso.Get_ID_LXN_New());
                                lblThongbao.ForeColor = Color.Blue;
                                lblThongbao.Text = "Thêm mới thành công";
                                lblTrangThaiChucNang.Text = "";
                                pnSearch.Enabled = true;
                                pnTree.Enabled = true;
                                pnThongTin.Visible = true;
                                pnAddChild.Visible = false;
                            }
                            else
                            {
                                lblThongbao.Text = "loại xét nghiệm cùng cấp đã tồn tại";
                            }
                            break;
                        }
                    case "addAffter":
                        {
                            // phần lấy giá trị index lưu vào db 
                            float trunggian = index + 1;
                            //  dt = pxnBSO.Get_Affter_Data(index, id_cha);
                            dt = _pxnBso.Get_Affter_Data(index, id_cha);
                            if (dt.Rows.Count > 0)
                            {
                                float index_before = float.Parse(dt.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
                                kq = (index + index_before) / 2;
                            }
                            else
                            {
                                kq = trunggian;
                            }
                            Medi_lxn.TenLoaiXN = tenLXN;
                            Medi_lxn.Id_Cha = id_cha;
                            Medi_lxn.Index = kq;
                            int idTrungTen = Convert.ToInt32(Check_trungTen(id_cha, tenLXN).ToString());
                            if (idTrungTen == 0)
                            {

                                _pxnBso.Createlxn(Medi_lxn);
                                LoadTree();
                                SelectNode(_pxnBso.Get_ID_LXN_New());
                                lblThongbao.ForeColor = Color.Blue;
                                lblThongbao.Text = "Thêm mới thành công";
                                lblTrangThaiChucNang.Text = "";
                                pnSearch.Enabled = true;
                                pnTree.Enabled = true;
                                pnThongTin.Visible = true;
                                pnAddChild.Visible = false;
                            }
                            else
                            {
                                lblThongbao.Text = "loại xét nghiệm cùng cấp đã tồn tại";
                            }
                            break;
                        }
                    case "edit":
                        {
                            // pxnBSO.Update_LXN(id, tenLXN);
                            int idTrungTen = Convert.ToInt32(Check_trungTen(id_cha, tenLXN).ToString());
                            if (idTrungTen == 0 || idTrungTen == id)
                            {
                                _pxnBso.Update_LXN(id, tenLXN);
                                LoadTree();
                                SelectNode(id);
                                lblThongbao.ForeColor = Color.Blue;
                                lblThongbao.Text = "cập nhật loại xét nghiệm thành công";
                                lblTrangThaiChucNang.Text = "";
                                pnSearch.Enabled = true;
                                pnTree.Enabled = true;
                                pnThongTin.Visible = true;
                                pnAddChild.Visible = false;
                            }
                            else
                            {
                                lblThongbao.Text = "loại xét nghiệm cùng cấp đã tồn tại";
                            }
                            break;
                        }
                }
                txtTenLXN.Text = "";
            }
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            txtTenLXN_add.Focus();
            if (txtTenLXN.Text != "")
            {
                lblThongbao.Text = "";
                lblTrangThaiChucNang.Text = "Chức năng sửa loại xét nghiệm";
                ViewState["CaseChucNang"] = "edit";
                txtTenLXN_add.Text = txtTenLXN.Text.Trim();
                pnSearch.Enabled = false;
                pnTree.Enabled = false;
                pnThongTin.Visible = false;
                pnAddChild.Visible = true;
            }
            else
            {
                lblThongbao.ForeColor = Color.Red;
                lblThongbao.Text = "Yêu cầu chọn loại xét nghiệm";
            }
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (txtTenLXN.Text != "")
            {
                DataTable dt_LXN = new DataTable();
                int id = Convert.ToInt32(hdfID.Value.Trim());
                dt_LXN = _pxnBso.Get_Data_LXN_TheoID(id);
                if (dt_LXN.Rows.Count > 0)
                {
                    //lblThongbao.Text = "";
                    //try
                    //{
                    //    _pxnBso.Delete_GiaLXN(id);
                    //    lblThongbao.ForeColor = Color.Blue;
                    //    lblThongbao.Text = "Xóa giá loại xét nghiệm thành công";
                    //}
                    //catch
                    //{
                    //    lblThongbao.ForeColor = Color.Red;
                    //    lblThongbao.Text = "Xóa giá loại xét nghiệm không thành công";
                    //}
                    lblThongbao.ForeColor = Color.Red;
                    lblThongbao.Text = "loaị xét nghiệm này đã được sử dụng, không thể xóa được ";

                }
                else
                {
                    _pxnBso.Delete_LXN(id);
                    lblThongbao.ForeColor = Color.Blue;
                    lblThongbao.Text = "Xóa loại xét nghiệm thành công";
                    txtTenLXN.Text = "";
                    LoadTree();
                }
            }
            else
            {
                lblThongbao.ForeColor = Color.Red;
                lblThongbao.Text = "Yêu cầu chọn loại xét nghiệm";
            }

        }
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            lblThongbao.Text = "";
            lblTrangThaiChucNang.Text = "";
            LoadTree();
            txtTenLXN.Text = "";
            pnSearch.Enabled = true;
            pnTree.Enabled = true;
            pnThongTin.Visible = true;
            pnAddChild.Visible = false;
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            lblThongbao.Text = "";
            DataTable dt_kq = new DataTable();
            dt_kq.Columns.Add("ID", typeof(int));
            dt_kq.Columns.Add("TenLoaiXN");
            dt_kq.Columns.Add("ID_Cha", typeof(int));
            dt_kq.Columns.Add("Index", typeof(float));
            DataTable dt_search = new DataTable();
            DataTable dt_parent = new DataTable();
            string key_value = txtSearch.Text.Trim();
            dt_search = _pxnBso.Get_List_LXN(key_value);
            if (dt_search.Rows.Count > 0)
            {
                int id_check = 0;
                for (int i = 0; i < dt_search.Rows.Count; i++)
                {
                    int id_cha = Convert.ToInt32(dt_search.Rows[i]["ID_Cha"]);
                    dt_parent = _pxnBso.Get_Parent_Data(id_cha);
                    if (dt_parent.Rows.Count > 0 && id_cha != id_check)
                    {
                        int dt_parent_id = Convert.ToInt32(dt_parent.Rows[0]["ID"]);
                        string dt_parent_tenlxn = dt_parent.Rows[0]["TenLoaiXN"].ToString().Trim();
                        int dt_parent_idcha = Convert.ToInt32(dt_parent.Rows[0]["ID_Cha"]);
                        float dt_parent_index = float.Parse(dt_parent.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
                        dt_kq.Rows.Add(dt_parent_id, dt_parent_tenlxn, dt_parent_idcha, dt_parent_index);
                    }
                    int dt_search_id = Convert.ToInt32(dt_search.Rows[i]["ID"]);
                    string dt_search_tenlxn = dt_search.Rows[i]["TenLoaiXN"].ToString().Trim();
                    int dt_search_idcha = Convert.ToInt32(dt_search.Rows[i]["ID_Cha"]);
                    float dt_search_index = float.Parse(dt_search.Rows[i]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
                    dt_kq.Rows.Add(dt_search_id, dt_search_tenlxn, dt_search_idcha, dt_search_index);
                    id_check = id_cha;
                }
            }
            else
            {
                lblThongbao.Text = "Không có loại xét nghiệm nào được tìm thấy";
            }
            CreateTree(dt_kq);
            rtvCtChung.EnableDragAndDrop = false;


        }
        protected void btn_Save_Node_Click(object sender, EventArgs e)
        {
            if (UpdateTreeView())
            {
                lblThongbao.ForeColor = Color.Blue;
                lblThongbao.Text = "Cập nhật node thành công";
                LoadTree();
            }
            else
            {
                lblThongbao.ForeColor = Color.Red;
                lblThongbao.Text = "Cập nhật không thành công";
            }
        }
        #endregion

        #region Custom Methods
        protected void LoadTree()
        {
            DataTable dt = new DataTable();
            dt = _pxnBso.Get_Data_LoadTree();
            CreateTree(dt);
        }

        private void CreateTree(DataTable dt)
        {
            rtvCtChung.Nodes.Clear();

            var roots = dt.Select("ID_Cha = 0");

            foreach (var dataRow in roots)
            {
                var rootNode = new RadTreeNode();
                var value = dataRow["ID"].ToString().Trim();
                var text = "";

                text = dataRow["TenLoaiXN"].ToString().Trim();

                rootNode.Value = value;
                rootNode.Text = text;
                rootNode.Attributes["index"] = dataRow["index"].ToString().Trim();

                rootNode.Expanded = true;

                CreateNode(rootNode, dt);
                rtvCtChung.Nodes.Add(rootNode);
            }
        }

        private void CreateNode(RadTreeNode rootNode, DataTable dt)
        {
            var childs = dt.Select("ID_Cha = " + rootNode.Value);
            if (childs.Any())
            {
                foreach (var dataRow in childs)
                {
                    var childNode = new RadTreeNode();
                    childNode.Value = dataRow["ID"].ToString().Trim();
                    var value = dataRow["ID"].ToString().Trim();
                    var text = "";

                    text = dataRow["TenLoaiXN"].ToString().Trim();

                    childNode.Value = value;
                    childNode.Text = text;
                    childNode.Attributes["index"] = dataRow["index"].ToString().Trim();
                    childNode.Expanded = true;
                    CreateNode(childNode, dt);
                    rootNode.Nodes.Add(childNode);
                }
            }
        }

        private void ShowControl(PageAction pageAction)
        {
            switch (pageAction)
            {
                case PageAction.Default:
                    //ẩn nút gì hiện nút gì ở đây
                    rtvCtChung.EnableDragAndDrop = true;
                    break;
                case PageAction.AddChild:
                    lblThongbao.Text = "";
                    lblTrangThaiChucNang.Text = "Chức năng thêm mới loại xét nghiệm <span style='Color: blue;'>nằm trong</span> loại xét nghiệm được chọn";
                    ViewState["CaseChucNang"] = "addChild";
                    txtTenLXN_add.Text = "";
                    pnSearch.Enabled = false;
                    pnTree.Enabled = false;
                    pnThongTin.Visible = false;
                    pnAddChild.Visible = true;
                    break;
                case PageAction.AddBefore:
                    lblThongbao.Text = "";
                    txtTenLXN_add.Text = "";
                    lblTrangThaiChucNang.Text = "Chức năng thêm mới loại xét nghiệm <span style='Color: blue;'>ngang hàng và đứng trước</span> loại xét nghiệm được chọn";
                    ViewState["CaseChucNang"] = "addBefore";
                    pnSearch.Enabled = false;
                    pnTree.Enabled = false;
                    pnThongTin.Visible = false;
                    pnAddChild.Visible = true;
                    break;
                case PageAction.AddAffter:
                    lblThongbao.Text = "";
                    txtTenLXN_add.Text = "";
                    lblTrangThaiChucNang.Text = "Chức năng thêm mới loại xét nghiệm <span style='Color: blue;'>ngang hàng và đứng sau</span> loại xét nghiệm được chọn";
                    ViewState["CaseChucNang"] = "addAffter";
                    pnSearch.Enabled = false;
                    pnTree.Enabled = false;
                    pnThongTin.Visible = false;
                    pnAddChild.Visible = true;
                    break;
            }
        }
        private void SelectNode(int id_Note)
        {
            int i = 1;
            foreach (RadTreeNode node in rtvCtChung.GetAllNodes())
            {
                int idNode = Convert.ToInt32(node.Value.Trim());
                if (idNode == id_Note)
                {
                    node.Selected = true;
                }
                i++;
            }
        }
        private bool UpdateTreeView()
        {
            try
            {
                int i = 1;
                foreach (RadTreeNode node in rtvCtChung.GetAllNodes())
                {
                    int idcha = 0;
                    int id = Convert.ToInt32(node.Value.Trim());
                    string tenLXN = node.Text.Trim();
                    if (node.ParentNode != null)
                    {
                        idcha = Convert.ToInt32(node.ParentNode.Value.Trim());
                    }
                    else
                    {
                        idcha = 0;
                    }
                    float index = float.Parse(i.ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);

                    bool rs = _pxnBso.Update_Node_THop(id, tenLXN, idcha, index);
                    i++;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void PerformDragAndDrop(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
        {
            switch (dropPosition)
            {
                case RadTreeViewDropPosition.Over:
                    // child
                    if (!sourceNode.IsAncestorOf(destNode))
                    {
                        sourceNode.Owner.Nodes.Remove(sourceNode);
                        destNode.Nodes.Add(sourceNode);
                    }
                    break;
                case RadTreeViewDropPosition.Above:
                    // sibling - above
                    sourceNode.Owner.Nodes.Remove(sourceNode);
                    destNode.InsertBefore(sourceNode);
                    break;
                case RadTreeViewDropPosition.Below:
                    // sibling - below
                    sourceNode.Owner.Nodes.Remove(sourceNode);
                    destNode.InsertAfter(sourceNode);
                    break;
            }
        }

        protected void PerformUpdateIndex(RadTreeViewDropPosition dropPosition, RadTreeNode sourceNode, RadTreeNode destNode)
        {
            var destNodeIndex = destNode.Next.Attributes["index"];
            switch (dropPosition)
            {
                case RadTreeViewDropPosition.Over:
                    break;

                case RadTreeViewDropPosition.Above:

                    break;
                case RadTreeViewDropPosition.Below:
                    break;
            }

            var asdas = destNode.Attributes;
            var aasdasd = destNode.Attributes["index"];
            var ascxcg = sourceNode.Attributes["index"];
            var prenode = destNode.Prev;
            var indexPrev = prenode.Attributes["index"];

        }

        #endregion

        //private void Update_Node()
        //{
        //    DataTable dt, dt_be, dt_af;
        //    float index_now = 0;
        //    string id_value = hdfvalue_id.Value.Trim();
        //    string position = hdfposition.Value.Trim();
        //    string id_now = hdfid_now.Value.Trim();
        //    if (id_value != "" && position == "below")
        //    {
        //        dt = pxnBSO.Get_Item_LXN(Convert.ToInt32(id_value));
        //        float index = float.Parse(dt.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
        //        int id_cha = Convert.ToInt32(dt.Rows[0]["ID_Cha"].ToString().Trim());
        //        dt_af = pxnBSO.Get_Affter_Data(index, id_cha);
        //        if (dt_af.Rows.Count > 0)
        //        {
        //            index_now = (index + float.Parse(dt_af.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat)) / 2;
        //        }
        //        else
        //        {
        //            index_now = index + 1;
        //        }
        //        try
        //        {
        //            pxnBSO.Update_Index_LXN( Convert.ToInt32(id_now), index_now);
        //            lblThongbao.ForeColor = Color.Blue;
        //            lblThongbao.Text = "Cập nhật xắp xếp thành công";
        //        }
        //        catch
        //        {
        //            lblThongbao.ForeColor = Color.Red;
        //            lblThongbao.Text = "Cập nhật xắp xếp không thành công";
        //        }
        //        loadTree();
        //    }
        //    if (id_value != "" && position == "above")
        //    {
        //        dt = pxnBSO.Get_Item_LXN(Convert.ToInt32(id_value));
        //        float index = float.Parse(dt.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
        //        int id_cha = Convert.ToInt32(dt.Rows[0]["ID_Cha"].ToString().Trim());
        //        dt_be = pxnBSO.Get_Before_Data(index, id_cha);
        //        if (dt_be.Rows.Count > 0)
        //        {
        //            index_now = (index + float.Parse(dt_be.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat)) / 2;
        //        }
        //        else
        //        {
        //            index_now = index - 1;
        //        }
        //        try
        //        {
        //            pxnBSO.Update_Index_LXN( Convert.ToInt32(id_now), index_now);
        //            lblThongbao.ForeColor = Color.Blue;
        //            lblThongbao.Text = "Cập nhật xắp xếp thành công";
        //        }
        //        catch
        //        {
        //            lblThongbao.ForeColor = Color.Red;
        //            lblThongbao.Text = "Cập nhật xắp xếp không thành công";
        //        }
        //        loadTree();
        //    }
        //}
        //protected void RadTreeView1_NodeDrop(object sender, Telerik.Web.UI.RadTreeNodeDragDropEventArgs e)
        //{
        //    DataTable dt, dt_be, dt_af;
        //    float index_now = 0;
        //    lblThongbao.Text = "";
        //    int id = Convert.ToInt32(rtvCtChung.SelectedNode.Value);
        //    dt = pxnBSO.Get_Item_LXN(id);
        //    float index = float.Parse(dt.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat);
        //    int id_cha = Convert.ToInt32(dt.Rows[0]["ID_Cha"].ToString().Trim());
        //    dt_be = pxnBSO.Get_Before_Data(index, id_cha);
        //    dt_af = pxnBSO.Get_Affter_Data(index, id_cha);
        //    if (dt_be.Rows.Count > 0 && dt_af.Rows.Count > 0)
        //    {
        //        index_now = (float.Parse(dt_be.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat) + float.Parse(dt_af.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat)) / 2;
        //    }
        //    if (dt_be.Rows.Count < 0 && dt_af.Rows.Count > 0)
        //    {
        //        index_now = float.Parse(dt_af.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat) - 1;
        //    }
        //    if (dt_be.Rows.Count > 0 && dt_af.Rows.Count < 0)
        //    {
        //        index_now = float.Parse(dt_be.Rows[0]["Index"].ToString().Trim(), CultureInfo.InvariantCulture.NumberFormat) + 1;
        //    }
        //    try
        //    {
        //        pxnBSO.Update_Index_LXN(id, index_now);
        //        lblThongbao.ForeColor = Color.Blue;
        //        lblThongbao.Text = "Cập nhật xắp xếp thành công";
        //    }
        //    catch
        //    {
        //        lblThongbao.ForeColor = Color.Red;
        //        lblThongbao.Text = "Cập nhật xắp xếp không thành công";
        //    }
        //    loadTree();
        private int Check_trungTen(int idCha, string ten)
        {
            DataTable dtTen = new DataTable();
            dtTen = _pxnBso.Check_CungTen(idCha, ten);
            if (dtTen.Rows.Count > 0 && dtTen != null)
             {
                return (Convert.ToInt32(dtTen.Rows[0]["ID"].ToString()));
            }
            else
            {
                return 0;
            }

        }
        protected void EventEnter()
        {
            txtSearch.Attributes.Add("onKeyPress", "doClick('" + btnSearch.ClientID + "',event)");

        }

    }
}