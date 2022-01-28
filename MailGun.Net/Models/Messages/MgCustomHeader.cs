namespace MailGun.Net.Models.Messages
{
    /// <summary>
    /// Class for adding custom MIME headers to the mail
    /// </summary>
    public class MgCustomHeader
    {
        public string Name { get; }
        public string Value { get; }
        
        public MgCustomHeader(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        
        
        
    }
}