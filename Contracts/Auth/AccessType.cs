
namespace Contracts.Auth
{
    public enum AccessType
    {
        READ,
        CREATE,
        EDIT,
        DELETE,
        CREATEFILTER,
        DELETEFILTER,
        EXPORT,
        EXPORTDATA,
        IMPORTDATA,
        EXECUTE,
        VERIFY,

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
