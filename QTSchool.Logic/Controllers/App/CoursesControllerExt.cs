using QTSchool.Logic.Contracts.App;
using QTSchool.Logic.Modules.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTSchool.Logic.Controllers.App
{
    partial class CoursesController
    {
        internal override IEnumerable<string> Includes => new string[] { nameof(Entities.App.Course.Students) };

        protected override void ValidateEntity(ActionType actionType, Entities.App.Course entity)
        {
            if (actionType == ActionType.Insert || actionType == ActionType.Update) //geht nur ums update
            {
                if (entity.Students.Count > entity.MaxStudents)
                    throw new LogicException($"There can't be more than {entity.MaxStudents} students in this course");
            }

            base.ValidateEntity(actionType, entity);

            //delete regeln wir in Asp
        }

        //public void RemoveTest()
        //{

        //}
    }
}
