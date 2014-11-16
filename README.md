SignalRBackplane
================

A SignalR .Net client pushing notifications to a hub which then pushes notifications to a second hub on another domain (enabled by Sql Server backplaning).  The second hub then pushes the notification to its .Net clients.

To run you will need to create an empty Sql database called "SignalrBackPlane" and update the connection string.
