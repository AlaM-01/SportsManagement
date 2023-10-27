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
    public partial class smR : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void reg(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string name = smrname.Text;
            string username = smruser.Text;
            string password = smrpass.Text;
            string stadiumname = stadiumn.Text;

            SqlCommand regchhh = new SqlCommand("userinuse", conn);
            regchhh.CommandType = CommandType.StoredProcedure;
            regchhh.Parameters.Add(new SqlParameter("@username", username));
            SqlParameter checkkk = regchhh.Parameters.Add("@check", SqlDbType.Int);

            checkkk.Direction = ParameterDirection.Output;

            conn.Open();
            regchhh.ExecuteNonQuery();
            conn.Close();
            if (checkkk.Value.ToString() == "1")
            {
                Response.Write("user in use");
            }
            else
            {
                SqlCommand regchh = new SqlCommand("checkstadiumsm", conn);
                regchh.CommandType = CommandType.StoredProcedure;
                regchh.Parameters.Add(new SqlParameter("@name", stadiumname));
                SqlParameter checkk = regchh.Parameters.Add("@check", SqlDbType.Int);

                checkk.Direction = ParameterDirection.Output;
                conn.Open();
                regchh.ExecuteNonQuery();
                conn.Close();

                if (checkk.Value.ToString() == "1")
                {

                    SqlCommand regf = new SqlCommand("addStadiumManager", conn);
                    regf.CommandType = CommandType.StoredProcedure;
                    regf.Parameters.Add(new SqlParameter("@name", name));
                    regf.Parameters.Add(new SqlParameter("@username", username));
                    regf.Parameters.Add(new SqlParameter("@password", password));
                    regf.Parameters.Add(new SqlParameter("@stadiumname", stadiumname));

                    SqlCommand regch = new SqlCommand("smr", conn);
                    regch.CommandType = CommandType.StoredProcedure;
                    regch.Parameters.Add(new SqlParameter("@username", username));
                    SqlParameter check = regch.Parameters.Add("@check", System.Data.SqlDbType.Bit);

                    check.Direction = ParameterDirection.Output;

                    conn.Open();
                    regf.ExecuteNonQuery();
                    conn.Close();

                    conn.Open();

                    regch.ExecuteNonQuery();
                    conn.Close();

                   // if (check.Value.ToString() == "1")
                   // {
                        Response.Redirect("smL.aspx");
                   /* }
                    else
                    {
                        Response.Write("a7a ba2a");
                    }*/
                }
                else
                {
                    Response.Write(" enter a valid stadium");
                }
            }
        }
    
    }
}