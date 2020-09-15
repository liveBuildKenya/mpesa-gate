using System.Runtime.Serialization;

namespace Mpesa.Gate.Models.Response
{
    /// <summary>
    /// Represents a business to customer response
    /// </summary>
    [DataContract]
    public class B2C
    {
        /// <summary>
        /// The conversation identifier
        /// </summary>
        [DataMember(Name = "ConversationID")]
        public string ConversationID { get; set; }

        /// <summary>
        /// The originator conversation identifier
        /// </summary>
        [DataMember(Name = "OriginatorConversationID")]
        public string OriginatorConversationID { get; set; }

        /// <summary>
        /// The response code
        /// </summary>
        [DataMember(Name = "ResponseCode")]
        public string ResponseCode { get; set; }

        /// <summary>
        /// The response description
        /// </summary>
        [DataMember(Name = "ResponseDescription")]
        public string ResponseDescription { get; set; }
    }
}
