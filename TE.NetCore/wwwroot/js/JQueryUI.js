$(document).ready(function () {
    $("#idBtn").button();
    $("#rect1").draggable();   ///可以拖动
    $("#rect2").droppable();   ///可放置drop
    $("#rect2").on("drop", function (event, ui) {
        $("#rect1").text("放置drop事件");
    });
    $("#rect3").resizable();  ///可以改变宽高大小
    $("#sortable").sortable();    //选中移动位置

    $("#btn").button();
    $("#select").selectable();
    $("#btn").on("click", function () {   //选择题选择提交
        if ($("#right").hasClass("ui-selected")) {
            alert("恭喜你答对了！");
        } else {
            alert("对不起，你答错了！");
        }
    });
    $("#Accordion").accordion();    //手风琴特效

    var autotags = ["html", "css", "javascript", "JQuery", "C#", "C++", "C", "java", "PHP", "asp.net", "Python"];
    $("#tags").autocomplete({    ///下拉选项
        source: autotags
    });

    $("#datepicker").datepicker();   //日期选择

    $("#menu").menu({ position: { at: "left bottom" } });   //菜单显示
    $("#input").spinner();
    $("#input").spinner("value", "5");   
    $("#spinnerbtn").button();  
    $("#spinnerbtn").click(function () {    //获取值
        alert($("#input").val());
    });
    $("#tabs").tabs();   //标签切换
    var slider = $("#slider");
    //slider.slider("option","10");
    slider.slider({
        //change: function (event, ui) {   ///拖动之后改变
        //    $("#sliderValue").text(slider.slider("option", "value"));
        //}   
        slide: function (event, ui) {   ///边拖动边改变
            $("#sliderValue").text(slider.slider("option", "value"));
        }
    })
});
var pb;
var max = 100;
var current = 0;
var itmout;
$(function () {     //弹出对话框
    $("#btnDiglog").button().on("click", function () {
        $("#dialog").dialog();
    });
    pb = $("#pb"); 
    pb.progressbar({ max: 100 });    //百分百进度条
    setInterval(changepb, 300);
});
function changepb() {     
    current++;
    if (current >= 100) {
        current = 0;
    }
    pb.progressbar("option", "value", current);
}

