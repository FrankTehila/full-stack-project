using BL.api;
using System.Text.Json.Serialization;

namespace BL.models
{
    public class EmployeeBL : IEmployeeBL
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int LeaderId { get; set; }
    }

    namespace BL.models
    {
        public class EmployeeDTO
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("email")]
            public string Email { get; set; }
            [JsonPropertyName("firstName")]
            public string FirstName { get; set; }
            [JsonPropertyName("lastName")]
            public string LastName { get; set; }
            [JsonPropertyName("leaderId")]
            public int? LeaderId { get; set; }
        }
    }
}
