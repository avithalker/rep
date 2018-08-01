using System;
using System.IO;
using System.Xml.Serialization;

namespace DesktopFacebook.Business.Settings
{
    public class UserSettings
    {
        private const string k_SettingsPath = "userSettings.xml";

        public string UserLastAccessToken { get; set; }

        private UserSettings()
        {
            UserLastAccessToken = string.Empty;
        }

        public static UserSettings LoadSettings()
        {
            UserSettings userSettings;

            try
            {
                using (Stream fileStream = new FileStream(k_SettingsPath, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(UserSettings));
                    userSettings = xmlSerializer.Deserialize(fileStream) as UserSettings;
                }
            }
            catch (Exception)
            {
                userSettings = new UserSettings();
            }

            return userSettings;
        }

        public void SaveSettings()
        {
            try
            {
                using (Stream fileStream = new FileStream(k_SettingsPath, FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
                    xmlSerializer.Serialize(fileStream, this);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
