using System.Runtime.Serialization;

namespace Mpesa.Gate.Models.Response
{
    /// <summary>
    /// Represents a customer to business response model
    /// </summary>
    [DataContract]
    public class C2B
    {
        /// <summary>
        /// The conversation identifier
        /// </summary>
        [DataMember(Name = "ConversationID")]
        public string ConversationID { get; set; }

        /// <summary>
        /// The originator conversation identifier
        /// </summary>
        [DataMember(Name = "OriginatorCoversationID")]
        public string OriginatorCoversationID { get; set; }

        /// <summary>
        /// The response description
        /// </summary>
        [DataMember(Name = "ResponseDescription")]
        public string ResponseDescription { get; set; }
    }
}
