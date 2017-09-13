using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace WebPx.Web
{
    [Serializable]
    public class PageActionSet : Collection<PageAction>
    {
        public PageActionSet()
        {

        }

        public void AddRange(PageActionSet pageActionSet)
        {
            foreach (var item in pageActionSet)
                this.Add(item);
        }
    }
}
