﻿//@GeneratedCode
namespace QTSchool.WebApi
{
    ///
    /// Generated by the generator
    ///
    partial class Program
    {
        static partial void AddServices(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<QTSchool.Logic.Contracts.App.ICoursesAccess, QTSchool.Logic.Controllers.App.CoursesController>();
            builder.Services.AddTransient<QTSchool.Logic.Contracts.App.IStudentsAccess, QTSchool.Logic.Controllers.App.StudentsController>();
        }
    }
}
