using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Data
{
    public class EmailSettingsData : IEmailSettingsData
    {
        #region Construction
            private readonly string _connectionString;

            public EmailSettingsData(string connectionString)
            {
                _connectionString = connectionString;
            }
        #endregion

        public async Task<EmailSettings> Get(string APIKey)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var param = new DynamicParameters();
                param.Add("@APIKey", APIKey);


                var result = await connection.QuerySingleOrDefaultAsync<EmailSettings>("adm.EmailSettings_Get", param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

    }
}
