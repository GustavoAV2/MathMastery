#Build stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build
WORKDIR /source
COPY . .

RUN dotnet restore "./HttpHost/HttpHost.csproj" --disable-parallel
RUN dotnet publish "./HttpHost/HttpHost.csproj" -C release -o /app --no-restore

#Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 7224

ENTRYPOINT ["dotnet", "HttpHost.dll"]
