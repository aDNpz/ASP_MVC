﻿//@GeneratedCode
namespace QTSchool.Logic.Controllers.App
{
    using TEntity = Entities.App.Course;
    using TOutModel = Models.App.Course;
    ///
    /// Generated by the generator
    ///
    
    public sealed partial class CoursesController : EntitiesController<TEntity, TOutModel>, Contracts.App.ICoursesAccess
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
        public CoursesController()
        {
            Constructing();
            
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        ///
        /// Generated by the generator
        ///
        public CoursesController(ControllerObject other)
        : base(other)
        {
            Constructing();
            
            Constructed();
        }
        ///
        /// Generated by the generator
        ///
        internal override TOutModel ToModel(TEntity entity)
        {
            var handled = false;
            TOutModel? result = default;
            
            BeforeToOutModel(entity, ref result, ref handled);
            if (handled == false || result == default)
            {
                result = new TOutModel(entity);
            }
            AfterToOutModel(entity, result);
            return result;
        }
        partial void BeforeToOutModel(TEntity entity, ref TOutModel? result, ref bool handled);
        partial void AfterToOutModel(TEntity entity, TOutModel result);
    }
}
