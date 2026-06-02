let greetButton = document.getElementById("greetBtn");

greetButton.addEventListener("click", function() {
    let name = document.getElementById("nameInput").value;
    document.getElementById("output").innerHTML = "Hello " + name + "!";
});