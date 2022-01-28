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
    public abstract class MgClient
    {
        protected readonly string ApiKey;
        protected readonly string DomainName;
        protected readonly MgRegion Region;

        public MgClient(string apiKey, string domainName, MgRegion region)
        {
            this.ApiKey = apiKey;
            this.DomainName = domainName;
            this.Region = region;
        }



    }
}