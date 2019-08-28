FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
COPY ./publish .
ARG DLL_FILE
ENV DLL_NAME_FILE = 'WebApi.dll'
ENTRYPOINT dotnet, ${DLL_NAME_FILE}
