function TagImagem() {
    return document.querySelector("#swagger-ui > section > div.topbar > div > div > a > img");
}

function TagLabel() {
    return document.querySelector("#swagger-ui > section > div.topbar > div > div > form > label > span");
}

var doJs = function () {
    TagImagem().src = "/assets/swagger-ui/custom-logo.png";
    TagLabel().innerHTML = "Selecione a versão:";
}

function waitHtmlLoad() {
    if (!TagImagem()) {
        setTimeout(waitHtmlLoad, 5);
    } else {
        doJs();
    }
}

waitHtmlLoad();
