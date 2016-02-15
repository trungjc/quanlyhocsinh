using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;
using ETO;
using System.Data;

namespace Fomusa.Client
{
    public partial class MainHomePage : System.Web.UI.UserControl
    {
        protected int isPopup = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            Viewpopup();

            GetModulePanel("Main", Language.lang);
        }
        private void Viewpopup()
        {
            ConfigBSO configBSO = new ConfigBSO();
            Config config = configBSO.GetAllConfig(Language.language);
            isPopup = Convert.ToInt32(config.IsPopup);
        }

        void GetModulePanel(string Panel, string lang)
        {
            ModulesFrontPanelBSO _module = new ModulesFrontPanelBSO();
            DataTable tb = _module.GetModulesFrontPanelbyPanel(Panel, lang);
            string _path = ResolveUrl("~/") + "Client/Modules/MainHome/";
            Control objControl = new Control();


            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    //if (tb.Rows[i]["ModulesFrontPanel_Panel"].Equals("Left") || tb.Rows[i]["ModulesFrontPanel_Panel"].Equals("Right"))
                    //    _path += "Client/Modules/Panel/";
                    //else
                    //    if (tb.Rows[i]["ModulesFrontPanel_Panel"].Equals("Main"))
                    //        _path += "Client/Modules/MainHome/";

                    objControl = (Control)this.LoadControl(_path + tb.Rows[i]["ModulesFrontPanel_Url"].ToString());

                    AreaMainPanel.Controls.Add(objControl);
                    ControlParameter(objControl, tb.Rows[i]["ModulesFrontPanel_Title"].ToString(), tb.Rows[i]["ModulesFrontPanel_Icon"].ToString(), tb.Rows[i]["ModulesFrontPanel_Value"].ToString(), Convert.ToInt32(tb.Rows[i]["ModulesFrontPanel_Record"].ToString()));

                }
            }

        }

        public void ControlParameter(Control _control, string title, string icon, string value, int record)
        {
            //Control _controlsTitle = _control.FindControl("lblTitle");
            //if (_controlsTitle != null)
            //{
            //    Type objTypeTitle = _controlsTitle.GetType();
            //    if (objTypeTitle.Name == "Label")
            //    {
            //        Label objlbl = (Label)_controlsTitle;
            //        objlbl.Text = title;
            //    }
            //}

            Control _controlsTitle = _control.FindControl("hddTitle");
            if (_controlsTitle != null)
            {
                Type objTypeTitle = _controlsTitle.GetType();
                if (objTypeTitle.Name == "HiddenField")
                {
                    HiddenField objlbl = (HiddenField)_controlsTitle;
                    objlbl.Value = title;
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
        }
    }
}