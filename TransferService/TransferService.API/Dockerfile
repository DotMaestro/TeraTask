#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TransferService.API/TransferService.API.csproj", "TransferService.API/"]
COPY ["TransferService.Application/TransferService.Application.csproj", "TransferService.Application/"]
COPY ["TransferService.Domain/TransferService.Domain.csproj", "TransferService.Domain/"]
COPY ["TransferService.Infrastructure/TransferService.Infrastructure.csproj", "TransferService.Infrastructure/"]
RUN dotnet restore "./TransferService.API/TransferService.API.csproj"
COPY . .
WORKDIR "/src/TransferService.API"
RUN dotnet build "./TransferService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TransferService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransferService.API.dll"]