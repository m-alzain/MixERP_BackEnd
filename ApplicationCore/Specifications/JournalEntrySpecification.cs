//using ApplicationCore.Entities.Finance;
//using Contracts.Finance.DTO;
//using Contracts.QueryModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ApplicationCore.Specifications
//{
//    public class JournalEntrySpecification : BaseSpecification<TransactionMaster>
//    {
//        public JournalEntrySpecification(EntryQuery query)

//            : base(j =>
//            (query.From == null || j.ValueDate >= query.From)
//            && (query.To == null || j.ValueDate <= query.To)
//            && (string.IsNullOrEmpty(query.Code)|| j.TransactionCode == query.Code)
//            && (string.IsNullOrEmpty(query.ReferenceNumber)|| j.ReferenceNumber == query.ReferenceNumber)
//            && (query.StatusId == null || j.VerificationStatusId == query.StatusId)
//            && (query.OfficeId == null || j.OfficeId == query.OfficeId)
//            )
//        {           
//            AddInclude(t => t.CostCenter);
//            AddInclude(t => t.Office);
//            AddInclude(t => t.VerificationStatus);
//            AddInclude(t => t.VerifiedByUser);
//        }
//    }
//}
