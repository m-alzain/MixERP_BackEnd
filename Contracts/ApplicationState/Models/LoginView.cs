using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.ApplicationState.Models
{
    public class LoginView
    {
        public long LoginId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsAdministrator { get; set; }
        public string Browser { get; set; }
        public string IpAddress { get; set; }
        public DateTimeOffset LoginTimestamp { get; set; }
        public string Culture { get; set; }
        public int OfficeId { get; set; }
        public string OfficeCode { get; set; }
        public string OfficeName { get; set; }
        public string Office { get; set; }
        public string Logo { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string PoBox { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string OfficeEmail { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Url { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string HundredthName { get; set; }
        public string PanNumber { get; set; }
        public DateTimeOffset LastSeenOn { get; set; }
    }
}
