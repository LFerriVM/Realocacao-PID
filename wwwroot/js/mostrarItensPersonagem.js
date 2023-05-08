function obterItensPersonagem() {
    const id = document.getElementById("idPersonagem").value;
    fetch("/Item/ObterItensPersonagem/" + id)
        .then(function (response) {
            alert(JSON.stringify(response));
        });
}
