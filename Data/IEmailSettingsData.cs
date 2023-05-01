using System.Threading.Tasks;
using Testing.Models;

namespace Testing.Data
{
    public interface IEmailSettingsData
    {
        Task<EmailSettings> Get(string APIKey);
    }
}