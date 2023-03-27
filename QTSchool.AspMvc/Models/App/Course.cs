namespace QTSchool.AspMvc.Models.App
{
    public class Course : VersionModel
    {
        public string Designation { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int MaxStudents { get; set; }

		public List<Student> AddStudents { get; set; } = new();
        
		//nav. prop.
		public List<Student> Students { get; set; } = new();

        public static Course Create(Logic.Models.App.Course course)
        {
            return new Course
            {
                Id = course.Id,
                Designation = course.Designation,
                Description = course.Description,
                MaxStudents = course.MaxStudents,
                Students = course.Students.Select(c => Models.App.Student.Create(c)).ToList(),
            };
        }
    }
}
