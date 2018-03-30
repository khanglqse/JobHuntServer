using System;

namespace JobHunt.Services.Models.Email
{
    [Serializable]
    public class EmailBaseModel
    {
        public string BenificiaryName { get; set; }
        //protected readonly string _siteUrl = string.IsNullOrEmpty(ConfigurationManager.AppSettings[Constants.AppSettings.SiteUrl]) ? Constants.SITEURL : ConfigurationManager.AppSettings[Constants.AppSettings.SiteUrl];
    }
}