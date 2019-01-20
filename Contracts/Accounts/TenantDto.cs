using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Accounts
{
    public class TenantDto
    {
        public Guid Id { get; set; }
        public string TenantCode { get; set; }
        public string TenantName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string CurrencyCode { get; set; }
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
        public string RegistrationNumber { get; set; }
        
        public IList<OfficeDto> Offices { get; set; }

        #region Audit

        public Guid? CreatedByUserId { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }        

        #endregion

    }
}
