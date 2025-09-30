using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreApp.Models
{
    public class Employee
    {
        [Key]//its says id is the primary key called as annotations
        public int Id { get; set; }// it should either Id or EmployeeId
        [Required(ErrorMessage ="Please Enter Name")]//anothre annotations bcz name should not be null
        [RegularExpression("^[A-Z]{1}[a-z]+$",ErrorMessage ="Invalid Name")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [RegularExpression("^[6789]{1}[0-9]{9}$")]//mobile number should start with 6789 and 10 digits
      
        public long Mobile { get; set; }
        
        public string SkillSet { get; set; }
        [ForeignKey("Department")]//creating the foreign key relations
        public int DepartmentId { get; set; }
        public virtual Department Department { set; get; }

    }
}
