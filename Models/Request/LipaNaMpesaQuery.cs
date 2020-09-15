using System.Runtime.Serialization;

namespace Mpesa.Gate.Models.Request
{
    [DataContract]
    public class LipaNaMpesaQuery
    {
        /// <summary>
        /// This is the shortcode of the organization initiating the request and expecting the payment.
        /// </summary>
        [DataMember(Name = "BusinessShortCode")]
        public string BusinessShortCode { get; set; }

        /// <summary>
        /// This is the Base64-encoded value of the concatenation of the Shortcode + LNM Passkey + Timestamp(YYYYMMDDHHmmss)
        /// </summary>
        [DataMember(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// This is the same Timestamp used in the encoding above, in the format YYYMMDDHHmmss.
        /// </summary>
        [DataMember(Name = "Timestamp")]
        public string Timestamp { get; set; }

        /// <summary>
        /// Check out Request ID
        /// </summary>
        [DataMember(Name = "CheckoutRequestID")]
        public string CheckoutRequestID { get; set; }
    }
}
