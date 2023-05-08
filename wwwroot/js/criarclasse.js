function temmagia(){
    if(document.getElementById('UsaMagiatrue').checked == true){
        document.getElementById('divusamagia').style.visibility = "visible";
        document.getElementById('divusamagia').style.display = "block";
        modomagia();
    }
    else{
        document.getElementById('divusamagia').style.visibility = "hidden";
        document.getElementById('divusamagia').style.display = "none";
        document.getElementsByClassName('modoobtevemagia')[0].checked = false;
        document.getElementsByClassName('modoobtevemagia')[1].checked = false
        document.getElementById('Conjurador').checked=null;
    }
}

function modomagia(){
        
    if(document.getElementById('Conjurador').checked == false && document.getElementById('Pacto').checked == false){
        for(let element of document.getElementsByClassName('conjuradortabela')){
            element.style.visibility= "hidden";
            element.style.display= "none";
        } 
        for(let element of document.getElementsByClassName('pactotabela')){
            element.style.visibility= "hidden";
            element.style.display= "none";
        }
    }

    if(document.getElementById('Conjurador').checked == true){
        for(let element of document.getElementsByClassName('conjuradortabela')){
            element.style.visibility= "visible";
            element.style.display= "table-cell";
        } 
        for(let element of document.getElementsByClassName('pactotabela')){
            element.style.visibility= "hidden";
            element.style.display= "none";
        }
    }
    if(document.getElementById('Pacto').checked == true){
        for(let element of document.getElementsByClassName('pactotabela')){
            element.style.visibility= "visible";
            element.style.display= "table-cell";
        }
        for(let element of document.getElementsByClassName('conjuradortabela')){
            element.style.visibility= "hidden";
            element.style.display= "none";
        } 
    }
}