<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadexp.aspx.cs" Inherits="uploadexp" %>

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

    <!-- Custom CSS -->
    <link href="../dist/css/sb-admin-2.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <!-- time picker -->
    <link rel="stylesheet" type="text/css" href="../css/jquery.datetimepicker.css" />

    <!-- time picker -->
    <link href="../css/timepickerbox.css" rel="stylesheet" type="text/css"/>

    <!-- line control -->
    <script type="text/javascript">
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit)
                field.value = field.value.substring(0, maxlimit);
        }
    </script>

    <!-- add min -->
    <script type="text/javascript">
        function add_min(field) {
            field.value = field.value.replace(/[^\d]/g, '')
            if (Number(field.value) > 480) {
                field.value = '480';
            }
        }
    </script>
    <script type="text/javascript">
        function onlyNum() {
            if(!(event.keyCode==46)&&!(event.keyCode==8)&&!(event.keyCode==37)&&!(event.keyCode==39))
            if(!((event.keyCode>=48&&event.keyCode<=57)||(event.keyCode>=96&&event.keyCode<=105)))
            event.returnValue=false;
        }
    </script>
    
    <!-- detail time submit button -->
    <script type="text/javascript">
        function detailtime_button() {
            var detailtimebox = document.getElementById('<%=Exp_DetailTime.ClientID%>');
            var starttime = document.getElementById('Exp_choosetime').value;
            var contime = document.getElementById('<%=Exp_Time.ClientID%>').value;    
            var num = document.getElementById('Exp_choosenumber').value;
            if (Number(contime) > 0 && Number(contime) <= 480) {
                var starttimehourvalue = Number(starttime.substring(0, 2));
                var starttimeminvalue = Number(starttime.substring(3, 5));
                var endtimehourvalue = starttimehourvalue + parseInt(contime / 60);
                var endtimeminvalue = starttimeminvalue + (contime % 60);
                if (endtimeminvalue >= 60) {
                    endtimehourvalue = endtimehourvalue + 1;
                    endtimeminvalue = endtimeminvalue - 60;
                }
                if (endtimehourvalue < 24 && endtimehourvalue >= 0 && endtimeminvalue >= 0 && endtimeminvalue < 60) {
                    if (endtimehourvalue > 0 && endtimehourvalue < 10) {
                        if (endtimeminvalue > 0 && endtimeminvalue < 10) {
                            detailtimebox.value = detailtimebox.value + starttime + ' - ' + '0' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';  人数：' + num + ';\n';
                        } else {
                            detailtimebox.value = detailtimebox.value + starttime + ' - ' + '0' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';  人数：' + num + ';\n';
                        }

                    }
                    else {
                        if (endtimeminvalue > 0 && endtimeminvalue < 10) {
                            detailtimebox.value = detailtimebox.value + starttime + ' - ' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';  人数：' + num + ';\n';
                        } else {
                            detailtimebox.value = detailtimebox.value + starttime + ' - ' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';  人数：' + num + ';\n';
                        }
                    }
                }
                if (endtimehourvalue >= 24) { alert('计算所得结束时间将超过当天！'); }
            }
        }
        function detailtime_button_undo()
        {
            var detailtimebox = document.getElementById('<%=Exp_DetailTime.ClientID%>');
            if (detailtimebox.value != "")
            {
                var detailtimeboxvaluelength=detailtimebox.value.length;
                detailtimebox.value = detailtimebox.value.substring(0, detailtimeboxvaluelength - 22);
            }
        }
        function detailtime_button_clear()
        {
            var detailtimebox = document.getElementById('<%=Exp_DetailTime.ClientID%>');
            detailtimebox.value = "";
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
                    <h1 class="page-header">发布实验</h1>
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

                                        <div class="form-group">
                                            <label class="font_exp_title">实验名称</label>
                                            <asp:TextBox ID="Exp_Name" runat="server" CssClass="form-control" MaxLength="49" placeholder="请输入实验名称" autocomplete="off"></asp:TextBox>
                                            <p class="help-block">请输入实验名称（50字以内），好的名称更能吸引大家来参加哦~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">实验简介</label>
                                            <asp:TextBox ID="Exp_Intro" runat="server" CssClass="form-control input_asp_box_multiline" Rows="8" placeholder="请输入实验简介" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                            <p class="help-block">请输入实验简介（500字以内）~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">起止时间与实验时长</label>
                                            <br />
                                            <div class="div_centerbox">
                                            <asp:TextBox ID="Exp_Start" runat="server" value="" CssClass="form-control-timechoice1" autocomplete="off" onfocus="this.blur()" placeholder="请选择开始日期"></asp:TextBox>
                                            <asp:TextBox ID="Exp_End" runat="server" value="" CssClass="form-control-timechoice2" autocomplete="off" onfocus="this.blur()" placeholder="请选择结束日期"></asp:TextBox>
                                            <asp:TextBox ID="Exp_Time" runat="server" value="" CssClass="form-control-timechoice3" autocomplete="off" placeholder="请填写实验时长（分钟）" onafterpaste="this.value=this.value.replace(/[^\d]/g,'')" onkeydown="onlyNum();" style="ime-mode:Disabled" MaxLength="3" TextMode="SingleLine"></asp:TextBox>
                                            </div>
                                            <p class="help-block">请选择实验的开始和结束日期，并输入实验时长（分钟）~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">每天实验安排</label>
                                            <br />
                                            <div class="div_centerbox">
                                            <input id="Exp_choosetime" type="text" class="form-control-detail" autocomplete="off" onfocus="this.blur()" placeholder="每场实验开始时间" />
                                            <label class="help_label">人数：</label>
                                            <select id="Exp_choosenumber" class="form-control-detail2">
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="5">5</option>
                                                <option value="6">6</option>
                                                <option value="7">7</option>
                                                <option value="8">8</option>
                                                <option value="9">9</option>
                                            </select>
                                                <div class="div_threebutton">
                                                    <input type="button" class="form-control-buttondetail" value="添 加" onclick="detailtime_button()"/>
                                                    <input type="button" class="form-control-buttondetail2" value="撤 销" onclick="detailtime_button_undo()"/>
                                                    <input type="button" class="form-control-buttondetail3" value="清 空" onclick="detailtime_button_clear()"/>
                                                </div>
                                            </div>
                                            <br />
                                            <p class="help-block">请选择每场实验的开始时间以及每场实验人数~</p>
                                            <br />
                                            <asp:TextBox ID="Exp_DetailTime" runat="server" value="" CssClass="form-control input_asp_box_multiline" Rows="8" autocomplete="off" onfocus="this.blur()" placeholder="" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>                                     
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">实验地点</label>
                                            <asp:TextBox ID="Exp_Pos" runat="server" CssClass="form-control" MaxLength="49" placeholder="请输入实验地点" autocomplete="off"></asp:TextBox>
                                            <p class="help-block">请输入实验地点（50字以内）~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">报酬</label>
                                            <asp:TextBox ID="Exp_Reward" runat="server" CssClass="form-control" MaxLength="49" placeholder="请输入实验报酬" autocomplete="off"></asp:TextBox>
                                            <p class="help-block">请输入实验报酬（数字），其他非现金报酬请注明~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">注意事项</label>
                                            <asp:TextBox ID="Exp_Warn" runat="server" CssClass="form-control input_asp_box_multiline" Rows="8" placeholder="请输入注意事项" autocomplete="off" TextMode="MultiLine"></asp:TextBox>
                                            <p class="help-block">请输入实验的注意事项（500字以内）~</p>
                                        </div>
                                        <br />

                                        <asp:Button ID="upload" runat="server" Text="上 传" class="btn btn-default" OnClick="upload_Click"/> &nbsp;&nbsp;&nbsp;
                                        <button type="reset" class="btn btn-default">重 置</button>
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

    <!-- timepicker -->
    <script src="../js/jquery.datetimepicker.full.js"></script>
    <script>
    $('#Exp_Start').datetimepicker({
        todayButton: false,    //关闭选择今天按钮
        yearStart: 2000,     //设置最小年份
        yearEnd: 2050,        //设置最大年份
        timepicker: false,    //关闭时间选项
        format: 'Y/m/d',
    });
    $('#Exp_End').datetimepicker({
        todayButton: false,    //关闭选择今天按钮
        yearStart: 2000,     //设置最小年份
        yearEnd: 2050,        //设置最大年份
        timepicker: false,    //关闭时间选项
        format: 'Y/m/d',
    });
    $('#Exp_choosetime').datetimepicker({
        todayButton: false,    //关闭选择今天按钮
        datepicker: false,    //关闭时间选项
        format: 'H:i',
        step: 10
    });
    </script>

</body>

</html>
