$(document).ready(function () {
    $("#myform").submit(function (e) {
        e.preventDefault();

        $("#PlayersTable").empty();

        var PlayersTableData = "<tr>";
        PlayersTableData += "<th>Player Name</th>";
        PlayersTableData += "<th>Email</th>";
        PlayersTableData += "<th>Phone</th>";
        PlayersTableData += "<th>Birth Date</th>";
        PlayersTableData += "<th>Gender</th>";
        PlayersTableData += "</tr>";

        $.ajax({
            type: "GET",
            url: "/Api/Players/",
            dataType: "Json",
            contentType: "Application/Json",

            success: function (data) {                
                $.each(data, function (key, value) {
                    PlayersTableData += "<tr>";
                    PlayersTableData += "<td>" + value.PlayerName + "</td>";
                    PlayersTableData += "<td>" + value.Email + "</td>";
                    PlayersTableData += "<td>" + value.Phone + "</td>";
                    PlayersTableData += "<td>" + value.BirthDate + "</td>";
                    PlayersTableData += "<td>" + value.Gender + "</td>";
                    PlayersTableData += "</tr>";
                })    
                $("#PlayersTable").append(PlayersTableData);
            }
        })
    })
})