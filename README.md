# .NET-Core-Weather-Application

This application allows users to log in using Google OAuth Authentication and a Weather API to search different locations, returning weather data.

The application is available from: https://liamfotheringhamweatherapplication.azurewebsites.net/

Built using the latest .NET Core v6.0, and hosted on an Azure App Service, this communicates with an internal SQL Server and Database, ensuring communication is trusted and internal.

A CI/CD Pipeline was implemented using GitHub Actions. Deployments are made to the App Service on each commit to the Master branch, as expected in a production pipeline.
