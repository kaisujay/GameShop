$(document).ready(function () {
    $("#myform").submit(function (e) {
        e.preventDefault();

        var insert = {};
        var formData = new FormData($("#myform")[0]);
        insert.GameName = formData.get("GameName");
        insert.Publisher = formData.get("Publisher");
        insert.PlayTime = formData.get("PlayTime");
        insert.ReleaseDate = formData.get("ReleaseDate");
        insert.GameType = formData.get("GameType");
        insert.Price = formData.get("Price");

        //var insert = {};
        //var FormDatas = $("#myform").serializeArray();
        ////console.log(FormDatas.name)
        ////console.log(FormDatas[1].name + " " + FormDatas[1].value)
        //for (var i = 0; i < FormDatas.length; i++) {
        //    if (FormDatas[i].name != "ConfirmPassword") {
        //        var key = FormDatas[i].name;
        //        var value = FormDatas[i].value;
        //        insert.key = value
        //        //alert(insert.key + " > " + value)
        //    }

        ////    //alert(FormDatas[i].name + " > " + FormDatas[i].value)
        //}

        $.ajax({
            type: "Post",
            url: "/Api/Games/",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(insert),
            success: function (data) {
                alert("Game Data Saved")
                //$("#label").text(data.Pages)
            }
        })


        //$.ajax({
        //    type: "GET",
        //    url: "/Api/Games/",
        //    dataType: "Json",
        //    contentType: "Application/Json",
        //    success: function (data) {
        //        //$("#PlayerName").val(data.Nam)
        //        alert(data.PlayerName)
        //    }
        //})

    })
});