# Robot Program Handler

## Purpose
The Robot Program Handler can be used for the external exchange of robot programs (KUKA). 
The control takes place via Orion Context Broker (OCB).

### Features
  - robot program transfer due to OCB request from file server to robot
  - robot program transfer due to OCB request from robot to file server
  - robot program status comparison between robot and file server

## Overview
The Robot Program Handler was developed as part of the Robosonic Project (Part of the 2nd [DIH²](http://www.dih-squared.eu/) funding project). Developed by [RoWa Automation GmBh](https://www.rowa-automation.at/)

## Architecture

![image](https://user-images.githubusercontent.com/102011176/175545628-99c261eb-96fb-4027-bb92-cadaf4a25932.png)

*The whole picture shows the scope of the entire Robosonic project. The red square shows the components of the Robot Program Handler.*

Basically, the Program Handler consists of 3 software components:
  - Robot Program Handler - Server
  - Robot Program Handler - Client
  - File Server

### Robot Program Handler - Server
Is a software written in C# that is based on the OpenSource [C3bridge-server](https://github.com/ulsu-tech/c3bridge-server).
The software itself has to be installed directly on the robot and .here it takes over the functions for sending and receiving robot programs.

### Robot Program Handler - Client
The robot program handler - client serves as a communication bridge between the individual components.
The interface to the OCB was realised via a specially developed API. The communication between client and server is done over TCP/IP. Furthermore, the client takes over the program transfer between file server and robot.

### File Server
The file server is used to make robot programs available to several processing centres.

## How to adapt it?

This software is working only with Kuka KRC4 robot, with operation system Windows XP or higher. 
First of all, it is neccesary, to know, what IP address Robot Controler has. This can be find directly in Kuka Teach Panel in (Manu -> Stat-up -> Network Configuration).
Then it is necessary to open Port 7000 in controller (Menu -> Start-up->  Network Configuration -> Advanced -> NAT -> Add Port) with permitted protocols "tcp/udp". After it, cold start with files reload must be performed. 

To start application running proper one must perform steps below:
1. Download C3 Bridge Interface Server from here https://github.com/ulsu-tech/c3bridge-server or http://c3.ulsu.tech/, put it to robot controller , if wished, it can be added to autostart. To put it proper to robot controller, admin account must be active and HMI must be minimized. Then just start it, server is already running and is ready to work.
2. In RowaConnct/exe is a executing file RowaConnect.exe, start it
3. Fill Ip Adress and Port field with correct data(Ip adress of robot os to find in robot Controller  (Menu -> Start-up->  Network Configuration)
4. Click on check connection, then, if connection is fine, find a correct path, where are located programs, which should be checked and add a path to server where files are stored (Robot also must see this path!)
5. Click on choose a folder to save your choice and then connect.
6. Program runs
![image](https://user-images.githubusercontent.com/103100980/187377224-612c7a82-ccaa-4008-9daa-21d2624af2bc.png)



The OPCUA_Server IP has to be adjust in the docker_compose file:
![image](https://user-images.githubusercontent.com/103100980/176501183-013f9ca7-a3fc-497f-81fd-5b1f726c0db6.png)

As well as in the config.properties of the IoT Agents:
![image](https://user-images.githubusercontent.com/103100980/176501471-5ff6d2e1-5905-4e63-8934-2c8e8e681225.png)

## How to deploy it?

For using a software, it is required to have docker compose and Visual Studio Code already installed on computer.

Program C3Bridge should be copied to robot and started - if wished, it can be moved to autostart. 

Code shall be copied to place, where program handler is supposed to work. 

Next step is to Compose Docker file. For it, file docker-compose.yml must be find in Visual Studio code:

![image](https://user-images.githubusercontent.com/103100980/176618480-dc39ad00-c259-440c-b9c3-495f8674e4f2.png)

and with right mouse button, choose an option Compose Up - Disclaimer: Docker must be active. 

In case, there is problem with restarting any of container, there are two way to go on Windows: 
1. Ubuntu for Windows must be installed
2a. Write a command -> wsl -d docker-desktop sysctl -w vm.max_map_count=262144 <- in Powershell
2b. Or :
- Set vm.max_map_count=262144 in /etc/sysctl.conf
- Apply with sudo sysctl -p

## How to use it?

After adapting and deploying it, program is supposed to be able to recive any wished order information directly on HMI and download/update programs from/to file server only by ordering it on HMI. 

HMI should be prepared for operator, the way, that involved people can freely use it. 

## Environment Restrictions

## Known Limitations
At the moment only can be used with KUKA KRC4 robots. 

## Improvements Backlog

## License
Provided under various open source licenses (mainly [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0.html) and [MIT](http://opensource.org/licenses/MIT)). Third-party libraries or application servers included are distributed under their respective licenses. Full list including optional dependencies can be found on [Camunda - Third party libraries](https://docs.camunda.org/manual/7.15/introduction/third-party-libraries/).
