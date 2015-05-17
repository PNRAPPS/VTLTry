
function ShowLoading(content, text) {

    if (jQuery.type(content) === "string") {
        text = content;
        content = $("body");
    }
    else {
        content = $(content);
    }

    text = (text == undefined ? "" : text = "<div class='loadingText'>" + text + "</div>");
    var htmlAppend = "<div class='loadingPanel' style=''><div class='loadingContent'></div>" + text + "</div>";
    content.append(htmlAppend);
    $(".loadingPanel", content).hide();
    $(".loadingPanel", content).fadeToggle();

}

function HideLoading(content) {
    content = $(content == undefined ? "body" : content);
    setTimeout(function () {
        $(".loadingPanel", content).fadeToggle(function () {
            $(this).remove();
        });
    }, 1000)
}