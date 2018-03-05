//2016.04 被试招募网站，搁浅
//2018.01 继续项目
//login.aspx 2018.03
//syw

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class uploadexp : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_PreLoad(object sender, EventArgs e)
    {
        if (Session["type"] == null || Session["UserId"] == null || Session["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else 
        {
            Exp_Intro.Attributes.Add("onKeyDown", "textCounter(this,499);");
            Exp_Intro.Attributes.Add("onKeyUp", "textCounter(this,499);");
            //Exp_Time.Attributes.Add("onKeyDown", "add_min(this);");
            Exp_Time.Attributes.Add("onKeyUp", "add_min(this);");
            if (Session["Type"].ToString() != "admin" && Session["Type"].ToString() != "exp")
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                if (Session["Type"].ToString() == "exp")
                {
                    StringBuilder type_html = new StringBuilder("");
                    type_html.Append("<ul class=\"nav\" id=\"side-menu\">");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"main.aspx\"><i class=\"fa fa-dashboard fa-fw\"></i>主页</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\" ><i class=\"fa fa-bar-chart-o fa-fw\"></i> Charts</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"tables.html\" ><i class=\"fa fa-table fa-fw\"></i> Tables</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"uploadexp.aspx\" ><i class=\"fa fa-edit fa-fw\"></i> 发布实验</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\"><i class=\"fa fa-files-o fa-fw\"></i> Sample Pages</a>");
                    type_html.Append("</li>");
                    type_html.Append("</ul>");
                    type_diff.InnerHtml = type_html.ToString();
                }
                else if (Session["Type"].ToString() == "admin")
                {
                    StringBuilder type_html = new StringBuilder("");
                    type_html.Append("<ul class=\"nav\" id=\"side-menu\">");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"main.aspx\"><i class=\"fa fa-dashboard fa-fw\"></i>主页</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\" ><i class=\"fa fa-bar-chart-o fa-fw\"></i> Charts</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"tables.html\" ><i class=\"fa fa-table fa-fw\"></i> Tables</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"uploadexp.aspx\" ><i class=\"fa fa-edit fa-fw\"></i> 发布实验</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\"><i class=\"fa fa-files-o fa-fw\"></i> Sample Pages</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\"><i class=\"fa fa-wrench fa-fw\"></i>管理</a>");
                    type_html.Append("</li>");
                    type_html.Append("</ul>");
                    type_diff.InnerHtml = type_html.ToString();
                }
                else
                {
                    StringBuilder type_html = new StringBuilder("");
                    type_html.Append("<ul class=\"nav\" id=\"side-menu\">");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"main.aspx\"><i class=\"fa fa-dashboard fa-fw\"></i>主页</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\" ><i class=\"fa fa-bar-chart-o fa-fw\"></i> Charts</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"tables.html\" ><i class=\"fa fa-table fa-fw\"></i> Tables</a>");
                    type_html.Append("</li>");
                    type_html.Append("<li>");
                    type_html.Append("<a href = \"#\"><i class=\"fa fa-files-o fa-fw\"></i> Sample Pages</a>");
                    type_html.Append("</li>");
                    type_html.Append("</ul>");
                    type_diff.InnerHtml = type_html.ToString();
                }
            }
        }
    }

    protected void upload_Click(object sender, EventArgs e)
    {
        try
        {
            string Exp_Name_Value = Exp_Name.Text;
            string Exp_Start_Value = Exp_Start.Text;
            string Exp_End_Value = Exp_End.Text;
            string Exp_Pos_Value = Exp_Pos.Text;
            int Exp_Time_Value = Convert.ToInt16(Exp_Time.Text);
            string Exp_Reward_Value = Exp_Reward.Text;
            string Exp_Warn_Value = Exp_Warn.Text;
            string Exp_DetailTime_Value = Exp_DetailTime.Text;

            if (Exp_Name_Value == "" || Exp_Name_Value.Length > 50 || Exp_Start_Value.Length != 10 || Exp_End_Value.Length != 10 || Exp_Pos_Value.Length > 50 || Exp_Time_Value > 480 || Exp_Time_Value <= 0 || Exp_Reward_Value.Length > 50 || Exp_Warn_Value.Length > 255 || Exp_DetailTime_Value.Length > 255)
            {
                Response.Write("<script language=\"javascript\">alert(\"数据错误\")</script>");
            }
            else
            {
                if (Session["UserId"].ToString() == "" || Session["UserPassword"].ToString() == "" || Session["Type"].ToString() == "")
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    sqlstr = "SELECT id FROM dbo.login WHERE password='" + Session["UserPassword"] + "'";
                    cn.Open();
                    da.CommandText = sqlstr;
                    da.Connection = cn;
                    da.ExecuteScalar();
                    if (da.ExecuteScalar() != null)
                    {
                        sqlstr = "SELECT type FROM dbo.login WHERE id='" + Session["UserId"] + "'";
                        da.CommandText = sqlstr;
                        da.ExecuteScalar();
                        Session["Type"] = da.ExecuteScalar().ToString();
                        if (Session["Type"].ToString() == "admin" || Session["Type"].ToString() == "exp")
                        {
                            sqlstr = "insert into 实验情况 (实验名称,实验简介,日期,校区,地点,时长,报酬,注意事项,当前人数,总人数,主试,联系方式,账号) values " + "";
                        }
                        else
                        {
                            Response.Write("<script language=\"javascript\">alert(\"权限不足\")</script>");
                        }
                    }
                    cn.Close();
                }
            }
        }
        catch
        {

        }    
    }
}