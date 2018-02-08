angular.module('escola').controller('alunoListaCtrl', function($http) {
    var vm = this;

    var urlApi = 'http://localhost:59796/';

    vm.alunos = [];
    vm.remover = remover;

    iniciar();

    function iniciar() {
        $http.get(urlApi + 'api/v1/aluno')       
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            vm.alunos = response.data.dados;
        }

        function erro(response) {
            toastr.error('');
        }
    }

    function remover(aluno) {
        $http.delete(urlApi + 'api/v1/aluno/' + aluno.id)
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            var idx = vm.alunos.indexOf(aluno);
            vm.alunos.splice(idx, 1);
            toastr.success(response.data.dados.mensagem);
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }        
    }
});