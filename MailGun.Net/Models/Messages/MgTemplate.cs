namespace MailGun.Net.Models.Messages
{
    public class MgTemplate
    {
        /// <summary>
        /// [template] Name of a template stored via template API. See Templates for more information
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// [t:version] Use this parameter to send a message to specific version of a template
        /// </summary>
        public string Version { get; set; }
        
        /// <summary>
        /// [t:text] True if you want to have rendered template in the text part of the message (in case of template sending)
        /// </summary>
        public bool RenderText { get; set; }
    }
}