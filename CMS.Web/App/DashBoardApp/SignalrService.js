MainApp.service('signalRSvc', function ($, $rootScope) {
    var proxy = null;

    var initialize = function () {
        //Getting the connection object
        connection = $.hubConnection();

        //Creating proxy
        this.proxy = connection.createHubProxy('ChatHub');

        //Starting connection
        connection.start();

        //Publishing an event when server pushes a greeting message
        this.proxy.on('acceptGreet', function (message) {
            $rootScope.$emit("acceptGreet", message);
        });
    };

    var sendRequest = function () {
        //Invoking greetAll method defined in hub
        this.proxy.invoke('send');
    };

    return {
        initialize: initialize,
        sendRequest: sendRequest
    };
});