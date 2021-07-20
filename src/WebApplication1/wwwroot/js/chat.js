
connection = new signalR.HubConnectionBuilder().withUrl("/applicationHub").build();

// When a message is received from the Hub

connection.on("ReceiveMessage", function (user, message) {

	var li = document.createElement("li");

	document.getElementById("messagesList").appendChild(li);

	// We can assign user-supplied strings to an element's textContent because it
	// is not interpreted as markup. If you're assigning in any other way, you 
	// should be aware of possible script injection concerns.

	li.textContent = `${user} says ${message}`;
});

// TODO: Might need to wire up a "StopClient" from the server.

connection.start().then(function () {
	// Enable the send button now that there is a connection.

	document.getElementById("disconnectButton").disabled = false;
	document.getElementById("sendButton").disabled = false;

}).catch(function (err) {
	return console.error(err.toString());
});

// Disable buttons until connection is established

document.getElementById("connectButton").disabled = true;
document.getElementById("disconnectButton").disabled = true;
document.getElementById("sendButton").disabled = true;

document.getElementById("sendButton").addEventListener("click", function (event) {

	var user = document.getElementById("userInput").value;
	var message = document.getElementById("messageInput").value;

	// Be aware that the Hub method name IS case sensitive.

	connection.invoke("SendMessage", user, message).catch(function (err) {
		return console.error(err.toString());
	});

	event.preventDefault();
});

document.getElementById("connectButton").addEventListener("click", function (event) {

	document.getElementById("connectButton").disabled = true;
	document.getElementById("disconnectButton").disabled = false;

	connection.start().then(function () {
		// Enable the disconnect button now that there is a connection.

		document.getElementById("disconnectButton").disabled = false;

	}).catch(function (err) {
		return console.error(err.toString());
	});

	event.preventDefault();
});

document.getElementById("disconnectButton").addEventListener("click", function (event) {

	document.getElementById("connectButton").disabled = false;
	document.getElementById("disconnectButton").disabled = true;

	connection.stop();

	event.preventDefault();
});