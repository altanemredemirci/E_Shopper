

$(document).ready(function () {
    var kdv = document.getElementById("CartSubTotal").innerHTML.substring(1).replace(", ", ".");
    document.getElementById("Tax").innerHTML = "₺" + Total(parseFloat(kdv) * 0.18).toFixed(2);
    Payment();
});

function arttir(Id) {
    var adet = document.getElementById(Id)
    adet.value = Number(adet.value) + 1;
    var fiyat = document.getElementsByClassName(Id)[0].innerHTML.substring(1).replace(",", ".");
    var total = (parseFloat(fiyat) * parseFloat(adet.value));
    document.getElementById("total+" + Id).innerHTML = "₺" + Total(total);
    var subtotal = (document.getElementById("CartSubTotal")).innerHTML.substring(1).replace(",", ".");
    document.getElementById("CartSubTotal").innerHTML = "₺" + Total((parseFloat(subtotal) + parseFloat(fiyat)))
    KDV()
    Payment()
    $.ajax({
        type: 'POST',
        url: '/Cart/AddToCart',
        data: { 'id': Id, 'quantity': +1 },
        dataType: 'json',
        success: function (data) {
            console.log("Merhaba")
            alert('Başarılı')
        },
        error: function (x) {
            console.log("HATA")
        }
    });
};

function azalt(Id) {
    var adet = document.getElementById(Id)
    adet.value = Number(adet.value) - 1;
    var fiyat = document.getElementsByClassName(Id)[0].innerHTML.substring(1).replace(",", ".");
    var total = (parseFloat(fiyat) * parseFloat(adet.value));
    document.getElementById("total+" + Id).innerHTML = "₺" + Total(total);
    var subtotal = (document.getElementById("CartSubTotal")).innerHTML.substring(1).replace(",", ".");
    document.getElementById("CartSubTotal").innerHTML = "₺" + Total((parseFloat(subtotal) - parseFloat(fiyat)))
    KDV()
    Payment()
    $.ajax({
        type: 'POST',
        url: '/Cart/AddToCart',
        data: { 'id': Id, 'quantity': -1 },
        dataType: 'json',
        success: function (data) {
            console.log("Merhaba")
            alert('Başarılı')
        },
        error: function (x) {
            console.log("HATA")
        }
    });
};

function Total(num) {
    if (Number.isInteger(num)) {
        return num + ".00";
    }
    else if (num.length > 4) {
        return num.substring(1, 5);
    }
    else {
        return num;
    }
}

function KDV() {
    var kdv = document.getElementById("CartSubTotal").innerHTML.substring(1).replace(", ", ".");
    document.getElementById("Tax").innerHTML = "₺" + Total(parseFloat(kdv * 0.18)).toFixed(2);
}

function Payment() {
    var total = document.getElementById("CartSubTotal").innerHTML.substring(1).replace(",", ".");
    var kdv = document.getElementById("Tax").innerHTML.substring(1).replace(",", ".");
    //var freight = document.getElementById("shippingCost").innerHTML.substring(1).replace(",", ".");
    document.getElementById("total").innerHTML = "₺" + Total(parseFloat(total) + parseFloat(kdv) + 9.00); //kargo maliyetini dahil et(freight)
}

function Goster() {
    document.getElementById("shopper-informations").style.display="block";
}

function NewAddress() {
    document.getElementById("newaddress").style.display = "block";
    document.getElementById("adres").style.display = "none";
}