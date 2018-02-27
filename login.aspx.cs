using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        cn = new SqlConnection(connString);
    }

    protected void login_btn_Click(object sender, EventArgs e)
    {
        if (name.Text != "" && password.Text != "")
        {
            string userid = name.Text;
            string userpassword = password.Text;
            sqlstr = "SELECT id FROM dbo.login WHERE password='" + password.Text + "'";
            cn.Open();

            da.CommandText = sqlstr;
            da.Connection = cn;
            da.ExecuteScalar();

            if (da.ExecuteScalar() != null)
            {
                response.InnerHtml = "登陆成功，跳转中···";
                sqlstr = "SELECT type FROM dbo.login WHERE id='" + userid + "'";
                da.Connection = cn;
                Session["UserId"] = userid;
                Session["UserPassword"] = password;
                Session["Type"] = da.ExecuteScalar().ToString();
                Response.Redirect("Default.aspx");
            }
            else
            {
                response.InnerHtml = "请输入正确的用户名和密码！";
            }
            cn.Close();
        }
        else {
            if (name.Text == "") response.InnerHtml = "请输入用户名!";
            if (password.Text == "") response.InnerHtml = "请输入密码！";
        }
        
    }
}