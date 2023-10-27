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
    public partial class crVIEW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);




            SqlCommand matches = new SqlCommand("select * from crinfo (@username)", conn);


            matches.Parameters.Add(new SqlParameter("@username", Session["cruser"]));
            matches.CommandType = System.Data.CommandType.Text;

            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int id = rdr.GetInt32(rdr.GetOrdinal(("id")));
                String hname = rdr.GetString(rdr.GetOrdinal("name"));

                
                String loc = rdr.GetString(rdr.GetOrdinal("loc"));
                Label name = new Label();
                name.Text = "<br>" + id + " name:"+ hname+ "<br>" +"     " //+ stat
                    + " location:  "  + loc + "     " + "<br>";

                form1.Controls.Add(name);
                Session["clubname"] = hname;
            }

        }

        protected void aumc(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand matchess = new SqlCommand("clubname", conn);
            matchess.CommandType = System.Data.CommandType.StoredProcedure;

            matchess.Parameters.Add(new SqlParameter("@username", Session["cruser"]));

            SqlParameter checck = matchess.Parameters.Add("@n", SqlDbType.VarChar, 25);

            checck.Direction = ParameterDirection.Output;

            conn.Open();
            matchess.ExecuteNonQuery();
            conn.Close();


            string x = checck.Value.ToString();
            ////////////////////////////////////////
            

           SqlCommand matches = new SqlCommand("select * from upcomingMatchesOfClub (@clubname)", conn);
            matches.Parameters.Add(new SqlParameter("@clubname", x));
            matches.CommandType = System.Data.CommandType.Text;

            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int id = rdr.GetInt32(rdr.GetOrdinal(("matchID")));
                String hname = rdr.GetString(rdr.GetOrdinal("hostName"));
                String gname = rdr.GetString(rdr.GetOrdinal("guestName"));
                DateTime stimeee = rdr.GetDateTime(rdr.GetOrdinal("startTime"));
                DateTime etimeee = rdr.GetDateTime(rdr.GetOrdinal("endTime"));
               object sname = rdr.GetValue(rdr.GetOrdinal("stadiumName"));

               
                Label name = new Label();
                name.Text = "<br>" +"matchID: "+ id + 
                             "<br>"+ "host: "+hname+
                             "<br>" + "guest: "+gname 
                             + "<br>" + "startTime"+stimeee 
                             + "<br>" +"endTime" +etimeee + 
                             "<br>" + sname
                             + "<br>";

                form1.Controls.Add(name);
                
                /*   matchesss.Parameters.Add(new SqlParameter("@hname", hname));
                   matchesss.Parameters.Add(new SqlParameter("@gname", gname));
                   matchesss.Parameters.Add(new SqlParameter("@stime", stimeee));
                   matchesss.Parameters.Add(new SqlParameter("@etime", etimeee));

                   conn.Open();
                   matchesss.ExecuteNonQuery();
                   conn.Cl//ose();
                   if (checckk.Value.ToString() != "laa")
                   {
                       string y = checckk.Value.ToString();

                       Label name = new Label();
                       name.Text = "<br>" + "     " + hname + "     " + gname
                            + "     " + stimeee + "     " + etimeee +
                            "      " + y + "<br>";
                       form1.Controls.Add(name);
                   }*/
                // else
                // {

                /*  if (!sname.Equals("Null"))
                      name.Text = name.Text + sname;

                      form1.Controls.Add(name);*/
                // }
            }
        }

        protected void avs(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            DateTime datee = DateTime.Parse(dateforav.Text);
            SqlCommand matches = new SqlCommand("select * from viewAvailableStadiumsOn (@date)", conn);
            matches.Parameters.Add(new SqlParameter("@date", datee));
            matches.CommandType = System.Data.CommandType.Text;

            Session["crviewdatestad"] = datee;

            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //int id = rdr.GetInt32(rdr.GetOrdinal(("matchID")));
                String hname = rdr.GetString(rdr.GetOrdinal("name"));
                String loc = rdr.GetString(rdr.GetOrdinal("location"));
                int cap = rdr.GetInt32(rdr.GetOrdinal(("capacity")));

                Label name = new Label();
                name.Text = "<br>" + "stadium name : " + hname +
                             "<br>" + "location: " + loc +
                             "<br>" + "capacity: " + cap
                             + "<br>"+ "<br>";


                form1.Controls.Add(name);
                
            }

           // Label note = new Label();
           // note.Text = "stadiums not appearing in the requests' list still is not assigned to a manager";
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("allL.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            //DateTime datee = DateTime.Parse(dateforav.Text);
            string chosenstadium =DropDownList3.SelectedValue.ToString();
            string d = DropDownList4.SelectedValue.ToString();

            //Session["crviewdatestad"] = datee;
            DateTime dt = DateTime.Parse(d);

            SqlCommand matches = new SqlCommand("addHostRequest", conn);
            matches.Parameters.Add(new SqlParameter("@clubname", Session["clubname"]));
            matches.Parameters.Add(new SqlParameter("@stadiumname", chosenstadium));
            matches.Parameters.Add(new SqlParameter("@starttime",dt ));

            SqlParameter checck = matches.Parameters.Add("@check", SqlDbType.Int);

            checck.Direction = ParameterDirection.Output;
            matches.CommandType = System.Data.CommandType.StoredProcedure;

            conn.Open();
            matches.ExecuteNonQuery();
            conn.Close();

            if(checck.Value.ToString()=="0")
            {
                Response.Write("request added successfully");
            }
            else
            {
                Response.Write("request already is added");
            }



        }
    }
}