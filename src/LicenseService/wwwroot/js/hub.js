connection = new signalR.HubConnectionBuilder().withUrl("/licenseHub").build();

// When a message is received from the Hub

connection.on("ReceiveMessage", function (licenseJson) {

	// Build the licenseTableId with the JSON data coming from the server.

	var li = document.createElement("li");

	document.getElementById("messagesList").appendChild(li);

	var licenses = JSON.parse(licenseJson);

	// TODO: This COULD build out an entire table with the delete button.

	li.textContent = " List Update (refresh for latest): ";

	licenses.forEach(function (item) {
		li.textContent += item.Key + ", ";
	});
});

connection.start().catch(function (err) {
	return console.error(err.toString());
});