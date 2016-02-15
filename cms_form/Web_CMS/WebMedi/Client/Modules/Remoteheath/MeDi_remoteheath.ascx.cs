using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;

namespace WebMedi.Client.Modules.Remoteheath
{
    public partial class MeDi_remoteheath : System.Web.UI.UserControl
    {
        Medi_PhieuXetNghiemBSO md = new Medi_PhieuXetNghiemBSO();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = md.Get_Data_Service();
            if (dt.Rows.Count > 0)
            {
                lblBody.Text = dt.Rows[0]["BODY"].ToString();
                lblHeader.Text = dt.Rows[0]["HEADER"].ToString();
                var ext = dt.Rows[0]["EXTENSION"].ToString();
                img.ImageUrl = "data:image/" + ext + ";base64," + dt.Rows[0]["IMAGE"];
            }
        }
    }
}