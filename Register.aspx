<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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


    <script type="text/javascript">
        function onlyNum() {
            if(!(event.keyCode==46)&&!(event.keyCode==8)&&!(event.keyCode==37)&&!(event.keyCode==39))
            if(!((event.keyCode>=48&&event.keyCode<=57)||(event.keyCode>=96&&event.keyCode<=105)))
            event.returnValue=false;
        }
        function onlynumber(field) {
            field.value = field.value.replace(/[^\d]/g, '')
        }
    </script>

    <script type="text/javascript">
        function UserInputIsOk() {
            var Part_Id_Value = document.getElementById('<%=Part_Id.ClientID%>').value;
            var Part_password1_Value = document.getElementById('<%=Part_password1.ClientID%>').value;
            var Part_password2_Value = document.getElementById('<%=Part_password2.ClientID%>').value;
            var Part_Name_Value = document.getElementById('<%=Part_Name.ClientID%>').value; //?
            var Part_Phone_Value = document.getElementById('<%=Part_Phone.ClientID%>').value;
            var Part_Birthday_Value = document.getElementById('<%=Part_Birthday.ClientID%>').value;
            var Part_Sex_Value = document.getElementById('<%=Part_Sex.ClientID%>').value;
            var returnvalue = true;
            if (Part_Id_Value == '' || Part_Id_Value.length > 10) {
                document.getElementById('<%=Part_Id.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_Id.ClientID%>').style.borderColor = '#ccc'; }
            if (Part_password1_Value == '')
            {
                document.getElementById('<%=Part_password1.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_password1.ClientID%>').style.borderColor = '#ccc'; }
            if (Part_password2_Value == '')
            {
                document.getElementById('<%=Part_password2.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_password2.ClientID%>').style.borderColor = '#ccc'; }
            if (Part_password2_Value != Part_password1_Value)
            {
                document.getElementById('<%=Part_password1.ClientID%>').style.borderColor = '#B0171F';
                document.getElementById('<%=Part_password2.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            if (Part_Name_Value == '')
            {
                document.getElementById('<%=Part_Name.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_Name.ClientID%>').style.borderColor = '#ccc'; }
            if (Part_Phone_Value == ''|| Part_Phone_Value.length!=11)
            {
                document.getElementById('<%=Part_Phone.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_Phone.ClientID%>').style.borderColor = '#ccc'; }
            if (Part_Birthday_Value == '')
            {
                document.getElementById('<%=Part_Birthday.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_Birthday.ClientID%>').style.borderColor = '#ccc'; }
            if (Part_Sex_Value == '')
            {
                document.getElementById('<%=Part_Sex.ClientID%>').style.borderColor = '#B0171F';
                returnvalue = false
            }
            else { document.getElementById('<%=Part_Sex.ClientID%>').style.borderColor = '#ccc'; }

            return returnvalue;
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

        </nav>
        <div class="loginpage">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">注册</h1>
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
                                            <label class="font_exp_title">账号</label>
                                            <asp:TextBox ID="Part_Id" runat="server" CssClass="form-control" MaxLength="49" placeholder="请输入账号" autocomplete="off"></asp:TextBox>
                                            <p class="help-block">请输入账号~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">密码</label>
                                            <asp:TextBox ID="Part_password1" runat="server" CssClass="form-control" MaxLength="49" placeholder="请输入密码" autocomplete="off" TextMode="Password"></asp:TextBox>
                                            <p class="help-block">请输入密码~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">确认密码</label>
                                            <asp:TextBox ID="Part_password2" runat="server" CssClass="form-control" MaxLength="49" placeholder="请再次输入密码" autocomplete="off" TextMode="Password"></asp:TextBox>
                                            <p class="help-block">请再次输入密码~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">姓名</label>
                                            <asp:TextBox ID="Part_Name" runat="server" CssClass="form-control" MaxLength="10" placeholder="请输入姓名" autocomplete="off" ></asp:TextBox>
                                            <p class="help-block">请输入姓名~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">联系方式</label>
                                            <asp:TextBox ID="Part_Phone" runat="server" CssClass="form-control" MaxLength="12" placeholder="请输入联系方式" autocomplete="off" onafterpaste="this.value=this.value.replace(/[^\d]/g,'')" onkeydown="onlyNum();" style="ime-mode:Disabled"></asp:TextBox>
                                            <p class="help-block">请输入联系方式~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">性别</label>
                                            <asp:DropDownList ID="Part_Sex" runat="server" CssClass="form-control">
                                                <asp:ListItem Selected="True" disabled="True"></asp:ListItem>
                                                <asp:ListItem>男</asp:ListItem>
                                                <asp:ListItem>女</asp:ListItem>
                                                <asp:ListItem>其他</asp:ListItem>
                                            </asp:DropDownList>
                                            <p class="help-block">请选择性别~</p>
                                        </div>
                                        <br />
                                        <div class="form-group">
                                            <label class="font_exp_title">生日</label>
                                            <asp:TextBox ID="Part_Birthday" runat="server" value="" CssClass="form-control" autocomplete="off" onfocus="this.blur()" placeholder="请选择实验日期"></asp:TextBox>
                                            <p class="help-block">请选择出生日期~</p>
                                        </div>
                                        <br />
                                        <asp:Button ID="upload" runat="server" Text="注 册" class="btn btn-default" OnClick="upload_Click"/> &nbsp;&nbsp;&nbsp;

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

    <script>
        $('#Part_Birthday').datetimepicker({
            todayButton: false,    //关闭选择今天按钮
            yearStart: 2000,     //设置最小年份
            yearEnd: 2050,        //设置最大年份
            timepicker: false,    //关闭时间选项
            format: 'Y/m/d',
        });
    </script>
</body>
</html>
