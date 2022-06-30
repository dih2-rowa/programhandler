# docker-compose with c#
Example with c# Fiware API.
    
## docker-compose extension
``` yml
  pghbackend:
    image: mcr.microsoft.com/dotnet/sdk:6.0
    volumes:
      - ./Fiware:/app
    tty: true
```
### Image [https://hub.docker.com/_/microsoft-dotnet-sdk](https://hub.docker.com/_/microsoft-dotnet-sdk)
This image is from Microsoft to develop a .NET app. How to containerize apps see [https://docs.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows](https://docs.microsoft.com/en-us/dotnet/core/docker/build-container?tabs=windows)

### volumes
``` yml
volumes:
    - ./Fiware:/app
```
This includes the Folder *Fiware* from your current working directory. Adapt this line to your needs.

## Testing
1. docker-compose up
2. Run commands from test.http