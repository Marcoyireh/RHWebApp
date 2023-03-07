using System.ComponentModel.DataAnnotations.Schema;

namespace RHWebApp.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual EmployeeRole? EmployeeRole { get; set; }

    }

    public class EmployeeRole
    {
        public EmployeeRole()
        {
            this.EmployeesList = new HashSet<Employees>();
        }
        public int id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Employees> EmployeesList { get; set; }
    }
}
