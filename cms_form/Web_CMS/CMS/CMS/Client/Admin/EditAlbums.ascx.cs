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
    public partial class EditAlbums : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Id = 0;
            if (Page.RouteData.Values["Id"] != null)
                int.TryParse(Page.RouteData.Values["Id"].ToString().Replace(",", ""), out Id);

            int cId = 0;
            if (Page.RouteData.Values["group"] != null)
                int.TryParse(Page.RouteData.Values["group"].ToString().Replace(",", ""), out cId);

            if (Page.RouteData.Values["dll"] != null)
                NavigationTitle(Page.RouteData.Values["dll"].ToString());
            if (!IsPostBack)
            {
                BindAlbumsCate(cId);
                hddAlbumsCateID.Value = Convert.ToString(cId);
                ViewAlbum(cId);
                initControl(Id);
            }
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

        #region BindAlbumsCate
        private void BindAlbumsCate(int cId)
        {
            AlbumsCateBSO albumscateBSO = new AlbumsCateBSO();
            DataTable table = albumscateBSO.GetAlbumsCate();
            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToDropDown(ddlAlbumsCate, table, "", "", "AlbumsCateName", "AlbumsCateID", "");

            if (cId != 0)
            {
                ddlAlbumsCate.Enabled = false;
                ddlAlbumsCate.SelectedValue = Convert.ToString(cId);

            }
            else
                ddlAlbumsCate.Enabled = true;
        }
        #endregion

        #region ViewAlbum
        private void ViewAlbum(int cId)
        {
            AlbumsBSO albumBSO = new AlbumsBSO();
            DataTable table = new DataTable();
            if (cId != 0)
                table = albumBSO.GetAlbumsByCate(cId);
            else
                table = albumBSO.GetAlbumsAll();

            commonBSO commonBSO = new commonBSO();
            commonBSO.FillToGridView(grvAlbum, table);
        }
        #endregion

        #region initControl
        private void initControl(int Id)
        {
            if (Id > 0)
            {
                btn_add.Visible = false;
                btn_edit.Visible = true;
                try
                {
                    AlbumsBSO albumBSO = new AlbumsBSO();
                    Albums album = albumBSO.GetAlbumsById(Id);


                    hddAlbumID.Value = Convert.ToString(album.AlbumsID);
                    hddAlbumsCateID.Value = Convert.ToString(album.AlbumsCateID);
                    ddlAlbumsCate.SelectedValue = Convert.ToString(album.AlbumsCateID);

                    hddImageLarge.Value = album.ImageLarge;
                    hddImageThumb.Value = album.ImageThumb;

                    txtTitle.Text = album.Title;
                    txtAuthor.Text = album.Author;
                    txtRadShort.Html = album.Description;
                    txtRadDate.SelectedDate = album.PostDate;

                    rdbIshome.SelectedValue = Convert.ToString(album.Ishome);
                    rdbIshot.SelectedValue = Convert.ToString(album.Ishot);

                    hddIsView.Value = Convert.ToString(album.Isview);
                    hddIsComment.Value = Convert.ToString(album.IsComment);
                    hddIsApproval.Value = Convert.ToString(album.IsApproval);
                    hddCreateUserName.Value = album.CreatedUserName;
                    hddApprovalUserName.Value = album.ApprovalUserName;
                    hddApprovalDate.Value = Convert.ToString(album.ApprovalDate);
                    hddCommentTotal.Value = Convert.ToString(album.CommentTotal);




                }
                catch (Exception ex)
                {
                    clientview.Text = ex.Message.ToString();
                }
            }
            else
            {
                btn_edit.Visible = false;
                btn_add.Visible = true;

                txtRadDate.SelectedDate = DateTime.Now;


            }
        }
        #endregion

        #region ReceiveHtml
        private Albums ReceiveHtml()
        {

            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            commonBSO commonBSO = new commonBSO();


            int thumb_w = Convert.ToInt32(config.New_icon_w);
            int thumb_h = Convert.ToInt32(config.New_icon_h);
            string path_thumb = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Albums/AlbumsImg/ImgThumb/";


            int large_w = Convert.ToInt32(config.New_large_w);
            int large_h = Convert.ToInt32(config.New_large_h);
            string path_large = Request.PhysicalApplicationPath.Replace(@"\", "/") + "/Upload/Albums/AlbumsImg/ImgLarge/";

            string image_thumb = commonBSO.UploadImage(file_image_thumb, path_thumb, thumb_w, thumb_h);
            string image_large = commonBSO.UploadImage(file_image_large, path_large, large_w, large_h);


            Albums album = new Albums();
            //album.AlbumID = (hddAlbumID.Value != "") ? Convert.ToInt32(hddAlbumID.Value) : 0;
            //album.CateNewsID = (ddlCateNews.SelectedValue != "") ? Convert.ToInt32(ddlCateNews.SelectedValue) : 0;
            //album.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            //album.ImageLarge = (image_large != "") ? image_large : hddImageLarge.Value;
            //album.IsHome = Convert.ToBoolean(rdbIsHome.SelectedValue);
            //album.Order = (hddOrder.Value != "") ? Convert.ToInt32(hddOrder.Value) : 0;

            album.AlbumsID = (hddAlbumID.Value != "") ? Convert.ToInt32(hddAlbumID.Value) : 0;
            album.AlbumsCateID = Convert.ToInt32(ddlAlbumsCate.SelectedValue);
            album.Title = txtTitle.Text;
            album.Description = txtRadShort.Html;
            album.ImageThumb = (image_thumb != "") ? image_thumb : hddImageThumb.Value;
            album.ImageLarge = (image_large != "") ? image_large : hddImageLarge.Value;
            album.Author = txtAuthor.Text;
            album.PostDate = txtRadDate.SelectedDate.Value;

            album.Status = Convert.ToBoolean(rdbStatus.SelectedItem.Value);
            album.Ishot = Convert.ToBoolean(rdbIshot.SelectedValue);
            album.Ishome = Convert.ToBoolean(rdbIshome.SelectedValue);

            album.Isview = (hddIsView.Value != "") ? Convert.ToInt32(hddIsView.Value) : 0;
            album.CommentTotal = (hddCommentTotal.Value != "") ? Convert.ToInt32(hddCommentTotal.Value) : 0;

            album.CreatedUserName = (hddCreateUserName.Value != "") ? hddCreateUserName.Value : Session["Admin_UserName"].ToString();
            album.ApprovalUserName = (hddApprovalUserName.Value != "") ? hddApprovalUserName.Value : Session["Admin_UserName"].ToString();

            album.IsComment = true;
            album.IsApproval = true;
            album.ApprovalDate = (hddApprovalDate.Value != "") ? Convert.ToDateTime(hddApprovalDate.Value) : DateTime.Now;



            return album;
        }
        #endregion

        protected void grvAlbum_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAlbum.PageIndex = e.NewPageIndex;

            ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
        }
        protected void grvAlbum_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int Id = Convert.ToInt32(e.CommandArgument.ToString());
            string nName = e.CommandName.ToLower();
            switch (nName)
            {
                case "_edit":
                    Response.Redirect("~/Admin/editalbums/" + Id + "/Default.aspx");
                    break;

                case "_delete":
                    AlbumsBSO albumBSO = new AlbumsBSO();
                    albumBSO.DeleteAlbums(Id);

                    ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
                    break;
            }
        }
        protected void grvAlbum_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton image_del = (ImageButton)e.Row.FindControl("btn_delete");
                image_del.Attributes.Add("onclick", "javascript:return confirm('Bạn có muốn chắc chắn xóa ???');");
            }
        }
        protected void btn_add_Click(object sender, EventArgs e)
        {

            try
            {
                if (String.IsNullOrEmpty(file_image_thumb.FileName))
                {
                    BindAlbumsCate(Convert.ToInt32(hddAlbumsCateID.Value));
                    ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
                    clientview.Text = "Chưa có hình ảnh";

                }
                else
                {
                    Albums album = new Albums();
                    album = ReceiveHtml();


                    AlbumsBSO albumBSO = new AlbumsBSO();
                    albumBSO.CreateAlbums(album);

                    BindAlbumsCate(Convert.ToInt32(hddAlbumsCateID.Value));
                    ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
                    clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);


                }


            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }

        }
        protected void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                Albums album = new Albums();
                album = ReceiveHtml();


                AlbumsBSO albumBSO = new AlbumsBSO();
                albumBSO.UpdateAlbums(album);

                BindAlbumsCate(Convert.ToInt32(hddAlbumsCateID.Value));
                ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
                clientview.Text = String.Format(Resources.StringAdmin.AddNewsSuccessful);
            }
            catch (Exception ex)
            {
                clientview.Text = ex.Message.ToString();
            }
        }

        protected void ddlAlbumsCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            hddAlbumsCateID.Value = ddlAlbumsCate.SelectedValue;
            ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
        }
        protected void ddlAlbumsCate_TextChanged(object sender, EventArgs e)
        {
            hddAlbumsCateID.Value = ddlAlbumsCate.SelectedValue;
            ViewAlbum(Convert.ToInt32(hddAlbumsCateID.Value));
        }

        protected void btn_edit_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Group/editalbums/" + hddAlbumsCateID.Value + "/Default.aspx");

        }

    }
}