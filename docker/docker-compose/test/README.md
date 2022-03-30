# Docker Compose Examples
## Preperations
In order to use the following examples it will be assumed that your current working directory is the *programmhandler/docker/docker-compose/test/* folder and your docker is up. 

## Orion Context Broker (OCB) minimal

The [docker-compose file docker-compose_orion-minimal.yml](docker-compose_orion-minimal.yml) includes a minimal setup to test the Orion Context Broker. This consists of a [mongodb](https://www.mongodb.com/) and the [Context Broker](https://fiware-orion.readthedocs.io/en/master/) itself.

### docker-compose.yml example
```yaml
version: "3.9"

services:
  mongo:
    image: mongo:4.4
    command: --nojournal
  orion:
    image: fiware/orion
    links:
      - mongo
    ports:
      - "1026:1026"
    command: -dbhost mongo
```

### Start the services
```bash 
docker-compose -f docker-compose_orion-minimal.yml up -d
```
#### docker-compose options used (see docker-compose --help and docker-compose up --help for further informations)
- -f, --file FILE             Specify an alternate compose file
                              (default: docker-compose.yml)
- -d, --detach               Detached mode: Run containers in the background,
                               print new container names. Incompatible with
                               --abort-on-container-exit.

### Testing the OCB
The file [example_walkthrough_apiv2.http](example_walkthrough_apiv2.http) includes some test cases, most of them are from the OCB Documentation.

#### Usefull programms for testing
- [curl](https://curl.se/) Command line Tool
- [Postman](https://www.postman.com/) API Platform
- [VSCode REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) allows you to send HTTP request and view the response in Visual Studio Code directly.

## OCB with persistent database
With including *docker volume* in the docker-compose file from [Orion Context Broker (OCB) minimal](/docker/docker-compose/README.md#testing-the-ocb) we can store the entities and Configurations. The result is [docker-compose_orion-persistent.yml](docker-compose_orion-persistent.yml)

