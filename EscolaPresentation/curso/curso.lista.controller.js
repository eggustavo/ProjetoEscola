angular.module('escola').controller('cursoListaCtrl', function($http) {
    var vm = this;

    var urlApi = 'http://localhost:59796/';

    vm.cursos = [];
    vm.remover = remover;

    iniciar();

    function iniciar() {
        $http.get(urlApi + 'api/v1/curso')       
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            vm.cursos = response.data.dados;
        }

        function erro(response) {
            toastr.error('');
        }
    }

    function remover(curso) {
        $http.delete(urlApi + 'api/v1/curso/' + curso.id)
            .then(sucesso)
            .catch(erro);

        function sucesso(response) {
            var idx = vm.cursos.indexOf(curso);
            vm.cursos.splice(idx, 1);            
            toastr.success(response.data.dados.mensagem);
        }

        function erro(response) {
            toastr.error(response.data.notificacoes, 'ETEC');
        }        
    }
});