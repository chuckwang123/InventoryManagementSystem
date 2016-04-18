angular.module('StockApp', [])
    .controller('StockController', function ($scope, $http) {
        $scope.title = "Stock Info";
        $scope.working = false;
        $scope.StockCollection = function () {
            $http.get("/api/Stock").success(function (data, status, headers, config) {
                $scope.Stocks = [];
                angular.forEach(data, function (value, key) {
                    $scope.Stocks.push(value);
                });
                $scope.working = false;
            }).error(function (data, status, headers, config) {
                $scope.title = "Oops... something went wrong";
                $scope.working = false;
            });
        };
    });