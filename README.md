# 🔗 SignalR-Connections

#### A project to illustrate and understand the connection lifetime events in SignalR.

This project calls out the connection lifetime events in a SignalR web application.  It can monitor the
connect and disconnect of each client.  A timer in the browser is utilized as well to disconnect the client.

## 📁 Folder Structure

* 📁 **src/LicenseService** - A .Net Core 5 MVC web app & API to get and return licenses
* 📁 **src/WebApplication1** - A .Net Core 5 MVC web app
* 📁 **src/WebApplication2** - A .Net 4.8 MVC web app (coming soon)

## 📝 TODO

* ⬜ Track Device ID to see who is connected.
* ⬜ Use Windows Authentication to figure out user.
* ⬜ Use DI and IoC container for object creation.
* ⬜ Use a timing mechanism in the server to disconnect the client when their time has expired.
  * Might possibly send a warning versus just logging them out (much like a "server needs to
    reboot in 5 minutes")
* ⬜ Monitor reconnect events (only available in the .Net Framework)
* ⬜ Authenticate user **before** connecting to SignalR *(use token as unique key for client app)*
* ⬜ Move SignalR communication to license web service
* ⬜ Move SignalR to separate server (need Redis for scale out)
* ⬜ Publish to Azure
* ⬜ Publish to local HyperV VM *(test network connectivity - easy to turn OFF network)*
* ⬜ Wrap all of this up neatly into deliverables so web applications to **minimal** setup.
* ⬜ Convert web application to Angular
* ⬜ Test with Jasmine?
* ⬜ Convert web application to React

There are slight differences between .Net Core and Framework SignalR libraries that are documented
[**here**](https://docs.microsoft.com/en-us/aspnet/core/signalr/version-differences?view=aspnetcore-5.0).

## 🔢 Steps to Recreate the Project(s)

* Create a new .Net Core 5 web application.
* Add the SignalR client library using `npm` or `libMan`. [Javascript Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-5.0&tabs=visual-studio)
  * The tutorial shows the `libman` UI, which has been depricated.
  * Look at this repo's `libman.json` file for reference
  * Right-click the file and select **Restore Client-Side Libraries**
* Create a hub inheriting from the `Hub` base class.
* Configure SignalR in the Startup.cs file.
* Create an HTML view.
* Create the Javascript methods to create a hub on the client and process the messages.

## ✅ Done!

* Track User ID to see who is connected.
  * Use the `Context.User` from the Hub to get the User Name.
* Add **Disconnect** button *(as well as **Connect** button)*
  * The **Send** button does not work when disconnected.  W.A.D.
* Steps to create the .Net Core 5 web application *(above)*
* Added messages for connect and disconnect
* Timer to warn user of inactivity *(user can cancel and reset the warning timer)*
* Timer for logout.
* Build license web service *(.Net Core 5.0)*

## 🤔 Things to Consider

* [**Configuration**](https://docs.microsoft.com/en-us/aspnet/core/signalr/configuration?view=aspnetcore-5.0&tabs=dotnet) - Timeouts, etc.
* [**Authentication and Authorization**](https://docs.microsoft.com/en-us/aspnet/core/signalr/authn-and-authz?view=aspnetcore-5.0)
* [**Host & Scale**](https://docs.microsoft.com/en-us/aspnet/core/signalr/scale?view=aspnetcore-5.0)
* [**Compare .Net Core & Framework API's / Features**](https://docs.microsoft.com/en-us/aspnet/core/signalr/version-differences?view=aspnetcore-5.0)
* [**Don't Use Session**](https://stackoverflow.com/questions/20522477/no-access-to-the-session-information-through-signalr-hub-is-my-design-is-wrong)
* [**WebSockets Takes More Sever Setup**]()

## 📚 References:

* [Understanding and Handling Connection Lifetime Events in SignalR](https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/handling-connection-lifetime-events)
* [Introduction to ASP.NET Core SignalR](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-5.0)
  * [Tutorials](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-5.0&tabs=visual-studio)
* [A Beginner's Guide to WebSockets](https://www.youtube.com/watch?v=8ARodQ4Wlf4)
* [LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-5.0)
  * [Manage Client-Side Libraries opens libman.json not UI Dialog](https://github.com/aspnet/LibraryManager/issues/411)
  * [Manually Configure SignalR using LibMan](https://docs.microsoft.com/en-us/aspnet/core/client-side/libman/libman-vs?view=aspnetcore-5.0#manually-configure-libman-manifest-file-entries)
* [Detect Browser Inactivity](https://stackoverflow.com/questions/13246378/detecting-user-inactivity-over-a-browser-purely-through-javascript)