# Microservices-Docker
In this sample, i create a sample .NET Core Web API using the microsoft/dotnet:5.1-sdk Docker image. After that, i create a Dockerfile, configure this app to use our SQL Server database, and then create a docker-compose.yml that defines the behavior of all of these components.
I create a docker-compose.yml file. Write the following in the file, and make sure to replace the password in the SA_PASSWORD environment variable under db below. This file defines the way the images interact as independent services.

docker-compose.yml:

version: '3.7'
services:
  apptest:
    build:
      context: .
      dockerfile: apptest/Dockerfile
    ports:
      - ":80"
      - ":443"
    networks:
      - mynetwork
    environment:
      ASPNETCORE_ENVIRONMENT: Production
  commandservice:
    build:
      context: .
      dockerfile: commandservice/Dockerfile
    ports:
      - ":80"
      - ":443"
    networks:
      - mynetwork
    environment:
      ASPNETCORE_ENVIRONMENT: Production 
  db:
     image: "mcr.microsoft.com/mssql/server"
     environment:
            SA_PASSWORD: "Pa55w0rd2019"
            ACCEPT_EULA: "Y" 
     ports:
        - 1433:1433
     networks:
      - mynetwork
  platformservice:
    build:
      context: .
      dockerfile: platformservice/Dockerfile
    ports:
      - ":80"
      - ":443"
    networks:
      - mynetwork
    environment:
      ASPNETCORE_ENVIRONMENT: Production 
networks:
  mynetwork:
    driver: bridge
