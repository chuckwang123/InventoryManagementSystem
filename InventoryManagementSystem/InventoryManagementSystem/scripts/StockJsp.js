var uri = '../api/Stock';

$(document).ready(function () {
    // Send an AJAX request
    $.getJSON(uri)
        .done(function (data) {
            // On success, 'data' contains a list of products.
            $.each(data, function (key, item) {
                // Add a list item for the product.
                $('<li>', { text: formatItem(item) }).appendTo($('#products'));
            });
        });
});

function formatItem(item) {
    return item.id ;
}

function AddRow(item) {
    var newRowContent = "<tr><td>" + item.id + "</td><td>" + item.Date + "</td><td>" + item.commodity.id + "</td><td>" + item.commodity.code + "</td><td>"
        + item.commodity.name + "</td><td>" + item.commodity.price + "</td><td>" + item.number + "</td><td>" + item.TotalPrice + "</td></tr>";

    $('#StockTable > tbody:last-child').append(newRowContent);
}
function find() {
    var id = $('#prodId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $("#StockTable > tbody tr").remove();
            if (typeof data.length === "undefined") {
                AddRow(data);
            } else {
                for (var i = 0; i < data.length; i++) {
                    AddRow(data[i]);
                }
            }
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#product').text('Error: ' + err);
        });
}