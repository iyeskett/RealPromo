"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/PromoHub").withAutomaticReconnect().build();

start();

connection.onclose(async (err) => {
    await start();
})

var btnCadastrar = document.querySelector("#btnCadastrar");

if (btnCadastrar != null) {
    btnCadastrar.addEventListener("click", function (e) {
        e.preventDefault();

        var empresa = document.querySelector("#empresa").value;
        var chamada = document.querySelector("#chamada").value;
        var regras = document.querySelector("#regras").value;
        var enderecoURL = document.querySelector("#enderecoURL").value;

        var promocao = { Empresa: empresa, Chamada: chamada, Regras: regras, EnderecoURL: enderecoURL }

        connection.invoke("CadastrarPromocao", promocao)
            .then(() => {
                console.info("Cadastrado com sucesso");
            })
            .catch((err) => {
                console.error(err.toString());
            });
    })
}

connection.on("CadastroRealizado", () => {
    document.querySelector("#formPromo").reset();

    var mensagem = document.querySelector("#mensagem");

    mensagem.innerHTML = "Cadastro de promoção realizado com sucesso";
});

connection.on("ReceberPromocao", (promocao) => {
    var container = document.querySelector("#container-login");

    var containerPromo = document.createElement("div");
    containerPromo.setAttribute("class", "container-promo");

    var containerChamada = document.createElement("div");
    containerChamada.setAttribute("class", "container-chamada");

    var h1Titulo = document.createElement("h1");
    h1Titulo.innerText = promocao.empresa;

    var p1 = document.createElement("p");
    p1.innerText = promocao.chamada;

    var p2 = document.createElement("p");
    p2.innerText = promocao.regras;

    var containerBotao = document.createElement("div");
    containerBotao.setAttribute("class", "container-botao");

    var link = document.createElement("a");
    link.setAttribute("href", promocao.enderecoURL);
    link.setAttribute("target", "_blank");
    link.innerText = "Pegar";

    containerChamada.appendChild(h1Titulo);
    containerChamada.appendChild(p1);
    containerChamada.appendChild(p2);

    containerBotao.appendChild(link);

    containerPromo.appendChild(containerChamada);
    containerPromo.appendChild(containerBotao);

    container.insertBefore(containerPromo, container.firstChild);
});

function start() {
    connection.start()
        .then(() => {
            console.info("Connected");
        })
        .catch((err) => {
            console.error(err.toString());
            setTimeout(() => start(), 5000)
        })
}