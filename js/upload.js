
        function textCounter(field, maxlimit) {
            if (field.value.length > maxlimit)
                field.value = field.value.substring(0, maxlimit);
        }

        function add_min(field) {
            field.value = field.value.replace(/[^\d]/g, '')
            if (Number(field.value) > 480) {
                field.value = '480';
            }
        }

        function onlyNum() {
            if(!(event.keyCode==46)&&!(event.keyCode==8)&&!(event.keyCode==37)&&!(event.keyCode==39))
                if(!((event.keyCode>=48&&event.keyCode<=57)||(event.keyCode>=96&&event.keyCode<=105)))
                    event.returnValue=false;
        }
    
        function getselect() {
            var n = document.getElementById('<%=Exp_DetailTime.ClientID%>');
            var v = '';
            for (var i = 0; i < n.options.length; i++) {
                if (i == 0) {
                    v = n.options[i].value;
                } else {
                    v += '|' + n.options[i].value;
                }
            }
            var choosetimefield = document.getElementById('<%=ChooseTime.ClientID%>');
            choosetimefield.value = v;
        }

        function detailtime_button() {
            var detailtimebox = document.getElementById('<%=Exp_DetailTime.ClientID%>');
            var starttime = document.getElementById('Exp_choosetime').value;
            var contime = document.getElementById('<%=Exp_Time.ClientID%>').value;
            var num = document.getElementById('Exp_choosenumber').value;
            if (Number(contime) > 0 && Number(contime) <= 480 && starttime != "") {
                var starttimehourvalue = Number(starttime.substring(0, 2));
                var starttimeminvalue = Number(starttime.substring(3, 5));
                var endtimehourvalue = starttimehourvalue + parseInt(contime / 60);
                var endtimeminvalue = starttimeminvalue + (contime % 60);
                if (endtimeminvalue >= 60) {
                    endtimehourvalue = endtimehourvalue + 1;
                    endtimeminvalue = endtimeminvalue - 60;
                }
                if (detailtimebox.options.length < 15) {
                    if (endtimehourvalue < 24 && endtimehourvalue >= 0 && endtimeminvalue >= 0 && endtimeminvalue < 60) {
                        if (endtimehourvalue >= 0 && endtimehourvalue < 10) {
                            if (endtimeminvalue >= 0 && endtimeminvalue < 10) {
                                var optiontxt = starttime + ' - ' + '0' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';  人数：0/' + num;
                                var optionval = starttime + ' - ' + '0' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';0;' + num;
                                detailtimebox.options.add(new Option(optiontxt, optionval));
                            } else {
                                var optiontxt = starttime + ' - ' + '0' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';  人数：0/' + num;
                                var optionval = starttime + ' - ' + '0' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';0;' + num;
                                detailtimebox.options.add(new Option(optiontxt, optionval));
                            }

                        }
                        else {
                            if (endtimeminvalue >= 0 && endtimeminvalue < 10) {
                                detailtimebox.value = detailtimebox.value + starttime + ' - ' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';  人数：0/' + num + ';\n';
                                var optiontxt = starttime + ' - ' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';  人数：0/' + num;
                                var optionval = starttime + ' - ' + endtimehourvalue.toString() + ':' + '0' + endtimeminvalue.toString() + ';0;' + num;
                                detailtimebox.options.add(new Option(optiontxt, optionval));
                            } else {
                                detailtimebox.value = detailtimebox.value + starttime + ' - ' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';  人数：0/' + num + ';\n';
                                var optiontxt = starttime + ' - ' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';  人数：0/' + num;
                                var optionval = starttime + ' - ' + endtimehourvalue.toString() + ':' + endtimeminvalue.toString() + ';0;' + num;
                                detailtimebox.options.add(new Option(optiontxt, optionval));
                            }
                        }
                    }
                    if (endtimehourvalue >= 24) { alert('计算所得结束时间将超过当天！'); }
                } else {
                    alert('要多休息~一天最多做15条实验哇~');
                }
            } else {
                alert('请输入合适的实验时长与开始时间！');
            }
        }
function detailtime_button_undo()
{
    var detailtimebox = document.getElementById('<%=Exp_DetailTime.ClientID%>');
    if (detailtimebox.value != "")
    {
        var index=detailtimebox.selectedIndex;
        detailtimebox.options.remove(index);
    }
}
function detailtime_button_clear()
{
    var detailtimebox = document.getElementById('<%=Exp_DetailTime.ClientID%>');
    detailtimebox.options.length = 0;
}


function UserInputIsOk() {
    var Exp_Name_Value = document.getElementById('<%=Exp_Name.ClientID%>').value;
    var Exp_Start_Value = document.getElementById('<%=Exp_Start.ClientID%>').value;
    var Exp_Time_Value = document.getElementById('<%=Exp_Time.ClientID%>').value;
    var Exp_School_Value = document.getElementById('<%=Exp_School.ClientID%>').value; //?
    var Exp_Pos_Value = document.getElementById('<%=Exp_Pos.ClientID%>').value;
    var Exp_Reward_Value = document.getElementById('<%=Exp_Reward.ClientID%>').value;
    var Exp_Warn_Value = document.getElementById('<%=Exp_Warn.ClientID%>').value;
    var returnvalue = true;
    if (Exp_Name_Value == '' || Exp_Name_Value.length > 10) {
        document.getElementById('<%=Exp_Name.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_Name.ClientID%>').style.borderColor = '#ccc'; }
    if (Exp_Start_Value == '') {
        document.getElementById('<%=Exp_Start.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_Start.ClientID%>').style.borderColor = '#ccc'; }
    if (Exp_Time_Value = '' || Number(Exp_Time_Value) <= 0 || Number(Exp_Time_Value) > 480) {
        document.getElementById('<%=Exp_Time.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_Time.ClientID%>').style.borderColor = '#ccc'; }
    if (Exp_School_Value == '') {
        document.getElementById('<%=Exp_School.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_School.ClientID%>').style.borderColor = '#ccc'; }
    if (Exp_Pos_Value == '') {
        document.getElementById('<%=Exp_Pos.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_Pos.ClientID%>').style.borderColor = '#ccc'; }
    if (Exp_Reward_Value == '') {
        document.getElementById('<%=Exp_Reward.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_Reward.ClientID%>').style.borderColor = '#ccc'; }
    if (Exp_Warn_Value == '') {
        document.getElementById('<%=Exp_Warn.ClientID%>').style.borderColor = '#B0171F';
        returnvalue = false
    }
    else { document.getElementById('<%=Exp_Warn.ClientID%>').style.borderColor = '#ccc'; }

    if (returnvalue) {
        var n = document.getElementById('<%=Exp_DetailTime.ClientID%>');
        var v = '';
        for (var i = 0; i < n.options.length; i++) {
            if (i == 0) {
                v = n.options[i].value;
            } else {
                v += '|' + n.options[i].value;
            }
        }
        var choosetimefield = document.getElementById('<%=ChooseTime.ClientID%>');
        choosetimefield.value = v;
    }
    else {
        alert("内容未填写完成~");
        return false;
    }
    return returnvalue;
}