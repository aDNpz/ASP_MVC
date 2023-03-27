//@CodeCopy
//MdStart
namespace QTSchool.AspMvc.Models.View
{
    public partial interface IFilterModel
    {
        bool Show { get; }
        bool HasEntityValue { get; }
        string CreateEntityPredicate();
    }
}
//MdEnd
