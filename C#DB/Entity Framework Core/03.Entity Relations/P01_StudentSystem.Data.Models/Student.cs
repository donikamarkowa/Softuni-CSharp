using P01_StudentSystem.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentCourses = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
        }
        [Key]
        public int StudentId { get; set; }

        [Required]
        [MaxLength(ValidationConstants.StudentNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(ValidationConstants.StudentPhoneNumberMaxLength)]
        [Column(TypeName = "CHAR")]
        public string? PhoneNumber { get; set; }

        public bool RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        [InverseProperty(nameof(StudentCourse.Student))]
        public ICollection<StudentCourse> StudentCourses { get; set; }

        [InverseProperty(nameof(Homework.Student))]
        public ICollection<Homework> Homeworks { get; set; }

    }
}