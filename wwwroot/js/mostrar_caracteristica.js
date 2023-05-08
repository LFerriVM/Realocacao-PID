function mostrar_caracteristica(){
    var e = document.getElementById("select_caracteristica");
    var value = e.value;
    var text = e.options[e.selectedIndex].text;
    
    for (let descricao of document.getElementsByClassName("habilidade_descricao"))
    {
        descricao.style.visibility="hidden";
        descricao.style.display="none";
    }
    document.getElementById(value).style.visibility = "visible";
    document.getElementById(value).style.display = "block";
    
}