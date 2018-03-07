using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class signup : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string str = Request.QueryString["id"];
        int exp_id_int = Convert.ToInt32(str);
        if (str == null)
        {
            Response.Redirect("main.aspx");
        }
        else
        {
            Exp_Id.Text = str;
        }
        if (Session["type"] == null || Session["UserId"] == null || Session["UserPassword"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            cn.ConnectionString = connString;
            if (Session["Type"].ToString() != "admin" && Session["Type"].ToString() != "exp" && Session["Type"].ToString() != "part") //记得权限修改
            {
                Response.Redirect("login.aspx");
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
                try
                {
                    SqlDataAdapter arolltable = new SqlDataAdapter("select * from dbo.Exp_Situation WHERE id='" + exp_id_int + "'", cn);
                    DataTable ds = new DataTable();
                    arolltable.Fill(ds);
                    if (ds != null)
                    {
                        Exp_Info.Text = "名称：" + ds.Rows[0][1].ToString() + ";\n日期：" + ds.Rows[0][2].ToString() + ";\n校区：" + ds.Rows[0][3].ToString() + ";\n地址：" + ds.Rows[0][4].ToString() + ";\n时长：" + ds.Rows[0][5].ToString() + " min;\n报酬：" + ds.Rows[0][6].ToString();
                        Exp_Warn.Text = ds.Rows[0][7].ToString();
                        string Exp_DetailTime = ds.Rows[0][9].ToString();
                        Exp_DetailTime = Exp_DetailTime.Replace("\n", "");
                        string[] Exp_Detail = Exp_DetailTime.Split(';');
                        for (int i = 0; i < Exp_Detail.Length - 1; i = i + 2)
                        {
                            if (Convert.ToInt16(Exp_Detail[i+1][5]) < Convert.ToInt16(Exp_Detail[i+1][7]))
                            {
                                ListItem Timechoose = new ListItem();
                                Timechoose.Text = Exp_Detail[i] + ";" + Exp_Detail[i + 1];
                                Exp_TimeChoose.Items.Add(Timechoose);
                            }
                            else
                            {

                            }
                        }
                    }
                }
                catch
                {
                    Response.Write("<script language=\"javascript\">alert(\"实验信息获取失败！\");location.href='main.aspx'</script>");
                }
                try
                {
                    SqlDataAdapter arolltable = new SqlDataAdapter("select * from dbo.login WHERE id='" + Session["UserId"].ToString() + "'", cn);
                    DataTable dp = new DataTable();
                    arolltable.Fill(dp);
                    if (dp != null)
                    {
                        Part_Info.Text = "姓名：" + dp.Rows[0][2].ToString() + ";\n性别：" + dp.Rows[0][4].ToString() + ";\n年龄：" + (DateTime.Now.Year - Convert.ToInt32(dp.Rows[0][5].ToString().Substring(0, 4))).ToString() + ";\n联系方式：" + dp.Rows[0][3].ToString().Substring(0, 3) + "****" + dp.Rows[0][3].ToString().Substring(6, 4) + ";";
                    }
                }
                catch
                {
                    Response.Write("<script language=\"javascript\">alert(\"账户信息获取失败！\");location.href='main.aspx'</script>");
                }
            }
        }
        if (!IsPostBack)
        {
            //前端先验证
            //upload.Attributes.Add("onclick", "return UserInputIsOk()");
        }
}

    protected void apply_button_Click(object sender, EventArgs e)
    {
        string expid = Exp_Id.Text;
        if (Exp_Id.Text!="" && Exp_Info.Text!="" && Exp_Warn.Text!="" &&Exp_TimeChoose.Text!="" && Part_Info.Text != "")
        {
            sqlstr = "SELECT id FROM dbo.login WHERE password='" + Session["UserPassword"].ToString() + "'";
            cn.Open();
            da.CommandText = sqlstr;
            da.Connection = cn;
            //检测权限
            if (da.ExecuteScalar() != null)
            {
                //try
                //{
                    SqlDataAdapter arolltable = new SqlDataAdapter("select * from dbo.Exp_Situation WHERE id='" + Convert.ToInt32(expid) + "'", cn);
                    DataTable ds = new DataTable();
                    arolltable.Fill(ds);
                    SqlDataAdapter arolltable2=new SqlDataAdapter("select * from dbo.login WHERE id='" + Session["UserId"].ToString() + "'", cn);
                    DataTable dp = new DataTable();
                    arolltable2.Fill(dp);
                    if (ds != null && dp != null) 
                    {
                        string Exp_DetailTime = ds.Rows[0][9].ToString();
                        Exp_DetailTime = Exp_DetailTime.Replace("\r", "");
                        string[] Exp_Detail = Exp_DetailTime.Split(';');
                        string[] Select_Time = Exp_TimeChoose.Text.Split(';');
                        string Detailtime = "";
                        bool ischange = false;
                        for (int i = 0; i < Exp_Detail.Length - 1; i = i + 2)
                        {
                            if (Select_Time[0] == Exp_Detail[i] && Convert.ToInt16(Exp_Detail[i + 1][5]) < Convert.ToInt16(Exp_Detail[i + 1][7]))
                            {
                                Detailtime = Detailtime + Exp_Detail[i] + ";" + Exp_Detail[i + 1].Substring(0, 5) + (Convert.ToInt16(Exp_Detail[i + 1][5])+1).ToString() + Exp_Detail[i + 1].Substring(6, 2) + ";\r";
                                ischange = true;
                            }
                            else
                            {
                                Detailtime = Detailtime + Exp_Detail[i] + ";" + Exp_Detail[i + 1] + ";\r";
                            }
                        }
                        if (ischange == true)
                        {
                            sqlstr = "SELECT Detailtime FROM dbo.Exp_Situation WHERE id='" + Convert.ToInt32(expid) + "'";
                            da.CommandText = sqlstr;
                            if (da.ExecuteScalar().ToString() == ds.Rows[0][9].ToString())
                            {
                                sqlstr = "UPDATE dbo.Exp_Situation SET Detailtime='" + Detailtime + "' WHERE id=" + Convert.ToInt32(expid);
                                da.CommandText = sqlstr;
                                int line1 = da.ExecuteNonQuery();
                                sqlstr = "insert into dbo.applytable (id,password,expid,expname,expdate,exptime,partname,partage,partsex,partcomment,expcomment,status) values ('" + Session["UserId"].ToString() + "','" + Session["UserPassword"].ToString() + "','" + expid + "','" + ds.Rows[0][1].ToString() + "'," + Convert.ToInt32(ds.Rows[0][2].ToString()) + ",'" + Select_Time[0].ToString() + "','" + dp.Rows[0][2].ToString() + "','" + (DateTime.Now.Year - Convert.ToInt32(dp.Rows[0][5].ToString().Substring(0, 4))).ToString() + "','" + dp.Rows[0][4].ToString() + "','" + " " + "','" + " " + "','" + "signing" + "')";
                                da.CommandText = sqlstr;
                                da.Connection = cn;
                                int line2 = da.ExecuteNonQuery();
                                if (line1 != 0 && line2 != 0) 
                                {
                                    Response.Write("<script language=\"javascript\">alert(\"报名成功，请等待实验发布者确认~\");location.href='main.aspx'</script>");
                                }
                                else
                                {
                                    Response.Write("<script language=\"javascript\">alert(\"报名失败1\");location.href='main.aspx'</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script language=\"javascript\">alert(\"报名冲突，请重新报名！\");location.href='main.aspx'</script>");
                            }
                        }
                    }
                //}
                //catch
                //{
                //   Response.Write("<script language=\"javascript\">alert(\"报名失败\");location.href='main.aspx'</script>");
                //}

            }
            cn.Close();
        }
    }
}