angular.module('escola').controller('cursoNovoAlterarCtrl', function($http, $location, $routeParams) {
    var vm = this;

    var urlApi = 'http://localhost:59796/';

    vm.periodos = [
        'Manhã',
        'Tarde',
        'Noite'
    ];

    vm.curso = {};
    vm.salvar = salvar;

    inicializar();

    function inicializar() {
        if ($routeParams.cursoId == null)
            return;

        $http.get(urlApi + 'api/v1/curso/' + $routeParams.cursoId)
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            vm.curso = response.data.dados;
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }
    }

    function salvar() {
        $http.post(urlApi + 'api/v1/curso', vm.curso)
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            toastr.success(response.data.dados.mensagem, 'ETEC');
            $location.path('curso/listar');
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }
    }
});