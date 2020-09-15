namespace Mpesa.Gate.Models.Request
{
    /// <summary>
    /// Represents OAuth requirements
    /// </summary>
    public class OAuth
    {
        /// <summary>
        /// Gets or sets the consumer key
        /// </summary>
        public string ConsumerKey { get; set; }

        /// <summary>
        /// Gets or sets the consumer secret
        /// </summary>
        public string ConsumerSecret { get; set; }
    }
}
