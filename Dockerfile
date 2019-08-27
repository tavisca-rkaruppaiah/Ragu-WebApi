FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS runtime
WORKDIR /app
COPY /bin/Debug/netcoreapp2.0/publish/ .
ENTRYPOINT ["dotnet", "WebApi.dll"]
