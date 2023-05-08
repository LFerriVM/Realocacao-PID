//Função para captar o dado escolhido e enviar para a função de rolagem
function clicar(){
    //Procura por qualquer tag html com a classe das rolagens feitas e remove todas para aguardar pelas novas rolagens
    document.querySelectorAll('.rolados').forEach(e => e.remove());
    //Captura o valor do campo de quantidade de dados a serem rolados
    let quantidade = Number.parseInt(document.getElementById('quantidade').value);
    //Inicia as checagens pelo radiobox checado, 
    if(document.getElementById('d4').checked == true){
        //Inicia a variável de número de lados do dado
        let num = 4;     
        //Chama a função de rolar, enviando como parâmetros o número de lados e a quantidade de dados
        rolar(num, quantidade);
    }
    else if(document.getElementById('d6').checked == true){
        let num = 6;        
        rolar(num, quantidade)
    }
    else if(document.getElementById('d8').checked == true){
        let num = 8;        
        rolar(num, quantidade)
    }
    else if(document.getElementById('d10').checked == true){
        let num = 10;
        rolar(num, quantidade)
    }
    else if(document.getElementById('d12').checked == true){
        let num = 12;
        rolar(num, quantidade)
    }
    else if(document.getElementById('d20').checked == true){
        let num = 20;
        rolar(num, quantidade)
    }
    else if(document.getElementById('d100').checked == true){
        let num = 100;
        rolar(num, quantidade)
    }

}

function rolar(num, quantidade){
    var somavar=0; 
    //Obtem o valor do ID da div onde os resultados serão mostrados
    var element = document.getElementById('displayresultado');
    //Realiza um loop para rolar a quantidade de dados pretendida pelo usuário
    for (i = 0; i<quantidade; i++){
        //Declara o valor do ID da tag referente ao valor que aparecerá na página
        var rolagemid = ("rolagem" + (i+1));
        //Instancia uma variável de criação de tags html
        var tag = document.createElement('h4');

        //Atribui o atributo "id" à tag html dos resultados
        tag.setAttribute('id', rolagemid);
        //Atribui o atributo "class" à tag html dos resultados
        tag.setAttribute('class', "rolados")
        //Atribui o atributo "style" à tag html dos resultados, centralizando-a
        tag.setAttribute('style', "text-align: center")

        tag.setAttribute('style', "display: inline-block")
        //Define que a tag html dos resultados será implementada dentro da div cujo id capturamos anteriormente
        element.appendChild(tag);
        //*******Tentativa de fazer uma "animação" para rolar vários números aleatórios********//
        // myInterval = setInterval(function(){
        //     resultado = Math.floor(Math.random() * num)+1;
        //     document.getElementById(valorid).innerHTML=resultado;
        // }, 2);
        // setTimeout(() => {
        //     clearInterval(myInterval);
        // }, 1000);

        //Faz um sorteio de um número aleatório, limitado ao número de lados do dado, começando pelo 0 (por isso adicionamos 1 ao "piso" deste resultado)
        resultado = Math.floor(Math.random() *num)+1;
        //Atribui o valor html da tag (através do id), o resultado do sorteio
        tag.innerHTML=resultado;


        var mais = document.createElement('h4');
        var sinalid = ("sinal" + (i+1));
        mais.setAttribute('style', 'display: inline-block')
        mais.setAttribute('id', sinalid);
        mais.setAttribute('class', 'rolados');
        element.appendChild(mais);
        
        if(i == (quantidade-1)){
            mais.innerHTML= '=';
        }
        else{
            mais.innerHTML = '+';
        }

        somavar += resultado;

    }
    soma(somavar, element);
}

function soma(somavar, element){
    var aux = document.createElement('h4');
    var id = ("resultado");
    aux.setAttribute('style', 'display: inline-block');
    aux.setAttribute('class', 'rolados')
    aux.setAttribute('id', id);
    element.appendChild(aux); 
    aux.innerHTML = somavar;
}
