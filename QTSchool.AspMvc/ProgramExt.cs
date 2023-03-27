﻿//@CodeCopy
//MdStart
namespace QTSchool.AspMvc
{
    /// <summary>
    /// Extension Program
    /// </summary>
    public partial class Program
    {
        /// <summary>
        /// Services can be added using this method.
        /// </summary>
        /// <param name="builder">The builder</param>
        public static void BeforeBuild(WebApplicationBuilder builder)
        {
#if ACCOUNT_ON
            builder.Services.AddTransient<Logic.Contracts.Account.IRolesAccess<Logic.Models.Account.Role>, Logic.Facades.Account.RolesFacade>();
            builder.Services.AddTransient<Logic.Contracts.Account.IUsersAccess<Logic.Models.Account.User>, Logic.Facades.Account.UsersFacade>();
            builder.Services.AddTransient<Logic.Contracts.Account.IIdentitiesAccess<Logic.Models.Account.Identity>, Logic.Facades.Account.IdentitiesFacade>();
#endif
            builder.Services.AddTransient<Logic.Contracts.App.IStudentsAccess, Logic.Controllers.App.StudentsController>();
            builder.Services.AddTransient<Logic.Contracts.App.ICoursesAccess, Logic.Controllers.App.CoursesController>();

            AddServices(builder);
        }
        /// <summary>
        /// Configures can be added using this method.
        /// </summary>
        /// <param name="app"></param>
        public static void AfterBuild(WebApplication app)
        {
            AddConfigures(app);
        }
        static partial void AddServices(WebApplicationBuilder builder);
        static partial void AddConfigures(WebApplication app);
    }
}
//MdEnd
