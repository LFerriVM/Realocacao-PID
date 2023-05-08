function escolher(id) {
    if (id.id == "radio_distpadrao") {
        document.getElementById('div_distpadrao').style.visibility = "visible";
        document.getElementById('div_distpadrao').style.display = "block";
        // document.getElementById('div_distrolar').style.visibility = "hidden";
        // document.getElementById('div_distrolar').style.display = "none";
    } else {
        document.getElementById('div_distpadrao').style.visibility = "hidden";
        document.getElementById('div_distpadrao').style.display = "none";
        // document.getElementById('div_distrolar').style.visibility = "visible";
        // document.getElementById('div_distrolar').style.display = "block";
        flushLocal();
    }
}


function atributos(patributo) {

    if (patributo.value != "") {
        // console.log(patributo.id)
        var atributos = ["Forca", "Destreza", "Constituicao", "Inteligencia", "Sabedoria", "Carisma"];
        var valor = document.getElementById(patributo.id).value;
        console.log(valor)
        // console.log(valor);
        for (i = 0; i < atributos.length; i++) {
            if (atributos[i] != patributo.id) {

                for (let option of document.getElementsByClassName("select_dist_" + valor))
                {
                    option.setAttribute("disabled", "disabled");
                }
                
                console.log("a")
            }
            else {
                console.log("b")

                var consulta = localStorage.getItem(patributo.id);
                if (consulta !== null) {
                    // console.log(consulta);
                    for (j = 0; j < atributos.length; j++) {
                        for (let option of document.getElementsByClassName("select_dist_"+ consulta))
                        {
                            option.removeAttribute("disabled");
                        }
                        
                    }
                }
                var local = localStorage.setItem(patributo.id, valor);
            }
        }

    }
}

function flushLocal() {
    var atributos = ["Forca", "Destreza", "Constituicao", "Inteligencia", "Sabedoria", "Carisma"];
    for (i = 0; i < atributos.length; i++) {
        localStorage.removeItem(atributos[i]);
        document.getElementById(atributos[i]).value=""
    }
    document.getElementById("radio_distpadrao").checked = false;
    document.getElementById("div_distpadrao").style.visibility= "hidden";
    document.getElementById("div_distpadrao").style.display="none"
}



function limitar(form) {
    var lista = [8, 10, 12, 13, 14, 15];

    var contador = 0;
    for (let valor of lista) {
        var contador = 0;
        for (let element of document.getElementsByClassName("select_dist")) {
            if (element.value == valor) {
                contador++;
                for (let element2 of document.getElementsByClassName("select_dist_" + valor)) {
                    // console.log(element.value)
                    element2.setAttribute("disabled", "disabled")
                }

            }
            else{
                for (let element2 of document.getElementsByClassName("select_dist_" + valor)) {
                    // console.log(element.value)
                    element2.removeAttribute("disabled")
                }
            } 
            if (contador > 1) {
                alert("Só um valor de cada, parsa")
                element.value = "";
                contador = 0;
            }
            console.log(element.value)
        }
    }


    // for (let element of document.getElementsByClassName("select_dist")) {
    //     console.log(element.value)
    //     if (element.value == lista) {
    //         for (let element2 of document.getElementsByClassName("select_dist_" + lista)) {
    //             console.log(element2)
    //             element2.setAttribute = "disabled"
    //         }
    //     }
    // }




}

function rolar(id) {
    var rolar;
    let rolados = [];
    var resultado = 0;
    for (i = 0; i < 4; i++) {
        rolar = Math.floor(Math.random() * 6) + 1;
        rolados.push(rolar)
    }
    var retirar = Math.min(...rolados);
    for (i = 0; i < rolados.length; i++) {
        resultado += rolados[i];
    }
    resultado -= retirar;
    if (resultado < 6 || resultado > 20) {
        rolar(id);
    }
    if (id.id == "roladorforca") {
        document.getElementsByClassName(id.id)[0].setAttribute('value', Number(resultado));
    }
    // if(id.id == "roladorf"){
    //     document.getElementsByClassName(id.id + "orca")[0].setAttribute('value', Number(resultado));
    // }
    if (id.id == "roladordestreza") {
        document.getElementsByClassName(id.id)[0].setAttribute('value', Number(resultado));
    }
    if (id.id == "roladorconstituicao") {
        document.getElementsByClassName(id.id)[0].setAttribute('value', Number(resultado));
    }
    if (id.id == "roladorinteligencia") {
        document.getElementsByClassName(id.id)[0].setAttribute('value', Number(resultado));
    }
    if (id.id == "roladorsabedoria") {
        document.getElementsByClassName(id.id)[0].setAttribute('value', Number(resultado));
    }
    if (id.id == "roladorcarisma") {
        document.getElementsByClassName(id.id)[0].setAttribute('value', Number(resultado));
    }
}
