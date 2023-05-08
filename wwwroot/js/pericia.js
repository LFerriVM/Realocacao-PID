function pericia(){
    var element = document.getElementsByName('pericia_cla');
    var contagem = 0;
    for(i=0; i<element.length; i++){
        if(element[i].checked == true){
            contagem++;
        }
        if(contagem > 2){
            alert("mais que dois marcados");
            for (let element of document.getElementsByName('pericia_cla')){
                element.checked=false;
            }
            contagem = 0;
        }
    }
}

