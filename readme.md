# M-PESA Example Usage

```C#
using Mpesa.Gate;
using Mpesa.Gate.Core;
using Mpesa.Gate.Models.Request;
using System;
using System.Net.Http;
using System.Text;

namespace MpesaConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var oAuth = new OAuth
            {
                ConsumerKey = "WG3Cbz2BDYTRph0iJTsu9yYq537qaVN0",
                ConsumerSecret = "G4oKroCBOMECEuTx"
            };

            var lnmPassKey = "bfb279f9aa9bdbcf158e97dd71a467cd2e0c893059b10f78e6b72ada1ed2c919";
            var businessShortCode = "174379";
            var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            var lnmModel = new LipaNaMpesa
            {
                BusinessShortCode = "174379",
                Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(businessShortCode + lnmPassKey + timeStamp)),
                Timestamp = timeStamp,
                TransactionType = "CustomerPayBillOnline",
                Amount = "2",
                PartyA = "254790801990",
                PartyB = businessShortCode,
                PhoneNumber = "254790801990",
                CallBackUrl = "http://requestbin.fullcontact.com/13neadh1",
                AccountReference = "174379",
                TransactionDescription = "Lipia kitu",
            };

            var client = new HttpClient
            {
                BaseAddress = new Uri(SystemEnvironment.Sandbox)
            };

            var mpesaService = new MpesaApiService(client);

            var response = mpesaService.LipaNaMpesa(lnmModel, oAuth);            

            Console.WriteLine(response.Result.CheckoutRequestID);
        }
    }
}
```
