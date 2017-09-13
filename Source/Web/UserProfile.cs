using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    [Serializable]
    public sealed class UserProfile : IUserProfile
    {
        public UserProfile()
        {

        }

        static UserProfile()
        {
            UserProfile.Init();
        }

        public UserProfile(IUserProfile source)
        {
            this.DisplayName = source.DisplayName;
            this.PicturePath = source.PicturePath;
        }

        public string DisplayName { get; set; }

        public string PicturePath { get; set; }

        public static UserProfileProvider Provider { get; private set; }

        private static void Init()
        {
            UserProfile.Provider = new UserProfileProviderTest();
        }

        public static IUserProfile Current
        {
            get
            {
                return UserProfile.Provider.GetUserProfile();
            }
        }
    }
}
