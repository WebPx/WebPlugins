using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public sealed class UserProfileProviderTest : UserProfileProvider
    {
        public UserProfileProviderTest()
        {

        }

        public override IUserProfile GetUserProfile()
        {
            var result = new UserProfile() { DisplayName = "José Luis" };
            return result;
        }
    }
}
