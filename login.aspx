<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>心理学实验参与者招募网</title>
    <link rel="stylesheet" href="CSS.css" type="text/css" />
</head>
<body>
<div class="bg-div"></div>

<div runat ="server" class="signin">
	<img class="user-avater" src="images/user-4.png"/>
	
	<div class="box">
		<form runat="server" class="signin-form" method="post">
            <div id="response" runat="server" class="response_div"></div>
			<div >
                <asp:TextBox ID="name" runat="server" class="form-control form-input" placeholder="用户名"></asp:TextBox>
			</div>
			<div class="" style="margin: 20px 0;">
                <asp:TextBox ID="password" runat="server" class="form-control form-input" placeholder="密   码" type="password"></asp:TextBox>
			</div>
            <asp:Button ID="login_btn" runat="server" class="btn btn-primary btn-submit" Text="登&nbsp;&nbsp;录" OnClick="login_btn_Click" />
        <span class="signup">还没有账户？立即<a class="signup-a" href="#">注册</a></span>
		</form>
	</div>
</div>
</body>
</html>
