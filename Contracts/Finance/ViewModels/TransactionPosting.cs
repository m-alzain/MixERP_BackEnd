using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Finance.ViewModels
{
    public class TransactionPosting
    {        
        public DateTime ValueDate { get; set; }

        public DateTime BookDate { get; set; }

        public string ReferenceNumber { get; set; }

        public int CostCenterId { get; set; }

        public List<JournalDetail> Details { get; set; }

        public List<Document> Attachements { get; set; }
    }
}
