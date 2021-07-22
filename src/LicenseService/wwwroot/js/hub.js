connection = new signalR.HubConnectionBuilder().withUrl("/licenseHub").build();

// When a message is received from the Hub

connection.on("ReceiveMessage", function (licenseJson) {

	// Build the licenseTableId with the JSON data coming from the server.

	var li = document.createElement("li");

	document.getElementById("messagesList").appendChild(li);

	li.textContent = `${licenseJson}`;
});

connection.start().catch(function (err) {
	return console.error(err.toString());
});