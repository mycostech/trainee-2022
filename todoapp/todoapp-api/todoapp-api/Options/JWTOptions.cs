namespace todoapp_api.Options
{
    public class JWTOptions
    {
        public const string JWT = "JWT";
        public string ValidAudience { get; set; } = String.Empty;
        public string ValidIssuer { get; set; } = String.Empty;
        //public string Secret { get; set; } = String.Empty; // should be remove on production
    }
}
