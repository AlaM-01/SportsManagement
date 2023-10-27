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
    public partial class fanview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        protected void Getmatch(object sender, EventArgs e)
        {
            //Response.Write("enter the id of the match you want to purchase the ticket for");
            
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand matches = new SqlCommand("select * from getmatchid('@date')", conn);

            DateTime date = DateTime.Parse(getmatch.Text);
            matches.Parameters.Add(new SqlParameter("@date", date));
            matches.CommandType = System.Data.CommandType.Text;
            Session["datefan"] = date;
            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int id= rdr.GetInt32(rdr.GetOrdinal(("matchID")));
                String hname = rdr.GetString(rdr.GetOrdinal("hostClubName"));
                String gname = rdr.GetString(rdr.GetOrdinal("guestClubName"));
                DateTime datee = rdr.GetDateTime(rdr.GetOrdinal("starttime"));
                String hs = rdr.GetString(rdr.GetOrdinal("hostingStadium"));
                String loc = rdr.GetString(rdr.GetOrdinal("location"));
                Label name = new Label();
                name.Text = "<br>" + "matchID: " + id +
                             "<br>" + "host: " + hname +
                             "<br>" + "guest: " + gname
                             + "<br>" + "startTime" + date
                             + "<br>" + "stadium" + hs +
                             "<br>" + "location: "+loc
                             + "<br>";
               // Button pt = new Button();
               // pt.Text = "purchase ticket";

               // pt.Attributes.Add("OnClick", "pt_Click");

                form1.Controls.Add(name);
                //form1.Controls.Add(pt);
   

            }
    
        }

        protected void pt_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

           /* SqlCommand midd = new SqlCommand("mid", conn);
            midd.CommandType = CommandType.StoredProcedure;

            int matchid= Int16.Parse(pti.Text);
            DateTime datee = DateTime.Parse(dateee.Text);
            midd.Parameters.Add(new SqlParameter("@matchid", matchid));
            midd.Parameters.Add(new SqlParameter("@mdate", datee));

            SqlParameter hname = midd.Parameters.Add("@hosttclubname", System.Data.SqlDbType.NVarChar);
            SqlParameter gname = midd.Parameters.Add("@guestclubname", System.Data.SqlDbType.NVarChar);
            SqlParameter sdate = midd.Parameters.Add("@starttime", System.Data.SqlDbType.DateTime);


            hname.Direction = ParameterDirection.Output;
            gname.Direction = ParameterDirection.Output;
            sdate.Direction = ParameterDirection.Output;

            conn.Open();
            midd.ExecuteNonQuery();
            conn.Close();


            SqlCommand regf = new SqlCommand("forpurchaseTicket", conn);
            regf.CommandType = CommandType.StoredProcedure;
            regf.Parameters.Add(new SqlParameter("@NID", Session["fannid"]));
            regf.Parameters.Add(new SqlParameter("@hostingClubName", hname.Value.ToString()));
            regf.Parameters.Add(new SqlParameter("@GuestName", gname.Value.ToString()));
            regf.Parameters.Add(new SqlParameter("@startTime", sdate.Value.GetType()));

            SqlParameter tid = midd.Parameters.Add("@tid", System.Data.SqlDbType.Int);

            tid.Direction = ParameterDirection.Output;

            SqlCommand regch = new SqlCommand("checkpt", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@tid", tid));

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
                Response.Write("a7a ba2a");
            }*/

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("allL.aspx");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string matchidd = DropDownList1.SelectedItem.Value;
            int matchid = Int16.Parse(matchidd);


            SqlCommand regch = new SqlCommand("getattacc", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@matchid", matchid));
            SqlParameter hostt = regch.Parameters.Add("@hostName", SqlDbType.VarChar, 30);
            SqlParameter guestt = regch.Parameters.Add("@guestName", SqlDbType.VarChar, 30);
            SqlParameter starttimet = regch.Parameters.Add("@startTime", SqlDbType.DateTime);

            hostt.Direction = ParameterDirection.Output;
            guestt.Direction = ParameterDirection.Output;
            starttimet.Direction = ParameterDirection.Output;

            conn.Open();
            regch.ExecuteNonQuery();
            conn.Close();

            string host = hostt.Value.ToString();
            string guest = guestt.Value.ToString();
            string starttimee = starttimet.Value.ToString();
            DateTime starttime = DateTime.Parse(starttimee);


            SqlCommand regchh = new SqlCommand("purchaseTicket", conn);
            regchh.CommandType = CommandType.StoredProcedure;
            regchh.Parameters.Add(new SqlParameter("@NID", Session["fannid"]));
            regchh.Parameters.Add(new SqlParameter("@hostingClubName", host));
            regchh.Parameters.Add(new SqlParameter("@guestName", guest));
            regchh.Parameters.Add(new SqlParameter("@startTime", starttime));
            SqlParameter check = regchh.Parameters.Add("@check", SqlDbType.Int);


            check.Direction = ParameterDirection.Output;



            conn.Open();
            regchh.ExecuteNonQuery();
            conn.Close();

            if(check.Value.ToString()=="1")
            {
                Response.Write("no tickets available");
            }
            else
            {
                Response.Write("ticket purchased successfully");
            }

        }
    }
}