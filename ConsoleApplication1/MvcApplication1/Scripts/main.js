(function () {
	var mySocket;
	function socketOpen(event) { console.log(arguments); }

	function socketMessage(event) { console.log(arguments); }

	function socketError(event) { console.log(arguments); }

	function hdnUrlForSocketActivationClick() {
		var msg = $("#txtMsg").val();
		mySocket.send(msg);
	}

	$(document).ready(function () {
		$("#hdnUrlForSocketActivation").on("click", hdnUrlForSocketActivationClick);

		var socketUrl = $("#hdnUrlForSocketActivation").val();
		mySocket = new WebSocket(socketUrl);

		mySocket.addEventListener("open", socketOpen);
		mySocket.addEventListener("message", socketMessage);
		mySocket.addEventListener("error", socketError);

	});
})();