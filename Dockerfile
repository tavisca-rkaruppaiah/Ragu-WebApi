FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
COPY ./publish .
ARG DLL_FILE
ENTRYPOINT ["dotnet", "${DLL_FILE}.dll"]
