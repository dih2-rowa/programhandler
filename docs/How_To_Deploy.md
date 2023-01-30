
### Program Handler - Server


This software is working only with Kuka KRC4 robot, with operation system Windows XP or higher. First of all, it is necessary, to know, what IP address Robot Controller has. This can be found directly in Kuka Teach Panel in (Menu -> Start-up -> Network Configuration). Then it is necessary to open Port 7000 in controller (Menu -> Start-up-> Network Configuration -> Advanced -> NAT -> Add Port) with permitted protocols "tcp/udp". After it, cold start with files reload must be performed.

1.	In Repository in RowaConnect/exe is an executing file ```RowaConnect.exe```, start it
2.	Fill Ip Address and Port field with correct data (Ip address of robot OS to find in robot Controller (Menu -> Start-up-> Network Configuration)
3.	Click on check connection, then, if connection is fine, find a correct path, where are located programs, which should be checked and add a path to server where files are stored (Robot also must see this path!)
4.	Click on choose a folder to save your choice and then connect.
5.	Program Runs


### Program Handler - Client

Download C3 Bridge Interface Server from here https://github.com/ulsu-tech/c3bridge-server or http://c3.ulsu.tech/, put it to robot controller , if wished, it can be added to AutoStart. To put it proper to robot controller, admin account must be active, and HMI must be minimized. Then just start it, server is already running and is ready to work.


### Rose AP1 - OCB connection 

1.	Open a docker Composer
2.	Turn on Ubuntu for Windows 
-	Set ```vm.max_map_count=262144 in /etc/sysctl.conf```
-	Apply with ```sudo sysctl -p```
Alternatively, you can write a command in PowerShell: 
```wsl -d docker-desktop sysctl -w vm.max_map_count=262144```
3.	In repository find a file named docker-compose.yml and with right mouse button choose an option Compose Up.
![image](https://user-images.githubusercontent.com/102011176/215488083-84fdbd86-e485-4e8e-a461-28d6a33b5734.png)

