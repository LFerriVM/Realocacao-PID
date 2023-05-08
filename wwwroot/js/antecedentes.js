function antecedentes(){
    var radio = document.getElementsByName('IdAntecedente');
    for (let element of document.getElementsByClassName("antecedente")){
        element.checked = false;
    }
    for(i=0;i<radio.length;i++)
    {
      if(document.getElementById('Antecedente1').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Acólitoantecedente").style.visibility = "visible";
        document.getElementById("Acólitoantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente2').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Artesão de Guildaantecedente").style.visibility = "visible";
        document.getElementById("Artesão de Guildaantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente3').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Artistaantecedente").style.visibility = "visible";
        document.getElementById("Artistaantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente4').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Charlatãoantecedente").style.visibility = "visible";
        document.getElementById("Charlatãoantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente5').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Criminosoantecedente").style.visibility = "visible";
        document.getElementById("Criminosoantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente6').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Eremitaantecedente").style.visibility = "visible";
        document.getElementById("Eremitaantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente7').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Forasteiroantecedente").style.visibility = "visible";
        document.getElementById("Forasteiroantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente8').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Herói do Povoantecedente").style.visibility = "visible";
        document.getElementById("Herói do Povoantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente9').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Marinheiroantecedente").style.visibility = "visible";
        document.getElementById("Marinheiroantecedente").style.display="block";
      }
      if(document.getElementById('Antecedente10').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Nobreantecedente").style.visibility = "visible";
        document.getElementById("Nobreantecedente").style.display="block";
      }
      else if (document.getElementById('Antecedente11').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Órfãoantecedente").style.visibility = "visible";
        document.getElementById("Órfãoantecedente").style.display="block";
      }
      else if (document.getElementById('Antecedente12').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Sábioantecedente").style.visibility = "visible";
        document.getElementById("Sábioantecedente").style.display="block";
      }
      else if (document.getElementById('Antecedente13').checked == true){
        for (let element of document.getElementsByClassName("antecedentes")){
          element.style.visibility="hidden";
          element.style.display="none";
        }
        document.getElementById("Soldadoantecedente").style.visibility = "visible";
        document.getElementById("Soldadoantecedente").style.display="block";
      }
    }
  }
