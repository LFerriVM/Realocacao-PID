// function generateJson() {
//     let itens = [
//         { id: 1, nome: "Armadura", qtde: 5},
//         { id: 2, nome: "Armadura", qtde: 5},
//         { id: 3, nome: "Armadura", qtde: 5},
//         { id: 4, nome: "Armadura", qtde: 5},
//         { id: 5, nome: "Armadura", qtde: 5},
//     ];
// }

function alterar_item_select(button) {
    for (let element of document.getElementsByClassName('alterar_item_select')) {
        element.style.visibility = "hidden";
        element.style.display = "none";
    }

    // SELECT
    if (button.id == "alterar_item_select_button_Armas") {
        document.getElementById('alterar_item_select_Armas').style.visibility = "visible";
        document.getElementById('alterar_item_select_Armas').style.display = "block";
        document.getElementById('alterar_item_select_Armaduras').value = "";
        document.getElementById('alterar_item_select_Itens').value = "";
        document.getElementById("IsEquipadaInventario").checked = false;
    }
    if (button.id == "alterar_item_select_button_Armaduras") {
        document.getElementById('alterar_item_select_Armaduras').style.visibility = "visible";
        document.getElementById('alterar_item_select_Armaduras').style.display = "block";
        document.getElementById('alterar_item_select_Armas').value = "";
        document.getElementById('alterar_item_select_Itens').value = "";
        document.getElementById("IsEquipadaInventario").checked = false;
    }
    if (button.id == "alterar_item_select_button_Itens") {
        document.getElementById('alterar_item_select_Itens').style.visibility = "visible";
        document.getElementById('alterar_item_select_Itens').style.display = "block";
        document.getElementById('alterar_item_select_Armas').value = "";
        document.getElementById('alterar_item_select_Armaduras').value = "";
        document.getElementById("IsEquipadaInventario").checked = false;
    }
}
function alterar_item_inventario(button) {
    for (let element of document.getElementsByClassName('alterar_item_inventario')) {
        element.style.visibility = "hidden";
        element.style.display = "none";
    }
    if (button.id == "alterar_item_inventario_button_Armas") {
        document.getElementById('alterar_item_inventario_Armas').style.visibility = "visible";
        document.getElementById('alterar_item_inventario_Armas').style.display = "block";
        document.getElementById('alterar_item_inventario_Armaduras').value = "";
        document.getElementById('alterar_item_inventario_Itens').value = "";
    }
    if (button.id == "alterar_item_inventario_button_Armaduras") {
        document.getElementById('alterar_item_inventario_Armaduras').style.visibility = "visible";
        document.getElementById('alterar_item_inventario_Armaduras').style.display = "block";
        document.getElementById('alterar_item_inventario_Armas').value = "";
        document.getElementById('alterar_item_inventario_Itens').value = "";
    }
    if (button.id == "alterar_item_inventario_button_Itens") {
        document.getElementById('alterar_item_inventario_Itens').style.visibility = "visible";
        document.getElementById('alterar_item_inventario_Itens').style.display = "block";
        document.getElementById('alterar_item_inventario_Armas').value = "";
        document.getElementById('alterar_item_inventario_Armaduras').value = "";
    }
}
function reset() {
    document.getElementById('alterar_item_select_Armas').value = "";
    document.getElementById('alterar_item_select_Armaduras').value = "";
    document.getElementById('alterar_item_select_Itens').value = "";
    document.getElementById('alterar_item_inventario_Armas').value = "";
    document.getElementById('alterar_item_inventario_Armaduras').value = "";
    document.getElementById('alterar_item_inventario_Itens').value = "";
    document.getElementById("IsEquipadaInventario").checked = false;
    for (let element of document.getElementsByClassName('alterar_item_select')) {
        element.style.visibility = "hidden";
        element.style.display = "none";
    }
    for (let element of document.getElementsByClassName('alterar_item_inventario')) {
        element.style.visibility = "hidden";
        element.style.display = "none";
    }
}

function transporvalores_armas(campo) {
    var Qtd = document.getElementById('hidden_inventario_Armas_' + campo.value + '_Qtd').value;
    document.getElementById("QtdInventario").setAttribute('value', Qtd);
    var IsEquipada = document.getElementById('hidden_inventario_Armas_' + campo.value + '_IsEquipada').value;
    // console.log(IsEquipada)
    if (IsEquipada == "True") {
        document.getElementById("IsEquipadaInventario").checked = true;
    }
    else if (IsEquipada == "False") {
        document.getElementById("IsEquipadaInventario").checked = false;
    }
}

function transporvalores_armaduras(campo) {
    var Qtd = document.getElementById('hidden_inventario_Armaduras_' + campo.value + '_Qtd').value;
    document.getElementById("QtdInventario").setAttribute('value', Qtd);
    var IsEquipada = document.getElementById('hidden_inventario_Armaduras_' + campo.value + '_IsEquipada').value;
    // console.log(IsEquipada)
    if (IsEquipada == "True") {
        document.getElementById("IsEquipadaInventario").checked = true;
    }
    else if (IsEquipada == "False") {
        document.getElementById("IsEquipadaInventario").checked = false;
    }
}

function transporvalores_itens(campo) {
    var Qtd = document.getElementById('hidden_inventario_Itens_' + campo.value + '_Qtd').value;
    document.getElementById("QtdInventario").setAttribute('value', Qtd);
}
function deletar() {
    document.getElementById("inputhidden_deletar").value = true;
}
function submit(form)
{
    document.getElementById(form.id).submit();
}