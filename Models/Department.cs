using System.ComponentModel.DataAnnotations;

namespace CoreApp.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public virtual List<Employee> Employees { set; get; }
    }
}
