$(document).ready(function () {
    $("#myform").submit(function (e) {
        e.preventDefault();

        $("#OrdersTable").empty();

        var OrdersTableData = "<tr>";
        OrdersTableData += "<th>Player Name</th>";
        OrdersTableData += "<th>Game Name</th>";
        OrdersTableData += "<th>Play Time</th>";     
        OrdersTableData += "<th>Game Type</th>";
        OrdersTableData += "<th>Email</th>";
        OrdersTableData += "<th>Phone</th>";     
        OrdersTableData += "<th>Price</th>";       
        OrdersTableData += "</tr>";

        $.ajax({
            type: "GET",
            url: "/Api/Orders/",
            dataType: "Json",
            contentType: "Application/Json",

            success: function (data) {                
                $.each(data, function (key, value) {
                    OrdersTableData += "<tr>";
                    OrdersTableData += "<td>" + value.player.PlayerName + "</td>";
                    OrdersTableData += "<td>" + value.game.GameName + "</td>";
                    OrdersTableData += "<td>" + value.game.PlayTime + "</td>";    
                    OrdersTableData += "<td>" + value.game.GameType + "</td>";
                    OrdersTableData += "<td>" + value.player.Email + "</td>";
                    OrdersTableData += "<td>" + value.player.Phone + "</td>";   
                    OrdersTableData += "<td>" + value.game.Price + "</td>";   
                    OrdersTableData += "</tr>";
                })    
                $("#OrdersTable").append(OrdersTableData);
            }
        })
    })
})