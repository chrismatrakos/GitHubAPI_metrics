FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-env
WORKDIR /app 
COPY *.csproj ./
RUN dotnet restore 
RUN dotnet --version
COPY . ./
RUN dotnet publish -c Release -o out 
RUN dotnet publish -c Release
# COPY bin/Release/net5.0/publish/ app/
ENTRYPOINT ["dotnet", "GitHubAPI_metrics.dll"]

FROM mcr.microsoft.com/dotnet/runtime:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GitHubAPI_metrics.dll"]
