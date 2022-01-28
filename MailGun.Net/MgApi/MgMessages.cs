using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MailGun.Net.ApiManagers;
using MailGun.Net.Models.Messages;
using MailGun.Net.Settings;

namespace MailGun.Net.MgApi
{
    public class MgMessages : MgClient
    {
        public MgMessages(string apiKey, string domainName, MgRegion region) : base(apiKey, domainName, region)
        {
        }
        
        public async Task<HttpResponseMessage> SendAsync([NotNull] MgEmail email)
        {
            try
            {
                string url = $"{this.Region.ApiUrl}/v3/{this.DomainName}/messages";
                string auth = Convert.ToBase64String(Encoding.UTF8.GetBytes($"api:{this.ApiKey}"));
                EmailSender emailSender = new();
                return await emailSender.SendEmailAsync(url, auth, email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Retrieve()
        {
            
        }

        /// <summary>
        /// Delete is unsupported by mailgun.
        /// Stored messages are retained in the system for 3 days and automatically purged after this retention period,
        /// therefore there is no need to delete messages explicitly.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete()
        {
            throw new NotImplementedException(
                "Delete is unsupported by mailgun." +
                " Stored messages are retained in the system for 3 days and automatically purged after this retention period," +
                " therefore there is no need to delete messages explicitly.");
        }
    }
}