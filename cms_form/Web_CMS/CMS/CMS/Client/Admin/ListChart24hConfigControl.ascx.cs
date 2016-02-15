using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using ETO;
using BSO;
using System.IO;

namespace CMS.Client.Admin
{
    public partial class ListChart24hConfigControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Init();
            }
        }

        private void Init()
        {
            txtTitleChart.Text = ReadFile();
        }

        private string ReadFile()
        {

            StreamReader sReader = new StreamReader(Server.MapPath("~/Upload/Files/ChartConfig.txt"), System.Text.Encoding.UTF8);
            string _title = sReader.ReadToEnd();
            sReader.Close();

            return _title;
        }

        private void WriteFile(string _title)
        {
            StreamWriter sWriter = new StreamWriter(Server.MapPath("~/Upload/Files/ChartConfig.txt"), false, System.Text.Encoding.UTF8);
            sWriter.WriteLine(_title);
            sWriter.Flush();
            sWriter.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            WriteFile(txtTitleChart.Text.ToString());
            Response.Write("<script language='javascript'> {window.close(); window.opener.SubmitForm(); }</script>");

        }
   
    }
}