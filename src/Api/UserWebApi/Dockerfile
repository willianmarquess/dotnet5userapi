#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Api/UserWebApi/UserWebApi.csproj", "src/Api/UserWebApi/"]
RUN dotnet restore "src/Api/UserWebApi/UserWebApi.csproj"
COPY . .
WORKDIR "/src/src/Api/UserWebApi"
RUN dotnet build "UserWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserWebApi.dll"]