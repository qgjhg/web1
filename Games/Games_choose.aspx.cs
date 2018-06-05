using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class Games_Games_choose : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["type"] == null || Session["UserId"] == null || Session["UserPassword"] == null)
        {
            Response.Redirect("../login.aspx");
        }
        else
        {
            cn.ConnectionString = connString;

            //-------------------------------------------------------------------


            //-------------------------------------------------------------------
        }
    }



}