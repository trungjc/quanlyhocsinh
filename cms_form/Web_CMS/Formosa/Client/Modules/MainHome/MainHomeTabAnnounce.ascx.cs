using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Web.UI.HtmlControls;
using System.Data;
using Telerik.WebControls;
using ETO;

namespace Fomusa.Client.Modules.MainHome
{
    public partial class MainHomeTabAnnounce : System.Web.UI.UserControl
    {
        protected string MyTab;
        protected void Page_Load(object sender, EventArgs e)
        {
            int group = 6;
            if (!Page.IsPostBack)
                BindTabStrip(group);

            MyTab = RadTabStrip1.InnerMostSelectedTab.Text;
        }
        private void BindTabStrip(int group)
        {
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateParentGroupAll(0, Language.language, group);
            DataView dataView = new DataView(table);

            dataView.Sort = "CateNewsOrder ASC";
            int j = 0;
            foreach (DataRowView Row in dataView)
            {
                if (j < 3)
                {
                    Tab rootTab = CreateRootTab(Row["CateNewsName"].ToString());
                    PageView pv = BuildPageViewContents(Convert.ToInt32(Row["CateNewsID"].ToString()), group);
                    RadMultiPage1.PageViews.Add(pv);
                }
                j++;
            }
        }
        //Tab
        private Tab CreateRootTab(string index)
        {
            Tab tab = new Tab();
            tab.Text = index;
            RadTabStrip1.Tabs.Add(tab);
            return tab;
        }


        private PageView BuildPageViewContents(int cId, int group)
        {
            PageView pageView = new PageView();

            string strCate = CateParentIDArray(cId);

            NewsGroupBSO newsGroupBSO = new NewsGroupBSO();
            DataTable table = newsGroupBSO.GetNewsGroupByCateAll(strCate, group);

            DataTable table1 = table.Clone();

            DataTable table2 = table.Clone();

            if (table.Rows.Count > 0)
            {

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (i == 0)
                        table1.ImportRow(table.Rows[i]);
                    else if (i > 0 && i < 10)
                        table2.ImportRow(table.Rows[i]);
                    else
                        break;
                }
                DataRow dataRow = table1.Rows[0];
                //HtmlTable
                HtmlTable htmlTable = new HtmlTable();
                htmlTable.Style.Value = "tab_Border_doc";
                htmlTable.CellPadding = 5;


                //Khoi tao 1 hang
                HtmlTableRow htmlRow = new HtmlTableRow();
                //Them dieu khien vao Cot thu 1
                HtmlTableCell htmlCell = new HtmlTableCell();
                htmlCell.VAlign = "top";
                htmlCell.Width = "100%";
                htmlCell.Align = "justify";
                Literal lit_img = new Literal();
                if (dataRow["ImageThumb"].ToString() != "")
                    lit_img.Text = @"<a href='" + ResolveUrl("~/") + "News/" + Convert.ToString(group) + "/" + dataRow["NewsGroupID"].ToString() + "/Default.aspx'><img src='" + ResolveUrl("~/") + "Admin/Upload/NewsGroup/NewsGroupThumb/" + dataRow["ImageThumb"].ToString() + "' vspace='1'  align='left' border='1' style='border-color:#cdcdcd; margin-right:5px ' width='100'></a>";
                else
                    lit_img.Text = "";
                HyperLink hyp = new HyperLink();
                hyp.Text = dataRow["Title"].ToString();
                hyp.NavigateUrl = "~/News/" + Convert.ToString(group) + "/" + dataRow["NewsGroupID"].ToString() + "/Default.aspx";
                hyp.CssClass = "tab_title_news";
                //Literal liter_br = new Literal();
                //liter_br.Text = @"<br/>";
                Label liter = new Label();
                liter.Text = "<div style='text-align:justify;padding-top:5px;margin-bottom:0px;'>" + dataRow["ShortDescribe"].ToString() + "</div>";
                liter.CssClass = "tab_desc_news";
                htmlCell.Controls.Add(lit_img);
                htmlCell.Controls.Add(hyp);
                //     htmlCell.Controls.Add(liter_br);
                htmlCell.Controls.Add(liter);

                //Them cot1 vao hang
                htmlRow.Cells.Add(htmlCell);
                //Thêm dòng 1 vào bảng
                htmlTable.Rows.Add(htmlRow);

                //Them hàng 2
                htmlRow = new HtmlTableRow();
                //Them dieu khien vao cot 2
                htmlCell = new HtmlTableCell();
                htmlCell.VAlign = "top";
                BulletedList bullet = new BulletedList();
                bullet.CssClass = "tab_bullet_link";
                bullet.DisplayMode = BulletedListDisplayMode.HyperLink;
                bullet.BulletStyle = BulletStyle.NotSet;
                bullet.DataSource = table2;
                bullet.DataTextField = "Title";
                bullet.DataValueField = "NewsGroupID";
                bullet.DataBind();
                foreach (ListItem items in bullet.Items)
                {
                    items.Value = "~/News/" + Convert.ToString(group) + "/" + items.Value + "/Default.aspx";
                }
                htmlCell.Controls.Add(bullet);
                //Them cot 2 vao hang
                htmlRow.Cells.Add(htmlCell);
                //Them hang vao bang 
                htmlTable.Rows.Add(htmlRow);
                //Them bang vao pageview
                pageView.Controls.Add(htmlTable);
            }
            return pageView;
        }

        private string CateParentIDArray(int Id)
        {
            string strArrayID = Convert.ToString(Id) + ",";
            CateNewsBSO catenewsBSO = new CateNewsBSO();
            DataTable table = catenewsBSO.GetCateNewsParentAll(Id, Language.language);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                strArrayID += table.Rows[i]["CateNewsID"].ToString() + ",";
            }

            return strArrayID;
        }
    }
}