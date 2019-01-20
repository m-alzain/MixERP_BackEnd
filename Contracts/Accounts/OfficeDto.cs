using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Accounts
{
    public class OfficeDto
    {
        public Guid TenantId { get; set; }
        public Guid Id { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string NickName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string CurrencyCode { get; set; }
        public string PoBox { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public byte[] Logo { get; set; }
        public Guid? ParentOfficeId { get; set; }
        public string RegistrationNumber { get; set; }
        public string PanNumber { get; set; }
        public bool AllowTransactionPosting { get; set; }
        public bool? Deleted { get; set; }

        public string Tenant { get; set; }
        public string ParentOffice { get; set; }
        
        #region Audit

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }        

        #endregion
    }
}
