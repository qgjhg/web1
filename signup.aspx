<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
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

    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />


    <link href="../css/timepickerbox.css" rel="stylesheet" type="text/css"/>

</head>
<body>
    <div id="wrapper">

        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="main.aspx">心理学实验报名网</a>
            </div>
            <!-- /.navbar-header -->

            <ul class="nav navbar-top-links navbar-right">
                <!-- /.dropdown -->
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-fw"></i> <i class="fa fa-caret-down"></i>
                    </a>
                    <ul class="dropdown-menu dropdown-user">
                        <li><a href="#"><i class="fa fa-user fa-fw"></i> 用户信息</a>
                        </li>
                        <li><a href="#"><i class="fa fa-gear fa-fw"></i> 设置</a>
                        </li>
                        <li class="divider"></li>
                        <li><a href="login.aspx"><i class="fa fa-sign-out fa-fw"></i> 登出</a>
                        </li>
                    </ul>
                    <!-- /.dropdown-user -->
                </li>
                <!-- /.dropdown -->
            </ul>
            <!-- /.navbar-top-links -->

            <div class="navbar-default sidebar" role="navigation">
                <div class="sidebar-nav navbar-collapse">
                    <div id="type_diff" runat="server">
                    </div>   
                </div>
                <!-- /.sidebar-collapse -->
            </div>
            <!-- /.navbar-static-side -->
        </nav>

                <div id="page-wrapper">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">实验报名</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">

                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server">
                            <div class="row">
                                <div class="col-lg-12">
                                    <form role="form" runat="server">
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="font_exp_title">实验ID</label>
                                            <asp:TextBox ID="Exp_Id" runat="server" CssClass="form-control" onfocus="this.blur()" ReadOnly="True" autocomplete="off"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="font_exp_title">实验信息</label>
                                            <asp:TextBox ID="Exp_Info" runat="server" Rows="6" CssClass="form-control input_asp_box_multiline" onfocus="this.blur()" ReadOnly="True" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <div class="form-group">
                                            <label class="font_exp_title">个人信息</label>
                                            <asp:TextBox ID="Part_Info" runat="server" Rows="6" CssClass="form-control input_asp_box_multiline" onfocus="this.blur()" ReadOnly="True" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="col-lg-12">
                                        <div class="form-group">
                                            <label class="font_exp_title">详情与注意事项</label>
                                            <asp:TextBox ID="Exp_Warn" runat="server" Rows="6" CssClass="form-control input_asp_box_multiline" onfocus="this.blur()" ReadOnly="True" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                            <p class="help-block">请仔细阅读实验注意事项！~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">请选择参加实验时段</label>
<%--                                            <asp:DropDownList ID = "Exp_TimeChoose" runat = "server" CssClass = "form-control">

                                            </asp:DropDownList>--%>
                                            <select id="Exp_TimeChoose" runat="server" class = "form-control">

                                            </select>
                                        </div>
                                        <br />
                                        <asp:Button ID="apply_button" runat="server" Text="报 名" class="btn btn-default" OnClick="apply_button_Click"/> &nbsp;&nbsp;&nbsp;
                                    </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            
        </div>
        <!-- /#page-wrapper -->
        <!-- /#page-wrapper -->

    </div>
    <!-- /#wrapper -->


    <!-- jQuery -->
    <script src="../vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>
    <!-- get data -->
    <script src="js/getdata.js"></script>
</body>
</html>
