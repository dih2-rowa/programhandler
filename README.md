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
Is a software written in C++ that is based on the OpenSource [C3bridge-server](https://github.com/ulsu-tech/c3bridge-server).
The software itself has to be installed directly on the robot and .here it takes over the functions for sending and receiving robot programs.

### Robot Program Handler - Client
The robot program handler - client serves as a communication bridge between the individual components.
The interface to the OCB was realised via a specially developed API. The communication between client and server is done over TCP/IP. Furthermore, the client takes over the program transfer between file server and robot.

### File Server
The file server is used to make robot programs available to several processing centres.


## How to install it?

Check the file [How_To_Install.md](/docs/How_To_Install.md) and follow steps.

## How to adapt it?

Check the file [How_To_Adapt.md](/docs/How_To_Adapt.md) and follow steps.

## How to deploy it?

Check the file [How_To_Deploy.md](/docs/How_To_Deploy.md) and follow steps.

## How to use it?

Check the file [How_To_Use.md](/docs/How_To_Use.md) and follow steps.

## Environment Restrictions

## Known Limitations
At the moment only can be used with KUKA KRC4 robots. 

## Improvements Backlog

## License
Provided under various open source licenses (mainly [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0.html) and [MIT](http://opensource.org/licenses/MIT)). Third-party libraries or application servers included are distributed under their respective licenses. Full list including optional dependencies can be found on [Camunda - Third party libraries](https://docs.camunda.org/manual/7.15/introduction/third-party-libraries/).
