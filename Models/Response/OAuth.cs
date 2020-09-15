using System.Runtime.Serialization;

namespace Mpesa.Gate.Models.Response
{
    /// <summary>
    /// Represents the authentication response 
    /// </summary>
    [DataContract]
    public class OAuth
    {
        /// <summary>
        /// Access token
        /// </summary>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Expiry perios remaining
        /// </summary>
        [DataMember(Name = "expires_in")]
        public string ExpiresIn { get; set; }
    }
}
