app.service('navService', ['$location', '$rootScope', function ($location, $rootScope) {
    var navService = {};
    navService.activeCallback = null;
    function active(href) {
        if (navService.activeCallback) navService.activeCallback(href);
    }

    $rootScope.$on('$routeChangeSuccess', function (next, current) { active($location.path()); });

    return navService;
}]);