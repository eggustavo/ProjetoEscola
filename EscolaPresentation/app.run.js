angular.module('escola').run(function($rootScope, $location) {
    $rootScope.usuario = null;
    $rootScope.$on("$routeChangeStart", function (event, next, current) {
        if ($rootScope.usuario === null) {
            $location.path("/login");              
        }
    });   
});