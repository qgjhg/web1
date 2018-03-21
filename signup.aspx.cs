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
    protected void Page_Load(object sender, EventArgs e)
    {
        string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
        SqlConnection cn = new SqlConnection();
        SqlCommand da = new SqlCommand();
        string sqlstr = "";
        string str = Request.QueryString["id"];
        //string str = "18000013";
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
                if (!IsPostBack)
                {
                    try
                    {
                        SqlDataAdapter arolltable = new SqlDataAdapter("select * from dbo.Exp_Situation WHERE id='" + exp_id_int + "'", cn);
                        DataTable ds = new DataTable();
                        arolltable.Fill(ds);
                        if (ds != null)
                        {
                            Exp_Info.Text = "名称：" + ds.Rows[0][1].ToString() + ";\n日期：" + ds.Rows[0][2].ToString() + ";\n校区：" + ds.Rows[0][3].ToString() + ";\n地址：" + ds.Rows[0][4].ToString() + ";\n时长：" + ds.Rows[0][5].ToString() + " min;\n报酬：" + ds.Rows[0][6].ToString();
                            Exp_Warn.Text = ds.Rows[0][7].ToString();

                            Exp_TimeChoose.Items.Clear();
                            Exp_TimeChoose.Items.Add(new ListItem("", " "));
                            string strDetail = "";
                            for(int mm = 9;mm < 53; mm = mm + 3){
                                if (ds.Rows[0][mm].ToString() != "-1" && Convert.ToInt16(ds.Rows[0][mm + 1].ToString()) < Convert.ToInt16(ds.Rows[0][mm + 2].ToString())) 
                                {
                                    strDetail = ds.Rows[0][mm].ToString() + "  人数：" + ds.Rows[0][mm + 1].ToString() + "/" + ds.Rows[0][mm + 2].ToString();
                                    ListItem Timechoose = new ListItem();
                                    Timechoose.Text = strDetail;
                                    Timechoose.Value = mm.ToString();
                                    Exp_TimeChoose.Items.Add(Timechoose);
                                }
                            }
                        }
                    }
                    catch
                    {
                        Response.Write("<script language=\"javascript\">alert(\"实验信息获取失败！\");location.href='main.aspx'</script>");
                    }
                }
                try
                {
                    SqlDataAdapter arolltable = new SqlDataAdapter("select * from dbo.login WHERE id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AI", cn);
                    DataTable dp = new DataTable();
                    arolltable.Fill(dp);
                    if (dp.Rows.Count != 0)
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
        string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
        SqlConnection cn = new SqlConnection();
        SqlCommand da = new SqlCommand();
        string sqlstr = "";
        string expid = Exp_Id.Text;
        if (Exp_Id.Text != "" && Exp_Info.Text != "" && Exp_Warn.Text != "" && Exp_TimeChoose.Value != " " && Part_Info.Text != "")
        {
            sqlstr = "SELECT password FROM dbo.login WHERE id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
            cn.ConnectionString = connString;
            cn.Open();
            da.CommandText = sqlstr;
            da.Connection = cn;
            //检测权限
            if (da.ExecuteScalar() != null)
            {
                if (da.ExecuteScalar().ToString() == Session["UserPassword"].ToString())
                {
                    try
                    {
                        int nowtime = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                        sqlstr = "SELECT COUNT(*) FROM dbo.applytable WHERE expdate>=" + nowtime + " and status in ('signing','pass') and id= '" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                        da.CommandText = sqlstr;
                        da.Connection = cn;
                        int timeline = Convert.ToInt32(da.ExecuteScalar().ToString());
                        if (timeline <= 1)
                        {

                            SqlDataAdapter arolltable = new SqlDataAdapter("select * from dbo.Exp_Situation WHERE id=" + Convert.ToInt32(expid), cn);
                            DataTable ds = new DataTable();
                            arolltable.Fill(ds);
                            SqlDataAdapter arolltable2 = new SqlDataAdapter("select * from dbo.login WHERE id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS", cn);
                            DataTable dp = new DataTable();
                            arolltable2.Fill(dp);
                            if (ds.Rows.Count != 0 && dp.Rows.Count != 0)
                            {
                                sqlstr = "SELECT COUNT(*) FROM dbo.applytable WHERE status in ('signing','pass') and expdate= " + Convert.ToInt32(ds.Rows[0][2].ToString()) + " and id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                                da.CommandText = sqlstr;
                                da.Connection = cn;
                                if ((int)da.ExecuteScalar() == 0)
                                {
                                    int Select_Time = Convert.ToInt16(Exp_TimeChoose.Value.ToString());
                                    string changenum = "N" + (((Select_Time - 9) / 3 + 1)).ToString();

                                    if (Convert.ToInt16(ds.Rows[0][Select_Time + 1].ToString()) < Convert.ToInt16(ds.Rows[0][Select_Time + 2].ToString()))
                                    {
                                        //插入之前实验信息--------------------------------------------------------
                                        string partinfo = "截至报名，该名被试信息如下：<br />是否在黑名单：";
                                        sqlstr = "SELECT COUNT(*) FROM PSYcollection.dbo.blackpage WHERE Name='" + dp.Rows[0][2].ToString() + "'";
                                        da.CommandText = sqlstr;
                                        if (Convert.ToInt32(da.ExecuteScalar().ToString()) > 0)
                                        {
                                            partinfo = partinfo + "是 <br />";
                                        }
                                        else
                                        {
                                            partinfo = partinfo + "否 <br />";
                                        }
                                        sqlstr = "SELECT birthday,point FROM PSYcollection.dbo.login WHERE id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                                        da.CommandText = sqlstr;
                                        int birth = 0;
                                        SqlDataReader readerpartinfo = da.ExecuteReader();
                                        while (readerpartinfo.Read())
                                        {
                                            string[] birth1 = readerpartinfo["birthday"].ToString().Split('/');
                                            string birth2 = birth1[0] + birth1[1] + birth1[2];
                                            birth = Convert.ToInt32(birth2);
                                            partinfo = partinfo + "累计被举报或强行取消次数：" + readerpartinfo["point"].ToString() + " <br />";
                                        }
                                        readerpartinfo.Close();

                                        sqlstr = "SELECT expname FROM PSYcollection.dbo.historytable WHERE partname='" + dp.Rows[0][2].ToString() + "' and birthday=" + birth;

                                        da.CommandText = sqlstr;
                                        SqlDataReader readerExp = da.ExecuteReader();

                                        partinfo = partinfo + "实验记录：<br />";
                                        while (readerExp.Read())
                                        {
                                            partinfo = partinfo + readerExp["expname"].ToString() + " <br />";
                                        }
                                        readerExp.Close();

                                        sqlstr = "SELECT expname FROM PSYcollection.dbo.applytable WHERE status='pass' and id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                                        da.CommandText = sqlstr;
                                        SqlDataReader readerExp2 = da.ExecuteReader();
                                        while (readerExp2.Read())
                                        {
                                            partinfo = partinfo + readerExp2["expname"].ToString() + " <br />";
                                        }
                                        readerExp2.Close();

                                        //--------------
                                        System.Diagnostics.Debug.WriteLine((int)ds.Rows[0][Select_Time + 1]);
                                        int uptime = (int)ds.Rows[0][Select_Time + 1] + 1;
                                        sqlstr = "UPDATE dbo.Exp_Situation SET " + changenum + "=" + uptime + " WHERE id=" + Convert.ToInt32(expid);
                                        da.CommandText = sqlstr;
                                        int line1 = da.ExecuteNonQuery();
                                        int changenumline = ((Select_Time - 9) / 3 + 1);
                                        sqlstr = "insert into dbo.applytable (id,expid,expname,expdate,exptime,partname,partage,partsex,partcomment,expcomment,status,changenum,partphone,parthand) values ('" + Session["UserId"].ToString() + "','" + expid + "','" + ds.Rows[0][1].ToString() + "'," + Convert.ToInt32(ds.Rows[0][2].ToString()) + ",'" + ds.Rows[0][Select_Time].ToString() + "','" + dp.Rows[0][2].ToString() + "','" + (DateTime.Now.Year - Convert.ToInt32(dp.Rows[0][5].ToString().Substring(0, 4))).ToString() + "','" + dp.Rows[0][4].ToString() + "','" + partinfo + "','" + " " + "','" + "signing" + "',"+changenumline+",'"+dp.Rows[0][3].ToString()+"','"+dp.Rows[0][8]+"')";
                                        da.CommandText = sqlstr;
                                        da.Connection = cn;
                                        int line2 = da.ExecuteNonQuery();
                                        if (line1 != 0 && line2 != 0)
                                        {
                                            Response.Write("<script language=\"javascript\">alert(\"报名成功，请等待实验发布者确认~\");location.href='main.aspx'</script>");
                                        }
                                        else if (line1 == 0)
                                        {
                                            Response.Write("<script language=\"javascript\">alert(\"报名失败1：刷新实验数据失败\");location.href='main.aspx'</script>");
                                        }
                                        else
                                        {
                                            Response.Write("<script language=\"javascript\">alert(\"报名失败2:数据添加失败\");location.href='main.aspx'</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script language=\"javascript\">alert(\"报名冲突，请重新报名！\");location.href='main.aspx'</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script language=\"javascript\">alert(\"每天最多报名参加一项实验~\");location.href='main.aspx'</script>");
                                }
                            }

                        }
                        else
                        {
                            Response.Write("<script language=\"javascript\">alert(\"最多同时报名两项实验~\");location.href='main.aspx'</script>");
                        }

                    }
                    catch
                    {
                       Response.Write("<script language=\"javascript\">alert(\"报名失败\");location.href='main.aspx'</script>");
                    }

                }
                cn.Close();

            }
        }
        else
        {
            //Response.Write("<script language=\"javascript\">alert(\"" + Exp_Id.Text + ";" + Exp_Info.Text + "\")</script>");
            Response.Write("<script language=\"javascript\">alert(\"信息不全，请选择实验时间\");location.href='main.aspx'</script>");
        }
    }

}