using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Data;
using Testing.Models;

namespace Testing.Services
{
    public class EmailSettingsService
    {
        #region Construction
        private readonly IEmailSettingsData emailSettingsData;
        private readonly IDonorInfoData donorInfoData;


        public EmailSettingsService(IEmailSettingsData emailSettingsData, IDonorInfoData donorInfoData)
        {
            this.emailSettingsData = emailSettingsData;
            this.donorInfoData = donorInfoData;
        }
        #endregion

        public async Task<EmailSettings> Get(string APIKey)
        {
            return await emailSettingsData.Get( APIKey);
        }

        public async Task SendEmail(string connectionString,string DonorID)
        {
            try
            {
                var obj =await  donorInfoData.Get("1032", DonorID);
                // Create an instance of EmailSender class
                var emailSender = new EmailSender(new EmailSettingsData(connectionString));

                // Set the email properties
                emailSender.Sendto = new List<string>(new[] { obj.Email });
                emailSender.Subject = "Reminder - Today is Your Blood Donation Day";
                emailSender.ToName = obj.Name;
                emailSender.Description = "This is a friendly reminder that today is your scheduled blood donation day. Please don't forget to donate and help save lives.<br/><br/>In case you're unable to make it today, kindly schedule your appointment by using our website. Your generosity is greatly appreciated";
                emailSender.ActionName = "Apply for Next Donation";
                emailSender.URL = "/Donor/DonarDonation";

                // Send the email
                await emailSender.SendEmail(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }

}
