# See https://aka.ms/containerfastmode to understand how Visual Studio uses this
# Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Server/uwu.Server.csproj", "Server/"]
COPY ["Library/uwu.Library.csproj", "Library/"]
RUN dotnet restore "Server/uwu.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "uwu.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "uwu.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "uwu.Server.dll"]
EXPOSE 5667
