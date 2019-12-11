
const insertUser = function(setUser, setDept, setStatus){
    const Sequelize = require('sequelize');
    const sequelize = new Sequelize('chatideal', 'scrappers', '4lertr4ck', {
        host: '10.0.1.5',
        dialect: 'mysql'
    });
    sequelize.authenticate().then(function(){
    }).catch(function(erro){
        console.log("falha ao se conectar"+erro);
    });
    const User = sequelize.define('users',{
        user: {type: Sequelize.STRING},
        dept:{type: Sequelize.STRING},
        status:{type: Sequelize.BOOLEAN}
    });
    // User.sync({force: true});
    User.create({
        user: setUser,
        dept: setDept,
        status: setStatus
    });
    console.log(setUser)
};
module.exports = insertUser;

