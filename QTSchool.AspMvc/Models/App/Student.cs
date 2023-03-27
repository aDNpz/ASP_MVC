namespace QTSchool.AspMvc.Models.App
{
    public class Student : VersionModel
    {
        public string FirstName { get; set; } = string.Empty;


        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{LastName} {FirstName}";

        public DateTime Birthdate { get; set; }

        public static Student Create(Logic.Models.App.Student student)
        {
            return new Student
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Birthdate = student.Birthdate,
            };
        }
    }
}
