using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Testing.Classes;
using Testing.Data;
using Testing.Services;

namespace Testing
{
    public class BloodBank
    {
        private readonly Timer timer;
        public BloodBank()
        {
            timer = new Timer(5000) { AutoReset=true};
            timer.Elapsed += timer_Elapsed;

        }

        public async void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //string[] lines = new string[] { DateTime.Now.ToString() };
            //File.AppendAllLines(@"F:\1.txt", lines);

            // call mypg method to send email
           await SendEmailDonor();
        }

        private static async Task SendEmailDonor()
        {

            try
            {
                #region DBConnectionSettings
                var dbConfig = DatabaseConfiguration.CreateDatabaseConfiguration();

                var connectionString = dbConfig.GetConnectionString();
                var emailSettingsData = new EmailSettingsData(connectionString);
                var donorInfoData = new DonorInfoData(connectionString);
                var emailSettingsService = new EmailSettingsService(emailSettingsData, donorInfoData);

                var donationData = new DonarDonationData(connectionString);
                var donorDonationService = new DonorDonationService(donationData);
                #endregion

                var objList = await donationData.GetList(
                     APIKey: "1032",
                     KeyW: "",
                     DonorID: "",
                     NIC: "",
                     DonationDate: "",
                     BloodBankCentreID: "",
                     DoctorID: "",
                     Status: "",
                     Page: 0,
                     PageSize: 999999
                    );
                var currentDate = DateTime.Now.Date;
                
                foreach (var obj in objList)
                {

                    if (obj.NextDonationDate.Date == currentDate)
                    {
                        await emailSettingsService.SendEmail(connectionString, obj.DonorID);
                        
                    }
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public void Start()
        {
            timer.Start();
        }
        public void Stop()
        {
            timer.Stop();
        }
    }
}
