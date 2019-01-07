var timoutid;
$(document).ready(function () {
    $(".main>a").click(function () {
        var ulNode = $(this).next("ul");
        /*if (ulNode.css("display") == "none") {
            ulNode.css("display", "block");
        } else {
            ulNode.css("display", "none");
        }
        ulNode.show();
        ulNode.hide();
        ulNode.toggle(this.normalize); //数字、slow、normal、fast
        ulNode.slideDown(1000);  
        ulNode.slideUp(1000);  */
        ulNode.slideToggle();
        changeIcon($(this));
    });
    $(".hmain").hover(function () {
        //$(this).children("ul").slideDown();
        $(this).children("ul").slideToggle();
        changeIcon($(this).children("a"));
    }, function () {
        //$(this).children("ul").slideUp();
        $(this).children("ul").slideToggle();
        changeIcon($(this).children("a"));
    });

    ///tab1
    $("#tabfirst li").each(function (index) {
        var liNode = $(this);
        liNode.mouseover(function () {
            timoutid = setTimeout(function () {
                $(".tab .contentShow").removeClass("contentShow");
                $("#tabfirst li.tabin").removeClass("tabin");
                $(".tab div").eq(index).addClass("contentShow");
                liNode.addClass("tabin");
            }, 300);
            //$(".tab .contentShow").removeClass("contentShow");
            //$("#tabfirst li .tabin").removeClass("tabin");
            //$(".tab div").eq(index).addClass("contentShow");
            //liNode.addClass("tabin");
        }).mouseout(function () {
            clearTimeout(timoutid);
        });
    });
    ///tab2
    //$("#tabsecond li").load("mytab.html");
    $("#tabsecond li").each(function (index) {
        var liNode = $(this);
        liNode.click(function () {
            $("#tabsecond li.tabin").removeClass("tabin");
            $(this).addClass("tabin");
            if (index == 0) {
                $("#myTab").load("../新文件夹/MyTab.html");
            } else if (index == 1) {
                $("#myTab").load("../新文件夹/SomeTab.html");
            } else if (index == 2) {
                $("#myTab").load("../新文件夹/InterData.html");
            }
        });
    });

});
function changeIcon(mainNode) {
    if (mainNode) {
        if (mainNode.css("background-image").indexOf("tab-close.png") >= 0) {
            mainNode.css("background-image", "url('../images/tab-open.png')");
        } else {
            mainNode.css("background-image", "url('../images/tab-close.png')");
        }
    }
}