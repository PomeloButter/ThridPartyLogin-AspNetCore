namespace ThridPartyLogin_AspNetCore.Entity
{
    public class CredentialSetting
    {
        /// <summary>
        ///     AppKey
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        ///     AppSecret
        /// </summary>
        public string ClientSecret { get; set; }
    }
}