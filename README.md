# StudioServer-master

This program ensures a markless development of the vSro database.
The vSro Studio is composed of a server and a client.
The server is connected to the SQL database and takes over the execution of the changes of your choice.
To avoid the client user getting direct access to the database, it connects to the server and communicates through the vSro API.


Components of the client:
=> ManagementLaunucher.exe
===> Keeps the client up to date.

=> ManagementClient.exe
===> Connects to the ManagementServer and allows remote editing.

=> ManagementServer.exe
===> Keeps the clients connected and ensures smooth development progress with change log.

=> Plugins
===> The different plugins used to load as dot NET Framework V 4.7.2 UserControl - TabPage into the Client interface.
===> Consider that each StudioAccount has different security level to access and work with existing data.

=> RisingSecurity.bak
===> RisingSecurity.bak is the database which contains the entired content of editing and storing the workflow of your users. 
===> The Administrator is able to set security levels to each user manually and provides different workspaces for each user. 


More informations coming soon!!!
