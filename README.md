SignalRBackplane
================

A SignalR .Net client pushing notifications to a hub which then pushes notifications to a hub on another domain which is backplaned by Sql Server.  The second hub then pushes the notification to its .Net clients.

To run you will need to create an empty Sql database called "SignalrBackPlane" and update the connection string.
