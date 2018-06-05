<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Games_choose.aspx.cs" Inherits="Games_Games_choose" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>乱入的小游戏</title>
    
    <!-- Bootstrap Core CSS -->
    <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Game CSS -->
    <link href="../css/Gamepage.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <div class="game_title">
        选择游戏
    </div>
    <div>
    
        <div class='sudu_imgbox'>
        <div id="suduku" class='sudu_img' onclick="window.location.href='../Games/Games_introsudu.aspx'">
        <image class='sudu_img' mode='scaleToFill' src="../images/suduku.jpg"></image>

        <div class='sudu_imginfo'>数独</div>
        </div>
        <div class='sudu_blackview'></div>
        <div class='sudu_img'>
        <image id='doing1' style='background-color:#F2F2F2' class='sudu_img' mode='scaleToFill' src=""></image>
        <div class='sudu_imginfo'>未完成</div>
        </div>
        </div>

        <div class='sudu_imgbox'>
        <div class='sudu_img'>
        <image id='doing2' style='background-color:#F2F2F2' class='sudu_img' mode='scaleToFill' src=""></image>
        <div class='sudu_imginfo'>未完成</div>
        </div>
        <div class='sudu_blackview'></div>
        <div class='sudu_img'>
        <image id='doing3' style='background-color:#F2F2F2' class='sudu_img' mode='scaleToFill' src=""></image>
        <div class='sudu_imginfo'>未完成</div>
        </div>
        </div>


    </div>
    </form>
    <script>

    </script>
</body>
</html>
