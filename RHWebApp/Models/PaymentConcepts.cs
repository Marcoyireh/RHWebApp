using System.ComponentModel.DataAnnotations.Schema;

namespace RHWebApp.Models
{
    public class PaymentConcepts
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Concept { get; set; }
        public double Amount { get; set; }
        public bool Operation { get; set; }
        public string RoleDescription { get; set; }
    }
}
