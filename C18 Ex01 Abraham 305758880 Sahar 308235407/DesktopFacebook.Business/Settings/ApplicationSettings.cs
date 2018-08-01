namespace DesktopFacebook.Business.Settings
{
    public static class ApplicationSettings
    {
        public const float k_FacebookApiVersion = 2.8f;
        public const string k_ApplicationId = "193793304621904";
        public static readonly string[] sr_ApplicationPermissions = new string[]
        {
            "public_profile", "user_birthday", "user_friends", "user_gender",
            "user_hometown", "user_location", "user_link", "user_photos", "user_posts", "manage_pages", "publish_pages"
        };
    }
}
