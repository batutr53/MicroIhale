#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MicroIhale.Sourcing/MicroIhale.Sourcing.csproj", "MicroIhale.Sourcing/"]
COPY ["EventBusRabbitMQ/EventBusRabbitMQ.csproj", "EventBusRabbitMQ/"]
RUN dotnet restore "MicroIhale.Sourcing/MicroIhale.Sourcing.csproj"
COPY . .
WORKDIR "/src/MicroIhale.Sourcing"
RUN dotnet build "MicroIhale.Sourcing.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroIhale.Sourcing.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroIhale.Sourcing.dll"]