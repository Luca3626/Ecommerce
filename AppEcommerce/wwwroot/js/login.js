const uri = "/Autentica/LoginUser"
window.onload = () => {
    let form_login = document.getElementById("form_login");
    form_login.onsubmit = () => {
        let pwd = document.getElementById('pwd').value;
        let username = document.getElementById('username').value;
        let hash = CryptoJS.SHA512(pwd);
        hash = hash.toString(CryptoJS.enc.Hex)

        const cliente = {

            username: username,
            password: hash
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
                alert("Utente loggato!")
                location.href = "/Home/Index";
            }
            else {
                alert("username o password errati!")
            }

        }).catch(error => console.error)

   }

}
