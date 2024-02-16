// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Função para mostrar o modal ao clicar no carrinho
function abrirModalCarrinho() {
    var myModal = new bootstrap.Modal(document.getElementById('modalCarrinho'));
    myModal.show();
}

// Adiciona um ouvinte de evento de clique ao elemento do carrinho
document.getElementById('carrinhoLink').addEventListener('click', abrirModalCarrinho);