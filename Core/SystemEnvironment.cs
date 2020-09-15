namespace Mpesa.Gate.Core
{
    /// <summary>
    /// Represents the system environment endpoints
    /// </summary>
    public static class SystemEnvironment
    {
        /// <summary>
        /// Represents the production endpoint link
        /// </summary>
        public static string Production { get { return "https://api.safaricom.co.ke/"; } }

        /// <summary>
        /// Represents the sandbox endpoint link
        /// </summary>
        public static string Sandbox { get { return "https://sandbox.safaricom.co.ke/"; } }
    }
}
