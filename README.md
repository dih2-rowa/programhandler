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

In Rowa Console Client, in ProgramID.cs, 


## How to deploy it?

## How to use it?

## Environment Restrictions

## Known Limitations
At the moment only can be used with KUKA robots.

## Improvements Backlog

## License
Provided under various open source licenses (mainly [Apache License 2.0](http://www.apache.org/licenses/LICENSE-2.0.html) and [MIT](http://opensource.org/licenses/MIT)). Third-party libraries or application servers included are distributed under their respective licenses. Full list including optional dependencies can be found on [Camunda - Third party libraries](https://docs.camunda.org/manual/7.15/introduction/third-party-libraries/).












## Test NGSI V2 API with VS code and docker desktop
### VScode Extensions used
 - Name: REST Client
    Id: humao.rest-client
    Description: REST Client for Visual Studio Code
    Version: 0.24.6
    Publisher: Huachao Mao
    VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=humao.rest-client
 - Name: Docker
    Id: ms-azuretools.vscode-docker
    Description: Makes it easy to create, manage, and debug containerized applications.
    Version: 1.21.0
    Publisher: Microsoft
    VS Marketplace Link: https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker

### Example
- Start Docker Desktop
- Open VS code
- Right Click to [docker-compose_orion-minimal.yaml](docker\docker-compose\test\docker-compose_orion-minimal.yml)
  - *Compose Up*
- Send Requests from [example_walkthrough_apiv2.http](docker\docker-compose\test\example_walkthrough_apiv2.http)

## OCB Datatype

See [#10](https://github.com/dih2-rowa/programhandler/issues/10)

## RPH API

See [#7](https://github.com/dih2-rowa/programhandler/issues/7) and [#6](https://github.com/dih2-rowa/programhandler/issues/6)


-----
#Original README
## Background

```text
Background information and links to relevant terms
```

## Install

```text
How to install the component

Information about how to install the <Name of component> can be found at the corresponding section of the
[Installation & Administration Guide](docs/installationguide.md).

A `Dockerfile` is also available for your use - further information can be found [here](docker/README.md)

```

## Usage

```text
How to use the component

Information about how to use the <Name of component> can be found in the [User & Programmers Manual](docs/usermanual.md).

The following features are listed as [deprecated](docs/deprecated.md).
```

## API

```text
Definition of the API interface:

Information about the API of  the <Name of component> can be found in the [API documentation](docs/api.md).

```

## Testing

```text
How to test the component

For performing a basic end-to-end test, you have to follow the step below. A detailed description about how to run tests can be found [here].

> npm test

```

## License

[MIT](LICENSE) © <TTE>
