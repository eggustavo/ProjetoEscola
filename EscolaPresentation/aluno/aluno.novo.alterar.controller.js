angular.module('escola').controller('alunoNovoAlterarCtrl', function($http, $location, $routeParams) {
    var vm = this;

    var urlApi = 'http://localhost:59796/';

    vm.periodos = [
        'Manhã',
        'Tarde',
        'Noite'
    ];

    vm.aluno = {};
    vm.cursos = [];
    vm.salvar = salvar;

    inicializar();

    function inicializar() {
        carregarCursos();

        if ($routeParams.alunoId == null)
            return;

        $http.get(urlApi + 'api/v1/aluno/' + $routeParams.alunoId)
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            vm.aluno = response.data.dados;
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }
    }

    function carregarCursos() {
        $http.get(urlApi + 'api/v1/curso')
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            vm.cursos = response.data.dados;
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }        
    }

    function salvar() {
        $http.post(urlApi + 'api/v1/aluno', vm.aluno)
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            toastr.success(response.data.dados.mensagem, 'ETEC');
            $location.path('aluno/listar');
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }
    }
});