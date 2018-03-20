//2016.04 被试招募网站，搁浅
//2018.01 继续项目
//management.aspx 2018.03
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

public partial class myuploadexp : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["type"] == null || Session["UserId"] == null || Session["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            cn.ConnectionString = connString;
            if (Session["Type"].ToString() != "admin" && Session["Type"].ToString() != "exp")
            {
                Response.Redirect("main.aspx");
            }
            else
            {
                if (Session["Type"].ToString() == "admin")
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
                    type_html.Append("<a href = \"myuploadexp.aspx\" ><i class=\"fa fa-sitemap fa-fw\"></i> 实验管理</a>");
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
                else if (Session["Type"].ToString() == "exp")
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
                    type_html.Append("<a href = \"myuploadexp.aspx\" ><i class=\"fa fa-sitemap fa-fw\"></i> 实验管理</a>");
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
            try
            {
                int todaydate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                sqlstr = "SELECT id FROM [PSYcollection].[dbo].[Exp_Situation] WHERE Date>= " + todaydate + " and Uploader ='" + Session["UserId"].ToString() + "' collate CHINESE_PRC_CS_AS";
                cn.ConnectionString = connString;
                cn.Open();
                da.CommandText = sqlstr;
                da.Connection = cn;
                SqlDataReader reader = da.ExecuteReader();
                HiddenThings.Value = "";
                while (reader.Read())
                {
                    string expid = reader["id"].ToString();
                    if (HiddenThings.Value == "")
                    {
                        HiddenThings.Value = HiddenThings.Value + expid;
                    }
                    else
                    {
                        HiddenThings.Value = HiddenThings.Value + ";" + expid;
                    }
                }
                reader.Close();
                if (HiddenThings.Value != "")
                {
                    string[] allexpid = HiddenThings.Value.Split(';');
                    if (allexpid.Length != 0)
                    {//多试验情况未写；考虑是否允许多实验；目前考虑最多两条实验
                        sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE status in ('signing','pass') and expid= '" + allexpid[0].ToString() + "'";
                        SqlDataAdapter dtable = new SqlDataAdapter(sqlstr, cn);
                        DataTable dp = new DataTable();
                        dtable.Fill(dp);
                        if (dp.Rows.Count > 0)
                        {
                            Exp_Name1.Visible = true;
                            Exp_Name1.Text = dp.Rows[0][2].ToString() + " - " + dp.Rows[0][3].ToString();
                            StringBuilder table_html = new StringBuilder();
                            table_html.Append("<table width = \"100%\" class=\"table table-striped table-bordered table-hover table-condensed table-responsive\"><thead><tr><th>时段</th><th>姓名</th><th>性别</th><th>年龄</th><th>phone</th><th>操作</th></tr></thead><tbody>");

                            for (int i = 0; i < dp.Rows.Count; i++)
                            {
                                if (dp.Rows[i][11].ToString() == "signing")
                                {
                                    table_html.Append("<tr>");
                                    table_html.Append("<td>" + dp.Rows[i][5].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][6].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][8].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][7].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][13].ToString() + "</td>");
                                    table_html.Append("<td><a onclick=\"return confirm('确定接受该名被试?')\" href=\"doingthings.aspx?oprate=true&num=" + dp.Rows[i][0].ToString() + "\">接受</a><br /><a onclick=\"return confirm('确定拒绝该名被试?')\" href=\"doingthings.aspx?oprate=false&num=" + dp.Rows[i][0].ToString() + "\">拒绝</a></td>");
                                    table_html.Append("</tr>");
                                }
                                else if (dp.Rows[i][11].ToString() == "pass")
                                {
                                    table_html.Append("<tr>");
                                    table_html.Append("<td>" + dp.Rows[i][5].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][6].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][8].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][7].ToString() + "</td>");
                                    table_html.Append("<td>" + dp.Rows[i][13].ToString() + "</td>");
                                    table_html.Append("<td>已接受<br /></td>");
                                    table_html.Append("</tr>");
                                }
                            }
                            table_html.Append("</tbody></table>");
                            table_div.InnerHtml = table_html.ToString();
                        }
                        else
                        {
                            Info.Visible = true;
                            Info.Text = "尚无人报名参加您的实验~";
                        }
                        if (allexpid.Length > 1)
                        {
                            sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE status in ('signing','pass') and expid= '" + allexpid[1].ToString() + "'";
                            SqlDataAdapter dtable2 = new SqlDataAdapter(sqlstr, cn);
                            DataTable dp2 = new DataTable();
                            dtable2.Fill(dp2);
                            if (dp2.Rows.Count > 0)
                            {
                                Exp_Name2.Visible = true;
                                Exp_Name2.Text = dp2.Rows[0][2].ToString() + " - " + dp2.Rows[0][3].ToString();
                                StringBuilder table_html2 = new StringBuilder();
                                table_html2.Append("<table width = \"100 %\" class=\"table table-striped table-bordered table-hover table-condensed table-responsive\"><thead><tr><th>时段</th><th>姓名</th><th>性别</th><th>年龄</th><th>phone</th><th>操作</th></tr></thead><tbody>");

                                for (int i = 0; i < dp2.Rows.Count; i++)
                                {
                                    if (dp2.Rows[i][11].ToString() == "signing")
                                    {
                                        table_html2.Append("<tr>");
                                        table_html2.Append("<td>" + dp2.Rows[i][5].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][6].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][8].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][7].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][13].ToString() + "</td>");
                                        table_html2.Append("<td><a onclick=\"return confirm('确定接受该名被试?')\" href=\"doingthings.aspx?oprate=true&num=" + dp2.Rows[i][0].ToString() + "\">接受</a><br /><a onclick=\"return confirm('确定拒绝该名被试?')\" href=\"doingthings.aspx?oprate=false&num=" + dp2.Rows[i][0].ToString() + "\">拒绝</a></td>");
                                        table_html2.Append("</tr>");
                                    }
                                    else if (dp2.Rows[i][11].ToString() == "pass")
                                    {
                                        table_html2.Append("<tr>");
                                        table_html2.Append("<td>" + dp2.Rows[i][5].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][6].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][8].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][7].ToString() + "</td>");
                                        table_html2.Append("<td>" + dp2.Rows[i][13].ToString() + "</td>");
                                        table_html2.Append("<td>已接受<br /></td>");
                                        table_html2.Append("</tr>");
                                    }
                                }
                                table_html2.Append("</table>");
                                table_div2.InnerHtml = table_html2.ToString();
                            }
                        }
                    }
                }
                else
                {
                    Info.Visible = true;
                    Info.Text = "您没有正在进行的实验~";
                }

                int ntime = DateTime.Today.Year * 10000 + DateTime.Today.Month * 100 + DateTime.Today.Day;
                string table_html3 = " <!-- /.table-responsive --> <table width=\"100%\" class=\"table table-striped table-bordered table-hover\" id=\"expdataTables\"><thead><tr><th>名称</th><th>日期</th><th>校区</th><th>时长</th><th>报酬</th></tr></thead><tbody>";
                sqlstr= "SELECT * FROM [PSYcollection].[dbo].[Exp_Situation] WHERE Uploader='" + Session["UserId"].ToString() + "' collate CHINESE_PRC_CS_AS";
                SqlDataAdapter stable = new SqlDataAdapter(sqlstr, cn);
                DataTable ds = new DataTable();
                stable.Fill(ds);
                int k = 0;
                int cuttime = 0;
                while (k < ds.Rows.Count) {
                    cuttime =Convert.ToInt32(ds.Rows[k][2].ToString());
                        string str = "";
                        for (int mm = 9; mm < 53; mm = mm + 3) {
                            if (ds.Rows[k][mm].ToString() != "-1") {
                                str = str + ds.Rows[k][mm].ToString() + "  人数：" + ds.Rows[k][mm + 1].ToString() + "/" + ds.Rows[k][mm + 2].ToString() + " &#13 ";
                            }
                        }
                        table_html3 = table_html3 + "<tr title=\"详细地址：&#13 " + ds.Rows[k][4].ToString() + "&#13&#13简介与注意事项：&#13 " + ds.Rows[k][7].ToString() + "&#13&#13报名情况：&#13 " + str + "\">";
                    table_html3 = table_html3 + "<td>" + ds.Rows[k][1].ToString() + "</td>";
                    table_html3 = table_html3 + "<td>" + cuttime.ToString() + "</td>";
                    table_html3 = table_html3 + "<td>" + ds.Rows[k][3].ToString() + "</td>";
                    table_html3 = table_html3 + "<td>" + ds.Rows[k][5].ToString() + "min</td>";
                    table_html3 = table_html3 + "<td>" + ds.Rows[k][6].ToString() + "</td>";
                    table_html3 = table_html3 + "</tr>";
                    k = k + 1;
                            
                }
                table_html3 = table_html3 + "</tbody></table>";
                history_div.InnerHtml = table_html3;


                //sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE expdate >= " + todaydate + " and status in ('signing','pass') and id='" + Session["UserId"].ToString() + "' collate CHINESE_PRC_CS_AS";
                //cn.ConnectionString = connString;
                //SqlDataAdapter dtable = new SqlDataAdapter(sqlstr, cn);
                //DataTable nowexp = new DataTable();
                //dtable.Fill(nowexp);

                cn.Close();
            }
            catch
            {

            }
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
                status = "强制关闭";
                break;
            default:
                status = "null";
                break;
        }
        return status;
    }
}