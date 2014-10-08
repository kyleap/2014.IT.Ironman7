MainApp.factory("CustService", function ($http, $q) {
    return {
        getData: function (currentPage, pageSize) {
            var deferred = $q.defer();
            $http.get('/api/Customer', { params: { CurrPage: currentPage, PageSize: pageSize } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },

        getCustomer: function (CustomerID) {
            var deferred = $q.defer();
            $http.get('/api/Customer', { params: { CustomerID: CustomerID } })
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },

        AddData: function (Customer) {
            var deferred = $q.defer();
            $http.post('/api/Customer', Customer)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },

        Update: function (Customer) {
            var deferred = $q.defer();
            $http.put('/api/Customer', Customer)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        },

        deleteCustomer: function (Cust) {
            var deferred = $q.defer();
            $http.delete('/api/Customer?id=' + Cust.CustomerID)
                .success(deferred.resolve)
                .error(deferred.reject);
            return deferred.promise;
        }

    }

});

