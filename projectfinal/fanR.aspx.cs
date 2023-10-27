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
    public partial class fanr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void register(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string name = fname.Text;
            string username = fusername.Text;
            string password = fpass.Text;
            string nid = nidd.Text;
            int phn = Int16.Parse(phnn.Text);
            string address = addresss.Text;
            string birthdate = birthdatee.Text;
            // Response.Write(name);

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
                Response.Write(" user in use");
            }
            else
            {
                SqlCommand regf = new SqlCommand("addFan", conn);
                regf.CommandType = CommandType.StoredProcedure;
                regf.Parameters.Add(new SqlParameter("@name", name));
                regf.Parameters.Add(new SqlParameter("@username", username));
                regf.Parameters.Add(new SqlParameter("@password", password));
                regf.Parameters.Add(new SqlParameter("@nid", nid));
                regf.Parameters.Add(new SqlParameter("@phone_No", phn));
                regf.Parameters.Add(new SqlParameter("@address", address));
                regf.Parameters.Add(new SqlParameter("@birthdate", birthdate));

                SqlCommand regch = new SqlCommand("fanr", conn);
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
                //Response.Write(check.Value.ToString());
               
                    
                    Response.Redirect("fanL.aspx");
                

      

            }


        }
    }
}