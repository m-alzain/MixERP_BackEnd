//using ApplicationCore.Entities.Finance;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ApplicationCore.Specifications
//{
//    public class CashRepositorySpecification : BaseSpecification<CashRepository>
//    {
//        public CashRepositorySpecification(string tenant, string cash_repository_code)
//            : base(c => (string.IsNullOrEmpty(cash_repository_code) || c.CashRepositoryCode == cash_repository_code)
//            && (c.Deleted.HasValue || c.Deleted.Value == false))
//        {
//        }
//    }
//}
