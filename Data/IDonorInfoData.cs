using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Data
{
    public interface IDonorInfoData
    {
        Task<DonorInfo> Get(string APIKey, string ID);
    }
}