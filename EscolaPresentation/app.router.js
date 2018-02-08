angular.module('escola').config(function($routeProvider) {
    $routeProvider
    .when('/', {
        templateUrl: 'home/home.html'
    })
    .when('/login', {
        templateUrl: 'login/login.html',
        controller: 'loginCtrl',
        controllerAs: 'vm'
    })    
    .when('/curso/listar', {
        templateUrl: 'curso/curso.lista.html',
        controller: 'cursoListaCtrl',
        controllerAs: 'vm'
    })
    .when('/curso/novo', {
        templateUrl: 'curso/curso.novo.alterar.html',
        controller: 'cursoNovoAlterarCtrl',
        controllerAs: 'vm'
    })
    .when('/curso/alterar/:cursoId', {
        templateUrl: 'curso/curso.novo.alterar.html',
        controller: 'cursoNovoAlterarCtrl',
        controllerAs: 'vm'
    })
    .when('/aluno/listar', {
        templateUrl: 'aluno/aluno.lista.html',
        controller: 'alunoListaCtrl',
        controllerAs: 'vm'
    })
    .when('/aluno/novo', {
        templateUrl: 'aluno/aluno.novo.alterar.html',
        controller: 'alunoNovoAlterarCtrl',
        controllerAs: 'vm'
    })
    .when('/aluno/alterar/:alunoId', {
        templateUrl: 'aluno/aluno.novo.alterar.html',
        controller: 'alunoNovoAlterarCtrl',
        controllerAs: 'vm'
    })
    .otherwise({
        redirectTo: '/'
    });
});