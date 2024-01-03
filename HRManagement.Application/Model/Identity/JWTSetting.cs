namespace HRManagement.Application.Model.Identity
{
    public class JWTSetting
    {
        public string Key { get; set; }

        public string Audience { get; set; }

        public string Issure { get; set; }

        public string DirectionInMinutes { get; set; }
    }
}
