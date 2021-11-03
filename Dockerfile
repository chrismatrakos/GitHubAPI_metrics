FROM mcr.microsoft.com/dotnet/runtime:5.0
RUN dotnet build -c Release
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "NetCore.Docker.dll"]