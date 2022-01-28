using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MailGun.Net.Models;
using MailGun.Net.Models.Messages;

namespace MailGun.Net.ApiManagers
{
    internal class EmailSender
    {
        public async Task<HttpResponseMessage> SendEmailAsync(string url, string auth, MgEmail email)
        {
            try
            {
                HttpClient client = new();
                HttpRequestMessage requestMessage = new(HttpMethod.Post, url);
                requestMessage.Headers.Authorization = new("basic", auth);
                MultipartFormDataContent emailForm = BuildEmailForm(email);

                emailForm = AddAttachments(emailForm, email);
                emailForm = AddFormOptions(emailForm, email);
                emailForm = AddTemplateOptions(emailForm, email.Template);

                requestMessage.Content = emailForm;

                HttpResponseMessage responseMessage = await client.SendAsync(requestMessage);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string result = responseMessage.Content.ReadAsStringAsync().Result;
                    Debug.WriteLine(result);
                }

                return responseMessage;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        
        
        
        private MultipartFormDataContent AddAttachments(MultipartFormDataContent emailForm, MgEmail email)
        {
            if (email.Attachments == null)
            {
                return emailForm;
            }

            foreach (MgAttachment attachment in email.Attachments)
            {
                string type = attachment.Inline ? "inline" : "attachment";
                emailForm.Add(new ByteArrayContent(attachment.FileBytes), type, attachment.Name);
            }

            return emailForm;
        }


        private MultipartFormDataContent AddFormOptions(MultipartFormDataContent emailForm, MgEmail email)
        {
            MgOptions options = email.Options;
            if (options == null)
            {
                return emailForm;
            }

            if (options.Tags != null)
            {
                foreach (string optionsTag in options.Tags)
                {
                    emailForm.Add(new StringContent(optionsTag), "o:tag");
                }
            }

            if (options.Dkim.HasValue)
            {
                emailForm.Add(new StringContent(options.Dkim.Value.ToString()), "o:dkim");
            }

            if (options.DeliveryTime.HasValue)
            {
                // ReSharper disable once StringLiteralTypo
                emailForm.Add(new StringContent(options.DeliveryTime?.ToString("R")), "o:deliverytime");
            }

            if (options.DeliveryTimeOptimisePeriod.HasValue)
            {
                // ReSharper disable once StringLiteralTypo
                emailForm.Add(new StringContent(options.DeliveryTimeOptimisePeriod.Value.ToString()), "o:deliverytime-optimize-period");
            }

            if (options.TimeZoneOptimisation != null)
            {
                emailForm.Add(new StringContent(options.TimeZoneOptimisation), "o:time-zone-localize");
            }

            if (options.TestMode.HasValue)
            {
                // ReSharper disable once StringLiteralTypo
                emailForm.Add(new StringContent(options.TestMode.Value.ToString()), "o:testmode");
            }

            if (options.RequireTls.HasValue)
            {
                emailForm.Add(new StringContent(options.RequireTls.Value.ToString()), "o:require-tls");
            }
            
            if (options.SkipVerification.HasValue)
            {
                emailForm.Add(new StringContent(options.SkipVerification.Value.ToString()), "o:skip-verification");
            }

            if (options.TrackingOptions?.Tracking == true)
            {
                MgTrackingOptions trackingOptions = options.TrackingOptions;
                emailForm.Add(new StringContent(trackingOptions.Tracking.ToString()), "o:tracking");

                if (trackingOptions.TrackingClicks.HasValue)
                {
                    emailForm.Add(new StringContent(trackingOptions.TrackingClicks.Value.ToString()), "o:tracking-clicks");
                }

                if (trackingOptions.TrackingOpens.HasValue)
                {
                    emailForm.Add(new StringContent(trackingOptions.TrackingClicks.Value.ToString()), "o:tracking-opens");
                }
            }

            emailForm = AddCustomHeaders(emailForm, options.CustomHeaders);
            
            return emailForm;
        }

        private MultipartFormDataContent AddCustomHeaders(MultipartFormDataContent emailForm, List<MgCustomHeader> customHeaders)
        {
            if (customHeaders == null)
            {
                return emailForm;
            }
            
            foreach (MgCustomHeader customHeader in customHeaders)
            {
                emailForm.Add(new StringContent(customHeader.Value), $"h:{customHeader.Name}");
            }

            return emailForm;

        }
        
        private MultipartFormDataContent AddTemplateOptions(MultipartFormDataContent emailForm, MgTemplate template)
        {
            if (template?.Name == null)
            {
                return emailForm;
            }

            emailForm.Add(new StringContent(template.Name), "template");

            if (template.Version != null)
            {
                emailForm.Add(new StringContent(template.Version), "t:version");
            }

            if (template.RenderText)
            {
                emailForm.Add(new StringContent("yes"), "t:text");
            }

            return emailForm;
        }

        private MultipartFormDataContent BuildEmailForm(MgEmail email)
        {
            MultipartFormDataContent mailContent = new();
            mailContent.Add(new StringContent($"{email.From.Name} <{email.From.Email}>"), "from");
            foreach (MgEmailAddress toAddresses in email.To)
            {
                mailContent.Add(new StringContent($"{toAddresses.Name} <{toAddresses.Email}>"), "to");
            }

            mailContent.Add(new StringContent($"{email.Subject}"), "subject");
            mailContent.Add(new StringContent($"{email.TextBody}"), "text");
            if (email.HtmlBody != null)
            {
                mailContent.Add(new StringContent($"{email.HtmlBody}"), "html");
            }

            return mailContent;
        }
    }
}