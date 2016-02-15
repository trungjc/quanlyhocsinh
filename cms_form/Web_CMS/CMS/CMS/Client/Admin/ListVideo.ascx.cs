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
    public partial class ListVideo : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
                initControl();
        }

        #region NavigationTitle
        private void NavigationTitle(string url)
        {
            ModulesBSO modulesBSO = new ModulesBSO();
            Modules modules = modulesBSO.GetModulesByUrl(url);
            imgIcon.ImageUrl = "~/Upload/Admin_Theme/Icons/" + modules.ModulesIcon;
            litModules.Text = modules.ModulesName;
        }
        #endregion

        #region ViewVideo
        protected void initControl()
        {

            ConfigBSO configBSO = new ConfigBSO();
            int Ngon_Ngu = Convert.ToInt32(ViewState["CauHinh_Viet"]);
            if (Ngon_Ngu == 1 || Ngon_Ngu == 0)
            {
                VideoBSO videoBSO = new VideoBSO();
                DataTable table = videoBSO.GetVideoAll(Language.language);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvVideo, table);

            }
            else
            {
                VideoBSO videoBSO = new VideoBSO();
                DataTable table = videoBSO.GetVideoAll(Language.language_Eng);
                commonBSO commonBSO = new commonBSO();
                commonBSO.FillToGridView(grvVideo, table);
            }




        }
        //public void ViewVideo()
        //{
        //    VideoBSO videoBSO = new VideoBSO();
        //    DataTable table = videoBSO.GetVideoAll(Language.language);
        //    commonBSO commonBSO = new commonBSO();
        //    commonBSO.FillToGridView(grvVideo, table);
        //}
        #endregion
        protected void grvVideo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {

                case "_edit":
                    Response.Redirect("~/Admin/editvideo/" + Id + "/Default.aspx");
                    break;
                case "_delete":

                    VideoBSO videoBSO = new VideoBSO();
                    videoBSO.DeleteVideo(Id);
                    initControl();
                    break;
            }
        }
        protected void grvVideo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");

            }
        }

        protected void Viet_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 1;
            initControl();
        }
        protected void Eng_Check(object sender, EventArgs e)
        {
            ViewState["CauHinh_Viet"] = 2;
            initControl();
        }

    }
}