using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IMDBDataStore.Configs;
using IMDBDataStore.Schema.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace IMDBDataStore.Schema
{
    public class SchemaInitializer : IHostedService
    {
        private readonly ILogger<SchemaInitializer> logger;
        private readonly DatabaseConfigurations databaseConfigs;
        public SchemaInitializer(ILogger<SchemaInitializer> logger, IOptions<DatabaseConfigurations> dbConfig)
        {
            this.logger = logger;
            databaseConfigs = dbConfig.Value;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            InitializeDataBase();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void InitializeDataBase()
        {
            if (!string.IsNullOrEmpty(databaseConfigs.ConnectionString))
            {
                var option = new DbContextOptionsBuilder<IMDBContext>().UseSqlServer(databaseConfigs.ConnectionString);
                var splitWiseDbContext = new IMDBContext(option.Options);
                logger.LogInformation("Trying toconnect to Database");
                if (splitWiseDbContext.Database.CanConnect())
                {
                    logger.LogInformation("DataBase Connections Successful");
                    if (databaseConfigs.AutomaticUpdatesEnabled)
                    {
                        logger.LogInformation("Checking for migrations");
                        if (splitWiseDbContext.Database.GetPendingMigrations().Any())
                        {
                            splitWiseDbContext.Database.Migrate();
                            logger.LogInformation("Database updated");
                        }
                        else
                        {
                            logger.LogInformation("Database is Uptodate");
                        }
                    }
                }
                else
                {
                    logger.LogInformation("database not exit");
                    if (databaseConfigs.AllowDatabaseCreation)
                    {
                        logger.LogInformation("Creating database");
                        splitWiseDbContext.Database.Migrate();
                        logger.LogInformation("Database created");
                        return;
                    }
                    logger.LogInformation("database creation failed : database creation disabled");
                }
            }
            else
            {
                logger.LogInformation("Database initialization failed: empty connection string");
            }
        }
    }
}