using BL.api;

namespace BL.models
{
    public class EmployeeBL:IEmployeeBL
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int LeaderId { get; set; }
    }
}