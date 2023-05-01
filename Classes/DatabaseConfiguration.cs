using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.Classes
{
    public class DatabaseConfiguration
    {
        private readonly IConfiguration _configuration;

        public DatabaseConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            var server = _configuration["ApplicationSettings:DBSettings:Server"];
            var database = _configuration["ApplicationSettings:DBSettings:Database"];
            var userId = _configuration["ApplicationSettings:DBSettings:UserId"];
            var password = _configuration["ApplicationSettings:DBSettings:Password"];

            return $"Data Source={server};Initial Catalog={database};User ID={userId};Password={password}";
        }
        public static DatabaseConfiguration CreateDatabaseConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return new DatabaseConfiguration(config);
        }

        public static string GetUploadPath()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return config["ApplicationSettings:Directory:UploadPath"];
        }


    }

}
