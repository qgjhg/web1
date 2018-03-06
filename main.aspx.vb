'2016.04 被试招募网站，搁浅
'2018.01 重启项目
'mainpage.aspx
'syw
Imports System.Data                                                         '数据库必备
Imports System.Data.SqlClient                                               '数据库必备
Imports System.Text
Partial Class main
    Inherits System.Web.UI.Page
    Dim cnstr As String = "Server=.;Initial Catalog=PSYcollection;Integrated Security=False;User ID=sa;Password=shiyanwei123;" '数据库地址
    Dim cn As New SqlClient.SqlConnection(cnstr)                             '连接sql server
    Dim da As New SqlClient.SqlDataAdapter
    Dim ds As New DataTable
    Dim dbo As New SqlClient.SqlCommand
    Dim sqlstr As String
    Dim SessionValue As String = ""
    Dim table_html As String = ""

    Private Sub main_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("UserId") = "" Or Session("UserPassword") = "" Or Session("Type") = "" Then
            Response.Redirect("login.aspx")
        Else
            Try
                table_html = " <!-- /.table-responsive --> <table width=" & Chr(34) & "100%" & Chr(34) & " class=" & Chr(34) & "table table-striped table-bordered table-hover" & Chr(34) & " id=" & Chr(34) & "expdataTables" & Chr(34) & "><thead><tr><th>名称</th><th>日期</th><th>校区</th><th>时长</th><th>报酬</th><th>操作</th>   </tr></thead><tbody>"
                da = New SqlDataAdapter("select * from dbo.Exp_Situation", cn)
                ds = New DataTable
                da.Fill(ds)
                Dim k As Integer = 0
                Dim j As Integer = 0
                Dim ntime As Integer = DateTime.Today.Year * 10000 + DateTime.Today.Month * 100 + DateTime.Today.Day
                Dim cuttime As Integer
                While k + j < ds.Rows.Count
                    cuttime = ds.Rows(k + j).Item(2)
                    If (cuttime >= ntime And cuttime < ntime + 7) Then

                        table_html = table_html + "<tr title=" & Chr(34) & "详细地址：&#13 " & ds.Rows(k + j).Item(4).ToString & "&#13&#13简介与注意事项：&#13 " & ds.Rows(k + j).Item(7).ToString & "&#13&#13报名情况：&#13 " & Trim(ds.Rows(k + j).Item(9).ToString) & Chr(34) & ">"
                        table_html = table_html + "<td>" & ds.Rows(k + j).Item(1).ToString & "</td>"
                        table_html = table_html + "<td>" & cuttime.ToString & "</td>"
                        table_html = table_html + "<td>" & ds.Rows(k + j).Item(3).ToString & "</td>"
                        table_html = table_html + "<td>" & ds.Rows(k + j).Item(5).ToString & "min</td>"
                        table_html = table_html + "<td>" & ds.Rows(k + j).Item(6).ToString & "</td>"
                        table_html = table_html + "<td><a href=""signup.aspx?id=" & ds.Rows(k + j).Item(0).ToString & """>" & "报名" & "</a></td>"
                        table_html = table_html + "</tr>"
                        k = k + 1
                    Else
                        j = j + 1
                    End If
                End While
                table_html = table_html & "</tbody></table>"
                table_div.InnerHtml = table_html
            Catch

            End Try

            If (Session("Type") = "exp") Then
                Dim type_html As New StringBuilder
                type_html.Append("<ul class=" & Chr(34) & "nav" & Chr(34) & " id=" & Chr(34) & "side-menu" & Chr(34) & ">")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "main.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-dashboard fa-fw" & Chr(34) & "></i> 主页</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "Myexperment.aspx" & Chr(34) & " ><i class=" & Chr(34) & "fa fa-table fa-fw" & Chr(34) & "></i> 我的实验</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "uploadexp.aspx" & Chr(34) & " ><i class=" & Chr(34) & "fa fa-edit fa-fw" & Chr(34) & "></i> 发布实验</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "help.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-files-o fa-fw" & Chr(34) & "></i> 帮助</a>")
                type_html.Append("</li>")
                type_html.Append("</ul>")
                type_diff.InnerHtml = type_html.ToString
            ElseIf (Session("Type") = "admin") Then
                Dim type_html As New StringBuilder
                type_html.Append("<ul class=" & Chr(34) & "nav" & Chr(34) & " id=" & Chr(34) & "side-menu" & Chr(34) & ">")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "main.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-dashboard fa-fw" & Chr(34) & "></i> 主页</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "Myexperment.aspx" & Chr(34) & " ><i class=" & Chr(34) & "fa fa-table fa-fw" & Chr(34) & "></i> 我的实验</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "uploadexp.aspx" & Chr(34) & " ><i class=" & Chr(34) & "fa fa-edit fa-fw" & Chr(34) & "></i> 发布实验</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "help.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-files-o fa-fw" & Chr(34) & "></i> 帮助</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "management.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-wrench fa-fw" & Chr(34) & "></i> 管理</a>")
                type_html.Append("</li>")
                type_html.Append("</ul>")
                type_diff.InnerHtml = type_html.ToString
            Else

                Dim type_html As New StringBuilder
                type_html.Append("<ul class=" & Chr(34) & "nav" & Chr(34) & " id=" & Chr(34) & "side-menu" & Chr(34) & ">")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "main.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-dashboard fa-fw" & Chr(34) & "></i> 主页</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "Myexperment.aspx" & Chr(34) & " ><i class=" & Chr(34) & "fa fa-table fa-fw" & Chr(34) & "></i> Tables</a>")
                type_html.Append("</li>")
                type_html.Append("<li>")
                type_html.Append("<a href = " & Chr(34) & "help.aspx" & Chr(34) & "><i class=" & Chr(34) & "fa fa-files-o fa-fw" & Chr(34) & "></i> 帮助</a>")
                type_html.Append("</li>")
                type_html.Append("</ul>")
                type_diff.InnerHtml = type_html.ToString

            End If
            If (IsPostBack = False) Then
                Check_Exp.Attributes.Add("onclick", "return UserInputIsOk()")
            End If
        End If
    End Sub
    Protected Sub Check_Exp_Click(sender As Object, e As EventArgs) Handles Check_Exp.Click
        If Session("UserId") = "" Or Session("UserPassword") = "" Or Session("Type") = "" Then
            Response.Redirect("login.aspx")
        Else
            Try
                table_html = " <!-- /.table-responsive --> <table width=" & Chr(34) & "100%" & Chr(34) & " class=" & Chr(34) & "table table-striped table-bordered table-hover" & Chr(34) & " id=" & Chr(34) & "expdataTables" & Chr(34) & "><thead><tr><th>名称</th><th>日期</th><th>校区</th><th>时长</th><th>报酬</th><th>操作</th>   </tr></thead><tbody>"
                da = New SqlDataAdapter("select * from dbo.Exp_Situation", cn)
                ds = New DataTable
                da.Fill(ds)
                Dim k As Integer = 0
                Dim j As Integer = 0
                Dim startchecktime As Integer = Convert.ToInt32(Check_Start.Text.Replace("/", ""))
                Dim endchecktime As Integer = Convert.ToInt32(Check_End.Text.Replace("/", ""))
                Dim cuttime As Integer
                If (endchecktime >= startchecktime And endchecktime >= 0 And startchecktime >= 0) Then
                    While k + j < ds.Rows.Count
                        cuttime = ds.Rows(k + j).Item(2)
                        If (cuttime >= startchecktime And cuttime <= endchecktime) Then
                            table_html = table_html + "<tr title=" & Chr(34) & "详细地址：&#13 " & ds.Rows(k + j).Item(4).ToString & "&#13&#13简介与注意事项：&#13 " & ds.Rows(k + j).Item(7).ToString & "&#13&#13报名情况：&#13 " & Trim(ds.Rows(k + j).Item(9).ToString) & Chr(34) & ">"
                            table_html = table_html + "<td>" & ds.Rows(k + j).Item(1).ToString & "</td>"
                            table_html = table_html + "<td>" & cuttime.ToString & "</td>"
                            table_html = table_html + "<td>" & ds.Rows(k + j).Item(3).ToString & "</td>"
                            table_html = table_html + "<td>" & ds.Rows(k + j).Item(5).ToString & "min</td>"
                            table_html = table_html + "<td>" & ds.Rows(k + j).Item(6).ToString & "</td>"
                            table_html = table_html + "<td><a href=""signup.aspx?id=" & ds.Rows(k + j).Item(0).ToString & """>" & "报名" & "</a></td>"
                            table_html = table_html + "</tr>"
                            k = k + 1
                        Else
                            j = j + 1
                        End If
                    End While
                End If
                table_html = table_html & "</tbody></table>"
                table_div.InnerHtml = table_html
            Catch

            End Try
        End If
    End Sub
End Class
