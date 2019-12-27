using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace IMAPMigrate
{
    class MailFolderHelper
    {
        public String FullPath = "";
        public String Path = "";
        public List<MailKit.UniqueId> MailGUID = new List<MailKit.UniqueId>();
    }
}
