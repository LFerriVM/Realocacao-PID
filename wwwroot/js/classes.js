function classes(){
  //Atribui à uma variável/lista todos os elementos que apresentem o atributo 'name' sendo 'classe'
  var radio = document.getElementsByName('IdClasse');
  //Desmarca qualquer opção, dentro dos formulários de descrição das classes, que por ventura esteja marcada
  // for (let element of document.getElementsByClassName("radioclasse")){
  //     element.checked = false;    
  // }
  //Realiza um loop através de todos os radiobox da variável 'radio'
  for(i=0;i<radio.length;i++)
  {
    //Checa se a radiobox com o id 'barbaro' está checada
    if(document.getElementById('Classe1').checked == true){
      //Realiza um loop por todos os elementos cuja classe seja 'classes', removendo sua visibility e seu display
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      //Atribui visibilidade e display ao furmulário cujo 'id' é 'barbaroclasse'
      document.getElementById("Bárbaroclasse").style.visibility = "visible";
      document.getElementById("Bárbaroclasse").style.display="block";
    }
    else if (document.getElementById('Classe2').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Bardoclasse").style.visibility = "visible";
      document.getElementById("Bardoclasse").style.display="block";
    }
    else if (document.getElementById('Classe3').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Bruxoclasse").style.visibility = "visible";
      document.getElementById("Bruxoclasse").style.display="block";
    }
    else if (document.getElementById('Classe4').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Clérigoclasse").style.visibility = "visible";
      document.getElementById("Clérigoclasse").style.display="block";
      
  }
  else if (document.getElementById('Classe5').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Druidaclasse").style.visibility = "visible";
      document.getElementById("Druidaclasse").style.display="block";
    }
    else if (document.getElementById('Classe6').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Feiticeiroclasse").style.visibility = "visible";
      document.getElementById("Feiticeiroclasse").style.display="block";
    }
    else if (document.getElementById('Classe7').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Guerreiroclasse").style.visibility = "visible";
      document.getElementById("Guerreiroclasse").style.display="block";
    }
    else if (document.getElementById('Classe8').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Ladinoclasse").style.visibility = "visible";
      document.getElementById("Ladinoclasse").style.display="block";
    }
    else if (document.getElementById('Classe9').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Magoclasse").style.visibility = "visible";
      document.getElementById("Magoclasse").style.display="block";
    }
    else if (document.getElementById('Classe10').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Mongeclasse").style.visibility = "visible";
      document.getElementById("Mongeclasse").style.display="block";
    }
    else if (document.getElementById('Classe11').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Paladinoclasse").style.visibility = "visible";
      document.getElementById("Paladinoclasse").style.display="block";
    }
    else if (document.getElementById('Classe12').checked == true){
      for (let element of document.getElementsByClassName("classes")){
        element.style.visibility="hidden";
        element.style.display="none";
      }
      document.getElementById("Patrulheiroclasse").style.visibility = "visible";
      document.getElementById("Patrulheiroclasse").style.display="block";
    }
  }
}

