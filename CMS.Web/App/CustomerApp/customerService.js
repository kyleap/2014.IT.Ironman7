MainApp.factory("CustService", function ($http, $q) {
    return {
        getData: function (currentPage, pageSize) {
            var deferred = $q.defer();
            $http.get('/api/Customer', { params: { CurrPage: currentPage, PageSize: pageSize } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }
    }
});

