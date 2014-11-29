using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorldInASPDOTNetMVC.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public System.DateTime PostDate { get; set; }
        public string Message { get; set; }
        public IEnumerable<PostComment> APostComment { set; get; }
    }
}