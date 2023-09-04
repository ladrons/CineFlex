document.addEventListener('DOMContentLoaded', function () {
    const seatsDiv = document.getElementById('seats');
    const numOfSeats = parseInt(seatsDiv.getAttribute('data-capacity'));
    const soldSeatsJSON = seatsDiv.getAttribute('data-soldseats');
    const soldSeats = JSON.parse(soldSeatsJSON);

    const numOfRows = Math.ceil(numOfSeats / 12);
    const seatAlphabets = ['A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L'];

    for (let row = 0; row < numOfRows; row++) {
        const seatRowDiv = document.createElement('div');
        for (let seatNum = 1; seatNum <= 12 && (row * 12 + seatNum) <= numOfSeats; seatNum++) {
            const seatDiv = document.createElement('div');
            seatDiv.classList.add('seat');
            const seatId = `${seatAlphabets[row]}${seatNum}`;
            seatDiv.setAttribute('id', seatId);
            seatDiv.innerText = seatId;

            if (soldSeats.includes(seatId)) {
                seatDiv.classList.add('sold');
                seatDiv.style.backgroundColor = 'red';
                seatDiv.removeEventListener('click', selectSeat);
            } else {
                seatDiv.addEventListener('click', selectSeat);
            }
            seatRowDiv.appendChild(seatDiv);
        }
        seatsDiv.appendChild(seatRowDiv);
    }
});


//Seçili koltuklarýn tutulduðu dizi
var selectedSeats = [];

//Seçili koltuk sayýsýný takip etmek için;
let numOfSelectedSeats = 0;

function selectSeat() {
    const seatsDiv = document.getElementById('seats');
    const ticketQuantity = parseInt(seatsDiv.getAttribute('data-quantity'));

    const seatDiv = this;
    if (seatDiv.classList.contains('selected')) {
        // Eðer seçili olan koltuða tekrar týklandýysa, seçimini kaldýr
        seatDiv.classList.remove('selected');
        selectedSeats = selectedSeats.filter(seat => seat !== seatDiv.id); // seçim kaldýrýlan koltuðu listeden çýkar
        numOfSelectedSeats--;
    } else if (numOfSelectedSeats < ticketQuantity) {
        // Seçili koltuk sayýsý Model'den gelen deðerden az ise, koltuðu seç
        seatDiv.classList.add('selected');
        selectedSeats.push(seatDiv.id); // seçilen koltuðu listeye ekle
        numOfSelectedSeats++;
    } else {
        // Seçili koltuk sayýsý Model'den gelen deðerden fazla ise, hata mesajý göster
        alert('En fazla ' + ticketQuantity +' koltuk seçebilirsiniz!');
    }
}


//Her koltuk bilgisini ayrý bþir input olarak oluþtur ve sunucuya gönder
const form = document.querySelector('#myForm');
form.addEventListener('submit', function (event) {
    event.preventDefault();
    for (let i = 0; i < selectedSeats.length; i++) {
        const input = document.createElement('input');
        input.type = 'hidden';
        input.name = 'selectedSeats';
        input.value = selectedSeats[i];
        form.appendChild(input);
    }
    form.submit();
});