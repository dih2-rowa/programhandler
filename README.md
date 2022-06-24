# Program Handler

## Purpose
The program handler can be used for the external exchange of robot programs (KUKA). 
The control takes place via Orion Context Broker (OCB).

### Features

  - program transfer due to OCB request from file server to robot
  - program transfer due to OCB request from robot to file server
  - program status compariso between robot and file server

## Overview
The Program Handler application is developed during the 2nd [DIH²](http://www.dih-squared.eu/) funding project. Developed by [RoWa Automation GmBh](https://www.rowa-automation.at/)

## Architecture

![image](https://user-images.githubusercontent.com/102011176/175516601-b5d3224b-77b2-4094-8b92-57606903c448.png)

Basically, the Program Handler consists of 3 software components:

  - Robot Program Handler - Server
  - Robot Program Handler - Client
  - File Server

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
