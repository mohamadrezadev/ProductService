using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Application.Utils;

public class DatabaseConnectionVerifier(ILogger<DatabaseConnectionVerifier> logger)
{
    public void IsServerConnected(string connectionString)
    {
        try
        {
            var connection = new SqlConnection(connectionString);

            logger.Log(LogLevel.Information, "Attempting to open connection to SqlServer");

            connection.Open();

            logger.Log(LogLevel.Information, "Successfully opened connection to SqlServer");
        }
        catch (SqlException ex)
        {
            logger.Log(LogLevel.Critical, "Failed to open connection to SqlServer, reason: {ErrorMessage}", ex.Message);
        }
    }
}