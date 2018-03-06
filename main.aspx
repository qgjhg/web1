<%@ Page Language="VB" AutoEventWireup="false" CodeFile="main.aspx.vb" Inherits="main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>

    <meta charset="utf-8" />
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


    <link href="../css/MainCss.css" rel="stylesheet" type="text/css" />
    
    <!-- check input -->
    <script type="text/javascript">
        function UserInputIsOk()
        {
            var Start_Date = document.getElementById("<%=Check_Start.ClientID%>").value;
            var End_Date = document.getElementById("<%=Check_End.ClientID%>").value;
            var stastr = 0;
            var endstr = 0;
            stastr = Number(Start_Date.replace(/[^\d]/g, ''));
            endstr = Number(End_Date.replace(/[^\d]/g, ''));
            if (stastr > 0 && endstr > 0 && stastr <= endstr) {
                if (endstr - stastr > 10) {
                    alert('查询时间最长10天');
                    return false;
                }
                else
                {
                    return true;
                }
            } else
            {
                alert('查询时间选择错误');
                return false;
            }
        }
    </script>
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
                    <h1 class="page-header">当前实验</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <form  runat="server">
                            <label>输入起止日期查询：</label>
                            <asp:TextBox ID="Check_Start" runat="server" value="" CssClass="form-control-timechoice1" autocomplete="off" onfocus="this.blur()" placeholder="开始日期"></asp:TextBox>
                            <asp:TextBox ID="Check_End" runat="server" value="" CssClass="form-control-timechoice2" autocomplete="off" onfocus="this.blur()" placeholder="结束日期"></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Check_Exp" runat="server" class="btn btn-default" Text="查 询" />
                            </form>
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body" runat="server" id="table_div">

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

    <!-- DataTables JavaScript -->
    <script src="../vendor/datatables/js/jquery.dataTables.min.js"></script>
    <script src="../vendor/datatables-plugins/dataTables.bootstrap.min.js"></script>
    <script src="../vendor/datatables-responsive/dataTables.responsive.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>

    <script>
       
    $(document).ready(function() {
        $("#expdataTables").DataTable({
            responsive: true
        });
    });
    </script>

    <!-- time picker -->
    <link rel="stylesheet" type="text/css" href="../css/jquery.datetimepicker.css" />
    <!-- timepicker -->
    <script src="../js/jquery.datetimepicker.full.js"></script>
    <script>
    $('#Check_Start').datetimepicker({
        todayButton: false,    //关闭选择今天按钮
        yearStart: 2000,     //设置最小年份
        yearEnd: 2050,        //设置最大年份
        timepicker: false,    //关闭时间选项
        format: 'Y/m/d',
    });
    $('#Check_End').datetimepicker({
        todayButton: false,    //关闭选择今天按钮
        yearStart: 2000,     //设置最小年份
        yearEnd: 2050,        //设置最大年份
        timepicker: false,    //关闭时间选项
        format: 'Y/m/d',
    });
    </script>
</body>
</html>

