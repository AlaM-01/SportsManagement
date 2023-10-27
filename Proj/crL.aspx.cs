using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DBM
{
    public partial class crL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string username = userf.Text;
            string password = passf.Text;

            SqlCommand regch = new SqlCommand("crl", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@username", username));
            regch.Parameters.Add(new SqlParameter("@password", password));
            SqlParameter check = regch.Parameters.Add("@check", SqlDbType.Int);

            check.Direction = ParameterDirection.Output;

            conn.Open();

            regch.ExecuteNonQuery();
            conn.Close();

            if (check.Value.ToString() == "1")
            {
                Session["cruser"] = username;
               // Session["crclub"] = clubname;
                Response.Redirect("crview.aspx");
            }
            else
            {
                Response.Write("either you are not a club representative or you entered invalid data");
            }
        }
    }
}