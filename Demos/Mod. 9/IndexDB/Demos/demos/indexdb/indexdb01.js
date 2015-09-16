/*
 * script para a demo indexdb01
 */

//Variáveis globais
var openRequest, initDB, objStore;

//adicionando evento após o carregamento do DOM (semelhante ao $.ready() no jQuery)
window.addEventListener('load', AddEventos, false);

//#region Funções Disparadas nos eventos
function Escreve(msg) {
    //Função que encapsula a saída para a div e o console

    var outPut = document.getElementById('outPut');

    if (msg) {
        if (typeof msg === 'string') {
            //só escreve na div se for texto o argumento da função
            var conteudo = outPut.innerHTML;
            outPut.innerHTML = conteudo + "<br />" + ">> " + msg;
            outPut.scrollTop = outPut.scrollHeight;
        }
        //joga no console tanto texto quanto objeto
        console.log(msg);
    } else {
        //limpa conteúdo da div qdo não passao argumento na função
        outPut.innerHTML = '';
    }
}

function AddEventos() {
    //Função disparada após o carregamento do DOM (window.addEventListener)

    var btnOpenDB = document.getElementById('btnOpenDB');
    var btnDeleteDB = document.getElementById('btnDeleteDB');
    var btnClear = document.getElementById('btnLimpar');
    var btnInsertDB = document.getElementById("btnInsertDB");
    var btnGetDB = document.getElementById("btnGetDB");
    var btnUpdateDB = document.getElementById('btnUpdateDB');
    var btnCloseDB = document.getElementById('btnCloseDB');
    var btnDeleteCli = document.getElementById('btnDeleteCli');
    var btnGetAll = document.getElementById('btnGetAll');

    //Adicionando eventos aos botões
    btnOpenDB.addEventListener('click', OpenDB, false);
    btnCloseDB.addEventListener('click', CloseDB, false);
    btnDeleteDB.addEventListener('click', DeleteDB, false);
    btnClear.addEventListener('click', LimparTela, false);
    btnInsertDB.addEventListener('click', InsertCliente, false);
    btnGetDB.addEventListener('click', GetCliente, false);
    btnGetAll.addEventListener('click', GetTodos, false);
    btnUpdateDB.addEventListener('click', UpdateCliente, false);
    btnDeleteCli.addEventListener('click', DeleteCliente, false);

    //ObjectStores usados para armazenar clientes e alunos
    objStore = ['clientes', 'alunos'];

    Escreve('Aguardando abertura da base.');
}

function LimparTela() {
    Escreve();
}

function OpenDB() {
    //Abrindo a base InitDB e na versão informada
    if (!initDB) {

        //jogo a abertura numa variável para disparar evento assíncrono
        openRequest = indexedDB.open('InitDB', 1);
        Escreve(openRequest);

        //Em caso de erro na tentativa de abertura
        openRequest.onerror = function () {
            Escreve('Erro');
        };

        //só entra aqui na criação ou atualização de versão do indexdb
        openRequest.onupgradeneeded = function (e) {
            Escreve('Atualização necessária');

            var newVersion = e.target.result;
            Escreve(newVersion);

            //criando os ObjectStores armazenaso no array objStore
            var nObjs = objStore.length;
            for (var i = 0; i < nObjs; i++) {
                if (!newVersion.objectStoreNames.contains(objStore[i])) {
                    newVersion.createObjectStore(objStore[i], { autoIncrement: true });
                    Escreve('Criado ' + objStore[i]);
                }
            }
        };

        //Se tudo ok
        openRequest.onsuccess = function (e) {
            Escreve('Database aberto!');
            initDB = e.target.result;
            Escreve(initDB);
        };
    } else
        Escreve('A base já está aberta!');
}

function CloseDB() {
    if (initDB) {
        Escreve('fechando base...');
        initDB.close();
        openRequest = initDB = undefined;
        Escreve('Base fechada com sucesso');
    } else
        Escreve('A base já está fechada');
}

function DeleteDB() {
    if (initDB) {
        Escreve('fechando base...');
        initDB.close();

        var deleteDB = window.indexedDB.deleteDatabase('InitDB');

        deleteDB.onerror = deleteDB.onblocked = function () {
            Escreve('Não é possível excluir a base, verifique se a continua aberta');
        };

        deleteDB.onsuccess = function () {
            Escreve('Base excluída com sucesso!');
            openRequest = initDB = undefined;
        };

    } else
        Escreve('Abra a base antes de excluí-la!');
}

function InsertCliente() {
    if (initDB) {

        //Obj a ser inserido
        var dt = new Date(); //data usada no obj
        var cliente = {
            clienteid: '4a385d3c-9ec6-4021-a68f-dd4c12a69345', //guid qualquer
            nome: 'José da Silva',
            telefone: '(11) 5555-5555',
            dtcadastro: dt,
            dtmodificacao: dt
        };

        //iniciar a transação do tipo readwrite no objectstore clientes
        var transacao = initDB.transaction(objStore[0], 'readwrite');

        //instância do objectStore que armazenará o novo registro
        var store = transacao.objectStore(objStore[0]);

        //jogo a inclusão numa variável para disparar evento do obj assíncrono
        var addRequest = store.add(cliente);

        //criando event listener para confirmar exclusão e obter a key
        addRequest.onsuccess = function (e) {
            Escreve("Adicionado registro - ID:" + e.target.result);
            Escreve(e.target);
        };
        //event listener em caso de erro
        addRequest.onerror = function () {
            Escreve('Não foi possível adicionar o cliente');
        };

    } else
        Escreve('Abra a base antes de inserir o cliente');
}

function GetCliente() {
    if (initDB) {

        //iniciar a transação do tipo readonly no objectstore clientes
        var transacao = initDB.transaction(objStore[0], 'readonly');

        //instância do objectStore onde buscaremos o registro
        var store = transacao.objectStore(objStore[0]);

        //id do cliente
        var key = 1;

        //jogando o retorno do get numa variável para consultarmos o método assíncrono onsucess
        var getRequest = store.get(key);

        //event listener após o sucess do get
        getRequest.onsuccess = function (e) {

            //obtendo o retorno do get
            var cliente = e.target.result;

            //verificando se houve o retorno esperado
            if (cliente) {
                var texto =
                    "Key: " + key +
                    " | ClienteID: " + cliente.clienteid +
                    " | Nome: " + cliente.nome +
                    " | Telefone: " + cliente.telefone +
                    " | Cadastro: " + cliente.dtcadastro +
                    " | Modificado: " + cliente.dtmodificacao;

                Escreve(texto);
                Escreve(cliente);
            } else
                Escreve('Registro não encontrado!');

            //event listener em caso de erro
            getRequest.onerror = function () {
                Escreve('Erro na tentativa de obter o cliente');
            };
        };
    } else
        Escreve('Abra a base antes de obter o cliente');
}

function GetTodos() {
    if (initDB) {

        //iniciar a transação do tipo readonly no objectstore clientes
        var transacao = initDB.transaction(objStore[0], 'readonly');

        //instância do objectStore onde buscaremos o registro
        var store = transacao.objectStore(objStore[0]);

        //obtendo um cursor para navegar entre os registros
        var cursorRequest = store.openCursor();

        cursorRequest.onsuccess = function (e) {
            var cliente = {};
            var result = e.target.result;


            if (result) {
                cliente = result.value;
                var texto =
                    "Key: " + result.key +
                    " | ClienteID: " + cliente.clienteid +
                    " | Nome: " + cliente.nome +
                    " | Telefone: " + cliente.telefone +
                    " | Cadastro: " + cliente.dtcadastro +
                    " | Modificado: " + cliente.dtmodificacao;

                Escreve(texto);
                Escreve(cliente);
                result.continue();
            } else
                Escreve('Não existem mais registros');
        };

        cursorRequest.onerror = function (e) {
            Escreve('Erro ao instanciar cursor');
        };



    } else
        Escreve('Abra a base antes de obter os clientes');
}

function UpdateCliente() {
    if (initDB) {

        //iniciar a transação do tipo readwrite no objectstore clientes
        var transacao = initDB.transaction(objStore[0], 'readwrite');

        //instância do objectStore onde buscaremos o registro
        var store = transacao.objectStore(objStore[0]);

        //id do cliente
        var key = 1;

        //jogando o retorno do get numa variável para consultarmos o método assíncrono onsucess
        var getRequest = store.get(key);

        //event listener após o sucess do get
        getRequest.onsuccess = function (e) {

            //obtendo o retorno do get
            var cliente = e.target.result;

            //verificando se houve o retorno esperado
            if (cliente) {
                //atualizando os dados do cliente
                cliente.nome = "José Alterado";
                cliente.telefone = "(11) 1111-1111";
                //atualizando a data de modificação -- COMPARE com a data de cadastro
                cliente.dtmodificacao = new Date();

                //atualizando o cliente no objectstore
                var putRequest = store.put(cliente, key);

                //event listener após o sucess do put
                putRequest.onsuccess = function () {
                    Escreve('Cliente atualizado com sucesso');
                    Escreve(cliente);
                };

                //em caso do erro no put
                putRequest.onerror = function () {
                    Escreve('Erro na tentativa de atualizar o cliente');
                };

            } else
                Escreve('Registro não encontrado!');

            //event listener em caso de erro no get
            getRequest.onerror = function () {
                Escreve('Erro na tentativa de obter o cliente');
            };
        };
    } else
        Escreve('Abra a base antes de atualizar o cliente');
}

function DeleteCliente() {
    if (initDB) {

        //iniciar a transação do tipo readwrite no objectstore clientes
        var transacao = initDB.transaction(objStore[0], 'readwrite');

        //instância do objectStore onde buscaremos o registro
        var store = transacao.objectStore(objStore[0]);

        //id do cliente
        var key = 1;

        //Poderia excluir sem consultar se tem ou não o obj
        //var deleteRequest = store.delete(key);

        //jogando o retorno do get numa variável para consultarmos o método assíncrono onsucess
        var getRequest = store.get(key);

        //event listener após o sucess do get
        getRequest.onsuccess = function (e) {

            //obtendo o retorno do get
            var cliente = e.target.result;

            //verificando se houve o retorno esperado
            if (cliente) {
                //jogando o retorno do delete numa variável para consultarmos os métodos assíncronos (onsucess,onerror,etc.)
                var deleteRequest = store.delete(key);

                deleteRequest.onsuccess = function () {
                    Escreve('Cliente excluído com sucesso');
                };

                deleteRequest.onerror = function () {
                    Escreve('Houve um erro na tentativa de excluir o cliente');
                };


            } else
                Escreve('Registro não encontrado!');


        };

        //event listener em caso de erro no get
        getRequest.onerror = function () {
            Escreve('Erro na tentativa de obter o cliente');
        };

    } else
        Escreve('Abra a base antes de excluir o cliente');
}
//#endregion