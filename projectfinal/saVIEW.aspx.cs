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
    public partial class saVIEW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addclub(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string name = sacname.Text;
            string location = sacloc.Text;

            SqlCommand regfy = new SqlCommand("checknameexistsc", conn);
            regfy.CommandType = CommandType.StoredProcedure;
            regfy.Parameters.Add(new SqlParameter("@clubname", name));
            SqlParameter ccheck = regfy.Parameters.Add("@check", SqlDbType.Int);

            ccheck.Direction = ParameterDirection.Output;

            conn.Open();
            regfy.ExecuteNonQuery();
            conn.Close();

            if (ccheck.Value.ToString() == "1")
            {
                // Response.Write(name);
                SqlCommand regf = new SqlCommand("addClub", conn);
                regf.CommandType = CommandType.StoredProcedure;
                regf.Parameters.Add(new SqlParameter("@clubname", name));
                regf.Parameters.Add(new SqlParameter("@location", location));


                SqlCommand regch = new SqlCommand("checkaddclub", conn);
                regch.CommandType = CommandType.StoredProcedure;
                regch.Parameters.Add(new SqlParameter("@name", name));
                regch.Parameters.Add(new SqlParameter("@location", location));

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

                    Response.Write("club added sucussfully");
                }

                else
                {
                    Response.Write("you intered invalid data");
                }
            }
            else
                Response.Write("name is taken");
        }

        protected void delclub(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //string name = sacnamee.Text;
            string name = DropDownList1.SelectedValue.ToString();

            // Response.Write(name);
            SqlCommand regf = new SqlCommand("deleteClub", conn);
            regf.CommandType = CommandType.StoredProcedure;
            regf.Parameters.Add(new SqlParameter("@clubname", name));
            


            SqlCommand regch = new SqlCommand("checkdclub", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@name", name));
            

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

                Response.Write("club deleted sucussfully");
            }

            else
            {
                Response.Write("you entered invalid data");
            }
        }

        protected void addstadium(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string name = sasname.Text;
            string location = sasloc.Text;
            int capacity = Int16.Parse(sacap.Text);

            SqlCommand regfy = new SqlCommand("checknameexistss", conn);
            regfy.CommandType = CommandType.StoredProcedure;
            regfy.Parameters.Add(new SqlParameter("@stadiumname", name));
            SqlParameter ccheck = regfy.Parameters.Add("@check", SqlDbType.Int);

            ccheck.Direction = ParameterDirection.Output;

            conn.Open();
            regfy.ExecuteNonQuery();
            conn.Close();

            if (ccheck.Value.ToString() == "1")
            {

                // Response.Write(name);
                SqlCommand regf = new SqlCommand("addStadium", conn);
                regf.CommandType = CommandType.StoredProcedure;
                regf.Parameters.Add(new SqlParameter("@stadiumName", name));
                regf.Parameters.Add(new SqlParameter("@location", location));
                regf.Parameters.Add(new SqlParameter("@capacity", capacity));


                SqlCommand regch = new SqlCommand("checkaddstadium", conn);
                regch.CommandType = CommandType.StoredProcedure;
                regch.Parameters.Add(new SqlParameter("@name", name));
                regch.Parameters.Add(new SqlParameter("@location", location));
                regch.Parameters.Add(new SqlParameter("@capacity", capacity));

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

                    Response.Write("stadium added sucussfully");
                }

                else
                {
                    Response.Write(" you entered invalid data");
                }
            }
            else
                Response.Write("name is taken already");
        }

        protected void blockf(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            int nid = Int16.Parse(nidbf.Text);


            // Response.Write(name);
            SqlCommand regf = new SqlCommand("blockFan", conn);
            regf.CommandType = CommandType.StoredProcedure;
            regf.Parameters.Add(new SqlParameter("@nid", nid));



            SqlCommand regch = new SqlCommand("checkfanb", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@nid", nid));
         

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

                Response.Write("fan blocked sucussfully");
            }

            else
            {
                Response.Write("error");
            }
        }

        protected void delstadd(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //string name = sasnamed.Text;

            string name = DropDownList2.SelectedValue.ToString();

            // Response.Write(name);
            SqlCommand regf = new SqlCommand("deleteStadium", conn);
            regf.CommandType = CommandType.StoredProcedure;
            regf.Parameters.Add(new SqlParameter("@stadiumName", name));



            SqlCommand regch = new SqlCommand("checkdstadium", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@name", name));


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

                Response.Write("stadium deleted sucussfully");
            }

            else
            {
                Response.Write("errora");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("allL.aspx");
        }
    }
}