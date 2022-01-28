using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;

namespace MailGun.Net.Models.Messages
{
    public class MgEmail
    {
        /// <summary>
        /// The senders email address
        /// </summary>
        [Required]
        public MgEmailAddress From { get; set; }

        /// <summary>
        /// Email address of the recipient(s)
        /// </summary>
        [Required]
        public List<MgEmailAddress> To { get; set; }

        /// <summary>
        /// Carbon Copy list
        /// </summary>
        [Required]
        public List<MgEmailAddress> Cc { get; set; }

        /// <summary>
        /// Blind carbon copy list
        /// </summary>
        [Required]
        public List<MgEmailAddress> Bcc { get; set; }

        /// <summary>
        /// The subject line of the email
        /// </summary>
        [Required]
        public string Subject { get; set; }

        /// <summary>
        /// Text version of the body of the message. Used if the html body is missing or unsupported
        /// </summary>
        [Required]
        public string TextBody { get; set; }

        /// <summary>
        /// Html version of the Body of the message. 
        /// </summary>
        public string HtmlBody { get; set; }

        /// <summary>
        /// Any attachments
        /// </summary>
        public List<MgAttachment> Attachments { get; set; }

        /// <summary>
        /// Customised options to tailor this message sending, optional.
        /// </summary>
        public MgOptions Options { get; set; }
        
        /// <summary>
        /// The Mailgun template setting to use with this email
        /// </summary>
        public MgTemplate Template { get; set; }

        public MgEmail()
        {
        }

        public MgEmail(MgEmailAddress from, List<MgEmailAddress> to, string subject, string textBody)
        {
            this.Subject = subject;
            this.TextBody = textBody;
            this.From = from;
            this.To = to;
        }

        public MgEmail(MgEmailAddress from, List<MgEmailAddress> to, string subject, string textBody, string htmlBody)
        {
            this.Subject = subject;
            this.TextBody = textBody;
            this.HtmlBody = htmlBody;
            this.From = from;
            this.To = to;
        }

        /// <summary>
        /// Helper method to support attaching files to MG email
        /// </summary>
        /// <param name="fileInfo">The FileInfo of the file</param>
        /// <param name="inline">Is this an inline attachment</param>
        public async Task AttachFileAsync(FileInfo fileInfo, bool inline = false)
        {
            try
            {
                this.Attachments ??= new();
                byte[] fileBytes = await File.ReadAllBytesAsync(fileInfo.FullName);
                MgAttachment attachment = new(fileInfo.Name, fileBytes, inline);
                this.Attachments.Add(attachment);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}