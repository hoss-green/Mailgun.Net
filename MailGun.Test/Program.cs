using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using MailGun.Net;
using MailGun.Net.MgApi;
using MailGun.Net.Models;
using MailGun.Net.Models.Messages;
using MailGun.Net.Settings;

namespace MailGun.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        public static async Task RunAsync()
        {
            string key = await File.ReadAllTextAsync("sendkeyfile.tmp");
            MgMessages mgClient = new(key, "mg.hossgreen.com", MgRegion.EU);
            MgEmailAddress fromEmail = new() { Name = "Hassan", Email = "no-reply@hossgreen.com" };
            MgEmailAddress toEmail = new() { Name = "Hoss", Email = "Hoss.Green@pm.me" };
            MgEmail email = new(fromEmail, new() { toEmail }, "Test Email", "Hello", "<h3>Hello HTML</h3>");
            await email.AttachFileAsync(new("TestAttachment.txt"));
            //email.SetDeliveryTime(DateTime.UtcNow.AddMinutes(3));
            HttpResponseMessage response =  await mgClient.SendAsync(email);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Success: {await response.Content.ReadAsStringAsync()}");
            }
            else
            {
                Console.WriteLine("Mail sending error: " + response.StatusCode);
            }
        }
    }
}