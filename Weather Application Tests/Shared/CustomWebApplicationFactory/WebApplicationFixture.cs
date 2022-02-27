﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Weather_Application.Data;

namespace Weather_Application_Tests.Shared.CustomWebApplicationFactory
{
    public class WebApplicationFixture
    {
        public CustomWebApplicationFactory Factory = null!;

        public WebApplicationFixture()
        {
            Factory = new CustomWebApplicationFactory();

            var services = Factory.Services.CreateScope().ServiceProvider;
            EnsureDatabasesCreatedAndMigrated(services);
        }

        private static void EnsureDatabasesCreatedAndMigrated(IServiceProvider services)
        {
            var logger = services.GetRequiredService<ILogger<WebApplicationFixture>>();

            try
            {
                logger.LogInformation("Migrating database.");

                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                logger.LogInformation("Database migration done.");
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Unhandled exception trying to ensure database created and migrated.");
            }
        }
    }
}
