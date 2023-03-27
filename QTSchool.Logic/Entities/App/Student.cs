using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTSchool.Logic.Entities.App
{
    [Table("students")]
    public class Student : VersionEntity
    {
        [Key]
        [Column("StudentId")]
        public override IdType Id { get => base.Id; internal set => base.Id = value; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        //nav. prop.
        public List<Course> Courses { get; set; } = new();
    }
}
