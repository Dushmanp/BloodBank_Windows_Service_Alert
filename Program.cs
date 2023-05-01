using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Testing;
using Testing.Classes;
using Testing.Data;
using Testing.Services;
using Topshelf;

public class Program
{
    public static void Main(string[] args)
    {
        var exitCode = HostFactory.Run(x =>
        {
            x.Service<BloodBank>(s =>
            {
                s.ConstructUsing(BloodBank => new BloodBank());
                s.WhenStarted(bloodBank => bloodBank.Start());
                s.WhenStopped(bloodBank => bloodBank.Stop());
            });
            x.RunAsLocalSystem();

            x.SetServiceName("BloodBankService");
            x.SetDisplayName("Blood Bank Service");
            x.SetDescription("This is the service which sent email for blood donor reminding the next donation date");
        });
        int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
        Environment.ExitCode =exitCodeValue;
    }

   


}
