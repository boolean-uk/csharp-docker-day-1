#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5137
EXPOSE 7242


# build my app as Release
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["exercise.wwwapi/exercise.wwwapi.csproj", "exercise.wwwapi/"]
RUN dotnet restore "./exercise.wwwapi/./exercise.wwwapi.csproj"
COPY . .
WORKDIR "/src/exercise.wwwapi"
RUN dotnet build "./exercise.wwwapi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./exercise.wwwapi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "exercise.wwwapi.dll"]
