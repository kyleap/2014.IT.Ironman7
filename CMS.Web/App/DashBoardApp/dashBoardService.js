MainApp.factory("DashBoardService", function ($http, $q) {
    return {
        getData: function () {
            var deferred = $q.defer();
            $http.get('/api/DashBoard')
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }
    }
});

