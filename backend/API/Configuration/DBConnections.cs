namespace API.Configuration
{
    public class DBConnections
    {
        public string ConnectionString { get; }

        public DBConnections()
        {
            DotNetEnv.Env.Load();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            string dbServer = configuration["DB_HOST"] ?? "localhost";
            string dbPort = configuration["DB_PORT"] ?? "1234";
            string dbName = configuration["DB_NAME"] ?? "base";
            string dbUser = configuration["DB_USER"] ?? "cons";
            string dbPassword = configuration["DB_PASS"] ?? "sorto";

            ConnectionString = $"Server={dbServer},{dbPort};Database={dbName};User Id={dbUser};Password={dbPassword};TrustServerCertificate=True;";
        }
    }
}
