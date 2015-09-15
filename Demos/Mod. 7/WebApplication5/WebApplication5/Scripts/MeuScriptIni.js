var Cliente = function (id, nome) {
    this.id = id;
    this.nome = nome;
    this.idade = 0;
    var _escopoInterno = "Variável de escopo interno";

    //precisa do this
    this.AlterarIdade = function (idade) {
        if (idade < 10) {
            alert("Idade não permitida");
            return false;
        }
        this.idade = idade;
    };

    this.ExibirNome = function () {
        alert(this.nome + " - da classe original");
    };

    this.ExibirVariavelPrivada = function () {
        alert(_escopoInterno);
        return _escopoInterno;
    };
};