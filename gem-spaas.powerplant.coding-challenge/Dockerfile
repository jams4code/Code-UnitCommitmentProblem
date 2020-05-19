#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["gem-spaas.powerplant.coding-challenge/gem-spaas.powerplant.coding-challenge.csproj", "gem-spaas.powerplant.coding-challenge/"]
RUN dotnet restore "gem-spaas.powerplant.coding-challenge/gem-spaas.powerplant.coding-challenge.csproj"
COPY . .
WORKDIR "/src/gem-spaas.powerplant.coding-challenge"
RUN dotnet build "gem-spaas.powerplant.coding-challenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "gem-spaas.powerplant.coding-challenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "gem-spaas.powerplant.coding-challenge.dll"]