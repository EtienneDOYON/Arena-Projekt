#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["BA2 Core/BA2 Core.csproj", "BA2 Core/"]
RUN dotnet restore "BA2 Core/BA2 Core.csproj"
COPY . .
WORKDIR "/src/BA2 Core"
RUN dotnet build "BA2 Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BA2 Core.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BA2 Core.dll"]