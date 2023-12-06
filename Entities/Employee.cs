using System.ComponentModel.DataAnnotations.Schema;

namespace Exam_sem3.Entities
{
    [Table("Employee_Tbl")]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Rank { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
