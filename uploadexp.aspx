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
                                <div class="col-lg-6">
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
                                            &nbsp;&nbsp;&nbsp;
                                            <input type="button" class="form-control-buttondetail" value="提 交" onclick="detailtime_button()"/>
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
                                        <div class="form-group">
                                            <label>Static Control</label>
                                            <p class="form-control-static">email@example.com</p>
                                        </div>
                                        <div class="form-group">
                                            <label>File input</label>
                                            <input type="file">
                                        </div>
                                        <div class="form-group">
                                            <label>Text area</label>
                                            <textarea class="form-control" rows="3"></textarea>
                                        </div>
                                        <div class="form-group">
                                            <label>Checkboxes</label>
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" value="">Checkbox 1
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" value="">Checkbox 2
                                                </label>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox" value="">Checkbox 3
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Inline Checkboxes</label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox">1
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox">2
                                            </label>
                                            <label class="checkbox-inline">
                                                <input type="checkbox">3
                                            </label>
                                        </div>
                                        <div class="form-group">
                                            <label>Radio Buttons</label>
                                            <div class="radio">
                                                <label>
                                                    <input type="radio" name="optionsRadios" id="optionsRadios1" value="option1" checked>Radio 1
                                                </label>
                                            </div>
                                            <div class="radio">
                                                <label>
                                                    <input type="radio" name="optionsRadios" id="optionsRadios2" value="option2">Radio 2
                                                </label>
                                            </div>
                                            <div class="radio">
                                                <label>
                                                    <input type="radio" name="optionsRadios" id="optionsRadios3" value="option3">Radio 3
                                                </label>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Inline Radio Buttons</label>
                                            <label class="radio-inline">
                                                <input type="radio" name="optionsRadiosInline" id="optionsRadiosInline1" value="option1" checked>1
                                            </label>
                                            <label class="radio-inline">
                                                <input type="radio" name="optionsRadiosInline" id="optionsRadiosInline2" value="option2">2
                                            </label>
                                            <label class="radio-inline">
                                                <input type="radio" name="optionsRadiosInline" id="optionsRadiosInline3" value="option3">3
                                            </label>
                                        </div>
                                        <div class="form-group">
                                            <label>Selects</label>
                                            <select class="form-control">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                            </select>
                                        </div>
                                        <div class="form-group">
                                            <label>Multiple Selects</label>
                                            <select multiple class="form-control">
                                                <option>1</option>
                                                <option>2</option>
                                                <option>3</option>
                                                <option>4</option>
                                                <option>5</option>
                                            </select>
                                        </div>
                                        <button type="submit" class="btn btn-default">Submit Button</button>
                                        <button type="reset" class="btn btn-default">Reset Button</button>
                                    </form>
                                </div>
                                <!-- /.col-lg-6 (nested) -->
                                <div class="col-lg-6">
                                    <h1>Disabled Form States</h1>
                                    <form role="form">
                                        <fieldset disabled>
                                            <div class="form-group">
                                                <label for="disabledSelect">Disabled input</label>
                                                <input class="form-control" id="disabledInput" type="text" placeholder="Disabled input" disabled>
                                            </div>
                                            <div class="form-group">
                                                <label for="disabledSelect">Disabled select menu</label>
                                                <select id="disabledSelect" class="form-control">
                                                    <option>Disabled select</option>
                                                </select>
                                            </div>
                                            <div class="checkbox">
                                                <label>
                                                    <input type="checkbox">Disabled Checkbox
                                                </label>
                                            </div>
                                            <button type="submit" class="btn btn-primary">Disabled Button</button>
                                        </fieldset>
                                    </form>
                                    <h1>Form Validation States</h1>
                                    <form role="form">
                                        <div class="form-group has-success">
                                            <label class="control-label" for="inputSuccess">Input with success</label>
                                            <input type="text" class="form-control" id="inputSuccess">
                                        </div>
                                        <div class="form-group has-warning">
                                            <label class="control-label" for="inputWarning">Input with warning</label>
                                            <input type="text" class="form-control" id="inputWarning">
                                        </div>
                                        <div class="form-group has-error">
                                            <label class="control-label" for="inputError">Input with error</label>
                                            <input type="text" class="form-control" id="inputError">
                                        </div>
                                    </form>
                                    <h1>Input Groups</h1>
                                    <form role="form">
                                        <div class="form-group input-group">
                                            <span class="input-group-addon">@</span>
                                            <input type="text" class="form-control" placeholder="Username">
                                        </div>
                                        <div class="form-group input-group">
                                            <input type="text" class="form-control">
                                            <span class="input-group-addon">.00</span>
                                        </div>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon"><i class="fa fa-eur"></i>
                                            </span>
                                            <input type="text" class="form-control" placeholder="Font Awesome Icon">
                                        </div>
                                        <div class="form-group input-group">
                                            <span class="input-group-addon">$</span>
                                            <input type="text" class="form-control">
                                            <span class="input-group-addon">.00</span>
                                        </div>
                                        <div class="form-group input-group">
                                            <input type="text" class="form-control">
                                            <span class="input-group-btn">
                                                <button class="btn btn-default" type="button"><i class="fa fa-search"></i>
                                                </button>
                                            </span>
                                        </div>
                                    </form>
                                </div>
                                <!-- /.col-lg-6 (nested) -->
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
