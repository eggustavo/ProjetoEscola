angular.module('escola').controller('loginCtrl', function($rootScope, $location) {
    var vm = this;

    vm.usuario = {};
    vm.login = login;
    vm.logout = logout;

    function login() {
        if (vm.usuario.email === 'adm@etec.com.br' && vm.usuario.senha === 'etec') {
            $rootScope.usuario = vm.usuario;
            $location.path('/');
        } else {
            toastr.error('Usuário ou Senha Inválidos!!!','ETEC');
        }
    }

    function logout() {
        $rootScope.usuario = null;
        $location.path('/login');        
    }
});