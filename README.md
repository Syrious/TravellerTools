# Traveller Tools II
Tools for the Traveller RPG

# Running the tool
There a multiple ways you can run this tool.

## Using pre-compiled files
- Download the `publish.zip`, extract and run `Grauenwolf.TravellerTools.Web.exe`

## Building your own
- Go to  https://dotnet.microsoft.com/en-us/download/dotnet (tested with 9.0) and download
  - SDK
  - .NET Runtime (not Desktop I guess)
  - ASP.NET Core Runtime
- Open a console and cd into `Grauenwolf.TravellerTools.Web`
  - `dotnet restore` to ensure all dependencies are restored
  - `dotnet build` to build the project
  - `dotnet run` to run the project
- Now open a browser and head to https://localhost:5001/

### Build your own .exe file
- Get the same dependecies as above
- `dotnet restore` to ensure all dependencies are restored
- `dotnet publish Grauenwolf.TravellerTools.Web/Grauenwolf.TravellerTools.Web.csproj -c Release -o publish`
- Go into publish folder and execute `Grauenwolf.TravellerTools.Web.exe`

### Docker-Container
- Get the same dependecies as above
- `dotnet restore` to ensure all dependencies are restored
- `dotnet publish Grauenwolf.TravellerTools.Web/Grauenwolf.TravellerTools.Web.csproj -c Release -o publish`
- `docker build -t traveller-tools .`
- `docker run --rm -it -p 8080:8080 --name traveller-tools traveller-tools`

# Issues
I could not get the build step inside the Dockerfile to work. After buildiung and starting the app is there but the style is totally messed up. If anyone knows how to fix it, please contact me. 

# Disclaimer
I did not implement any of this code. This repository is just a fork. Please do not ask if I can fix anything.
