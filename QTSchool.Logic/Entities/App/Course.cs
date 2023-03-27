namespace QTSchool.Logic.Entities.App
{
    [Table("courses")]
    [Index(nameof(Designation), IsUnique = true)]
    public class Course : VersionEntity
    {
        [Key]
        [Column("CourseId")]
        public override int Id { get => base.Id; internal set => base.Id = value; }

        [Required]
        [MaxLength(64)]
        public string Designation { get; set; } = string.Empty;

        [MaxLength(264)]
        public string? Description { get; set; }

        public int MaxStudents { get; set; }

        //nav. prop.
        public List<Student> Students { get; set; } = new();
    }
}
