function SetupGrid(seletorTabela, opcoes) {
    const jqueryTabela = $(seletorTabela);
    const opcoesPadrao = {
        Url: "",
        Colunas: [
            "Idxxx",
            "Nomexxxx"
        ],
        ConteinerDoPaginador: "",
        Consulta: {
            ContagemDeLinhas: 0,
            ContagemDePaginas: 0,
            ItensPorPagina: 0,
            PaginaAtual: 0,
            OrdemNome: "",
            OrdemDirecao: 0
        }
    };
    const opcoesVigentes = Object.assign({}, opcoesPadrao, opcoes);
    const paginadoOrdenado = opcoesVigentes.Consulta;
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
        $.ajax(opcoesVigentes.Url, {
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
            AtualizarCabecalho();
        });
    }

    const PopularTabela = function () {
        var corpoDaTabela = jqueryTabela.find("tbody");
        corpoDaTabela.html('');
        for (var y = 0; y < paginadoOrdenado.Itens.length; y++) {
            var linha = $("<tr />");
            var itemLinha = paginadoOrdenado.Itens[y];
            for (var x = 0; x < opcoesVigentes.Colunas.length; x++) {
                var opcaoColuna = opcoesVigentes.Colunas[x];
                var celula;
                if (typeof (opcaoColuna) == 'string') {
                    celula = RenderizaCelulaPadrao(itemLinha[opcoesVigentes.Colunas[x]]);
                } else {
                    if (opcaoColuna.CallbackDeRenderizacao != null) {
                        celula = opcaoColuna.CallbackDeRenderizacao(itemLinha, opcoesVigentes.Colunas[x].NomeDoCampo);
                    }
                }
                linha.append(celula);
            }
            corpoDaTabela.append(linha);
        }
    }

    const RenderizaCelulaPadrao = function (texto) {
        var celula = $("<td />").append(texto);
        return celula;
    }

    const PaginadorClicado = function () {
        var essaPagina = $(this).html();
        PegarDados({ page: essaPagina });
    }

    const PopularPaginador = function () {
        var $paginador = $("<ul />").addClass("pagination");
        for (var i = 1; i <= paginadoOrdenado.ContagemDePaginas; i++) {
            var itemLink = "";
            $paginador.append(
                $("<li />").addClass(i == paginadoOrdenado.PaginaAtual ? "active" : "").append($('<a href="#"/>').on('click', PaginadorClicado).append(i))
            );
        }
        $(opcoesVigentes.ConteinerDoPaginador).html('').append($paginador);
    }


    const OrdenadorClicado = function () {
        var atributo = $(this).data("chave");
        var direcao = $(this).data("direcao");
        PegarDados({ sort: atributo, direction: direcao });
    }

    const AtualizarCabecalho = function () {
        var cabecalhos = jqueryTabela.find("thead").find("th");

        cabecalhos.each((indice, elementoHtml) => {

            var elemento = $(elementoHtml);

            if (elemento.data("sort") == true) {

                var atributo = elemento.data("key");
                var texto = elemento.data("texto");
                if (texto == undefined) {
                    texto = elemento.html();
                    elemento.data("texto", texto);
                }
                var linkDeOrdenacao = $("<a href=\"javascript:;\" />").html('').append(texto);

                linkDeOrdenacao.data('direcao', 0);
                linkDeOrdenacao.data('chave', atributo);

                if (paginadoOrdenado.OrdemNome == atributo) {
                    var indicadordeOrdenacao = $("<sub />");
                    if (paginadoOrdenado.OrdemDirecao == 1) {
                        indicadordeOrdenacao.append("DESC");
                    } else {
                        indicadordeOrdenacao.append("ASC");
                        linkDeOrdenacao.data('direcao', 1);
                    }
                }

                linkDeOrdenacao.append(indicadordeOrdenacao).on('click', OrdenadorClicado);
                elemento.html('').append(linkDeOrdenacao);
            }
        });
    }
    PegarDados();
}