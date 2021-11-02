
### PROJECT Github Api Metrics  
 
### Description  
A simple dotnet application that given a PAT  of a user  
makes a GET request to https://api.github.com/rate_limit to determine the threashold of a user.  

### Prerequisites  
.NET SDK and .NET runtime are installed on the machine.  
The .NET SDK includes both the .NET Runtime and the .NET CLI.    
Verify by running  
```bash  
dotnet  --version
```  

### Setup and Run locally using dotnet   
Clone the repo loccally and at the root directory  
start the dotnet console application running the command:  
```bash
dotnet run  
```  

To clean the the build run:   
```bash
dotnet clean  
```

### How to create and run the dotnet application from CLI     
Create the dotnet console application running the command:
```bash
dotnet new console --framework net5.0  
```
.NET framework might differ. I use net5.0.

To build the application run  
```bash
dotnet build  
```
This will build an executable in `GitHubAPI_metrics\bin\Debug\net5.0\GitHubAPI_metrics`.  
 
To start the application run  
```bash
dotnet run  
```
To add/remove packages run  
```bash
dotnet add/remove package NAME   
```

To publish the application and dependencies to be ready for deployment run  
```bash
dotnet publish -c Release
```
This will create a dll in "bin\Debug\netVersion\"   
and also will create a publish folder in "bin\Debug\netVersion\publish" with an executable and dependencies.  