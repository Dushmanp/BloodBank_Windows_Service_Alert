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
    public class DonorInfoData : IDonorInfoData
    {
        #region Construction
        private readonly string _connectionString;

        public DonorInfoData(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        public async Task<DonorInfo> Get(string APIKey, string ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var param = new DynamicParameters();
                param.Add("@APIKey", APIKey);
                param.Add("@ID", ID);
                var result = await connection.QuerySingleOrDefaultAsync<DonorInfo>("dnr.Donor_Get", param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
