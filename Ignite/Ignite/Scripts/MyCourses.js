$(document).ready(function () {
    $("li.state-tabs").on("click", function () {
   
        $("li.state-tabs").removeClass("active");
        $(this).addClass("active");
    })
})