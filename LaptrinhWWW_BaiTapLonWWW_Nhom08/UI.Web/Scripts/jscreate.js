$(document).ready(function () {
    document.getElementById("Image").style.display = "none";
    CKEDITOR.replace("Description");
    CKEDITOR.instances["Description"].on('change', function () {
        var obj = CKEDITOR.instances["Description"].getData();
        $("#Description").val(obj);
    });
    $("#select").click(function () {
        var finder = new CKFinder();
        finder.selectActionFunction = function (fileUrl) {
            $("#review").attr("src", "../../.." + fileUrl);
            var str = String(fileUrl).replace("/Uploads/images/", "");
            $("#Image").val(str);
        };
        finder.popup();
    });

});