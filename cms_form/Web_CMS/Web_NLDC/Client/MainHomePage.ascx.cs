using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BSO;
using ETO;

namespace Web_NLDC.Client
{
    public partial class MainHomePage : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetModulePanel("Main", Language.lang);
        }

        void GetModulePanel(string panel, string lang)
        {
            var module = new ModulesFrontPanelBSO();
            var tb = module.GetModulesFrontPanelbyPanel(panel, lang);
            var path = ResolveUrl("~/") + "Client/Modules/MainHome/";


            if (tb.Rows.Count <= 0) return;
            for (var i = 0; i < tb.Rows.Count; i++)
            {
                try
                {
                    var objControl = (Control)this.LoadControl(path + tb.Rows[i]["ModulesFrontPanel_Url"].ToString());
                    AreaMainPanel.Controls.Add(objControl);
                    ControlParameter(objControl, tb.Rows[i]["ModulesFrontPanel_Title"].ToString(), tb.Rows[i]["ModulesFrontPanel_Icon"].ToString(), tb.Rows[i]["ModulesFrontPanel_Value"].ToString(), Convert.ToInt32(tb.Rows[i]["ModulesFrontPanel_Record"].ToString()), tb.Rows[i]["ModulesFrontPanel_ID"].ToString());
                }
                catch
                {

                }
            }
        }

        public void ControlParameter(Control control, string title, string icon, string value, int record, string panelId)
        {
            var controlsTitle = control.FindControl("hddTitle");
            if (controlsTitle != null)
            {
                var objTypeTitle = controlsTitle.GetType();
                if (objTypeTitle.Name == "HiddenField")
                {
                    var objlbl = (HiddenField)controlsTitle;
                    objlbl.Value = title;
                }
            }

            var controlsIcon = control.FindControl("imgIcon");
            if (controlsIcon != null)
            {
                var objTypeIcon = controlsIcon.GetType();
                if (objTypeIcon.Name == "Image")
                {
                    var objimg = (Image)controlsIcon;
                    objimg.ImageUrl = "~/Upload/Admin_Theme/Icons/" + icon;
                }
            }


            var controlsValue = control.FindControl("hddValue");
            if (controlsValue != null)
            {
                var objTypeValue = controlsValue.GetType();
                if (objTypeValue.Name == "HiddenField")
                {
                    var objvalue = (HiddenField)controlsValue;
                    objvalue.Value = value;
                }
            }

            var controlsRecord = control.FindControl("hddRecord");
            if (controlsRecord != null)
            {
                var objTypeRecord = controlsRecord.GetType();
                if (objTypeRecord.Name == "HiddenField")
                {
                    var objRecord = (HiddenField)controlsRecord;
                    objRecord.Value = record.ToString();
                }
            }

            var controlsId = control.FindControl("hdfPanelId");
            if (controlsId != null)
            {
                var objTypePnId = controlsId.GetType();
                if (objTypePnId.Name == "HiddenField")
                {
                    var objPnId = (HiddenField)controlsId;
                    objPnId.Value = panelId;
                }
            }
        }
    }
}