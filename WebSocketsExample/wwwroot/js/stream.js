//(function () {
//    var getWebSocketMessages = function (onMessageReceived) {
//        var url = `wss://${location.host}/stream/get`
//        console.log('url is: ' + url);

//        var webSocket = new WebSocket(url);

//        webSocket.onmessage = onMessageReceived;
//    };

//    var ulElement = document.getElementById('StreamToMe');

//    getWebSocketMessages(function (message) {
//        ulElement.innerHTML = ulElement.innerHTML += `<li>${message.data}</li>`
//    });
//}());

function SendHandshake() {
    function GetWebSocketMessages(onMessageReceived) {
        var url = `wss://${location.host}/stream/get`
            console.log('url is: ' + url);

        var webSocket = new WebSocket(url);

        console.log('url is: ' + url);

        webSocket.onmessage = onMessageReceived;

        console.log('url is: ' + url);
    };

    var ulElement = document.getElementById("StreamToMe");


    GetWebSocketMessages(function (message) {
        ulElement.innerHTML = ulElement.innerHTML += `<li>${message.data}</li>`
    });
};

SendHandshake();