FROM microsoft/dotnet:2.1-aspnetcore-runtime
COPY ./publish .
ARG DLL_FILE
ENTRYPOINT ["dotnet", "${DLL_FILE}.dll"]
