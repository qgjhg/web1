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
            Exp_Warn.Attributes.Add("onKeyDown", "textCounter(this,254);");
            Exp_Warn.Attributes.Add("onKeyUp", "textCounter(this,254);");
            //Exp_Time.Attributes.Add("onKeyDown", "add_min(this);");
            Exp_Time.Attributes.Add("onKeyUp", "add_min(this);");
            cn.ConnectionString = connString;
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
            }
        }
        if (!IsPostBack)
        {
            //前端先验证
            upload.Attributes.Add("onclick", "return UserInputIsOk()");
            reset.Attributes["OnClick"] = "return confirm('确定重置?')";
            Exp_DetailTime.Items.Clear();
        }
        }

    protected void upload_Click(object sender, EventArgs e)
    {
        try
        {
            string Exp_Name_Value = Exp_Name.Text;
            string Exp_Start_Value = Exp_Start.Text;
            //string Exp_End_Value = Exp_End.Text;
            string Exp_Pos_Value = Exp_Pos.Text;
            int Exp_Time_Value;
            if (Exp_Time.Text != "")
            {
                Exp_Time_Value = Convert.ToInt32(Exp_Time.Text);
            }
            else
            {
                Exp_Time_Value = 0;
            }
            string Exp_Reward_Value = Exp_Reward.Text;
            string Exp_Warn_Value = Exp_Warn.Text;
            string Exp_School_Value = Exp_School.SelectedItem.Text;
            string Hidden_Value = ChooseTime.Value.ToString();

            if (Exp_School_Value == "" || Exp_Name_Value == "" || Exp_Start_Value == "" || Exp_Pos_Value == "" || Exp_Warn_Value == "" || Exp_Name_Value.Length > 16 || Exp_Start_Value.Length != 10 || Exp_Pos_Value.Length > 50 || Exp_Time_Value > 480 || Exp_Time_Value <= 0 || Exp_Reward_Value.Length > 50 || Exp_Warn_Value.Length > 255 || Hidden_Value == "")
            {
                Response.Write("<script type=\"text/javascript\">alert(\"数据错误或不完整！\")</script>");
            }
            else
            {
                if (Session["UserId"].ToString() == "" || Session["UserPassword"].ToString() == "" || Session["Type"].ToString() == "")
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    sqlstr = "SELECT password FROM dbo.login WHERE id='" + Session["UserId"] + "' collate Chinese_PRC_CS_AI";
                    cn.Open();
                    da.CommandText = sqlstr;
                    da.Connection = cn;
                    if (da.ExecuteScalar() != null)
                    {
                        if (da.ExecuteScalar().ToString() == Session["UserPassword"].ToString())
                        {
                            sqlstr = "SELECT type FROM dbo.login WHERE id='" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AI";
                            da.CommandText = sqlstr;
                            da.ExecuteScalar();
                            Session["Type"] = da.ExecuteScalar().ToString();
                            if (Session["Type"].ToString() == "admin" || Session["Type"].ToString() == "exp")
                            {
                                int todaydate = DateTime.Now.Year * 10000 + DateTime.Now.Month * 100 + DateTime.Now.Day;
                                int Exp_Time_Int = Convert.ToInt32(Exp_Time_Value);
                                int Exp_Date_Int = Convert.ToInt32(Exp_Start_Value.Substring(0, 4)) * 10000 + Convert.ToInt16(Exp_Start_Value.Substring(5, 2)) * 100 + Convert.ToInt16(Exp_Start_Value.Substring(8, 2));
                                if (Exp_Date_Int > todaydate)
                                {
                                    sqlstr = "SELECT COUNT(*) FROM dbo.Exp_Situation WHERE Date>=" + todaydate + " and Uploader = '" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                                    da.CommandText = sqlstr;
                                    int line = Convert.ToInt16(da.ExecuteScalar().ToString());
                                    if (line < 2)
                                    {
                                        sqlstr = "SELECT COUNT(*) FROM dbo.Exp_Situation WHERE Date=" + Exp_Date_Int + " and Name = '" + Exp_Name_Value + "'";
                                        da.CommandText = sqlstr;
                                        int countnum = Convert.ToInt32(da.ExecuteScalar().ToString());
                                        if (countnum == 0)
                                        {
                                            try
                                            {
                                                string[,] Detail_All = new string[15, 3];
                                                string[] Detail_All_Line = Hidden_Value.Split('|');
                                                for (int i = 0; i < Detail_All_Line.Length; i++)
                                                {
                                                    if (i < 15)
                                                    {
                                                        string[] Detail_Item = Detail_All_Line[i].Split(';');
                                                        Detail_All[i, 0] = Detail_Item[0];
                                                        Detail_All[i, 1] = Detail_Item[1];
                                                        Detail_All[i, 2] = Detail_Item[2];
                                                    }
                                                }
                                                for (int i = Detail_All_Line.Length; i < 15; i++)
                                                {
                                                    if (i < 15)
                                                    {
                                                        Detail_All[i, 0] = "-1";
                                                        Detail_All[i, 1] = "-1";
                                                        Detail_All[i, 2] = "-1";
                                                    }
                                                }
                                                sqlstr = "insert into Exp_Situation (Name,Date,School,Position,Time_min,Reward,Warning,Uploader,Detail1,N1,T1,Detail2,N2,T2,Detail3,N3,T3,Detail4,N4,T4,Detail5,N5,T5,Detail6,N6,T6,Detail7,N7,T7,Detail8,N8,T8,Detail9,N9,T9,Detail10,N10,T10,Detail11,N11,T11,Detail12,N12,T12,Detail13,N13,T13,Detail14,N14,T14,Detail15,N15,T15) values ('" +
                                                        Exp_Name_Value + "'," + Exp_Date_Int + ",'" + Exp_School_Value + "','" + Exp_Pos_Value + "'," + Exp_Time_Int + ",'" + Exp_Reward_Value + "','" + Exp_Warn_Value + "','" + Session["UserId"].ToString() + "','" + Detail_All[0, 0] + "'," + Convert.ToInt16(Detail_All[0, 1].ToString()) + "," + Convert.ToInt16(Detail_All[0, 2].ToString()) + ",'" +
                                                        Detail_All[1, 0] + "'," + Convert.ToInt16(Detail_All[1, 1].ToString()) + "," + Convert.ToInt16(Detail_All[1, 2].ToString()) + ",'" + Detail_All[2, 0] + "'," + Convert.ToInt16(Detail_All[2, 1].ToString()) + "," + Convert.ToInt16(Detail_All[2, 2].ToString()) + ",'" + Detail_All[3, 0] + "'," + Convert.ToInt16(Detail_All[3, 1].ToString()) + "," + Convert.ToInt16(Detail_All[3, 2].ToString()) + ",'" +
                                                        Detail_All[4, 0] + "'," + Convert.ToInt16(Detail_All[4, 1].ToString()) + "," + Convert.ToInt16(Detail_All[4, 2].ToString()) + ",'" + Detail_All[5, 0] + "'," + Convert.ToInt16(Detail_All[5, 1].ToString()) + "," + Convert.ToInt16(Detail_All[5, 2].ToString()) + ",'" + Detail_All[6, 0] + "'," + Convert.ToInt16(Detail_All[6, 1].ToString()) + "," + Convert.ToInt16(Detail_All[6, 2].ToString()) + ",'" +
                                                        Detail_All[7, 0] + "'," + Convert.ToInt16(Detail_All[7, 1].ToString()) + "," + Convert.ToInt16(Detail_All[7, 2].ToString()) + ",'" + Detail_All[8, 0] + "'," + Convert.ToInt16(Detail_All[8, 1].ToString()) + "," + Convert.ToInt16(Detail_All[8, 2].ToString()) + ",'" + Detail_All[9, 0] + "'," + Convert.ToInt16(Detail_All[9, 1].ToString()) + "," + Convert.ToInt16(Detail_All[9, 2].ToString()) + ",'" +
                                                        Detail_All[10, 0] + "'," + Convert.ToInt16(Detail_All[10, 1].ToString()) + "," + Convert.ToInt16(Detail_All[10, 2].ToString()) + ",'" + Detail_All[11, 0] + "'," + Convert.ToInt16(Detail_All[11, 1].ToString()) + "," + Convert.ToInt16(Detail_All[11, 2].ToString()) + ",'" + Detail_All[12, 0] + "'," + Convert.ToInt16(Detail_All[12, 1].ToString()) + "," + Convert.ToInt16(Detail_All[12, 2].ToString()) + ",'" +
                                                        Detail_All[13, 0] + "'," + Convert.ToInt16(Detail_All[13, 1].ToString()) + "," + Convert.ToInt16(Detail_All[13, 2].ToString()) + ",'" + Detail_All[14, 0] + "'," + Convert.ToInt16(Detail_All[14, 1].ToString()) + "," + Convert.ToInt16(Detail_All[14, 2].ToString()) + ")";
                                                da.CommandText = sqlstr;
                                                da.ExecuteNonQuery();
                                                Response.Write("<script language=\"javascript\">alert(\"实验发布成功！\");location.href='uploadexp.aspx'</script>");
                                            }
                                            catch
                                            {
                                                Response.Write("<script language=\"javascript\">alert(\"实验发布失败！\")</script>");
                                            }
                                        }
                                        else
                                        {
                                            Response.Write(Exp_Date_Int);
                                            Response.Write("<script language=\"javascript\">alert(\"当天已存在该实验名称！\")</script>");
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script language=\"javascript\">alert(\"最多仅能有两条进行中的实验！\")</script>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script language=\"javascript\">alert(\"只能发布明天及之后的实验\")</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script language=\"javascript\">alert(\"权限不足\")</script>");
                            }
                        }
                    }
                    cn.Close();
                }
            }
        }
        catch
        {
            Response.Write("<script language=\"javascript\">alert(\"数据库错误\")</script>");
        }
    }

    protected void reset_Click(object sender, EventArgs e)
    {
        Response.Write("<script language=\"javascript\">location.href='uploadexp.aspx'</script>");
    }
}