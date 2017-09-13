using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    public interface IUserProfile
    {
        string DisplayName { get; }
        string PicturePath { get; }
    }
}
