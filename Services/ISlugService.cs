using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderQuandaryBlog.Services
{
    public interface ISlugService
    {
        //aids in SEO
        string UrlFriendly(string title);

        //slugs need to be unique in Db
        bool IsUnique(string slug);
    }
}
