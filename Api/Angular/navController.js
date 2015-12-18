app.controller('navController', ['$scope', 'navService', function ($scope, navService) {
    $scope.init = function () {
        $scope.navItems = [];
        $scope.navItems.push({
            href: '/home',
            text: 'Home',
            icon: 'dashboard',
            active: false
        });
        $scope.navItems.push({
            href: '/test',
            text: 'Test',
            icon: 'alert',
            active: false,
            subItems: [
                {
                    href: '/test/test1',
                    text: 'Sub menu test1',
                    icon: 'bell'
                },
                {
                    href: '/test/test2',
                    text: 'Sub menu test2',
                    icon: 'bell'
                }
            ]
        });
        navService.activeCallback = function (href) {
            active = href;
            jQuery.each($scope.navItems, function (i, v) { v.active = false; });
        };
    };
    var active = '';
    $scope.isActive = function (item) {
        return item.active || item.href == active || (item.subItems && $.grep(item.subItems, function (e) { return e.href == active; }).length > 0);
    };

    $scope.init();
}]);