

MainApp.controller("CustEditCtrl", function ($scope, $location,$routeParams, $route, CustService) {
    var id = $routeParams.id;
    $scope.IsLoad = true;

    // 依據$routeParams取得的ID，去取得單筆客戶資料
    CustService.getCustomer(id).then(function (response) {
        // 給Customer ViewModel
        $scope.Customer = response;
        $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
    }, function () {
        $scope.error = "取得資料錯誤!";
        $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
    })

    // 更新
    $scope.Update = function () {
        CustService.Update($scope.Customer).then(function (response) {
            alert('更新成功!');
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        }, function (response) {
            alert('更新失敗!');
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        })
    }

});