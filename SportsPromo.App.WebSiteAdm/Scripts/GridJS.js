function SetupGrid(seletorTabela, options) {

    const jqueryTabela = $(seletorTabela);

    const defaultOptions = {
        Url: "",
        Columns: [
            "Idxxx",
            "Nomexxxx"
        ],
        ConteinerDoPaginador:"",
        QueryObject: {
            ContagemDeLinhas: 0,
            ContagemDePaginas: 0,
            ItensPorPagina: 0,
            PaginaAtual: 0,
            OrdemNome: "",
            OrdemDirecao: 0
        }
    };
    const currentOptions = Object.assign({}, defaultOptions, options);
    const url = currentOptions.Url;

    const paginadoOrdenado = currentOptions.QueryObject;


    const Preparar = function () {

        const resultado = {
            page: paginadoOrdenado.PaginaAtual,
            sort: paginadoOrdenado.OrdemNome,
            direction: paginadoOrdenado.OrdemDirecao,
        };
        return resultado;
    }

    const PegarDados = function (opcoesDePegar) {
        var dadosPreparados = Object.assign({}, Preparar(), opcoesDePegar);
        $.ajax(url, {
            method: "GET",
            data: dadosPreparados
        }).done(function (response, textStatus, jqXHR) {
            paginadoOrdenado.Itens = response;
            paginadoOrdenado.ContagemDeLinhas = jqXHR.getResponseHeader("X-ITEM_COUNT");
            paginadoOrdenado.ContagemDePaginas = jqXHR.getResponseHeader("X-PAGE_COUNT");
            paginadoOrdenado.ItensPorPagina = jqXHR.getResponseHeader("X-PAGE_SIZE");
            paginadoOrdenado.PaginaAtual = jqXHR.getResponseHeader("X-PAGE_CURRENT");
            paginadoOrdenado.OrdemDirecao = jqXHR.getResponseHeader("X-SORT_DIRECTION");
            paginadoOrdenado.OrdemNome = jqXHR.getResponseHeader("X-SORT");
            PopularTabela();
            PopularPaginador();
        });

    }
    const PopularTabela = function () {

        jqueryTabela.find("tbody").html('');

        for (var y = 0; y < paginadoOrdenado.Itens.length; y++) {
            var linha = $("<tr />");
            var itemLinha = paginadoOrdenado.Itens[y];
            for (var x = 0; x < currentOptions.Columns.length; x++) {
                var atributo = itemLinha[currentOptions.Columns[x]];
                var celula = linha.append($("<td />").append(atributo))
            }
            jqueryTabela.find("tbody").append(linha);
        }
    }

    const PopularPaginador = function () {
        var $paginador = $("<ul />").addClass("pagination");

        for (var i = 1; i <= paginadoOrdenado.ContagemDePaginas; i++) {
            var itemLink = "";
            $paginador.append(
                $("<li />").append($('<a href="#"/>').on('click', PaginadorClicado).append(i))
            );
            
            

        }
        $(currentOptions.ConteinerDoPaginador).html('').append($paginador);
    }




    PegarDados();

    const PaginadorClicado = function () {
        var essaPagina = $(this).html();
        PegarDados({ page: essaPagina });
    }

}