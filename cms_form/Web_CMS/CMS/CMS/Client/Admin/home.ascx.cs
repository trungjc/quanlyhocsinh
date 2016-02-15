using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;
using System.Data;

namespace CMS.Client.Admin
{
    public partial class home : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindMenuAdminCate(0);
            }
            //BindMenuAdmin();
        }

        private void BindMenuAdminCate(int cId)
        {
            if (Session["Admin_Username"] != null)
            {
                ModulesBSO modulesBSO = new ModulesBSO();
                DataTable table = modulesBSO.ViewMainModulesRoles(Session["Admin_Username"].ToString());
                DataView dataView = new DataView(table);
                dataView.RowFilter = "Modules_Parent = " + cId;
                DataList1.DataSource = dataView;
                DataList1.DataBind();
            }
            else
                Response.Redirect("~/Default.aspx");
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            DataList dtl2 = (DataList)e.Item.FindControl("DataList2");

            int cateId;
            int.TryParse(DataBinder.Eval(e.Item.DataItem, "Modules_ID").ToString(), out cateId);


            if (Session["Admin_Username"] != null)
            {
                ModulesBSO modulesBSO = new ModulesBSO();
                DataTable table = modulesBSO.ViewMainModulesRoles(Session["Admin_Username"].ToString());
                DataView dataView = new DataView(table);
                dataView.RowFilter = "Modules_Parent = " + cateId;
                dtl2.DataSource = dataView;
                dtl2.DataBind();
            }
            else
                Response.Redirect("~/Default.aspx");


        }

        //private void BindMenuAdmin() 
        //{
        //    if (Session["Admin_Username"]!=null) 
        //    {
        //        ModulesBSO modulesBSO = new ModulesBSO();
        //        DataTable table = modulesBSO.ViewMainModulesRoles(Session["Admin_Username"].ToString());
        //        DataView dataView = new DataView(table);
        //        dataView.RowFilter = "Modules_Parent = 0";
        //        DataList1.DataSource = dataView;
        //        DataList1.DataBind();
        //    }
        //    else
        //        Response.Redirect("~/Default.aspx");
        //}

    }
}