using System;

namespace JobHunt.Services.Models.Login
{
    [Serializable]
    public class SignOnModel
    {
        public string Username { get; set; }
        public string Domain { get; set; }
        public string AccessToken { get; set; }
        public string RegistrationToken { get; set; }
        public bool LoggedOut { get; set; }
        public string Platform { get; set; }
    }
}