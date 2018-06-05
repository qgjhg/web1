<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Games_login.aspx.cs" Inherits="Games_Games_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Legendary_pig Game Center</title>
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
                <asp:TextBox ID="name" runat="server" autocomplete="off" class="form-control form-input" placeholder="用户名"></asp:TextBox>
			</div>
			<div class="" style="margin: 20px 0;">
                <asp:TextBox ID="password" runat="server" autocomplete="off" class="form-control form-input" placeholder="密   码" type="password"></asp:TextBox>
			</div>
            <asp:Button ID="login_btn" runat="server" class="btn btn-primary btn-submit" Text="登&nbsp;&nbsp;录" OnClick="login_btn_Click" />
		</form>
	</div>
</div>
</body>
</html>
