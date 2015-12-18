var app = angular.module('app', ['ngRoute', 'ngAnimate']).run(['$rootScope', function ($rootScope) {
    $rootScope.pageLocation = '';
}]);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/home', {
            templateUrl: partialParser('home/home.html'),
            controller: 'homeController',
            caseInsensitiveMatch: false
        })
        .when('/test/test1', {
            templateUrl: partialParser('test/test1.html'),
            controller: 'test1Controller',
            caseInsensitiveMatch: false
        })
        .when('/test/test2', {
            templateUrl: partialParser('test/test2.html'),
            controller: 'test2Controller',
            caseInsensitiveMatch: false
        })
        .otherwise({
            redirectTo: '/home'
        });
    $locationProvider.html5Mode(true);
}]);

function partialParser(partial) {
    return '/partial?partial=~/angular/' + partial;
};
