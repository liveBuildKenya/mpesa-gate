using System.Runtime.Serialization;

namespace Mpesa.Gate.Models.Response
{
    /// <summary>
    /// Represents a register url response model
    /// </summary>
    [DataContract]
    public class RegisterUrl
    {
        /// <summary>
        /// The Conversation Identifier
        /// </summary>
        [DataMember(Name = "ConversationID")]
        public string ConversationID { get; set; }

        /// <summary>
        /// The orignator conversation identifier
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
