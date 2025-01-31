
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app

COPY api-cinema-challenge/*.csproj ./
RUN dotnet restore

COPY api-cinema-challenge ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime

WORKDIR /app

COPY --from=build /app/out ./

EXPOSE 8080

ENTRYPOINT ["dotnet", "api-cinema-challenge.dll"]
