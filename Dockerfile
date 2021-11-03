FROM mcr.microsoft.com/dotnet/aspnet:5.0
FROM mcr.microsoft.com/dotnet/sdk:5.0

RUN dotnet --version
RUN ls
COPY . App/
RUN dotnet build -c Release
COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "GitHubApi_metrics.dll"]