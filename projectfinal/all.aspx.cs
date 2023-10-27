using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBM
{
    public partial class all : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void systemadmin(object sender, EventArgs e)
        {

        }

        protected void fan(object sender, EventArgs e)
        {
            Response.Redirect("fanR.aspx");

        }

        protected void spm(object sender, EventArgs e)
        {
            Response.Redirect("spmR.aspx");

        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //cr
            Response.Redirect("crR.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("smR.aspx");
        }
    }
}