using System;
using System.Collections.Generic;

namespace MailGun.Net.Models.Messages
{
    public class MgOptions
    {
        /// <summary>
        /// [o:tag](s) Tag string. A single message may be marked with up to 3 tags.
        /// Tags are case insensitive and should be ascii only. Maximum tag length is 128 characters. 
        /// </summary>
        public List<string> Tags { get; set; }
        
        /// <summary>
        /// [o:dkim] Enables/disables DKIM signatures on per-message basis.
        /// </summary>
        public bool? Dkim { get; set; }
        
        // ReSharper disable once CommentTypo
        /// <summary>
        /// [o:deliverytime] The target time for email delivery 
        /// </summary>
        public DateTime? DeliveryTime { get; set; }
        
        // ReSharper disable once CommentTypo
        /// <summary>
        /// [o:deliverytime-optimize-period] Toggles Send Time Optimization (STO) on a per-message basis.
        /// String should be set to the number of hours in [0-9]+h format, with the minimum being 24h and the maximum being 72h.
        /// This value defines the time window in which Mailgun will run the optimization algorithm based on prior engagement data of a given recipient.
        /// </summary>
        public int? DeliveryTimeOptimisePeriod { get; set; }
        
        //TODO: Replace this with a date time
        /// <summary>
        /// [o:time-zone-localize] Toggles Timezone Optimization (TZO) on a per message basis.
        /// String should be set to preferred delivery time in HH:mm or hh:mmaa format, where HH:mm is used for 24 hour format without AM/PM and hh:mmaa is used for 12 hour format with AM/PM.
        /// </summary>
        public string TimeZoneOptimisation { get; set; }
        
        // ReSharper disable once CommentTypo
        /// <summary>
        /// [o:testmode] Enables sending in test mode. (You are charged for messages sent in test mode.) 
        /// </summary>
        public bool? TestMode { get; set; }

        /// <summary>
        /// Responsible for controlling the tracking options of this email
        /// </summary>
        public MgTrackingOptions TrackingOptions { get; set; }

        /// <summary>
        /// [o:require-tls] If set to True this requires the message only be sent over a TLS connection. If a TLS connection can not be established, Mailgun will not deliver the message.
        /// If set to False or no, Mailgun will still try and upgrade the connection, but if Mailgun can not, the message will be delivered over a plaintext SMTP connection.
        /// </summary>
        public bool? RequireTls { get; set; }

        /// <summary>
        /// [o:skip-verification] If set to True, the certificate and hostname will not be verified when trying to establish a TLS connection and Mailgun will accept any certificate during delivery.
        /// If set to False, Mailgun will verify the certificate and hostname. If either one can not be verified, a TLS connection will not be established.
        /// </summary>
        public bool? SkipVerification { get; set; }

        /// <summary>
        /// Allows appending a custom MIME header to the message. For example, h:Reply-To to specify Reply-To address.
        /// </summary>
        public List<MgCustomHeader> CustomHeaders { get; set; }
        
        
        
        

    }
}