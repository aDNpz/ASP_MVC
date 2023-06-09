﻿//@GeneratedCode
namespace QTSchool.Logic.Facades.App
{
    using TOutModel = Models.App.Student;
    ///
    /// Generated by the generator
    ///
    public sealed partial class StudentsFacade : ControllerFacade<TOutModel>, Contracts.App.IStudentsAccess
    {
        ///
        /// Generated by the generator
        ///
        static StudentsFacade()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();
        
        ///
        /// Generated by the generator
        ///
        public StudentsFacade()
        : base(new QTSchool.Logic.Controllers.App.StudentsController())
        {
            Constructing();
            
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public StudentsFacade(FacadeObject facadeObject)
        : base(new QTSchool.Logic.Controllers.App.StudentsController(facadeObject.ControllerObject))
        {
            Constructing();
            
            Constructed();
        }
    }
}
