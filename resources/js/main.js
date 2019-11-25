function getEl(id){
    return document.getElementById(id);
}

function prop(prop, key) {
    return setAttribute(prop, key);
}

function activeLink() {
    switch (location.pathname) {
        case "/index.aspx":
            getEl("nav_login").setAttribute("class", "active");
            break;
        case "/home.aspx":
            getEl("nav_home").setAttribute("class", "active");
            break;
        case "/about.aspx":
            getEl("nav_about").setAttribute("class", "active");
            break;
        case "/signup.aspx":
            getEl("nav_signup").setAttribute("class", "active");
            break;
        case "/admin.aspx":
            getEl("nav_admin").setAttribute("class", "active");
            break;
        default:
    }
}