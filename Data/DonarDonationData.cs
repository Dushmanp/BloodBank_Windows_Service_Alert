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
    public class DonarDonationData : IDonarDonationData
    {
        #region Construction
        private readonly string _connectionString;

        public DonarDonationData(string connectionString)
        {
            _connectionString = connectionString;
        }
        #endregion

        public async Task<int> GetCount(string apiKey, string keyW, string donorId, string nic, string donationDate, string bloodBankCentreId, string doctorId, string status)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var param = new DynamicParameters();
                param.Add("@APIKey", apiKey);
                param.Add("@KeyW", keyW);
                param.Add("@DonorID", donorId);
                param.Add("@NIC", nic);
                param.Add("@DonationDate", donationDate);
                param.Add("@BloodBankCentreID", bloodBankCentreId);
                param.Add("@DoctorID", doctorId);
                param.Add("@Status", status);

                var result = await connection.QueryAsync<int>("dnr.DonarDonation_Count", param, commandType: CommandType.StoredProcedure);

                return result.Single();
            }
        }

        public async Task<List<DonarDonation>> GetList(string APIKey, string KeyW = "", string DonorID = "", string NIC = "", string DonationDate = "", string BloodBankCentreID = "", string DoctorID = "", string Status = "", int Page = 0, int PageSize = 99999)
        {
           
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var param = new DynamicParameters();
                param.Add("@APIKey", APIKey);
                param.Add("@KeyW", KeyW);
                param.Add("@DonorID", DonorID);
                param.Add("@NIC", NIC);
                param.Add("@DonationDate", DonationDate);
                param.Add("@BloodBankCentreID", BloodBankCentreID);
                param.Add("@DoctorID", DoctorID);
                param.Add("@Status", Status);
                param.Add("@Page", Page);
                param.Add("@PageSize", PageSize);

                var result = await connection.QueryAsync<DonarDonation>("dnr.DonarDonation_List", param, commandType: CommandType.StoredProcedure);

                return result.ToList();
            }
        }

    }
}
