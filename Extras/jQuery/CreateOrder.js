$(document).ready(function () {

    var PlayerList = "";
    $.ajax({
        type: "GET",
        url: "/Api/Players/",
        dataType: "Json",
        contentType: "Application/Json",

        success: function (data) {
            $.each(data, function (key, value) {
                PlayerList += "<option value='"+value.PlayerName + "'>" + value.PlayerName +"</option>";
            })
            $("#PlayerNameList").append(PlayerList);
        }
    })

    var GameList = "";
    $.ajax({
        type: "GET",
        url: "/Api/Games/",
        dataType: "Json",
        contentType: "Application/Json",

        success: function (data) {
            $.each(data, function (key, value) {
                GameList += "<option value='" + value.GameName + "'>" + value.GameName + "</option>";
            })
            $("#GameNameList").append(GameList);
        }
    })

    $("#myform").submit(function (e) {
        e.preventDefault();

        var insert = {};
        var formData = new FormData($("#myform")[0]);
        insert.PlayerName = formData.get("PlayerNameList");
        insert.GameName = formData.get("GameNameList");
        insert.DiscountPrice = formData.get("Discount");

        //console.log(insert.GameName + " " + insert.PlayerName + " " + insert.Discount);

        $.ajax({
            type: "Post",
            url: "/Api/Orders/",
            dataType: "json",
            contentType: 'application/json',
            data: JSON.stringify(insert),            
            success: function (data) {
                alert("Order Saved")
                //$("#label").text(data.Pages)
            }
        })
    })
})