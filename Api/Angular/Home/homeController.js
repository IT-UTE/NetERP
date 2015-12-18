app.controller('homeController', ['$scope', '$rootScope', 'navService', function ($scope, $rootScope, navService) {
    $scope.init = function () {
        $rootScope.pageLocation = 'Home';
        $scope.msg = 'Mesagge!';
    };

    $scope.init();
}]);