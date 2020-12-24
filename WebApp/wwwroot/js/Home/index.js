function toggleMenu(x) {
    if (x.matches) { // If media query matches
        var menu = document.getElementById("toggle-menu-list");
        menu.style.display = "none";
        var nav = document.getElementById("toggle-menu-show");
        nav.addEventListener("click", ShowMenu);
    } else {
        var menu = document.getElementById("toggle-menu-list");
        menu.style.display = "block";
        var nav = document.getElementById("toggle-menu-show");
        nav.removeEventListener("click", ShowMenu);
    }
}

function ShowMenu(event) {
    var menu = document.getElementById("toggle-menu-list");
    if (menu.style.display == "none") {
        menu.style.display = "block";
    } else {
        menu.style.display = "none";
    }
}

document.addEventListener("DOMContentLoaded", function (event) {
    var x = window.matchMedia("(max-width: 480px)")
    toggleMenu(x) // Call listener function at run time
    x.addListener(toggleMenu) // Attach listener function on state changes 


});
