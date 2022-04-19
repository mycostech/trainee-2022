namespace todoapp_api.Options
{
    public static class EnvironmentVariables
    {
        public static string JWT_SECRET { get; private set; } = Environment.GetEnvironmentVariable("JWT_SECRET") ?? String.Empty;
        public static string DB_CONNECTION_STRING { get; private set; } = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? String.Empty;
    }
}
