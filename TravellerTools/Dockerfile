# Use Microsoft's official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory inside the container
WORKDIR /src

# Copy the solution file and .csproj files into the container
COPY *.sln ./
COPY Grauenwolf.TravellerTools.Animals/*.csproj ./Grauenwolf.TravellerTools.Animals/
COPY Grauenwolf.TravellerTools.Characters/*.csproj ./Grauenwolf.TravellerTools.Characters/
COPY Grauenwolf.TravellerTools.Encounters/*.csproj ./Grauenwolf.TravellerTools.Encounters/
COPY Grauenwolf.TravellerTools.Equipment/*.csproj ./Grauenwolf.TravellerTools.Equipment/
COPY Grauenwolf.TravellerTools.Services/*.csproj ./Grauenwolf.TravellerTools.Services/
COPY Grauenwolf.TravellerTools.Shared/*.csproj ./Grauenwolf.TravellerTools.Shared/
COPY Grauenwolf.TravellerTools.Tests/*.csproj ./Grauenwolf.TravellerTools.Tests/
COPY Grauenwolf.TravellerTools.TradeCalculator/*.csproj ./Grauenwolf.TravellerTools.TradeCalculator/
COPY Grauenwolf.TravellerTools.Web/*.csproj ./Grauenwolf.TravellerTools.Web/
COPY Tortuga.Yardarm/*.csproj ./Tortuga.Yardarm/

# Restore dependencies
RUN dotnet restore

# Copy the rest of the app's code
COPY . .

# Build the app in release mode and publish it
RUN dotnet publish "Grauenwolf.TravellerTools.Web/Grauenwolf.TravellerTools.Web.csproj" -c Release -o /publish-output

# Use the .NET runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Set environment variables for proper app behavior
ENV ASPNETCORE_ENVIRONMENT=Production

COPY --from=build /publish-output .

# Launch the app
ENTRYPOINT ["dotnet", "Grauenwolf.TravellerTools.Web.dll"]