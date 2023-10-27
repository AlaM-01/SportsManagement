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
    public partial class fanL : System.Web.UI.Page
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

            SqlCommand regch = new SqlCommand("fanl", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@username", username));
            regch.Parameters.Add(new SqlParameter("@password", password));
            SqlParameter check = regch.Parameters.Add("@check", SqlDbType.Int);
            SqlParameter nidd = regch.Parameters.Add("@nid", SqlDbType.VarChar,20);

            check.Direction = ParameterDirection.Output;
            nidd.Direction = ParameterDirection.Output;

            conn.Open();

            regch.ExecuteNonQuery();
            conn.Close();

            string nid = nidd.Value.ToString();
         


            if (check.Value.ToString() == "1")
            {

                Session["fannid"] = nid;
                Response.Redirect("fanview.aspx");
            }
            else
            {
                Response.Write("either you are not a fan or you entered invalid data");
            }

        }
    }
}