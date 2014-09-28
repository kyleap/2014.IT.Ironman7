var MainApp = angular.module('MainApp', ['ngRoute', 'ui.bootstrap']);
MainApp.config(['$routeProvider','$locationProvider', function ($routeProvider, $locationProvider) {
    var viewBase = '/App/CustomerApp/';
    $routeProvider
            .when('/Customer', {
                controller: 'CustCtrl',
                templateUrl: viewBase + 'List.html',
            })
            .when('/Customer/Add', {
                controller: 'CustCtrl',
                templateUrl: viewBase + 'Add.html'
            })

    $locationProvider.html5Mode(true);

}]);
