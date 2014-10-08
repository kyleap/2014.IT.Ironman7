

MainApp.controller("CustAddCtrl", function ($scope, $location, $route, CustService) {
    $scope.IsLoad = true; //預設讀取中

    // 可以給Model初始值
    $scope.CustomerID = '';
    $scope.CompanyName = '';
    $scope.ContactName = '';

    $scope.Add = function () {
        // 雙向繫結特性讓textbox欄位值改變，Controller也跟著變
        var Customer = {
            CustomerID : $scope.CustomerID,
            CompanyName : $scope.CompanyName,
            ContactName : $scope.ContactName
        }
        // POST到Web API
        CustService.AddData(Customer).then(function (response) {
            alert('新增成功!');
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        }, function () {
            $scope.error = "新增失敗!";
            $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
        })
    }

});