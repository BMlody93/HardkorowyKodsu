using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardkorowyKodsu.WebApi.Business.Interfaces;
using HardkorowyKodsu.WebApi.CommonModel.Structures;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace HardkorowyKodsu.WebApi.Business.Managers
{
    public class SqlServerDatabaseStructureManager : IDatabaseStructureManager
    {
        private string _connectionString;

        public SqlServerDatabaseStructureManager(IConfiguration configuration)
        {
            if (configuration is null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _connectionString = configuration["SqlServerDatabaseStructureManager:ConnectionString"] ?? "";

            if(string.IsNullOrEmpty(_connectionString))
                throw new ArgumentException(nameof(configuration));
        }
        public async Task<DatabaseStructure> GetDatabaseStructureAsync()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    Log.Debug("Opening connection to database");
                    await connection.OpenAsync();

                    string query = @"
                        SELECT TABLE_NAME, TABLE_TYPE
                        FROM INFORMATION_SCHEMA.TABLES
                        WHERE TABLE_TYPE IN ('BASE TABLE', 'VIEW')
                        ORDER BY TABLE_TYPE, TABLE_NAME";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        Log.Debug("Executing reader command");
                        using (SqlDataReader reader = await command.ExecuteReaderAsync ())
                        {
                            var databaseStructure = new DatabaseStructure()
                            {
                                NamesType = new Dictionary<string, string>()
                            };

                            while (await reader.ReadAsync())
                            {
                                var tableType = reader["TABLE_TYPE"].ToString();
                                var tableName = reader["TABLE_NAME"].ToString();

                                databaseStructure.NamesType.Add(tableName, tableType);
                            }

                            return databaseStructure;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<TableStructure> GetTableStructureAsync(string tableName)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    Log.Debug("Opening connection to database");
                    await connection.OpenAsync();

                    string query = @"
                        SELECT COLUMN_NAME, DATA_TYPE
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_NAME = @TableName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TableName", tableName);

                        Log.Debug("Executing reader command");
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            var tableStructure = new TableStructure()
                            {
                                Columns = new Dictionary<string, string>()
                            };

                            while (await reader.ReadAsync())
                            {
                                var columnName = reader["COLUMN_NAME"].ToString();
                                var columnType = reader["DATA_TYPE"].ToString();

                                tableStructure.Columns.Add(columnName, columnType);
                            }

                            return tableStructure;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
