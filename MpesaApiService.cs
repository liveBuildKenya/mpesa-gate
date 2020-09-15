using Mpesa.Gate.Core;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mpesa.Gate
{
    /// <summary>
    /// The MPESA Application Programming Interface
    /// Register the service using the following code:
    ///     services.AddHttpClient<MpesaApiService>(c =>
    ///    {
    ///        c.BaseAddress = new Uri("https://api.github.com/");
    ///    });
    /// </summary>
    public class MpesaApiService
    {
        private readonly HttpClient _httpClient;

        public MpesaApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        #region Utilities

        public async Task<Models.Response.OAuth> GenerateAccessToken(Models.Request.OAuth model)
        {
            //get key secret
            var keySecret = model.ConsumerKey + ":" + model.ConsumerSecret;
            //get base64 encoding of the keySecret(consumerKey:consumerSecret)
            var encodedKeySecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(keySecret));
            //set Authorization header 
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Basic " + encodedKeySecret);
            //send request            
            var response = await _httpClient.GetAsync(SystemTransactionEndpoint.OAuth);
            //ensure success
            response.EnsureSuccessStatusCode();
            //stringify content
            var resultContent = await response.Content.ReadAsStringAsync();
            //deserialize object
            var result = JsonConvert.DeserializeObject<Models.Response.OAuth>(resultContent);

            return result;
        }

        private async Task<T> GetMpesaResponseAsync<T, U>(string uri, U model, Models.Request.OAuth oAuth)
        {
            //Get the access token
            var accessTokenModel = await GenerateAccessToken(oAuth);
            //serialize request model
            var serializedObject = JsonConvert.SerializeObject(model);
            //set the content
            var content = new StringContent(serializedObject, Encoding.UTF8, "application/json");
            //Remove initial authorization header
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            //Set current authorization header
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessTokenModel.AccessToken);
            //send request
            var response = await _httpClient.PostAsync(uri, content);
            //ensure success
            response.EnsureSuccessStatusCode();
            //stringify content
            var resultContent = await response.Content.ReadAsStringAsync();
            //deserialize object
            var result = JsonConvert.DeserializeObject<T>(resultContent);

            return result;
        }

        #endregion

        #region Methods

        /// <summary>
        /// This API enables you to register the callback URLs via which you shall receive payment notifications for payments to your paybill/till number.
        /// </summary>
        /// <param name="model">RegisterUrl model</param>
        /// <param name="oAuth">OAth model</param>
        /// <returns>RegisterUrlResponse model</returns>
        public async Task<Models.Response.RegisterUrl> RegisterUrl(Models.Request.RegisterUrl model, Models.Request.OAuth oAuth)
        {
            var result = await GetMpesaResponseAsync<Models.Response.RegisterUrl, object>(SystemTransactionEndpoint.C2BRegisterUrl, model, oAuth);

            return result;
        }

        /// <summary>
        /// This API is used to simulate payment requests from clients and to your API. 
        /// It basically simulates a payment made from the client phone's STK/SIM Toolkit menu, and enables you to receive the payment requests in real time.
        /// </summary>
        /// <param name="model">C2B model</param>
        /// <param name="oAuth">OAuth model</param>
        /// <returns>C2BResponse model</returns>
        public async Task<Models.Response.C2B> C2B(Models.Request.C2B model, Models.Request.OAuth oAuth)
        {
            var result = await GetMpesaResponseAsync<Models.Response.C2B, object>(SystemTransactionEndpoint.C2BSimulateTransaction, model, oAuth);

            return result;
        }

        /// <summary>
        /// Also known as the Bulk Payment API, the Business to Consumer (B2C) API enables a Business or Organization to pay their customers for a variety of reasons.
        /// </summary>
        /// <param name="model">B2C model</param>
        /// <param name="oAuth">OAuth model</param>
        /// <returns>B2CResponse model</returns>
        public async Task<Models.Response.B2C> B2C(Models.Request.B2C model, Models.Request.OAuth oAuth)
        {
            var result = await GetMpesaResponseAsync<Models.Response.B2C, object>(SystemTransactionEndpoint.B2C, model, oAuth);

            return result;
        }

        /// <summary>
        /// The Lipa na M-Pesa (LNM) API is a C2B API designed to utilize the new feature introduced by Safaricom known as STK Push.
        /// </summary>
        /// <param name="model">LipaNaMpesa model</param>
        /// <param name="oAuth">OAuth model</param>
        /// <returns>LipaNaMpesaResponse model</returns>
        public async Task<Models.Response.LipaNaMpesa> LipaNaMpesa(Models.Request.LipaNaMpesa model, Models.Request.OAuth oAuth)
        {
            var result = await GetMpesaResponseAsync<Models.Response.LipaNaMpesa, object>(SystemTransactionEndpoint.LipaNaMpesa, model, oAuth);

            return result;
        }

        /// <summary>
        /// Use this API to check the status of a Lipa Na M-Pesa Online Payment.
        /// </summary>
        /// <param name="model">LipaNaMpesaQuery model</param>
        /// <param name="oAuth">OAuth model</param>
        /// <returns>LipaNaMpesaQueryResponse model</returns>
        public async Task<Models.Response.LipaNaMpesaQuery> LipaNaMpesaQuery(Models.Request.LipaNaMpesaQuery model, Models.Request.OAuth oAuth)
        {
            var result = await GetMpesaResponseAsync<Models.Response.LipaNaMpesaQuery, object>(SystemTransactionEndpoint.LipaNaMpesaQuery, model, oAuth);

            return result;
        }

        #endregion
    }
}
