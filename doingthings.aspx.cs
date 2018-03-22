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
using System.IO;

public partial class doingthings : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null || Session["UserPassword"] == null || Session["Type"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (Session["Type"].ToString() == "admin" || Session["Type"].ToString() == "exp")
            {
                //try
                //{
                
                string oprate = Request.QueryString["oprate"];
                string num = Request.QueryString["num"];
                if ((oprate == "true" || oprate == "false" || oprate == "tipoff") && num != null)
                {
                    cn.ConnectionString = connString;
                    sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE Num = " + num;
                    SqlDataAdapter dtable = new SqlDataAdapter(sqlstr, cn);
                    DataTable dp = new DataTable();
                    dtable.Fill(dp);
                    if (dp.Rows.Count > 0)
                    {
                        sqlstr = "SELECT Uploader FROM [PSYcollection].[dbo].[Exp_Situation] WHERE id = " + Convert.ToInt32(dp.Rows[0][2].ToString());
                        cn.ConnectionString = connString;
                        da.CommandText = sqlstr;
                        da.Connection = cn;
                        cn.Open();
                        if (da.ExecuteScalar().ToString() == Session["UserId"].ToString())
                        {
                            if (oprate == "true")
                            {
                                if (dp.Rows[0][11].ToString() == "signing")
                                {
                                    sqlstr = "UPDATE [PSYcollection].[dbo].[applytable] SET status='pass' WHERE Num = " + num;
                                    da.CommandText = sqlstr;
                                    da.Connection = cn;
                                    int line = da.ExecuteNonQuery();
                                    if (line > 0)
                                    {
                                        Response.Redirect("myuploadexp.aspx");
                                    }
                                }
                            }
                            if (oprate == "false")
                            {
                                if (dp.Rows[0][11].ToString() == "signing")
                                {
                                    TextBox1.Visible = true;
                                    Button1.Visible = true;
                                }
                            }
                            if (oprate == "tipoff")
                            {
                                sqlstr = "UPDATE [PSYcollection].[dbo].[applytable] SET status='tipoff' WHERE Num = " + num;
                                da.CommandText = sqlstr;
                                da.Connection = cn;
                                int line = da.ExecuteNonQuery();
                                sqlstr = "SELECT id FROM [PSYcollection].[dbo].[applytable] WHERE Num = " + num;
                                da.CommandText = sqlstr;
                                string partid = da.ExecuteScalar().ToString();
                                sqlstr = "UPDATE [PSYcollection].[dbo].[login] SET point=point+1 WHERE id = '" + partid + "' collate Chinese_PRC_CS_AI";
                                da.CommandText = sqlstr;
                                int line2 = da.ExecuteNonQuery();
                                if (line > 0 && line2 > 0)
                                {
                                    Response.Redirect("myuploadexp.aspx");
                                }
                            }
                        }
                        cn.Close();
                    }
                }
                else if (oprate == "dn" && num != null)
                {
                    cn.ConnectionString = connString;
                    sqlstr = "SELECT Uploader FROM [PSYcollection].[dbo].[Exp_Situation] WHERE id = " + Convert.ToInt32(num);
                    da.Connection = cn;
                    cn.Open();
                    da.CommandText = sqlstr;
                    string name = da.ExecuteScalar().ToString();
                    cn.Close();
                    if (name == Session["UserId"].ToString())
                    {
                        cn.Open();
                        sqlstr = "SELECT name FROM [PSYcollection].[dbo].[login] WHERE id = '" + Session["UserId"].ToString() + "' collate Chinese_PRC_CS_AS";
                        da.CommandText = sqlstr;
                        string zhushiname = da.ExecuteScalar().ToString();
                        sqlstr = "SELECT School,Position FROM [PSYcollection].[dbo].[Exp_Situation] WHERE id = " + Convert.ToInt32(num);
                        da.CommandText = sqlstr;
                        SqlDataReader readerexp = da.ExecuteReader();
                        string expposition="";
                        while (readerexp.Read())
                        {
                            expposition = readerexp["School"].ToString() + " " + readerexp["Position"].ToString();
                        }
                        readerexp.Close();
                        string path = Server.MapPath("~/file") + "\\" + num + ".txt";
                        FileInfo fi = new FileInfo(path);
                        if (fi.Exists)
                        {
                            fi.Delete();
                            StreamWriter sw = new StreamWriter(fi.Create(), Encoding.Unicode);
                            sw.WriteLine("日期\t实验时间段\t主试\t被试姓名\t被试性别\t联系方式\t实验名称\t利手\t年龄\t地点");
                            sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE expid = " + Convert.ToInt32(num) + "and status = 'pass'";
                            da.CommandText = sqlstr;
                            SqlDataReader reader = da.ExecuteReader();
                            while (reader.Read())
                            {
                                string expdate = reader["expdate"].ToString();
                                expdate = expdate.Substring(0, 4) + "/" + expdate.Substring(4, 2) + "/" + expdate.Substring(6, 2);
                                sw.WriteLine(expdate + "\t" + reader["exptime"].ToString() + "\t" + zhushiname + "\t" + reader["partname"].ToString() + "\t" + reader["partsex"].ToString() + "\t" + reader["partphone"].ToString() + "\t" + reader["expname"].ToString() + "\t" +reader["parthand"].ToString() +"\t"+reader["partage"] + "\t" + expposition);
                            }
                            reader.Close();
                            download.InnerHtml = "<a href=\"/file/"+num+".txt\" download=\"" + num + ".txt\">点此下载</a>";
                            sw.Flush();
                            sw.Close();
                        }
                        else
                        {
                            StreamWriter sw = new StreamWriter(fi.Create(), Encoding.Unicode);
                            sw.WriteLine("日期\t实验时间段\t主试\t被试姓名\t被试性别\t联系方式\t实验名称\t利手\t年龄\t地点");
                            sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE expid = " + Convert.ToInt32(num) + "and status = 'pass'";
                            da.CommandText = sqlstr;
                            SqlDataReader reader = da.ExecuteReader();
                            while (reader.Read())
                            {
                                string expdate = reader["expdate"].ToString();
                                expdate = expdate.Substring(0, 4) + "/" + expdate.Substring(4, 2) + "/" + expdate.Substring(6, 2);
                                sw.WriteLine(expdate + "\t" + reader["exptime"].ToString() + "\t" + zhushiname + "\t" + reader["partname"].ToString() + "\t" + reader["partsex"].ToString() + "\t" + reader["partphone"].ToString() + "\t" + reader["expname"].ToString() + "\t" + reader["parthand"].ToString() + "\t" + reader["partage"] + "\t" + expposition);
                                download.InnerHtml = "<a href=\"/file/" + num + ".txt\" download=\"" + num + ".txt\">点此下载</a>";
                            }
                            reader.Close();
                            sw.Flush();
                            sw.Close();
                        }
                        cn.Close();
                    }
                    else
                    {
                        Response.Redirect("main.aspx");
                    }
                }
                else
                {
                    Response.Redirect("myuploadexp.aspx");
                }
                //}
                //catch
                //{
                //   Response.Redirect("main.aspx");
                //}
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["UserId"].ToString() == "" || Session["UserPassword"].ToString() == "" || Session["Type"].ToString() == "")
        {
            Response.Redirect("login.aspx");
        }
        else
        {
            if (Session["Type"].ToString() == "admin" || Session["Type"].ToString() == "exp")
            {
                if (TextBox1.Text != "")
                {
                    //try
                    //{

                    string oprate = Request.QueryString["oprate"];
                    string num = Request.QueryString["num"];
                    sqlstr = "SELECT * FROM [PSYcollection].[dbo].[applytable] WHERE Num = " + num;
                    cn.ConnectionString = connString;
                    SqlDataAdapter dtable = new SqlDataAdapter(sqlstr, cn);
                    DataTable dp = new DataTable();
                    dtable.Fill(dp);
                    if (dp.Rows.Count > 0)
                    {
                        sqlstr = "SELECT Uploader FROM [PSYcollection].[dbo].[Exp_Situation] WHERE id = " + Convert.ToInt32(dp.Rows[0][2].ToString());
                        cn.ConnectionString = connString;
                        da.CommandText = sqlstr;
                        da.Connection = cn;
                        cn.Open();
                        if (da.ExecuteScalar().ToString() == Session["UserId"].ToString())
                        {
                            if (oprate == "false")
                            {
                                if (dp.Rows[0][11].ToString() == "signing")
                                {
                                    sqlstr = "UPDATE [PSYcollection].[dbo].[applytable] SET status='reject' ,expcomment='" + TextBox1.Text + "' WHERE Num = " + num;
                                    da.CommandText = sqlstr;
                                    da.Connection = cn;
                                    int line = da.ExecuteNonQuery();
                                    if (line > 0)
                                    {
                                        string expnum = "N" + dp.Rows[0][12].ToString();
                                        sqlstr = "UPDATE [PSYcollection].[dbo].[Exp_Situation] SET " + expnum + "=" + expnum + "-1 WHERE id = " + Convert.ToInt32(dp.Rows[0][2].ToString());
                                        da.CommandText = sqlstr;
                                        da.Connection = cn;
                                        int line2 = da.ExecuteNonQuery();
                                        if (line2 > 0)
                                        {
                                            Response.Write("<script language=\"javascript\">alert(\"已拒绝！\");location.href='myuploadexp.aspx'</script>");
                                        }
                                    }
                                }
                            }
                        }
                        cn.Close();
                    }
                    Response.Redirect("myuploadexp.aspx");
                    //}
                    //catch
                    //{
                    //   Response.Redirect("main.aspx");
                    //}
                }
                else
                {
                    Response.Write("<script language=\"javascript\">alert(\"请输入拒绝理由！\")</script>");
                }
            }
        }
    }
}