using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBM
{
    public partial class allL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void spm(object sender, EventArgs e)
        {
            Response.Redirect("spmL.aspx");
        }

        protected void fan(object sender, EventArgs e)
        {
            Response.Redirect("fanL.aspx");
        }

        protected void sm(object sender, EventArgs e)
        {
            Response.Redirect("smL.aspx");
        }

        protected void cr(object sender, EventArgs e)
        {
            Response.Redirect("crL.aspx");
        }

        protected void systemadmin(object sender, EventArgs e)
        {
            Response.Redirect("saL.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("all.aspx");
        }
    }
}