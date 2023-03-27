using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QTSchool.AspMvc.Controllers.App
{
    public class CoursesController : Controller
    {
        private readonly Logic.Contracts.App.ICoursesAccess _coursesAccess;
        private readonly Logic.Contracts.App.IStudentsAccess _studentsAccess;

        public CoursesController(Logic.Contracts.App.ICoursesAccess coursesAccess, 
                                 Logic.Contracts.App.IStudentsAccess studentsAccess)
        {
            _coursesAccess = coursesAccess;
            _studentsAccess = studentsAccess;
        }

        // GET: CoursesController
        public async Task<ActionResult> Index()
        {
            var entities = await _coursesAccess.GetAllAsync();
            var models = entities.Select(e => Models.App.Course.Create(e)).ToArray();
            return View(models);
        }

        // GET: CoursesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = default(Models.App.Course);

            var entity = await _coursesAccess.GetByIdAsync(id);

            if (entity != null)
                model = Models.App.Course.Create(entity);

            return model != null ? View(model) : NotFound();
        }

        // GET: CoursesController/Create
        public ActionResult Create()
        {
            var entity = _coursesAccess.Create();

            return View(Models.App.Course.Create(entity));
        }

        // POST: CoursesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Models.App.Course model)
        {
            try
            {
                var entity = _coursesAccess.Create();

                entity.Designation = model.Designation;
                entity.Description = model.Description;
                entity.MaxStudents = model.MaxStudents;

                entity = await _coursesAccess.InsertAsync(entity);
                await _coursesAccess.SaveChangesAsync();

                return RedirectToAction(nameof(Edit), new { id = entity.Id});
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        // GET: CoursesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = default(Models.App.Course);
            var entity = await _coursesAccess.GetByIdAsync(id);

            if (entity != null)
            {
                var existingStudentIds = entity.Students.Select(e => e.Id).ToArray();
                var students = await _studentsAccess.GetAllAsync();

                var addStudents = students.Where(s => existingStudentIds.Contains(s.Id) == false);

                model = Models.App.Course.Create(entity);
                model.AddStudents = addStudents.Select(s => Models.App.Student.Create(s)).ToList();
            }
            return model != null ? View(model) : NotFound();
        }

        public async Task<ActionResult> AddStudent(int courseId, int studentId)
        {
            var studentEntity = await _studentsAccess.GetByIdAsync(studentId);
            var courseEntity = await _coursesAccess.GetByIdAsync(courseId);

            if (studentEntity != null && courseEntity != null)
            {
                courseEntity.Students.Add(studentEntity);

                //await _coursesAccess.UpdateAsync(courseEntity);
                await _coursesAccess.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Edit), new { id = courseId });
        }

        public async Task<ActionResult> RemoveStudent(int courseId, int studentId)
        {
			var studentEntity = await _studentsAccess.GetByIdAsync(studentId);
			var courseEntity = await _coursesAccess.GetByIdAsync(courseId);

			if (studentEntity != null && courseEntity != null)
			{
				courseEntity.Students.Remove(studentEntity);

                //_coursesAccess.RemoveTest();

				//await _coursesAccess.UpdateAsync(courseEntity);
				await _coursesAccess.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Edit), new { id = courseId });
		}


		// POST: CoursesController/Edit/5
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Models.App.Course model)
        {
            try
            {
                var entity = await _coursesAccess.GetByIdAsync(id);

                if (entity != null)
                {
                    entity.Designation = model.Designation;
                    entity.Description = model.Description;
                    entity.MaxStudents = model.MaxStudents;

                    //entity.CopyFrom(model); //???

                    await _coursesAccess.UpdateAsync(entity);
                    await _coursesAccess.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }

        // GET: CoursesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = default(Models.App.Course);
            var entity = await _coursesAccess.GetByIdAsync(id);

            if (entity != null)
            {
                model = Models.App.Course.Create(entity);
            }

            return model != null ? View(model) : RedirectToAction(nameof(Index));
        }

        // POST: CoursesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Models.App.Course model)
        {
            try
            {
                var entity = await _coursesAccess.GetByIdAsync(id);

                if (entity != null) 
                {
					////Version 1: alles löschen
					//entity.Students.Clear();
                    //await _coursesAccess.SaveChangesAsync();

                    //Version 2: Fehlermeldung
                    if (entity.Students.Any())
                    {
                        throw new Exception("Please delete all Students of this course first");
                    }
                }

                await _coursesAccess.DeleteAsync(id);
                await _coursesAccess.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(model);
            }
        }
    }
}
