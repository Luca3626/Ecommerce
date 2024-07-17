const uri = "/Ordini/Checkout"
window.onload = () => {
    let form_ordini = document.getElementById("form_ordini");
    form_ordini.onsubmit = () => {
        console.log("ok")
        let username = document.getElementById('username').value;
        let indirizzo = document.getElementById('address').value;
        let indirizzo2 = document.getElementById('address2').value;
               if (indirizzo2 != '')
            indirizzo = indirizzo2;
        let pagamento = document.getElementById('tipo_pagamento').value;
        const ordine = {

            data: new Date(),
            tipoPagamento: pagamento,
            fkCliente: username,
            indirizzoFat:indirizzo

        }
        console.log(ordine)
        fetch(uri, {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(ordine)
        }).then(response => {

            if (response.ok) {
                alert("Ordine registrato correttamente!")
                location.href = "/Home/Index"

            }

        }).catch(error => console.error)
    }

}
