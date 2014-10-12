var MainApp = angular.module('MainApp', ['ngRoute', 'ui.bootstrap']);
MainApp.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    var viewBase = '/App/';
    $routeProvider
            .when('/Customer', {
                controller: 'CustCtrl',
                templateUrl: viewBase + 'CustomerApp/List.html'
            })
            .when('/Customer/Add', {
                controller: 'CustAddCtrl',
                templateUrl: viewBase + 'CustomerApp/AddCustomer.html'
            })
            .when('/Customer/Edit/:id', {
                controller: 'CustEditCtrl',
                templateUrl: viewBase + 'CustomerApp/EditCustomer.html'
            })
            //.otherwise({
            //    controller: 'DashBoardCtrl',
            //    templateUrl: viewBase + 'DashBoardApp/Index.html'
            //});

    $locationProvider.html5Mode(true);

}]);
