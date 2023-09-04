function updateQuantity() {
    var inputs = document.getElementsByClassName('qty-input');
    var total = 0;

    // Toplam miktarý hesapla
    for (var i = 0; i < inputs.length; i++) {
        total += parseInt(inputs[i].value);
    }

    // Deðerleri güncelle
    for (var i = 0; i < inputs.length; i++) {
        var maxAllowed = 10 - total + parseInt(inputs[i].value);
        inputs[i].max = maxAllowed;
        inputs[i].value = Math.min(inputs[i].value, maxAllowed);
    }
}