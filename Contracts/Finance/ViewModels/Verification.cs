using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Finance.ViewModels
{
    public sealed class Verification
    {
        public long TranId { get; set; }
        public int OfficeId { get; set; }
        public int UserId { get; set; }
        public long LoginId { get; set; }
        public short VerificationStatusId { get; set; }
        public string Reason { get; set; }
    }
}
