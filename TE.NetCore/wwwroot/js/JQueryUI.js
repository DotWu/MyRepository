$(document).ready(function () {
    $("#idBtn").button();
    $("#rect1").draggable();   ///可以拖动
    $("#rect2").droppable();   ///可放置drop
    $("#rect2").on("drop", function (event, ui) {
        $("#rect1").text("放置drop事件");
    });
    $("#rect3").resizable();  ///可以改变款高大小
    $("#sortable").sortable();

    $("#btn").button();
    $("#select").selectable();
    $("#btn").on("click", function () {
        if ($("#right").hasClass("ui-selected")) {
            alert("恭喜你答对了！");
        } else {
            alert("对不起，你答错了！");
        }
    });
    $("#Accordion").accordion();

    var autotags = ["html", "css", "javascript", "JQuery", "C#", "C++", "C", "java", "PHP", "asp.net", "Python"];
    $("#tags").autocomplete({
        source: autotags
    });

    $("#datepicker").datepicker();
});

$(function () {
    $("#btnDiglog").button().on("click", function () {
        $("#dialog").dialog();
    });
});

