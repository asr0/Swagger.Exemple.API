#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Swagger.Exemple.API/Swagger.Exemple.API.csproj", "Swagger.Exemple.API/"]
RUN dotnet restore "Swagger.Exemple.API/Swagger.Exemple.API.csproj"
COPY . .
WORKDIR "/src/Swagger.Exemple.API"
RUN dotnet build "Swagger.Exemple.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Swagger.Exemple.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Swagger.Exemple.API.dll"]