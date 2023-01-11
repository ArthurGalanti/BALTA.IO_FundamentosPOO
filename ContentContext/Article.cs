using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Balta.ContentContext
{
    public class Article : Content
    {
        public Article(string title, string url) : base(title, url)
        {

        }
    }
}