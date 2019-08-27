FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
COPY ./publish .
ARG SOLUTION_NAME = "Default"
ENTRYPOINT ["dotnet", "${SOLUTION_NAME}.dll"]