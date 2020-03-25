using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGridApp.Interfaces
{
    public interface INewsFeed
    {
        DateTime TimeStamp { get; set; }
        string Content { get; set; }
    }
}
