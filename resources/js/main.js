function getEl(id){
    return document.getElementById(id);
}

function activeLink() {
    switch (location.pathname) {
        case "/index.aspx":
            getEl("nav_home").setAttribute("class", "active");
            break;
        case "/about.aspx":
            getEl("nav_about").setAttribute("class", "active");
            break;
        default:
    }
}