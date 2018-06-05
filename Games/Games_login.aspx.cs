//2018.05
//微信小程序无法发布（懒得弄游戏协议、懒得备案网站），迁移到网站版
//Game_login.aspx
//syw

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Games_Games_login : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] != null) { Session.Abandon(); }
        cn = new SqlConnection(connString);

    }

    protected void login_btn_Click(object sender, EventArgs e)
    {
        try
        {
            if (name.Text != "" && password.Text != "")
            {
                string userid = name.Text;
                string userpassword = password.Text;
                sqlstr = "SELECT password FROM dbo.login WHERE id='" + name.Text + "' collate Chinese_PRC_CS_AI";
                cn.Open();

                da.CommandText = sqlstr;
                da.Connection = cn;
                if (da.ExecuteScalar() != null)
                {
                    if (da.ExecuteScalar().ToString() == userpassword)
                    {
                        response.InnerHtml = "登陆成功，跳转中···";
                        sqlstr = "SELECT type FROM dbo.login WHERE id='" + userid + "' collate Chinese_PRC_CS_AS";
                        da.Connection = cn;
                        da.CommandText = sqlstr;
                        da.ExecuteScalar();
                        Session["UserId"] = userid;
                        Session["UserPassword"] = userpassword;
                        Session["Type"] = da.ExecuteScalar().ToString();
                        string nowtime = DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "  " + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                        sqlstr = "UPDATE dbo.login SET LastLogin = GETDATE() WHERE id='" + userid + "' collate Chinese_PRC_CS_AS";
                        da.Connection = cn;
                        da.CommandText = sqlstr;
                        da.ExecuteScalar();
                        Response.Redirect("main.aspx");
                    }
                    else
                    {
                        response.InnerHtml = "请输入正确的用户名和密码！";
                    }
                }
                else
                {
                    response.InnerHtml = "请输入正确的用户名和密码！";
                }
                cn.Close();
            }
            else
            {
                if (name.Text == "") response.InnerHtml = "请输入用户名!";
                if (password.Text == "") response.InnerHtml = "请输入密码！";
            }
        }
        catch
        {
            response.InnerHtml = "404错误···";

        }


    }
}