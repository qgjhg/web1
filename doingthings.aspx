<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doingthings.aspx.cs" Inherits="doingthings" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>心理学实验报名网</title>

    <!-- Bootstrap Core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="../vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />

    <link href="css/timepickerbox.css" rel="stylesheet" />

</head>
<body>
    <div class="panel">
        
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
            <form id="form1" runat="server">
            <div class="form-control">
                <asp:TextBox Visible="false" ID="TextBox1" MaxLength="254" CssClass="form-control input_asp_box_multiline" Rows="8" runat="server" placeholder="请输入拒绝理由" autocomplete="off" TextMode="MultiLine"></asp:TextBox>

            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
                <div id="download" runat="server" class="col-lg-12">

                </div>
                <asp:Button ID="Button1" runat="server" Text="确认" CssClass="btn btn-default" OnClick="Button1_Click" Visible="False" />
            </div>
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </form>
            </div>
                </div>
        </div>
    </div>

    <!-- jQuery -->
    <script src="../vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>
</body>
</html>
