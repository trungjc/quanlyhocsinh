using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;
using ETO;
using CMS;

namespace Fomusa.Client.Modules.Search
{
    public partial class SearchResult : System.Web.UI.UserControl
    {
        private string keyword
        {
            get
            {
                if (Page.RouteData.Values["id"] != null) // thay biến keyword bằng biến id vì trong router data đã có giá trị này rồi
                    return Page.RouteData.Values["id"].ToString();
                else
                    return "";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewNewsResult(keyword);

                title_cate.Text = "<a href='" + ResolveUrl("~/") + "Default.aspx' class='content_Text_Cat'>" + Resources.resource.Home + "</a> &nbsp;<img src='" + ResolveUrl("~/") + "images/icon_arrows1.png'>&nbsp;";

                title_name.Text = "Kết quả tìm kiếm";
            }
        }
        //private void ViewNewsResult(string keyword)
        //{
        //    NewsGroupBSO newsBSO = new NewsGroupBSO();
        //    DataTable table = newsBSO.GetNewsGroupAll(Language.language);
        //    DataView dataView = new DataView(table);
        //    string sqlSearch = "";

        //    sqlSearch = "(Title like '%" + keyword + "%' or ShortDescribe like '%" + keyword + "%') And Status =1 And IsApproval=1";

        //    dataView.RowFilter = sqlSearch;

        //    DataListCateNews.DataSource = dataView;
        //    DataListCateNews.DataBind();

        //}

        private void ViewNewsResult(string keyword)
        {
            NewsGroupBSO newsBSO = new NewsGroupBSO();
            DataTable table = newsBSO.GetNewsGroupAll(Language.language);
            DataView dataView = new DataView(table);

            if (keyword.Trim() != "")
            {

                keyword = keyword.Replace("'", "");
                string[] _keyws = keyword.Split('_');
                if (_keyws != null)
                {
                    if (_keyws.Length > 0)
                    {
                        string _finter = "";
                        foreach (string _key in _keyws)
                        {
                            _finter += " AND (Title like N'%" + _key + "%'";
                            _finter += " or ShortDescribe like N'%" + _key + "%'" + ")";
                        }
                        _finter += " And Status =1 And IsApproval=1 " + " AND Language = '" + Language.language + "'";

                        DataTable _tb = newsBSO.NewsGroupSearch(_finter);
                        if (_tb != null)
                        {
                            if (_tb.Rows.Count > 0)
                            {
                                foreach (string _key1 in _keyws)
                                {

                                    foreach (DataRow _dr in _tb.Rows)
                                    {
                                        if (_dr["Title"].ToString().Contains(_key1))
                                        {
                                            _dr["Title"] = _dr["Title"].ToString().Replace(_key1, "<font color ='Red'>" + _key1 + "</font>");

                                        }
                                        if (_dr["ShortDescribe"] != null && _dr["ShortDescribe"] != DBNull.Value)
                                        {
                                            if (_dr["ShortDescribe"].ToString().Contains(_key1))
                                            {
                                                _dr["ShortDescribe"] = HtmlRemoval.StripTagsCharArray(HttpUtility.HtmlDecode(_dr["ShortDescribe"].ToString()));
                                                _dr["ShortDescribe"] = _dr["ShortDescribe"].ToString().Replace(_key1, "<font color ='Red'>" + _key1 + "</font>");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        DataListCateNews.DataSource = _tb;
                        DataListCateNews.DataBind();
                    }
                }
            }


        }

        protected string GetString(object _txt)
        {
            if (_txt != null)
            {
                Utils objUtil = new Utils();
                return objUtil.Getstring(_txt.ToString());
            }
            return "";
        }
    }
}