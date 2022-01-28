namespace MailGun.Net.Models.Messages
{
    /// <summary>
    /// Class for adding custom MIME headers to the mail
    /// </summary>
    public class MgCustomVariable
    {
        public string Name { get; }
        public string Value { get; }
        
        public MgCustomVariable(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        
        
        
    }
}