var selectedTime = null;

$('.get-times').on('click', function () {

    var seanceDate = $(this).val();
    var movieId = $(this).data('movie-id');

    clearSelectedTime();

    $('#MovieId').val(movieId);
    $('#Date').val(seanceDate);


    $.ajax({
        url: 'https://localhost:7251/Ticketing/GetSeanceTimesByDate',
        data: { seanceDate: seanceDate, movieId: movieId },
        type: 'GET',
        success: function (data) {
            AddTimes(data);
        }
    });
});

$(document).on('click', '.select-time', function () {

    selectedTime = $(this).val();
    console.log(selectedTime);

    $('#Time').val(selectedTime);
})


function AddTimes(timeList) {
    var timeDiv = $('#timeDiv');
    timeDiv.empty();

    $.each(timeList, function (key, data) {
        timeDiv.append("<input type='button' class='list-group-item list-group-item-action select-time' value='" + data + "' />");
    });
}
function clearSelectedTime() {
    if (selectedTime !== null) {

        // Atanmýþ deðer varsa temizle
        selectedTime = null;

        // Sunucuya gönderilecek deðeride güncelle.
        $('#Time').val(selectedTime);
        console.log(selectedTime); //Test içindir.
    }
}