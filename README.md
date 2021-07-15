# 🔗 SignalR-Connections

## A project to illustrate and understand the connection lifetime events in SignalR.

Ideally this project will call out the connection lifetime events of a web-client.

## Folder Structure

* 📁 **WebApplication1** - A .Net Core 5 MVC web app
* 📁 **WebApplication2** - A .Net 4.8 MVC web app (coming soon)

There are slight differences between .Net Core and Framework SignalR libraries that are documented [**here**](https://docs.microsoft.com/en-us/aspnet/core/signalr/version-differences?view=aspnetcore-5.0).

## Steps to Recreate the Project(s)

* Create a new .Net Core 5 web application.
* Add the SignalR client library using `npm` or `libMan`.
* Create a hub inheriting from the `Hub` base class.
* Configure SignalR in the Startup.cs file.
* Create and HTML view.
* Create the Javascript methods to create a hub on the client and process the messages.

## Things to Consider

* [**Configuration**](https://docs.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-5.0&tabs=dotnet) - Timeouts, etc.
* [**Authentication and Authorization**](https://docs.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-5.0)
* [**Host & Scale**](https://docs.microsoft.com/en-us/aspnet/core/signalr/scale?view=aspnetcore-5.0)
* [**Compare .Net Core & Framework API's / Features**](https://docs.microsoft.com/en-us/aspnet/core/signalr/version-differences?view=aspnetcore-5.0)



## 📚 References:

* [Understanding and Handling Connection Lifetime Events in SignalR](https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/handling-connection-lifetime-events)
* [Introduction to ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-5.0)
* [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-5.0)
  * [Manage Client-Side Libraries opens libman.json not UI Dialog](https://github.com/aspnet/LibraryManager/issues/411)
  * [Manually Configure SignalR using LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-5.0#manually-configure-libman-manifest-file-entries)