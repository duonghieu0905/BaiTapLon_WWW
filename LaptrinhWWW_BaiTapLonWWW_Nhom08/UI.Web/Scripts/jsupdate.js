$(document).ready(function () {
   
    document.getElementById("Image").style.display = "none"; //bỏ
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
    $('.checktopic').change(function () {
        var checkedValue = "";
        var inputElements = document.getElementsByClassName('checktopic');
        for (var i = 0; inputElements[i]; ++i) {
            if (inputElements[i].checked) {
                checkedValue = checkedValue += inputElements[i].value + ",";
            }
        }
        checkedValue = checkedValue.substring(0, checkedValue.length - 1);
        $('#topicstring').val(checkedValue);
    });

});