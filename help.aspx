<%@ Page Language="C#" AutoEventWireup="true" CodeFile="help.aspx.cs" Inherits="help" %>

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

    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- time picker -->
    <link rel="stylesheet" type="text/css" href="../css/jquery.datetimepicker.css" />

    <!-- time picker -->
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
                    <h1 class="page-header">帮助</h1>
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
                            <div class="row">
                                <div class="col-lg-12">
                                    <form role="form" runat="server">
                                        <div>
                                            <h3>Bug反馈与改善建议</h3>
                                            <div class="col-lg-12">
                                                <h5>如发现bug或对本网站有任何意见与建议，请联系邮箱 <a>qgjhg@qq.com</a></h5>
                                            </div>
                                            <br />
                                            <br />
                                            <br />
                                            <h3>参与实验限制</h3>
                                            <div class="col-lg-12">
                                                <h5>为了确保实验数据的有效性，每人每天仅能参与一项实验，感谢您的理解。如果确实两项实验可连续做且不存在相互影响，主试会将其发布在同一实验条目下。</h5>
                                                <h5>每人最多允许同时报名两项实验（进行中或已接受状态）。</h5>
                                            </div>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <h3>如何有权发布实验？</h3>
                                            <div class="col-lg-12">
                                                <h5>发布者账号无法注册，请联系管理员添加权限。由于实验室数目的有限性，每名发布者最多允许有两条进行中的实验（包括实验当天）。</h5>
                                            </div>                                        
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <h3>移动端APP？</h3>
                                            <div class="col-lg-12">
                                                <h5>考虑使用微信小程序完成手机端任务（但目前要忙毕业&找工作，遥遥无期系列QAQ）。</h5>
                                            </div>                                        
                                        </div>


                                    </form>
                                </div>
                            </div>
                            <!-- /.row (nested) -->
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

    <!-- Custom Theme JavaScript -->
    <script src="../dist/js/sb-admin-2.js"></script>

    <!-- timepicker -->
    <script src="../js/jquery.datetimepicker.full.js"></script>
</body>
</html>
