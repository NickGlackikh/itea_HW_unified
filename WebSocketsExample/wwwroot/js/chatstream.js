function OpenConnection() {
    console.log(1);
    let webSocket
    function GetWebSocketMessages(onMessageReceived) {
        let url = `wss://${location.host}/stream/get`;
            webSocket = new WebSocket(url);

        webSocket.onmessage = onMessageReceived;
    };

    let ulElement = document.getElementById('chatMessages');

    GetWebSocketMessages(function (message) {
        ulElement.innerHTML = ulElement.innerHTML += `<li>${message.data}</li>`
    });

    document.getElementById("sendmessage").addEventListener("click", function () {
        let textElement = document.getElementById('messageTextInput');
        let text = textElement.value;
        webSocket.send(text);
        textElement.value = '';
    });
};
OpenConnection();