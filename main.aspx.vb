'2016.04 被试招募网站，搁浅
'2018.01 重启项目
'mainpage.aspx
'syw
Imports System.Data                                                         '数据库必备
Imports System.Data.SqlClient                                               '数据库必备
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
        table_html = " <!-- /.table-responsive --> <table width=" & Chr(34) & "100%" & Chr(34) & " class=" & Chr(34) & "table table-striped table-bordered table-hover" & Chr(34) & " id=" & Chr(34) & "expdataTables" & Chr(34) & "><thead><tr><th>实验名称</th><th>日期</th><th>校区</th><th>地点</th><th>时长</th><th>报酬</th><th>报名情况</th><th>查看详情</th>   </tr></thead><tbody>"
        da = New SqlDataAdapter("select * from dbo.实验情况", cn)
        ds = New DataTable
        da.Fill(ds)
        Dim k As Integer = 0
        Dim j As Integer = 0
        Dim ntime As Integer = DateTime.Today.Year * 10000 + DateTime.Today.Month * 100 + DateTime.Today.Day
        Dim cuttime As Integer
        While k + j < ds.Rows.Count
            cuttime = ds.Rows(k + j).Item(3)
            If (cuttime >= ntime) Then
                table_html = table_html + "<tr><td>" & ds.Rows(k + j).Item(1).ToString & "</td>"
                table_html = table_html + "<td>" & cuttime.ToString & "</td>"
                table_html = table_html + "<td>" & ds.Rows(k + j).Item(4).ToString & "</td>"
                table_html = table_html + "<td>" & ds.Rows(k + j).Item(5).ToString & "</td>"
                table_html = table_html + "<td>" & ds.Rows(k + j).Item(6).ToString & "</td>"
                table_html = table_html + "<td>" & ds.Rows(k + j).Item(7).ToString & "</td>"
                table_html = table_html + "<td>" & ds.Rows(k + j).Item(9).ToString & "/" & ds.Rows(k + j).Item(10).ToString & "</td>"
                table_html = table_html + "<td><div title=" & Chr(34) & ds.Rows(k + j).Item(2).ToString & Chr(34) & ">查看详情</div></td></tr>"
                k = k + 1
            Else
                j = j + 1
            End If
        End While
        table_html = table_html & "</tbody></table>"
        table_div.InnerHtml = table_html

    End Sub
End Class
