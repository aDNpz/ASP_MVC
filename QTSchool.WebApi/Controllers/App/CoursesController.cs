﻿//@GeneratedCode
namespace QTSchool.WebApi.Controllers.App
{
    ///
    /// Generated by the generator
    ///
    public sealed partial class CoursesController : Controllers.GenericController<QTSchool.Logic.Models.App.Course, QTSchool.WebApi.Models.App.CourseEdit, QTSchool.WebApi.Models.App.Course>
    {
        ///
        /// Generated by the generator
        ///
        static CoursesController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        
        ///
        /// Generated by the generator
        ///
        public CoursesController(QTSchool.Logic.Contracts.App.ICoursesAccess other)
        : base(other)
        {
            Constructing();
            
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        protected override QTSchool.WebApi.Models.App.Course ToOutModel(QTSchool.Logic.Models.App.Course accessModel)
        {
            var handled = false;
            var result = default(QTSchool.WebApi.Models.App.Course);
            BeforeToOutModel(accessModel, ref result, ref handled);
            if (handled == false || result == null)
            {
                result = QTSchool.WebApi.Models.App.Course.Create(accessModel);
            }
            AfterToOutModel(result);
            return result;
        }
        partial void BeforeToOutModel(QTSchool.Logic.Models.App.Course accessModel, ref QTSchool.WebApi.Models.App.Course? outModel, ref bool handled);
        partial void AfterToOutModel(QTSchool.WebApi.Models.App.Course outModel);
    }
}
