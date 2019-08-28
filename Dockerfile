FROM microsoft/dotnet:2.1-aspnetcore-runtime
COPY ./publish .
ARG DLL_FILE
ENV DLL_NAME_FILE = $DLL_FILE
ENTRYPOINT ["dotnet", "$DLL_NAME_FILE.dll"]
