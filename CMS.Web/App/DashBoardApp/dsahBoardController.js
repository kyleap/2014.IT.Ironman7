

MainApp.controller("DashBoardCtrl", function ($scope, $location, $route, DashBoardService, $window) {
    $scope.IsLoad = true; //預設讀取中
    $scope.Msg = '';

    DashBoardService.getData().then(function (response) {
        $scope.Datas = response;
        $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
    }, function () {
        $scope.error = "取得資料錯誤!";
        $scope.IsLoad = false; //讀取完畢,隱藏loading圖示
    });


    $scope.add = function () {
        hubProxy.server.add({ Name: $scope.add_friend.Name });
        $scope.add_friend.Name = "";
    }

    // 訊息陣列
    $scope.Messages = [];
    
    // 建立連線
    var hub = $window.jQuery.hubConnection();
    // SignalR Hub名稱
    var proxy = hub.createHubProxy('ChatHub');
    // SignalR 回傳function
    proxy.on('addMessageToPage', function (Name, Message, Time) {
        $scope.Messages.push({ Name: Name, Message: Message, Time: Time });
        // 重要，如果不加這段AngularJS的Model無法更新
        $scope.$apply();
    });

    // 發送訊息至Server Hub
    hub.start();

    $scope.SendMessage = function () {
        // 當點選Send按鈕的時候，發送輸入的訊息
        proxy.invoke('send', "Kyle", $scope.Msg)
    };

});