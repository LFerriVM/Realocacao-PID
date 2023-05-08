function submit_nivel_form() {
    document.getElementById("nivel_form").submit();
}

function pagina1() {
    document.getElementById("container_telafrontal").style.visibility = "visible"
    document.getElementById("container_telafrontal").style.display = "block"
    document.getElementById("container_telatraseira").style.visibility = "hidden"
    document.getElementById("container_telatraseira").style.display = "none"
    console.log("1")
}
function pagina2() {
    document.getElementById("container_telatraseira").style.visibility = "visible"
    document.getElementById("container_telatraseira").style.display = "block"
    document.getElementById("container_telafrontal").style.visibility = "hidden"
    document.getElementById("container_telafrontal").style.display = "none"
    console.log("2")
}
function sumirtudo() {
    document.getElementById("container_telatraseira").style.visibility = "hidden"
    document.getElementById("container_telatraseira").style.display = "none"
    document.getElementById("container_telafrontal").style.visibility = "visible"
    document.getElementById("container_telafrontal").style.display = "block"
}