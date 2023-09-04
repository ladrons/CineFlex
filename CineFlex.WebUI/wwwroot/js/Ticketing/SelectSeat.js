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


//Se�ili koltuklar�n tutuldu�u dizi
var selectedSeats = [];

//Se�ili koltuk say�s�n� takip etmek i�in;
let numOfSelectedSeats = 0;

function selectSeat() {
    const seatsDiv = document.getElementById('seats');
    const ticketQuantity = parseInt(seatsDiv.getAttribute('data-quantity'));

    const seatDiv = this;
    if (seatDiv.classList.contains('selected')) {
        // E�er se�ili olan koltu�a tekrar t�kland�ysa, se�imini kald�r
        seatDiv.classList.remove('selected');
        selectedSeats = selectedSeats.filter(seat => seat !== seatDiv.id); // se�im kald�r�lan koltu�u listeden ��kar
        numOfSelectedSeats--;
    } else if (numOfSelectedSeats < ticketQuantity) {
        // Se�ili koltuk say�s� Model'den gelen de�erden az ise, koltu�u se�
        seatDiv.classList.add('selected');
        selectedSeats.push(seatDiv.id); // se�ilen koltu�u listeye ekle
        numOfSelectedSeats++;
    } else {
        // Se�ili koltuk say�s� Model'den gelen de�erden fazla ise, hata mesaj� g�ster
        alert('En fazla ' + ticketQuantity +' koltuk se�ebilirsiniz!');
    }
}


//Her koltuk bilgisini ayr� b�ir input olarak olu�tur ve sunucuya g�nder
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