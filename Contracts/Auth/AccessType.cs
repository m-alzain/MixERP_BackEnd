
namespace Contracts.Auth
{
    public enum AccessType
    {
        READ = 1,
        CREATE = 2,
        EDIT = 3,
        DELETE = 4,
        CREATEFILTER = 5,
        DELETEFILTER = 6,
        EXPORT = 7,
        EXPORTDATA = 8,
        IMPORTDATA = 9,
        EXECUTE = 10,
        VERIFY = 11,

        #region Commented (From the old system)

        //public int AccessTypeId { get; set; }
        //public string AccessTypeName { get; set; }
        //public ICollection<GroupEntityAccessPolicy> GroupEntityAccessPolicies { get; set; }
        //public ICollection<EntityAccessPolicy> EntityAccessPolicies { get; set; }
        //public User AuditUser { get; set; }
        //public int? AuditUserId { get; set; }
        //public DateTimeOffset? AuditTs { get; set; }
        //public bool? Deleted { get; set; }

        #endregion

    }
}
