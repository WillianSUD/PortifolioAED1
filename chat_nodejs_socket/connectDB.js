//----------------------------------------------------------------------------------------------------
// ESTE BLOCO REALIZA CONEXÃO COM BANCO DE DADOS ESPECIFICADO

const Sequelize = require('sequelize');
const sequelize = new Sequelize('chatideal', 'scrappers', '4lertr4ck', {
    host: '10.0.1.5',
    dialect: 'mysql'
});
//----------------------------------------------------------------------------------------------------


//----------------------------------------------------------------------------------------------------
// ESTE BLOCO VERIFICA SE A CONEXÃO COM O BANCO DE DADOS FOI BEM SUCEDIDA OU NÃO

sequelize.authenticate().then(function(){
    console.log("Conectado com sucesso!");
}).catch(function(erro){
    console.log("falha ao se conectar"+erro);
});
//----------------------------------------------------------------------------------------------------


//----------------------------------------------------------------------------------------------------
// ESTE BLOCO É RESPONSÁVEL POR CRIAR OS MODELS (TABELAS E SUAS COLUNAS)

const User = sequelize.define('users',{
    user: {type: Sequelize.STRING},
    dept:{type: Sequelize.STRING},
    status:{type: Sequelize.BOOLEAN}
});

const Message = sequelize.define('messages',{
    message: {type: Sequelize.TEXT},
    from:{type: Sequelize.STRING},
    for:{type: Sequelize.STRING}
});

// CRIA O MODEL DESEJADO NO BANCO DE DADOS

// User.sync({force: true});
// Message.sync({force: true});
//----------------------------------------------------------------------------------------------------


//----------------------------------------------------------------------------------------------------
// ESTE BLOCO REALIZA A INSERÇÃO NO BANCO DE DADOS UTILIZANDO O MODEL

Message.create({
    message: "nao funciona mesmo",
    from: "Leonardo",
    for: "DB"
});

User.create({
    user: "Leonardo",
    dept: "DEV",
    status: 0
});
//----------------------------------------------------------------------------------------------------
