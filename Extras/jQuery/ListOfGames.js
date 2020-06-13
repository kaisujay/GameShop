$(document).ready(function () {
    $("#myform").submit(function (e) {
        e.preventDefault();

        $("#GamesTable").empty();

        var GamesTableData = "<tr>";
        GamesTableData += "<th>Game Name</th>";
        GamesTableData += "<th>Publisher</th>";
        GamesTableData += "<th>Play Time</th>";
        GamesTableData += "<th>Release Date</th>";
        GamesTableData += "<th>Game Type</th>";
        GamesTableData += "<th>Price</th>";
        GamesTableData += "</tr>";

        $.ajax({
            type: "GET",
            url: "/Api/Games/",
            dataType: "Json",
            contentType: "Application/Json",

            success: function (data) {                
                $.each(data, function (key, value) {
                    GamesTableData += "<tr>";
                    GamesTableData += "<td>" + value.GameName + "</td>";
                    GamesTableData += "<td>" + value.Publisher + "</td>";
                    GamesTableData += "<td>" + value.PlayTime +" Hours"+ "</td>";
                    GamesTableData += "<td>" + value.ReleaseDate + "</td>";
                    GamesTableData += "<td>" + value.GameType + "</td>";
                    GamesTableData += "<td>" + "$" + value.Price + "</td>";
                    GamesTableData += "</tr>";
                })    
                $("#GamesTable").append(GamesTableData);
            }
        })
    })
})