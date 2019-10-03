using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        [Required]
        [Display(Name ="Employee Id")]
        public int EmpId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string EmpFna { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string EmpLna { get; set; }
        [Required]
        [Display(Name = "Department")]
        public string Dept { get; set; }
    }
}