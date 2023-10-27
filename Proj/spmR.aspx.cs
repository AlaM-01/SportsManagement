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
    public partial class spmr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string name = spmrname.Text;
            string username = spmruser.Text;
            string password = spmrpass.Text;

            SqlCommand regchh = new SqlCommand("userinuse", conn);
            regchh.CommandType = CommandType.StoredProcedure;
            regchh.Parameters.Add(new SqlParameter("@username", username));
            SqlParameter checkk = regchh.Parameters.Add("@check", SqlDbType.Int);

            checkk.Direction = ParameterDirection.Output;

            conn.Open();
            regchh.ExecuteNonQuery();
            conn.Close();

            if (checkk.Value.ToString() == "1")
            {
                Response.Write("user in use");
            }
            else
            {

                SqlCommand regf = new SqlCommand("addAssociationManager", conn);
                regf.CommandType = CommandType.StoredProcedure;
                regf.Parameters.Add(new SqlParameter("@name", name));
                regf.Parameters.Add(new SqlParameter("@username", username));
                regf.Parameters.Add(new SqlParameter("@password", password));

                SqlCommand regch = new SqlCommand("spmr", conn);
                regch.CommandType = CommandType.StoredProcedure;
                regch.Parameters.Add(new SqlParameter("@username", username));
                SqlParameter check = regch.Parameters.Add("@check", SqlDbType.Int);

                check.Direction = ParameterDirection.Output;

                conn.Open();
                regf.ExecuteNonQuery();
                conn.Close();

                conn.Open();

                regch.ExecuteNonQuery();
                conn.Close();

                if (check.Value.ToString() == "1")
                {
                    Response.Redirect("spmL.aspx");
                }
                else
                {
                    Response.Write(" error");
                }
            }

        }
    }
}