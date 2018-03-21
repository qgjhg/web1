//2016.04 被试招募网站，搁浅
//2018.01 继续项目
//register.aspx 2018.03
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

public partial class Register : System.Web.UI.Page
{
    string connString = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;";
    SqlConnection cn = new SqlConnection();
    SqlCommand da = new SqlCommand();
    string sqlstr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Part_Phone.Attributes.Add("onKeyUp", "onlynumber(this)");
            upload.Attributes.Add("onclick", "return UserInputIsOk()");
        }
    }

    protected void upload_Click(object sender, EventArgs e)
    {
        if (Part_Id.Text != "" || Part_Name.Text != "" || Part_password1.Text != "" || Part_password2.Text != "" || Part_Phone.Text != "" || Part_Sex.Text != "" || Part_Hand.Text != "" || Part_Birthday.Text != "" || Part_password1.Text != Part_password2.Text) 
        {
            try
            {
                sqlstr = "SELECT COUNT(*) FROM dbo.login WHERE id='" + Part_Id.Text + "'";
                cn.ConnectionString = connString;
                cn.Open();
                da.CommandText = sqlstr;
                da.Connection = cn;
                if (Convert.ToInt16(da.ExecuteScalar().ToString()) == 0)
                {
                    sqlstr = "SELECT COUNT(*) FROM dbo.login WHERE phone='" + Part_Phone.Text + "'";
                    da.CommandText = sqlstr;
                    da.Connection = cn;
                    if (Convert.ToInt16(da.ExecuteScalar().ToString()) == 0)
                    {
                        sqlstr = "insert into dbo.login (id,password,name,phone,sex,birthday,point,type,Hand) values ('" + Part_Id.Text + "','" + Part_password1.Text + "','" + Part_Name.Text + "','" +
                            Part_Phone.Text + "','" + Part_Sex.Text + "','" + Part_Birthday.Text + "',0,'part','" + Part_Hand.Text + "')";
                        da.CommandText = sqlstr;
                        da.Connection = cn;
                        int line = da.ExecuteNonQuery();
                        if (line > 0)
                        {
                            Session["UserId"] = Part_Id.Text;
                            Session["UserPassword"] = Part_password1.Text;
                            Session["Type"] = "part";
                            Response.Write("<script type=\"text/javascript\">alert(\"注册成功！\");location.href='main.aspx'</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert(\"注册失败，该号码已注册！\")</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert(\"注册失败，用户名已占用！\")</script>");
                }
                cn.Close();
            }
            catch
            {
                Response.Write("<script type=\"text/javascript\">alert(\"注册失败，数据库链接失败！\")</script>");
            }
        }
        else
        {
            Response.Write("<script type=\"text/javascript\">alert(\"数据错误或不完整！\")</script>");
        }

    }
}