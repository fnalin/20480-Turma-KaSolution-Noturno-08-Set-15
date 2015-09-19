this.onmessage = function (e) {
    if (e.data > 0) {
        var calc = new CalculandoFibonacci();
        calc.generateFibonacciSeries(e.data);
    }
};

var CalculandoFibonacci = function () {
    var results = [];

    var calculateNextFibonacciValue = function (n) {
        var s = 0;
        var returnValue;

        if (n == 0) {
            return (s);
        }
        if (n == 1) {
            s += 1;
            return (s);
        }
        else {
            return (calculateNextFibonacciValue(n - 1) + calculateNextFibonacciValue(n - 2));
        }
    };

    this.generateFibonacciSeries = function (n) {
        for (var i = 0; i <= n - 1; i++) {
            results.push(calculateNextFibonacciValue(i));
        }
        postMessage(results);
    }
};