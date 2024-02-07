FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["exercise.wwwapi/exercise.wwwapi.csproj", "exercise.wwwapi/"]
RUN dotnet restore "exercise.wwwapi/exercise.wwwapi.csproj"
COPY . .
WORKDIR "/src/exercise.wwwapi"
RUN dotnet build "exercise.wwwapi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "exercise.wwwapi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "exercise.wwwapi.dll"]