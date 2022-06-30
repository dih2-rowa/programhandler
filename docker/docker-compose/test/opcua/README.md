# FIWARE OPCUA commands

With the FIWARE OPCUA Agent data on the Server can only be written via methods (See [https://stackoverflow.com/questions/67381102/how-to-change-values-from-writable-basic-datatypes-on-an-opc-ua-server-with-fiwa](https://stackoverflow.com/questions/67381102/how-to-change-values-from-writable-basic-datatypes-on-an-opc-ua-server-with-fiwa)).

## OPC UA methods
- [Documentation OPC UA](https://reference.opcfoundation.org/v104/Core/docs/Part3/5.7/)

### Example python
- Source [https://github.com/FreeOpcUa/python-opcua/blob/master/examples/server-methods.py](https://github.com/FreeOpcUa/python-opcua/blob/master/examples/server-methods.py)

## OPC UA Client
- Uncomment the api and agent-id parameters in the config.properties file.
- Use the *autoconfig* function to get a first draw.
- Adapt config.json, especially the *inputArgument* field in the *contextSubscriptions* section.

## Run the example
- Start the docker-compose_opcua.yml
- Check OCB and OPCUA Client Entities, Subscriptions and Registrations via [docker\docker-compose\test\opcua\api-calls\OPC_UA_Test.http](docker\docker-compose\test\opcua\api-calls\OPC_UA_Test.http)
- Update Entity MyObject/attrs/2:multiply?type=MyObject

