
const insertMessage = function(setMessage, setFrom, setFor){
    const Sequelize = require('sequelize');
    const sequelize = new Sequelize('chatideal', 'scrappers', '4lertr4ck', {
        host: '10.0.1.5',
        dialect: 'mysql'
    });
    sequelize.authenticate().then(function(){
    }).catch(function(erro){
        console.log("falha ao se conectar"+erro);
    });
    const Message = sequelize.define('messages',{
        message: {type: Sequelize.TEXT},
        from:{type: Sequelize.STRING},
        for:{type: Sequelize.STRING}
    });
    // Message.sync({force: true});
    Message.create({
        message: setMessage,
        from: setFrom,
        for: setFor
    });
    // console.log(setMessage+'/'+setFrom+'/'+setFor)
};
module.exports = insertMessage;