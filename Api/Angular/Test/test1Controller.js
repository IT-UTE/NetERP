app.controller('test1Controller', ['$scope', '$rootScope', 'navService', function ($scope, $rootScope, navService) {
    $scope.init = function () {
        $rootScope.pageLocation = 'Test sub-item 1';
        $scope.msg = 'Test 1 mesagge!';
    };
    $scope.init();
}]);