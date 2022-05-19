# docker-compose with c#
Example with c# HelloWorld.
    
## docker-compose extension
``` yml
  pgh-backend:
    image: mcr.microsoft.com/dotnet/sdk:6.0
    volumes:
      - ./testApp:/app
    tty: true
```
### Image [https://hub.docker.com/_/microsoft-dotnet-sdk](https://hub.docker.com/_/microsoft-dotnet-sdk)
This image is from Microsoft to develop a .NET app. How to containerize apps see [https://docs.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows](https://docs.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows)

### volumes
``` yml
volumes:
    - ./testApp:/app
```
This includes the Folder *testApp* from your current working directory. Adapt this line to your needs.

### tty: true
This flag is used to prevent the container from shutdown.

## Testing
1. docker-compose up
2. Attach shell to pgh-backend
    1. Change directory to app
    2. run 'dotnet run' 