using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public abstract class UserProfileProvider
    {
        public abstract IUserProfile GetUserProfile();
    }
}
