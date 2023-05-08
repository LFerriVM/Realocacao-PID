function racas(botao) {
  //Atribui à uma variável/lista todos os elementos que apresentem o atributo 'name' sendo 'raca'
  var radio = document.getElementsByName('IdRaca');
  //Desmarca qualquer opção, dentro dos formulários de descrição das raças e subraças, que por ventura esteja marcada
  for (let element of document.getElementsByClassName("subracas")) {
    element.checked = false;
  }
  //Realiza um loop através de todos os radiobox da variável 'radio'
  for (i = 0; i < radio.length; i++) {
    //Checa se a radiobox com o id 'anao' está checada
    if (botao.id == "Raca1" && botao.checked == true) {
      //Realiza um loop por todos os elementos cuja classe seja 'subracas', removendo sua visibility e seu display
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Anãosubracas").style.visibility = "visible";
      document.getElementById("Anãosubracas").style.display = "block";
      //Atribui visibilidade e display ao furmulário cujo 'id' é 'anaosubracas'
      // document.getElementById("Anãosubracas").style.visibility = "visible";
      // document.getElementById("Anãosubracas").style.display = "block";
      for (let element of document.getElementsByClassName("Anãosubracas")) {
        element.style.visibility = "visible";
        element.style.display = "block";
      }

    }
    else if (botao.id == "Raca2" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Elfosubracas").style.visibility = "visible";
      document.getElementById("Elfosubracas").style.display = "block";

      for (let element of document.getElementsByClassName("Elfosubracas")) {
        element.style.visibility = "visible";
        element.style.display = "block";
      }
    }
    else if (botao.id == "Raca3" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Halflingsubracas").style.visibility = "visible";
      document.getElementById("Halflingsubracas").style.display = "block";

      for (let element of document.getElementsByClassName("Halflingsubracas")) {
        element.style.visibility = "visible";
        element.style.display = "block";
      }
    }
    else if (botao.id == "Raca4" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Humanosubracas").style.visibility = "visible";
      document.getElementById("Humanosubracas").style.display = "block";

    }
    else if (botao.id == "Raca5" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Draconatosubracas").style.visibility = "visible";
      document.getElementById("Draconatosubracas").style.display = "block";
    }
    else if (botao.id == "Raca6" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Gnomosubracas").style.visibility = "visible";
      document.getElementById("Gnomosubracas").style.display = "block";

      for (let element of document.getElementsByClassName("Gnomosubracas")) {
        element.style.visibility = "visible";
        element.style.display = "block";
      }
    }
    else if (botao.id == "Raca7" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Meio-Elfosubracas").style.visibility = "visible";
      document.getElementById("Meio-Elfosubracas").style.display = "block";
    }
    else if (botao.id == "Raca8" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Meio-Orcsubracas").style.visibility = "visible";
      document.getElementById("Meio-Orcsubracas").style.display = "block";
    }
    else if (botao.id == "Raca9" && botao.checked == true) {
      for (let element of document.getElementsByClassName("subracas")) {
        element.style.visibility = "hidden";
        element.style.display = "none";
      }
      document.getElementById("Tieflingsubracas").style.visibility = "visible";
      document.getElementById("Tieflingsubracas").style.display = "block";
    }
  }
  for(i = 1; i <= 9; i++){
    document.getElementById("Subraca"+i).checked = false;
  }
}
function subracas(botao) {
  console.log(botao.id)
  for (let element of document.getElementsByClassName("subracas2")) {
    element.style.visibility = "hidden";
    element.style.display = "none";
  }
  if (botao.id == "Subraca1") {
    document.getElementById("SubRaca_div1").style.visibility = "visible";
    document.getElementById("SubRaca_div1").style.display = "block";
  }
  else if (botao.id == "Subraca2") {
    document.getElementById("SubRaca_div2").style.visibility = "visible";
    document.getElementById("SubRaca_div2").style.display = "block";
  }
  else if (botao.id == "Subraca3") {
    document.getElementById("SubRaca_div3").style.visibility = "visible";
    document.getElementById("SubRaca_div3").style.display = "block";
  }
  else if (botao.id == "Subraca4") {
    document.getElementById("SubRaca_div4").style.visibility = "visible";
    document.getElementById("SubRaca_div4").style.display = "block";
  }
  else if (botao.id == "Subraca5") {
    document.getElementById("SubRaca_div5").style.visibility = "visible";
    document.getElementById("SubRaca_div5").style.display = "block";
  }
  else if (botao.id == "Subraca6") {
    document.getElementById("SubRaca_div6").style.visibility = "visible";
    document.getElementById("SubRaca_div6").style.display = "block";
  }
  else if (botao.id == "Subraca7") {
    document.getElementById("SubRaca_div7").style.visibility = "visible";
    document.getElementById("SubRaca_div7").style.display = "block";
  }
  else if (botao.id == "Subraca8") {
    document.getElementById("SubRaca_div8").style.visibility = "visible";
    document.getElementById("SubRaca_div8").style.display = "block";
  }
  else if (botao.id == "Subraca9") {
    document.getElementById("SubRaca_div9").style.visibility = "visible";
    document.getElementById("SubRaca_div9").style.display = "block";
  }
  for (i = 1; i <= 9; i++){
    if(botao.id != ("Subraca"+i)){
      document.getElementById("Subraca"+i).checked = false
    }
  }
}