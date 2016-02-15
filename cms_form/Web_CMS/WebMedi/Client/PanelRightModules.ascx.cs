using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;

namespace WebMedi.Client
{
    public partial class PanelRightModules : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetModulePanel("Right", Language.lang);
        }

        void GetModulePanel(string Panel, string Lang)
        {
            ModulesFrontPanelBSO _module = new ModulesFrontPanelBSO();
            DataTable tb = _module.GetModulesFrontPanelbyPanel(Panel, Lang);
            string _path = ResolveUrl("~/") + "Client/Modules/Panel/";
            Control objControl = new Control();


            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    try
                    {
                        objControl = (Control)this.LoadControl(_path + tb.Rows[i]["ModulesFrontPanel_Url"].ToString());
                        AreaRightPanel.Controls.Add(objControl);
                        ControlParameter(objControl, tb.Rows[i]["ModulesFrontPanel_Title"].ToString(), tb.Rows[i]["ModulesFrontPanel_Icon"].ToString(), tb.Rows[i]["ModulesFrontPanel_Value"].ToString(), Convert.ToInt32(tb.Rows[i]["ModulesFrontPanel_Record"].ToString()), tb.Rows[i]["ModulesFontPanel_Content"].ToString());
                    }
                    catch 
                    {
                        
                    }
                }
            }
        }

        public void ControlParameter(Control _control, string title, string icon, string value, int record, string content)
        {
            Control _controlsTitle = _control.FindControl("Literal1");
            if (_controlsTitle != null)
            {
                Type objTypeTitle = _controlsTitle.GetType();
                if (objTypeTitle.Name == "Literal")
                {
                    Literal objlbl = (Literal)_controlsTitle;
                    objlbl.Text = title;
                }
            }

            Control _controlsIcon = _control.FindControl("imgIcon");
            if (_controlsIcon != null)
            {
                Type objTypeIcon = _controlsIcon.GetType();
                if (objTypeIcon.Name == "Image")
                {
                    Image objimg = (Image)_controlsIcon;
                    objimg.ImageUrl = "~/Upload/Admin_Theme/Icons/" + icon;
                }
            }

            Control _controlsValue = _control.FindControl("hddValue");
            if (_controlsValue != null)
            {
                Type objTypeValue = _controlsValue.GetType();
                if (objTypeValue.Name == "HiddenField")
                {
                    HiddenField objvalue = (HiddenField)_controlsValue;
                    objvalue.Value = value;
                }
            }

            Control _controlsRecord = _control.FindControl("hddRecord");
            if (_controlsRecord != null)
            {
                Type objTypeRecord = _controlsRecord.GetType();
                if (objTypeRecord.Name == "HiddenField")
                {
                    HiddenField objRecord = (HiddenField)_controlsRecord;
                    objRecord.Value = record.ToString();
                }
            }

            Control _controlsContent = _control.FindControl("hddContent");
            if (_controlsContent != null)
            {
                Type objTypeContent = _controlsContent.GetType();
                if (objTypeContent.Name == "HiddenField")
                {
                    HiddenField objContent = (HiddenField)_controlsContent;
                    objContent.Value = content.ToString();
                }
            }
        }
    }
}