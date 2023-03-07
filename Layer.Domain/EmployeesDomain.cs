using Layer.AccessData;
using RHWebApp.Models;

namespace Layer.Domain
{
    public class EmployeesDomain
    {
        public List<PaymentConcepts> GetByEmployeeId(int EmployeeId)
        {
            return PaymentConceptsAccessData.GetByEmployeeId(EmployeeId);
        }
    }
}