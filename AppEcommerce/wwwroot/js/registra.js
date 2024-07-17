const uri = "/Autentica/SaveUser"
window.onload = () => {
    let form_registra = document.getElementById("form_registra");
    form_registra.onsubmit = () => {
        let pwd = document.getElementById('pwd').value;
        let username = document.getElementById('username').value;
        let nome = document.getElementById('nome').value;
        let cognome = document.getElementById('cognome').value;
        let indirizzo = document.getElementById('indirizzo').value;
         
        let hash = CryptoJS.SHA512(pwd);
        hash = hash.toString(CryptoJS.enc.Hex)
        const cliente = {

            username: username,
            nome: nome,
            cognome:cognome,
            password: hash,
            indirizzo:indirizzo
        }
        fetch(uri, {
            method: "POST",
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            },
            body: JSON.stringify(cliente)
        }).then(response => {

            if (response.ok) {
                alert("Utente inserito correttamente. Andare su login per eseguire gli ordini!")
                location.href="/Autentica/Login"  

            }
              
        }).catch(error => console.error)
        

    }
 
    }
 