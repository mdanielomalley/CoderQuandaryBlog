using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderQuandaryBlog.ViewModels
{
    public class MailSettings
    {
        //To configure and use the smtp server
        //i.e from google 

        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }
}
