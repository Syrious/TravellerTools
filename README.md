# Traveller Tools II
Tools for the Traveller RPG

# Local run
- Go to  https://dotnet.microsoft.com/en-us/download/dotnet (tested with 9.0) and download
  - SDK
  - .NET Runtime (not Desktop I guess)
  - ASP.NET Core Runtime
- Open a console and cd into `Grauenwolf.TravellerTools.Web`
  - `dotnet restore` to ensure all dependencies are restored
  - `dotnet build` to build the project
  - `dotnet run` to run the project
- Now open a browser and head to https://localhost:5001/

# Build
- In root folder (Traveller_Tools)
- `dotnet publish Grauenwolf.TravellerTools.Web/Grauenwolf.TravellerTools.Web.csproj -c Release -o ./publish-output` 
- Navigate to publish-output and start `Grauenwolf.TravellerTools.Web.exe`


# Build with Docker (kind of)
- `dotnet publish Grauenwolf.TravellerTools.Web/Grauenwolf.TravellerTools.Web.csproj -c Release -o publish`
- `docker build -t traveller-tools .`
- `docker run --rm -it -p 8080:8080  --name traveller-tools traveller-tools`