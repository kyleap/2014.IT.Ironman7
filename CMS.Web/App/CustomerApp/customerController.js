

MainApp.controller("CustCtrl", function ($scope,$location,$route, CustService) {
    $scope.IsLoad = true; //預設讀取中
    
    // 分頁參數
    $scope.totalRecords = 0;
    $scope.pageSize = 10; // 每頁筆數
    $scope.currentPage = 1; // 初始值，第一頁

    // 當有分頁
    $scope.pageChanged = function () {
        $scope.IsLoad = true;
        GetData();
    };

    var GetData = function () {
        CustService.getData($scope.currentPage, $scope.pageSize).then(function (response) {
            $scope.Customers = response.Data;
            $scope.totalRecords = response.Total;
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        }, function ()
        {
            $scope.error = "取得資料錯誤!";
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        })
    }

    GetData();

});