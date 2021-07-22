# 🔑 License Service

A simple project to Get and Return licenses via the API and the home page displays the list of licenses currently obtained.
This application also uses SignalR to update the web clients from the API calls.

*(NOTE: This contains a singleton of licenses that are not persisted, therefore if this services is spun down the list will be lost.)*

## 📝 TODO

* Clean up client hub callback to build a table from the JSON received.

## 📚 References:

* [Send messages from outside a hub](https://docs.microsoft.com/en-us/aspnet/core/signalr/hubcontext?view=aspnetcore-5.0)