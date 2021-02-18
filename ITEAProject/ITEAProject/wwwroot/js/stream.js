//(function () {
//    var getWebSocketMessages = function (onMessageReceived) {
//        var url = `wss://${location.host}/stream/get`

//        var webSocket = new WebSocket(url);

//        webSocket.onmessage = onMessageReceived;
//    };

//    var ulElement = document.getElementById('StreamToMe');

//    getWebSocketMessages(function (message) {
//        ulElement.innerHTML = ulElement.innerHTML += `<li>${message.data}</li>`
//    });
//}());

function Main(onMessageReceived) {
    let username = '';
    var url = `wss://${location.host}/stream/getstream`;
    var webSocket = new WebSocket(url);
    webSocket.onmessage = onMessageReceived;
}

function getWebSocketMessages(message) {
    var ulElement = document.getElementById('StreamToMe');
    ulElement.innerHTML = `<li>${message.data}</li>`
}

Main(getWebSocketMessages);