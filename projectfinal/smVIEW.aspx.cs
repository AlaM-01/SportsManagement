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
    public partial class smVIEW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand matches = new SqlCommand("select * from sminfo (@username)", conn);

           
            matches.Parameters.Add(new SqlParameter("@username", Session["smuser"]));
            matches.CommandType = System.Data.CommandType.Text;
            
            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int id = rdr.GetInt32(rdr.GetOrdinal(("id")));
                String hname = rdr.GetString(rdr.GetOrdinal("name"));
                
                int cap = rdr.GetInt32(rdr.GetOrdinal(("cap")));
                bool stat = rdr.GetBoolean(rdr.GetOrdinal(("stat")));
                String loc = rdr.GetString(rdr.GetOrdinal("loc"));
                string s;
                if(stat)
                {
                    s = "available";
                }
                else
                {
                    s = "unavailable";
                }


                Label name = new Label();
                name.Text = "<br>"  + id +
                            "<br>" + "stadium name : "+ hname + 
                             "<br>"+"status : " + s +
                             "<br>" + "capacity : " + cap +
                              "<br>" + "location : " +loc + "<br>";

                form1.Controls.Add(name);

            }

        }

        protected void allreq(object sender, EventArgs e)
        {
            acce.Enabled = true;
            rejeq.Enabled = true;
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand matches = new SqlCommand("select * from allreq (@smuser)", conn);


            matches.Parameters.Add(new SqlParameter("@smuser", Session["smuser"]));
            matches.CommandType = System.Data.CommandType.Text;

            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int id = rdr.GetInt32(rdr.GetOrdinal(("id")));
                String hname = rdr.GetString(rdr.GetOrdinal("hostName"));
                String gname = rdr.GetString(rdr.GetOrdinal("guestName"));
                String cname = rdr.GetString(rdr.GetOrdinal("cname"));
                DateTime stime = rdr.GetDateTime(rdr.GetOrdinal("st"));
                DateTime etime = rdr.GetDateTime(rdr.GetOrdinal("et"));
                 string stat = rdr.GetString(rdr.GetOrdinal(("stat")));
                Label name = new Label();
                name.Text = "<br>" + "matchID: " + id +
                             "<br>" + "club representative name: " + cname +
                             "<br>" + "host: " + hname +
                             "<br>" + "guest: " + gname +
                              "<br>" + "startTime: " + stime +
                             "<br>" + "endTime: " + etime +
                              "<br>"+ "status : "+stat+
                             "<br>";
                form1.Controls.Add(name);

            }
        }

        protected void acce_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            string matchidd = DropDownList1.SelectedItem.Value;
            int matchid = Int16.Parse(matchidd);
            

            SqlCommand regch = new SqlCommand("getattacc", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@matchid", matchid));
            SqlParameter hostt = regch.Parameters.Add("@hostName", SqlDbType.VarChar,30);
            SqlParameter guestt = regch.Parameters.Add("@guestName", SqlDbType.VarChar,30);
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


            SqlCommand regchh = new SqlCommand("acceptRequest", conn);
            regchh.CommandType = CommandType.StoredProcedure;
            regchh.Parameters.Add(new SqlParameter("@stadiumManagerUsername", Session["smuser"]));
            regchh.Parameters.Add(new SqlParameter("@hostClubName", host));
            regchh.Parameters.Add(new SqlParameter("@guestClubName", guest));
            regchh.Parameters.Add(new SqlParameter("@startTime", starttime));

            conn.Open();
            regchh.ExecuteNonQuery();
            conn.Close();

            //Response.Write(" "+ matchid);

            /*  SqlCommand midd = new SqlCommand("accr", conn);
              midd.CommandType = CommandType.StoredProcedure;


              int hid = Int16.Parse(acc.Text);

              midd.Parameters.Add(new SqlParameter("@smuser", Session["smuser"]));
              midd.Parameters.Add(new SqlParameter("@hid", hid));

              SqlCommand regch = new SqlCommand("checkacc", conn);
              regch.CommandType = CommandType.StoredProcedure;
              regch.Parameters.Add(new SqlParameter("@hid", hid));
              SqlParameter check = regch.Parameters.Add("@check", SqlDbType.Int);

              check.Direction = ParameterDirection.Output;

              conn.Open();
              midd.ExecuteNonQuery();
              conn.Close();

              conn.Open();
              regch.ExecuteNonQuery();
              conn.Close();

              if (check.Value.ToString() == "1")
              {

                  Response.Write("request accepted");
              }
              else
              {
                  Response.Write("acceptes STILL umhandled");
              }*/

        }

        protected void rejeq_Click(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);



            string matchidd = DropDownList2.SelectedItem.Value;
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


            SqlCommand regchh = new SqlCommand("rejectRequest", conn);
            regchh.CommandType = CommandType.StoredProcedure;
            regchh.Parameters.Add(new SqlParameter("@stadiumManagerUsername", Session["smuser"]));
            regchh.Parameters.Add(new SqlParameter("@hostClubName", host));
            regchh.Parameters.Add(new SqlParameter("@guestClubName", guest));
            regchh.Parameters.Add(new SqlParameter("@startTime", starttime));

            conn.Open();
            regchh.ExecuteNonQuery();
            conn.Close();




            /*  SqlCommand midd = new SqlCommand("rejr", conn);
              midd.CommandType = CommandType.StoredProcedure;

              int hid = Int16.Parse(rej.Text);

              midd.Parameters.Add(new SqlParameter("@smuser", Session["smuser"]));
              midd.Parameters.Add(new SqlParameter("@hid", hid));

              SqlCommand regch = new SqlCommand("checkrej", conn);
              regch.CommandType = CommandType.StoredProcedure;
              regch.Parameters.Add(new SqlParameter("@hid", hid));
              SqlParameter check = regch.Parameters.Add("@check", SqlDbType.Int);

              check.Direction = ParameterDirection.Output;

              conn.Open();

              regch.ExecuteNonQuery();
              conn.Close();
              if (check.Value.ToString() == "1")
              {

                  Response.Write("request rejected");
              }
              else
              {
                  Response.Write("acceptes STILL umhandled");
              }*/
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("allL.aspx");
        }
    }
}