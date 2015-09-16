var Test = 'ooops';
(
    function () {
        console.clear();
        console.log('iniciando script');
        window.addEventListener("load", init(Test));
    }
)(Test);

function init(texto) {
    console.log('após carregar o dom');
    console.log(texto);
}