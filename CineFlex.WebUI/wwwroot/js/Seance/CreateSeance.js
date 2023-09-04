
$(document).ready(function () {
    var counter = 1;

    $("#addTimeBox").click(function () {
        addTimeBox(counter);
        counter++;
    });

    $("#removeTimeBox").click(function () {
        if (counter > 1) {
            removeTimeBox(counter - 1);
            counter--;
        } else {
            alert("Daha fazla zaman kutusu yok.");
        }
    });

    $(".select-theater").click(function () {
        handleSelectedTheater(this)
    })
})

//--------//

function handleSelectedTheater(button) {
    $(".select-theater").removeClass("btn-success disabled");
    $(button).addClass("btn-success disabled");

    var selectedTheaterId = $(button).closest("tr").find("td:first").data("theaterid");

    console.log(selectedTheaterId);

    $("#TheaterId").val(selectedTheaterId);
}

function addTimeBox(counter) {
    if (counter > 6) {
        alert("Maksimum 6 kutu eklenebilir.");
        return;
    }

    var newTextBoxDiv = $("<div>")
        .attr("id", 'TimeDiv' + counter);

    newTextBoxDiv.append('<label><b>Seans Saati ' + counter + '</b></label>' +
        '<input type="time" class="form-control" name="SeanceTimeList[]" value="">'
    );

    $("#seanceTimeBoxGroup").append(newTextBoxDiv);
}

function removeTimeBox(counter) {
    $("#TimeDiv" + counter).remove();
}