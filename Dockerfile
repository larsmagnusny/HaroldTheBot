#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0.13-focal-arm64v8 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0.404-focal-arm64v8 AS build
WORKDIR /src
COPY ["HaroldTheBot.csproj", "."]
RUN dotnet restore "./HaroldTheBot.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "HaroldTheBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HaroldTheBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HaroldTheBot.dll"]