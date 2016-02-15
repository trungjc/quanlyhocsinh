using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using System.Data;
using ETO;

namespace Web_NLDC.Client
{
    public partial class PanelRightModules : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetModulePanel("Right", Language.lang);
        }

        void GetModulePanel(string panel, string lang)
        {
            var module = new ModulesFrontPanelBSO();
            var tb = module.GetModulesFrontPanelbyPanel(panel, lang);
            var path = ResolveUrl("~/") + "Client/Modules/Panel/";
            var objControl = new Control();


            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    try
                    {
                        objControl = (Control)this.LoadControl(path + tb.Rows[i]["ModulesFrontPanel_Url"].ToString());
                        AreaRightPanel.Controls.Add(objControl);
                        ControlParameter(objControl, tb.Rows[i]["ModulesFrontPanel_Title"].ToString(), tb.Rows[i]["ModulesFrontPanel_Icon"].ToString(), tb.Rows[i]["ModulesFrontPanel_Value"].ToString(), Convert.ToInt32(tb.Rows[i]["ModulesFrontPanel_Record"].ToString()), tb.Rows[i]["ModulesFontPanel_Content"].ToString());
                    }
                    catch
                    {

                    }
                }
            }
        }

        public void ControlParameter(Control control, string title, string icon, string value, int record, string content)
        {
            var controlsTitle = control.FindControl("Literal1");
            if (controlsTitle != null)
            {
                var objTypeTitle = controlsTitle.GetType();
                if (objTypeTitle.Name == "Literal")
                {
                    var objlbl = (Literal)controlsTitle;
                    objlbl.Text = title;
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

            var controlsContent = control.FindControl("hddContent");
            if (controlsContent != null)
            {
                var objTypeContent = controlsContent.GetType();
                if (objTypeContent.Name == "HiddenField")
                {
                    var objContent = (HiddenField)controlsContent;
                    objContent.Value = content.ToString();
                }
            }
        }
    }
}