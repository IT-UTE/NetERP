app.controller('test2Controller', ['$scope', '$rootScope', 'navService', function ($scope, $rootScope, navService) {
    $scope.init = function () {
        $rootScope.pageLocation = 'Test sub-item 2';
        $scope.msg = 'Test 2 mesagge!';
    };
    $scope.init();
}]);