<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Myexperiment.aspx.cs" Inherits="Myexperiment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <title>心理学实验报名网</title>

    <!-- Bootstrap Core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- MetisMenu CSS -->
    <link href="../vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />

    <!-- DataTables CSS -->
    <link href="../vendor/datatables-plugins/dataTables.bootstrap.css" rel="stylesheet" />

    <!-- DataTables Responsive CSS -->
    <link href="../vendor/datatables-responsive/dataTables.responsive.css" rel="stylesheet" />

    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- time picker -->
    <link rel="stylesheet" type="text/css" href="../css/jquery.datetimepicker.css" />

    <!-- time picker -->
    <link href="css/timepickerbox.css" rel="stylesheet" type="text/css"/>
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
                    <h1 class="page-header">我的实验</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">

                        </div>
                        <div class="panel-body">
                                    <form role="form" runat="server">
                                        <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                                            <div class="form-group">
                                                <label class="font_exp_title">进行中</label>
                                            </div>
                                        </div>
                                        <div class="col-lg-6 col-sm-12 col-md-12 col-xs-12">
                                            <div class="form-group">     
                                                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">                                               
                                                    <asp:TextBox ReadOnly="true" Visible="false" ID="Exp_ID_1" runat="server" CssClass="input_asp_box_single_noborder" autocomplete="off"></asp:TextBox>   
                                                </div>
                                                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">                                               
                                                    <asp:TextBox ReadOnly="true" Visible="false" ID="Exp_Status_1" runat="server" CssClass="input_asp_box_single_noborder" autocomplete="off"></asp:TextBox>   
                                                </div>                                           
                                                <div class="col-lg-5 col-sm-12 col-md-12 col-xs-12"> 
                                                    <asp:TextBox ID="Exp_Info_1" runat="server" Rows="6" CssClass="input_asp_box_multiline_noborder" onfocus="this.blur()" autocomplete="off" TextMode="MultiLine"></asp:TextBox>   
                                                </div>
                                                <div class="col-lg-5 col-sm-12 col-md-12 col-xs-12"> 
                                                    <asp:TextBox Visible="false" ID="Exp_Detail_1" runat="server" Rows="6" CssClass="input_asp_box_multiline_noborder" onfocus="this.blur()" autocomplete="off" TextMode="MultiLine"></asp:TextBox>   
                                                </div>    
                                                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">
                                                    <asp:Button Visible="false" ID="undo1" runat="server" Text="取消报名" class="btn btn-default" OnClick="undo1_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-lg-6 col-sm-12 col-md-12 col-xs-12">
                                            <div class="form-group">
                                                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">                                               
                                                    <asp:TextBox ReadOnly="true" Visible="false" ID="Exp_ID_2" runat="server" CssClass="input_asp_box_single_noborder" autocomplete="off"></asp:TextBox>   
                                                </div>
                                                <div class="col-lg-12 col-sm-12 col-md-12 col-xs-12">                                               
                                                    <asp:TextBox ReadOnly="true" Visible="false" ID="Exp_Status_2" runat="server" CssClass="input_asp_box_single_noborder" autocomplete="off"></asp:TextBox>   
                                                </div>
                                                <div class="col-lg-5 col-sm-12 col-md-12 col-xs-12"> 
                                                    <asp:TextBox Visible="false" ID="Exp_Info_2" runat="server" Rows="6" CssClass="input_asp_box_multiline_noborder" onfocus="this.blur()" autocomplete="off" TextMode="MultiLine"></asp:TextBox>   
                                                </div>
                                                <div class="col-lg-5 col-sm-12 col-md-12 col-xs-12"> 
                                                    <asp:TextBox Visible="false" ID="Exp_Detail_2" runat="server" Rows="6" CssClass="input_asp_box_multiline_noborder" onfocus="this.blur()" autocomplete="off" TextMode="MultiLine"></asp:TextBox>   
                                                </div>    
                                                <div class="col-lg-6 col-sm-12 col-md-12 col-xs-12">
                                                    <asp:Button Visible="false" ID="undo2" runat="server" Text="取消报名" class="btn btn-default" OnClick="undo2_Click" />
                                                </div>
                                            </div>
                                        </div>
                                        <br />
                                        <div class="col-lg-12 col-xs-12 col-md-12 col-sm-12">
                                        <hr style=" height:1px;border:none;border-top:1px solid lightgray;" />
                                        <br />
                                            <label class="font_exp_title">历史记录</label>
                                            <div class="form-group">
                                                <div class="panel-body" runat="server" id="table_div">

                                                </div>
                                            </div>
                                        </div>
                                        <asp:HiddenField ID="HiddenThings" runat="server" />


                                    </form>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
        </div>
    </div>
    <!-- /#wrapper -->

    <!-- jQuery -->
    <script src="../vendor/jquery/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script src="../vendor/metisMenu/metisMenu.min.js"></script>

    <!-- DataTables JavaScript -->
    <script src="../vendor/datatables/js/jquery.dataTables.min.js"></script>
    <script src="../vendor/datatables-plugins/dataTables.bootstrap.min.js"></script>
    <script src="../vendor/datatables-responsive/dataTables.responsive.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>

    <!-- timepicker -->
    <script src="../js/jquery.datetimepicker.full.js"></script>

    <script>
       
    $(document).ready(function() {
        $("#expdataTables").DataTable({
            responsive: true
        });
    });
    </script>
</body>

</html>
