<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Games_introsudu.aspx.cs" Inherits="Games_Games_introsudu" %>

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
        <div class="game_title">数独规则说明</div>
        <div class="sudu_txtbox">
            18世纪末，瑞士数学家欧拉发明了一种叫做“拉丁方阵（Latin Square）”的游戏。虽然最初这个游戏并没有风靡起来，但随着时间的推移，在20世纪70年代的美国，这个游戏以“数字拼图（Number Place）”的名字迅速流行起来，之后逐渐流传到日本、英国，到现在已经成为了红遍全球的智力游戏。
        </div>
        <div class="sudu_txtbox">
            <l style="font-weight:bolder">游戏具体规则如下：</l><br />
            在一个（9×9）的九宫格中给出一些初始数字。玩家需要在九宫格内填入缺失的数字（1-9），填入数字后满足：<br />
            1. 每一行的 9 个数字各不相同<br />
            2. 每一列的 9 个数字各不相同<br />
            3. 每一个标识出的3×3的小正方形内9个数字各不相同
        </div>
        <div class="sudu_centerbtn" style="font-weight:bolder">
            <button class="btn btn-default" style="width:100%">进入游戏</button>
        </div>
    </form>
    <script>
        function choosetype() {
            var r = confirm("选择游戏模式");
        }
    </script>
</body>
</html>
