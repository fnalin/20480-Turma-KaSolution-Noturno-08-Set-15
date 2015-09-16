/*
    script para a demo webstorage
*/
var tipostorage;
var strtipo = '';

var funcoes = {
    init: function () {
        //alert('carregou o dom');
        output.innerHTML = "";
        document.getElementById('tipostorage').innerHTML = strtipo + ' Storage';

        //Monitorando o webstorage --> enviando o objeto alterado ao log
        //Só é disparado em outra sessão do browser
        window.addEventListener('storage', function (e) { console.log(e) }, false);

        if (tipostorage.length > 0)
            funcoes.obtertodoslocal();

        btnAddKey.onclick = function () {
            var chave = key.value;
            var valor = value.value;

            if (chave.length > 0 && valor.length > 0)
                funcoes.addkey(chave, valor);

            key.value = '';
            value.value = '';
            key.focus();
        };

        keys.onchange = function () {
            output.innerHTML = "";
            if (this.selectedIndex > 0)
                funcoes.obterkey(this.value);
        };

        remove.onclick = function () {
            if (keys.selectedIndex > 0) {
                if (confirm("Deseja realmente excluir o " + keys.value + "?")) {
                    tipostorage.removeItem(keys.value);
                    keys.remove(keys.selectedIndex);
                    output.innerHTML = '';
                }
                return null;
            }
            alert('Selecione o item a ser excluído!');
        };
    },
    additem: function (key, value) {
        var selectKeys = document.getElementById('keys');
        selectKeys.options[0].text = "Selecione uma das keys ...";
        var option = document.createElement("option");
        option.text = key;
        option.value = key;
        selectKeys.appendChild(option);
        selectKeys.selectedIndex = 0;
    },
    addkey: function (key, value) {
        if (window.localStorage) {
            //alert("key: " + key + " | value: " + value);

            tipostorage.setItem(key, value);
            //localStorage[key] = value;

            funcoes.additem(key, value);
            output.innerHTML = "";
        } else {
            alert("sem suporte");
        }
    },
    obterkey: function (key) {
        var valor = tipostorage.getItem(key);
        //var valor = localStorage[key];
        output.innerHTML =
            "<p>Key: " + key + " | valor: " + (valor != null ? valor : "não encontrado") + "</p>";
    },
    obtertodoslocal: function () {
        var selectKeys = document.getElementById('keys');
        selectKeys.options[0].text = "Selecione uma das keys ...";
        var total = tipostorage.length;

        for (var i = 0; i < total; i++) {
            var option = document.createElement("option");
            var key = tipostorage.key(i);
            option.text = key;
            option.value = key;
            selectKeys.appendChild(option);
        }
        selectKeys.selectedIndex = 0;
    }
};

(function () {
    addEventListener('load', funcoes.init);
    //alert('ainda não carregou o dom.');

    if (window.location.search.indexOf('session') != -1) {
        strtipo = 'Session';
        tipostorage = window.sessionStorage;
    }
    else {
        strtipo = 'Local';
        tipostorage = window.localStorage;
    }
}
)();