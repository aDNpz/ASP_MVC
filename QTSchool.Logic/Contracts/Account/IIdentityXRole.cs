//@CodeCopy
//MdStart
#if ACCOUNT_ON
namespace QTSchool.Logic.Contracts.Account
{
    using QTSchool.Logic.Entities.Account;

    public partial interface IIdentityXRole
    {
        IdType IdentityId { get; set; }
        IdType RoleId { get; set; }
        Role? Role { get; set; }
    }
}
#endif
//MdEnd
