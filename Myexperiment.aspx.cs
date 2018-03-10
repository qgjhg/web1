//2016.04 被试招募网站，搁浅
//2018.01 继续项目
//myexperment.aspx 2018.03
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

public partial class Myexperiment : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["type"] == null || Session["UserId"] == null || Session["UserPassword"] == null)
            {
                Response.Redirect("login.aspx");
                return;
            }
            else
            {
                cn.ConnectionString = connString;
                if (Session["Type"].ToString() != "admin" && Session["Type"].ToString() != "exp")
                {
                    Response.Redirect("main.aspx");
                    return;
                }
                else
                {
                    if (Session["Type"].ToString() == "exp")
                    {
                        StringBuilder type_html = new StringBuilder("");
                        type_html.Append("<ul class=\"nav\" id=\"side-menu\">");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"main.aspx\"><i class=\"fa fa-dashboard fa-fw\"></i> 主页</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"Myexperiment.aspx\" ><i class=\"fa fa-table fa-fw\"></i> 我的实验</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"uploadexp.aspx\" ><i class=\"fa fa-edit fa-fw\"></i> 发布实验</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"help.aspx\"><i class=\"fa fa-files-o fa-fw\"></i> 帮助</a>");
                        type_html.Append("</li>");
                        type_html.Append("</ul>");
                        type_diff.InnerHtml = type_html.ToString();
                    }
                    else if (Session["Type"].ToString() == "admin")
                    {
                        StringBuilder type_html = new StringBuilder("");
                        type_html.Append("<ul class=\"nav\" id=\"side-menu\">");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"main.aspx\"><i class=\"fa fa-dashboard fa-fw\"></i> 主页</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"Myexperiment.aspx\" ><i class=\"fa fa-table fa-fw\"></i> 我的实验</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"uploadexp.aspx\" ><i class=\"fa fa-edit fa-fw\"></i> 发布实验</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"help.aspx\"><i class=\"fa fa-files-o fa-fw\"></i> 帮助</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"management.aspx\"><i class=\"fa fa-wrench fa-fw\"></i> 管理</a>");
                        type_html.Append("</li>");
                        type_html.Append("</ul>");
                        type_diff.InnerHtml = type_html.ToString();
                    }
                    else
                    {
                        StringBuilder type_html = new StringBuilder("");
                        type_html.Append("<ul class=\"nav\" id=\"side-menu\">");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"main.aspx\"><i class=\"fa fa-dashboard fa-fw\"></i> 主页</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"Myexperiment.aspx\" ><i class=\"fa fa-table fa-fw\"></i> 我的实验</a>");
                        type_html.Append("</li>");
                        type_html.Append("<li>");
                        type_html.Append("<a href = \"help.aspx\"><i class=\"fa fa-files-o fa-fw\"></i> 帮助</a>");
                        type_html.Append("</li>");
                        type_html.Append("</ul>");
                        type_diff.InnerHtml = type_html.ToString();
                    }
                }
                if (!IsPostBack)//验证账户
                {
                    sqlstr = "SELECT password FROM dbo.login WHERE id = '" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                    cn.ConnectionString = connString;
                    cn.Open();
                    da.CommandText = sqlstr;
                    da.Connection = cn;
                    if (da.ExecuteScalar() != null)
                    {
                        string userpassword = da.ExecuteScalar().ToString();
                        if (userpassword != Session["UserPassword"].ToString())
                        {
                            Response.Redirect("login.aspx");
                        }
                    }
                    cn.Close();
                }
                int todaydate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE expdate >= " + todaydate + " and status in ('signing','pass') and id='" + Session["UserId"].ToString() + "' collate CHINESE_PRC_CS_AS";
                cn.ConnectionString = connString;
                SqlDataAdapter dtable = new SqlDataAdapter(sqlstr, cn);
                DataTable nowexp = new DataTable();
                dtable.Fill(nowexp);
                if (nowexp.Rows.Count != 0)
                {
                    HiddenThings.Value = "";
                    string status = changestatus(nowexp.Rows[0][11].ToString());
                    Exp_ID_1.Visible = true;
                    undo1.Visible = true;

                    Exp_ID_1.Text = nowexp.Rows[0][2].ToString() + " - " + status;
                    sqlstr = "SELECT * FROM [PSYcollection].[dbo].[Exp_Situation] WHERE id = " + Convert.ToInt32(nowexp.Rows[0][2].ToString());
                    dtable = new SqlDataAdapter(sqlstr, cn);
                    DataTable firstexp = new DataTable();
                    dtable.Fill(firstexp);
                    HiddenThings.Value = HiddenThings.Value + nowexp.Rows[0][2].ToString() + ";" + nowexp.Rows[0][5].ToString();
                    Exp_Info_1.Text = " 名称：" + nowexp.Rows[0][3].ToString() + "\n 日期：" + firstexp.Rows[0][2].ToString() + "\n 时间：" +
                        nowexp.Rows[0][5].ToString() + "\n 时长：" + firstexp.Rows[0][5].ToString() + " min \n 校区：" + firstexp.Rows[0][3].ToString() + "\n 地址：" +
                        firstexp.Rows[0][4].ToString() + "\n 报酬：" + firstexp.Rows[0][6].ToString() + "\n 注意事项：\n" + firstexp.Rows[0][7];
                    if (nowexp.Rows.Count > 1)
                    {
                        string status2 = changestatus(nowexp.Rows[0][11].ToString());
                        Exp_ID_2.Visible = true;
                        Exp_Info_2.Visible = true;
                        undo2.Visible = true;
                        Exp_ID_2.Text = nowexp.Rows[1][2].ToString() + " - " + status2;
                        sqlstr = "SELECT * FROM [PSYcollection].[dbo].[Exp_Situation] WHERE id = " + Convert.ToInt32(nowexp.Rows[1][2].ToString());
                        dtable = new SqlDataAdapter(sqlstr, cn);
                        DataTable secondexp = new DataTable();
                        dtable.Fill(secondexp);
                        HiddenThings.Value = HiddenThings.Value + ";" + nowexp.Rows[1][2].ToString() + ";" + nowexp.Rows[0][5].ToString();
                        Exp_Info_2.Text = " 名称：" + nowexp.Rows[1][3].ToString() + "\n 日期：" + secondexp.Rows[0][2].ToString() + "\n 时间：" +
                            nowexp.Rows[1][4].ToString() + "\n 时长：" + secondexp.Rows[0][5].ToString() + " min \n 校区：" + secondexp.Rows[0][3].ToString() + "\n 地址：" +
                            secondexp.Rows[0][5].ToString() + "\n 报酬：" + secondexp.Rows[0][6].ToString() + "\n 注意事项：\n" + secondexp.Rows[0][7];
                    }
                }
                else
                {
                    Exp_Info_1.Text = "您没有进行中的任何实验，快去参加吧~";
                }
                sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE id='" + Session["UserId"].ToString() + "' collate CHINESE_PRC_CS_AS";
                cn.ConnectionString = connString;
                dtable = new SqlDataAdapter(sqlstr, cn);
                DataTable allexp = new DataTable();
                dtable.Fill(allexp);
                StringBuilder table_html = new StringBuilder();
                table_html.Append("<table width = \"100 %\" class=\"table table-striped table-bordered table-hover\" id=\"expdataTables\"><thead><tr><th>日期</th><th>名称</th><th>状态</th><th>备注</th></tr></thead><tbody>");
                string status1 = "";
                for (int i = 0; i < allexp.Rows.Count; i++)
                {
                    if (Convert.ToInt32(allexp.Rows[i][4].ToString()) < todaydate)
                    {
                        status1 = changestatus_old(allexp.Rows[i][11].ToString());
                    }
                    else
                    {
                        status1 = changestatus(allexp.Rows[i][11].ToString());
                    }
                    table_html.Append("<tr>");
                    table_html.Append("<td>" + allexp.Rows[i][4].ToString() + "</td>");
                    table_html.Append("<td>" + allexp.Rows[i][3].ToString() + "</td>");
                    table_html.Append("<td>" + status1 + "</td>");
                    table_html.Append("<td>" + allexp.Rows[i][10] + "</td>");
                    table_html.Append("</tr>");
                }
                table_html.Append("</table>");
                table_div.InnerHtml = table_html.ToString();
            }
        }
        catch
        {
            Response.Redirect("main.aspx");
        }
    }

    private string changestatus(string dbstatus)//转换状态
    {
        string status = "";
        switch (dbstatus)
        {
            case "signing":
                status = "待确认";
                break;
            case "pass":
                status = "已确认";
                break;
            case "finish":
                status = "已完结";
                break;
            case "reject":
                status = "已关闭";
                break;
            case "delete":
                status = "已取消";
                break;
            case "harddelete":
                status = "已关闭";
                break;
            default:
                status = "null";
                break;
        }
        return status;
    }

    private string changestatus_old(string dbstatus)//转换状态
    {
        string status = "";
        switch (dbstatus)
        {
            case "signing":
                status = "已关闭";
                break;
            case "pass":
                status = "已完结";
                break;
            case "finish":
                status = "已完结";
                break;
            case "reject":
                status = "已关闭";
                break;
            case "delete":
                status = "已取消";
                break;
            case "harddelete":
                status = "已关闭";
                break;
            default:
                status = "null";
                break;
        }
        return status;
    }


    protected void undo1_Click(object sender, EventArgs e)
    {
        string[] str = HiddenThings.Value.Split(';');
    }

    protected void undo2_Click(object sender, EventArgs e)
    {
        string[] str = HiddenThings.Value.Split(';');
    }
}