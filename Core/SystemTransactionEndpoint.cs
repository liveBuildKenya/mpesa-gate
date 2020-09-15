namespace Mpesa.Gate.Core
{
    /// <summary>
    /// Represents transaction endpoints
    /// </summary>
    public static class SystemTransactionEndpoint
    {
        /// <summary>
        /// Transaction Reversal API reverses a M-Pesa transaction.
        /// </summary>
        public static string Reversal { get { return "/mpesa/reversal/v1/request"; } }

        /// <summary>
        /// Use this API to transact between an M-Pesa short code to a phone number registered on M-Pesa.
        /// </summary>
        public static string B2C { get { return "/mpesa/b2c/v1/paymentrequest"; } }

        /// <summary>
        /// Use this API to enquire the balance on an M-Pesa BuyGoods (Till Number).
        /// </summary>
        public static string BalanceInquiry { get { return "/mpesa/accountbalance/v1/query"; } }

        /// <summary>
        /// Use this api to check the transaction status.
        /// </summary>
        public static string TransactionStatus { get { return "/mpesa/transactionstatus/v1/query"; } }

        /// <summary>
        /// Use this API to initiate online payment on behalf of a customer.
        /// </summary>
        public static string LipaNaMpesa { get { return "/mpesa/stkpush/v1/processrequest"; } }

        /// <summary>
        /// Use this API to check the status of a Lipa Na M-Pesa Online Payment.
        /// </summary>
        public static string LipaNaMpesaQuery { get { return "/mpesa/stkpushquery/v1/query"; } }

        /// <summary>
        /// Use this API to generate an OAuth access token to access other APIs
        /// </summary>
        public static string OAuth { get { return "oauth/v1/generate?grant_type=client_credentials"; } }

        /// <summary>
        /// Use this API to register validation and confirmation URLs on M-Pesa
        /// </summary>
        public static string C2BRegisterUrl { get { return "/mpesa/c2b/v1/registerurl"; } }

        /// <summary>
        /// This API is used to make payment requests from Client to Business (C2B)
        /// </summary>
        public static string C2BSimulateTransaction { get { return "/mpesa/c2b/v1/simulate"; } }
    }
}
