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
    public partial class spmVIEW : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addmatch(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand midd = new SqlCommand("addNewMatch", conn);
            midd.CommandType = CommandType.StoredProcedure;

            string hnamee = hnamespm.Text;
            string gnamee = gnamespm.Text;

            DateTime stimee = DateTime.Parse(stimespm.Text);
            DateTime etimee = DateTime.Parse(etimespm.Text);

            midd.Parameters.Add(new SqlParameter("@hostName", hnamee));
            midd.Parameters.Add(new SqlParameter("@GuestName", gnamee));
            midd.Parameters.Add(new SqlParameter("@startTime", stimee));
            midd.Parameters.Add(new SqlParameter("@endTime", etimee));



            SqlCommand regch = new SqlCommand("chechaddmatch", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@hostName", hnamee));
            regch.Parameters.Add(new SqlParameter("@GuestName", gnamee));
            regch.Parameters.Add(new SqlParameter("@startTime", stimee));
            regch.Parameters.Add(new SqlParameter("@endTime", etimee));

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
               
                Response.Write("adding done succsesfully");
            }

            else
            {
                Response.Write("a7a");
            }
        }

        protected void aum(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand matches = new SqlCommand("select * from aum", conn);
            matches.CommandType = System.Data.CommandType.Text;


            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //int id = rdr.GetInt32(rdr.GetOrdinal(("matchID")));
                String hname = rdr.GetString(rdr.GetOrdinal("hostName"));
                String gname = rdr.GetString(rdr.GetOrdinal("guestName"));
                DateTime stimeee = rdr.GetDateTime(rdr.GetOrdinal("startTime"));
                DateTime etimeee = rdr.GetDateTime(rdr.GetOrdinal("endTime"));

                Label name = new Label();
                name.Text = "<br>" + "host: " + hname +
                            "<br>" + "guest: " + gname +
                            "<br>" + "start time: " + stimeee +
                            "<br>" + "end time: " + etimeee +
                            "<br>";
                form1.Controls.Add(name);
            }
        }

        protected void apm(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand matches = new SqlCommand("select * from apm", conn);
            matches.CommandType = System.Data.CommandType.Text;


            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //int id = rdr.GetInt32(rdr.GetOrdinal(("matchID")));
                String hname = rdr.GetString(rdr.GetOrdinal("hostName"));
                String gname = rdr.GetString(rdr.GetOrdinal("guestName"));
                DateTime stimeee = rdr.GetDateTime(rdr.GetOrdinal("startTime"));
                DateTime etimeee = rdr.GetDateTime(rdr.GetOrdinal("endTime"));

                Label name = new Label();
                name.Text = "<br>" + "host: " + hname +
                            "<br>" + "guest: " + gname  +
                            "<br>" + "start time: "+stimeee + 
                            "<br>" + "end time: " + etimeee +
                            "<br>";
                form1.Controls.Add(name);
            }
        }

        protected void cnp(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand matches = new SqlCommand("select * from clubsNeverMatched", conn);
            matches.CommandType = System.Data.CommandType.Text;


            conn.Open();
            SqlDataReader rdr = matches.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                //int id = rdr.GetInt32(rdr.GetOrdinal(("matchID")));
                String hname = rdr.GetString(rdr.GetOrdinal("firstClub"));
                String gname = rdr.GetString(rdr.GetOrdinal("secondClub"));

                Label name = new Label();
                name.Text = "<br>"  + "club1:"+ hname+
                  "<br>" + "club2:" + gname
                      + "<br>";

                form1.Controls.Add(name);

            }
        }

        protected void deletematch(object sender, EventArgs e)
        {

            String connStr = WebConfigurationManager.ConnectionStrings["DBM"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand midd = new SqlCommand("deleteMatch3", conn);
            midd.CommandType = CommandType.StoredProcedure;

            string hnamee = hnamed.Text;
            string gnamee = gnamed.Text;

            DateTime stimee = DateTime.Parse(stimed.Text);
            DateTime etimee = DateTime.Parse(etimed.Text);

            midd.Parameters.Add(new SqlParameter("@hostName", hnamee));
            midd.Parameters.Add(new SqlParameter("@GuestName", gnamee));
            midd.Parameters.Add(new SqlParameter("@startTime", stimee));
            midd.Parameters.Add(new SqlParameter("@endTime", etimee));



            SqlCommand regch = new SqlCommand("chechdeletematch", conn);
            regch.CommandType = CommandType.StoredProcedure;
            regch.Parameters.Add(new SqlParameter("@hostName", hnamee));
            regch.Parameters.Add(new SqlParameter("@GuestName", gnamee));
            regch.Parameters.Add(new SqlParameter("@startTime", stimee));
            regch.Parameters.Add(new SqlParameter("@endTime", etimee));

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

                Response.Write("deleting done succsesfully");
            }

            else
            {
                Response.Write(" sth you entred is invalid");
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Response.Redirect("allL.aspx");
        }
    }
}