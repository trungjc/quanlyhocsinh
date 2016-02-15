using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BSO;

namespace WebMedi.Client.Modules.Panel
{
    public partial class BlockCounter : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewHitCounter();
        }

        private void ViewHitCounter()
        {
            HitCounterBSO hitcounterBSO = new HitCounterBSO();
            long hitcounter = hitcounterBSO.GetHitCounter();            
            LiteralHitCounter.Text = Convert.ToString(hitcounter);

            LiteralOnline.Text = Application.Get("CurrentUsers").ToString();
        }
    }
}