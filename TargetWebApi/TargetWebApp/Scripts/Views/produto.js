$(document).ready(function () {

    carregarListaProdutosCadastrados();
   
})

function carregarListaProdutosCadastrados() {
    showBlockUI();
    $("#tableProdutos").load("/Produtos/GetProdutosCadastrados",
        function () {
            hideBlockUI();
        }
    );
}

function Alterar(id) {

    showBlockUI();

    $.ajax({
        type: 'POST',
        url: '/Produtos/ObterPorId',
        data: { Id: id },
        success: function (result) {
            if (Object.keys(result).length > 0) {
                hideBlockUI();
                $.fancybox.open({
                    src: '#formProdutos',
                    type: 'inline'
                });


                $("#Id").val(result.ID);
                $("#Descricao").val(result.Descricao);
                $("#CodBarras").val(result.CodBarras);
                $("#IdFornecedor").val(result.ID_Fornecedor);
                $("#EstoqueMinimo").val(result.EstoqueMinimo);
                $("#EstoqueMaximo").val(result.EstoqueMaximo);
                $("#valorCompra").val(result.ValorCompraVisualizacao);
                $("#valorVenda").val(result.ValorVendaVisualizacao);

            }
            else {
                hideBlockUI();
            }
        },
        error: function (XMLHttpRequest, txtStatus, errorThrown) {
            alert("Status: " + txtStatus); alert("Error: " + errorThrown);
            hideBlockUI();
        }
    });
}

$("#btnConfirmar").click(function () {
    var Id = $("#Id").val();
    var Descricao = $("#Descricao").val();
    var CodBarras = $("#CodBarras").val();
    var IdFornecedor = $("#IdFornecedor").val();
    var EstoqueMinimo = $("#EstoqueMinimo").val();
    var EstoqueMaximo = $("#EstoqueMaximo").val();
    var valorCompra = $("#valorCompra").val();
    var valorVenda = $("#valorVenda").val();

    if (Descricao == "") {
        msg += "Por favor, informe uma descrição para o produto.<br />";
    }
    else {
        showBlockUI();
        $.ajax({
            type: 'POST',
            url: '/Produtos/Gravar',
            data: {
                Id: Id, Descricao: Descricao, CodBarras: CodBarras, IdFornecedor: IdFornecedor,
                EstoqueMinimo: EstoqueMinimo, EstoqueMaximo: EstoqueMaximo, valorCompra: valorCompra, valorVenda: valorVenda
            },
            success: function (result) {
                hideBlockUI();
                if (result.length > 0) {
                    Mensagem("divAlertaNovoProduto", result);
                }
                else {
                    LimparFormulario();
                    $.fancybox.close();
                    carregarListaProdutosCadastrados();
                }
            },
            error: function (XMLHttpRequest, txtStatus, errorThrown) {
                alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                hideBlockUI();
            }
        });
    }
});

function LimparFormulario() {
    $("#Id").val('-1');
    $("#Descricao").val('');
    $("#CodBarras").val('');
    $("#IdFornecedor").val('-1');
    $("#EstoqueMinimo").val('0');
    $("#EstoqueMaximo").val('0');
    $("#valorCompra").val('0,00');
    $("#valorVenda").val('0,00');
}

function Excluir(id) {
    bootbox.confirm({
        message: "Confirma a exclusão deste registro?",
        buttons: {
            confirm: {
                label: 'Sim',
                className: 'btn-success'
            },
            cancel: {
                label: 'Não',
                className: 'btn-danger'
            }
        },
        callback: function (result) {
            if (result) {
                showBlockUI();
                $.ajax({
                    type: 'POST',
                    url: '/Produtos/Excluir',
                    data: { Id: id },
                    success: function (result) {
                        if (result == "") {
                            carregarListaProdutosCadastrados();
                        }
                        else {
                            Mensagem("divAlertaNovoProduto", result);
                        }

                        hideBlockUI();
                    },
                    error: function (XMLHttpRequest, txtStatus, errorThrown) {
                        alert("Status: " + txtStatus); alert("Error: " + errorThrown);
                        hideBlockUI();
                    }
                });
            }
        }
    });
};