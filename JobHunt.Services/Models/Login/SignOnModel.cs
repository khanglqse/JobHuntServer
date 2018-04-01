using System;

namespace JobHunt.Services.Models.Login
{
    [Serializable]
    public class SignOnModel
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public string Platform { get; set; }
    }
}