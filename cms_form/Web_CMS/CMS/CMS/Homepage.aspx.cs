using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ETO;
using BSO;

namespace CMS
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Lang"] == null)
                Session["Lang"] = "vi-VN";
            Language.lang = Session["Lang"].ToString();
            var configBso = new ConfigBSO();
            var config = configBso.GetAllConfig(Language.lang);
            Page.Title = config.Titleweb;

            var userName = "";
            var cookie = Request.Cookies["UserInfor_ES"];
            if (cookie != null && cookie["UserName"] != null && cookie["UserName"].Trim() != string.Empty)
            {
                userName = cookie["UserName"];
            }
            Session["Admin_Username"] = userName;

            if (Session["Admin_Username"] == null)
            {
                if (Page.RouteData.Values["dll"] != null)
                {
                    if (RouteData.Values["dll"].Equals("login"))
                        PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
                    else
                        Response.Redirect("~/Admin/login");
                }
                else
                    Response.Redirect("~/Admin/login");
            }
            else
                if (Page.RouteData.Values["dll"] != null)
                {
                    if (CheckExit(RouteData.Values["dll"].ToString()))
                    {
                        var levelAdmin = CheckLevelAdmin(RouteData.Values["dll"].ToString(), Session["Admin_UserName"].ToString());
                        if (levelAdmin == true)
                        {
                            PlaceHolder1.Controls.Add(LoadControl("Client/Admin/" + RouteData.Values["dll"].ToString() + ".ascx"));
                        }
                        else
                            if (RouteData.Values["dll"].Equals("login"))
                                PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
                            else
                            {
                                Response.Redirect("~/Admin/login");
                            }
                    }
                    else
                    {
                        if (RouteData.Values["dll"].Equals("login"))
                            PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
                        else
                        {
                            Response.Redirect("~/Admin/home/Default.aspx");
                        }
                    }

                }
                else
                {
                    //Response.Redirect("~/Admin/login");
                    PlaceHolder1.Controls.Add(LoadControl("Client/Admin/Login.ascx"));
                }

        }

        private string GetIpAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        private bool CheckLevelAdmin(string url, string sStrAdmin)
        {
            var levelAdmin = false;
            var modulesBso = new ModulesBSO();
            levelAdmin = modulesBso.CheckLevelModulesRoles(url, sStrAdmin);

            return levelAdmin;
        }

        private bool CheckExit(string url)
        {
            var exit = false;
            var modulesBso = new ModulesBSO();
            exit = modulesBso.CheckExist(url);

            return exit;
        }
    }
}