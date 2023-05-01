using System.Collections.Generic;
using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Data
{
    public interface IDonarDonationData
    {
        Task<List<DonarDonation>> GetList(string APIKey, string KeyW = "", string DonorID = "", string NIC = "", string DonationDate = "", string BloodBankCentreID = "", string DoctorID = "", string Status = "", int Page = 0, int PageSize = 99999);
        Task<int> GetCount(string apiKey, string keyW, string donorId, string nic, string donationDate, string bloodBankCentreId, string doctorId, string status);
    }
}