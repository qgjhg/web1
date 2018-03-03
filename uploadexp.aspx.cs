using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class uploadexp : System.Web.UI.Page
{

    protected void Page_PreLoad(object sender, EventArgs e)
    {
        if (Session["type"] == null || Session["UserId"] == null || Session["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else 
        {
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
}