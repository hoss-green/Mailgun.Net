namespace MailGun.Net.Models.Messages
{
    /// <summary>
    /// A File to attach to an email
    /// </summary>
    public class MgAttachment
    {
        /// <summary>
        /// The name of the attachment
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// The bytes of the attachment
        /// </summary>
        public byte[] FileBytes { get; }
        
        /// <summary>
        /// If this is an inline attachment (default = false)
        /// </summary>
        public bool Inline { get; }
        
        public MgAttachment(string name, byte[] fileBytes, bool inline = false)
        {
            this.Name = name;
            this.FileBytes = fileBytes;
            this.Inline = inline;
        }

        
    }
}