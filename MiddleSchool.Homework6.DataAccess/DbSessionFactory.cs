using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace MiddleSchool.Homework6.DataAccess;

// internal class DbSessionFactory
// {
//     public async ValueTask<MySqlConnection> GetConnection()
//     {
//         while (true)
//         {
//             try
//             {
//                 return await _mySqlDataSource.OpenConnectionAsync();
//             }
//             catch (MySqlException ex)
//             {
//                 if (ex.Message.Contains("Got timeout reading communication packets"))
//                 {
//                     _logger.Log(LogLevel.Warning, new EventId(315453, "MySqlConnector.ServerTimeout"),
//                         "Failed to connect.", ex, static (x, y) => x);
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }
//         }
//     }
// }