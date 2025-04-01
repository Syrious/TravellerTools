# Use the .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Set environment variables for proper app behavior
ENV ASPNETCORE_ENVIRONMENT=Production

# Copy the previously published files into the container
COPY ./publish .

# Launch the app
ENTRYPOINT ["dotnet", "Grauenwolf.TravellerTools.Web.dll"]