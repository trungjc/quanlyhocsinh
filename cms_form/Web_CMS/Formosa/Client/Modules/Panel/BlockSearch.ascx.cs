using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fomusa.Client.Modules.Panel
{
    public partial class BlockSearch : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            keyword = keyword.Trim();

            keyword = keyword.Replace("'", "");
            keyword = keyword.Replace("=", "");
            keyword = keyword.Replace("-", "");
            keyword = keyword.Replace("+", "");
            keyword = keyword.Replace("*", "");
            keyword = keyword.Replace("/", "");
            keyword = keyword.Replace("\\", "");
            keyword = keyword.Replace("?", "");
            keyword = keyword.Replace("$", "");
            keyword = keyword.Replace("%", "");
            keyword = keyword.Replace("`", "");
            keyword = keyword.Replace("@", "");
            keyword = keyword.Replace("~", "");
            keyword = keyword.Replace("!", "");
            keyword = keyword.Replace("#", "");
            keyword = keyword.Replace("^", "");
            keyword = keyword.Replace("|", "");
            keyword = keyword.Replace(";", "");
            keyword = keyword.Replace(":", "");
            keyword = keyword.Replace("(", "");
            keyword = keyword.Replace(")", "");
            keyword = keyword.Replace("{", "");
            keyword = keyword.Replace("}", "");
            keyword = keyword.Replace("[", "");
            keyword = keyword.Replace("]", "");
            keyword = keyword.Replace(",", "");
            keyword = keyword.Replace(".", "");
            keyword = keyword.Replace("\"", "");
            keyword = keyword.Replace("&", "");
            keyword = keyword.Replace(">", "");
            keyword = keyword.Replace("<", "");

            keyword = RemoveExtraSpaces(keyword);

            keyword = keyword.Replace(" ", "_");

            if (keyword != "")
            {
                //     string text = txtSearch.Text.Replace(" ", "-");
                //Response.Redirect("~/Default.aspx?go=search&keyword=" + txtSearch.Text);
                Response.Redirect("~/Search/" + keyword + "/Default.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        private string RemoveExtraSpaces(string s)
        {
            if (!s.Contains("  ")) return s;

            return RemoveExtraSpaces(s.Replace("  ", " "));
        }
    }
}