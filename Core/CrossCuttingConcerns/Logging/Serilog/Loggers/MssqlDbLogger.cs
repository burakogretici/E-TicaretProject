using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;


namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers
{
    public class MssqlDbLogger : LoggerServiceBase
    {
        public MssqlDbLogger()
        {
            var configuration = ServiceTool.ServiceProvider.GetService<IConfiguration>();
            var logConfig = configuration.GetSection("SeriLogConfigurations:MsSqlConfiguration")
                .Get<MssqlDbConfiguration>();

            Logger = new LoggerConfiguration()
                .WriteTo.MSSqlServer(logConfig.ConnectionString, logConfig.Table, autoCreateSqlTable: true, columnOptions: GetSqlColumnOptions())
                .CreateLogger();

            var a = Logger;

        }
        static ColumnOptions GetSqlColumnOptions()
        {
            var columnOptions = new ColumnOptions();
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Add(StandardColumn.LogEvent);

            columnOptions.AdditionalDataColumns = new Collection<DataColumn>
        {
            new DataColumn {DataType = typeof(string), ColumnName = "Application"},
            new DataColumn {DataType = typeof(string), ColumnName = "Environment"}
        };

            return columnOptions;
        }
    }
}
