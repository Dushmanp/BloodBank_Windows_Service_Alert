using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Data;
using Testing.Models;

namespace Testing.Services
{
    public class DonorDonationService
    {
        private readonly IDonarDonationData _donarDonationData;

        public DonorDonationService(IDonarDonationData donarDonationData)
        {
            _donarDonationData = donarDonationData;
        }

        public async Task<int> GetCount(string apiKey, string keyW, string donorId, string nic, string donationDate, string bloodBankCentreId, string doctorId, string status)
        {
            return await _donarDonationData.GetCount(apiKey, keyW, donorId, nic, donationDate, bloodBankCentreId, doctorId, status);
        }

        public async Task<List<DonarDonation>> GetList(string APIKey, string KeyW = "", string DonorID = "", string NIC = "", string DonationDate = "", string BloodBankCentreID = "", string DoctorID = "", string Status = "", int Page = 0, int PageSize = 99999)
        {
            return await _donarDonationData.GetList( APIKey,  KeyW ,  DonorID,  NIC,  DonationDate,  BloodBankCentreID,  DoctorID,  Status,  Page ,  PageSize );
        }
    }

}
