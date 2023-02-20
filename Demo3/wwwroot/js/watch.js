function ScriptAlert(message) {
    alert(message);
}

function displayRandom(randomIdName) {
    console.log(randomIdName);
    var my = document.getElementById(randomIdName);
    my.style.visibility = "visible";
};
function closePreRandom(id) {
    var you = document.getElementById(id)
    you.style.visibility = "hidden";
}