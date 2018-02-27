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

    Private Sub main_Load(sender As Object, e As EventArgs) Handles Me.Load

        da = New SqlDataAdapter("select * from dbo.实验情况", cn)
        ds = New DataTable
        da.Fill(ds)
        Dim k As Integer = 0
        Dim j As Integer = 0
        Dim yy As Integer = 0
        Dim mm As Integer = 0
        Dim dd As Integer = 0
        Dim nyy As Integer = DateTime.Today.Year
        Dim nmm As Integer = DateTime.Today.Month
        Dim ndd As Integer = DateTime.Today.Day
        Dim cuttime As String
        While k + j < ds.Rows.Count
            cuttime = ds.Rows(k + j).Item(3).ToString
            yy = Left(ds.Rows(k + j).Item(3).ToString, 4)
            mm = Mid(ds.Rows(k + j).Item(3).ToString, 5, 2)
            dd = Right(ds.Rows(k + j).Item(3).ToString, 2)
            If (yy = nyy And mm = nmm And dd >= ndd Or (yy = nyy And mm > nmm) Or (yy > nyy)) Then
                expdataTables.Rows.Add(New TableRow)
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(0).Text = ds.Rows(k + j).Item(1).ToString
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(1).Text = yy & "-" & mm & "-" & dd
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(2).Text = ds.Rows(k + j).Item(4).ToString
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(3).Text = ds.Rows(k + j).Item(5).ToString
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(4).Text = ds.Rows(k + j).Item(6).ToString
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(5).Text = ds.Rows(k + j).Item(7).ToString
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(6).Text = ds.Rows(k + j).Item(9).ToString + "/" + ds.Rows(k + j).Item(10).ToString
                expdataTables.Rows(k + 1).Cells.Add(New TableCell)
                expdataTables.Rows(k + 1).Cells(7).Text = "<div title=" & Chr(34) & ds.Rows(k + j).Item(2).ToString & Chr(34) & ">查看详情</div>"
                k = k + 1
            Else
                j = j + 1
            End If
        End While


    End Sub
End Class
