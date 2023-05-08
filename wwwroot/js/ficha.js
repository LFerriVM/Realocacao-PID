function divs(button){
    var botao = document.getElementById(button);
    var element = document.getElementsByClassName('div');
    for(i=0; i<element.length; i++){
        element[i].style.visibitily = "hidden";
        element[i].style.display = "none";
    }
    document.getElementById("div_"+button.id).style.visibility = "visible";
    document.getElementById("div_"+button.id).style.display = "block";
}