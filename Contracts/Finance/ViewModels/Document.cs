using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Finance.ViewModels
{
    public class Document
    {
        public string OriginalFileName { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
        public string Memo { get; set; }
    }
}
