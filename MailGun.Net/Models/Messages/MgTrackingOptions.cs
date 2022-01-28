using MailGun.Net.Enums;

namespace MailGun.Net.Models.Messages
{
    public class MgTrackingOptions
    {
        /// <summary>
        /// [o:tracking] Toggles tracking on a per-message basis
        /// </summary>
        public bool Tracking { get; set; }
        
        /// <summary>
        /// [o:tracking-clicks] Toggles clicks tracking on a per-message basis. Has higher priority than domain-level setting.
        /// </summary>
        public MgTrackingTypes? TrackingClicks { get; set; }
        
        /// <summary>
        /// [o:tracking-opens] Toggles opens tracking on a per-message basis. Has higher priority than domain-level setting. 
        /// </summary>
        public bool? TrackingOpens { get; set; }
        
    }
}