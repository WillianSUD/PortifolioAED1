// faz com que seja possível enviar mensagens com Enter
document.getElementById('menssagem').addEventListener('keypress', function(e) {
    var key = e.which || e.keyCode;
    if (key === 13) {
        enviar_menssagem();
    }
});
// inicia o client socketIO
var socket = io();
// Abre um popup perguntando o nome da pessoa
var nome_usuario = prompt("Nome de Usuário: ");
var dept_usuario = prompt("Departamento do Usuário: ");

// TENTANDO INSERIR USUARIO NO BANCO DE DADOS
// var insertUser = require("insertUser");
// insertUser(nome_usuario, dept_usuario, 1);



//--------------------------------------------------------------------------------------
// CONDICIONAL ANTIGA
// Lista com alguns nomes do Final Fantasy

var ff = [
    "Cloud Strife",
    "Sephiroth",
    "Vincent Valentine",
    "Zack Fair",
    "Aerith Gainsborough",
    "Tifa Lockhart",
    "Barret Wallace",
    "Yuffie Kisaragi",
];
// Caso usuário não informe um nome será atribuido um nome aleatório da lista
if (nome_usuario === null || nome_usuario === "" || nome_usuario === " ") {
    nome_usuario = ff[Math.floor(Math.random() * ff.length)];
}
//--------------------------------------------------------------------------------------


socket.emit('chat message', nome_usuario + "(" + dept_usuario + ")" +" se conectou ao chat.");
// adiciona um addEventListener para o botão de submit
document.getElementById('enviar_menssagem').addEventListener("click", enviar_menssagem);
// cria a função que conecta no websocket e emite a mensagem
function enviar_menssagem() {
    // salva a mensagem como uma string
    msg = document.getElementById('menssagem').value;

    //TENTANDO INSERIR MENSAGEM AO BANCO DE DADOS
    // var insertMessage = require("insertMessage");
    // insertMessage(nome_usuario, msg, 'sei la');


    if (msg.length > 0) {
        console.log(msg);
        // concatena o nome de usuário e a mensagem para enviar ao socketIo
        socket.emit('chat message', nome_usuario + ": " + msg);

        // reseta o valor do input da mensagem
        document.getElementById('menssagem').value = "";
    }
}
// sempre que receber uma mensagem ela é adicionada a lista
socket.on('chat message', function(msg){
    // busca o elemento UL
    let ul = document.getElementById("messages");
    // cria um elemento LI
    let li = document.createElement('li');
    // cria o elemento de quebra de linha
    let br = document.createElement('br');
    li.appendChild(document.createTextNode(msg));
    // adicionar o nome do usuário quebra a linha e adicionar a mensagem à lista de mensagems
    ul.appendChild(li);
});