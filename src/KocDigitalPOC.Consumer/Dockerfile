#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/KocDigitalPOC.Consumer/KocDigitalPOC.Consumer.csproj", "src/KocDigitalPOC.Consumer/"]
RUN dotnet restore "src/KocDigitalPOC.Consumer/KocDigitalPOC.Consumer.csproj"
COPY . .
WORKDIR "/src/src/KocDigitalPOC.Consumer"
RUN dotnet build "KocDigitalPOC.Consumer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KocDigitalPOC.Consumer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KocDigitalPOC.Consumer.dll"]