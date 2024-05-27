using System.ComponentModel.DataAnnotations;

namespace ST10182111_2024POE.Models
{
    public class UserLeadEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string LeadSource { get; set; }

    }
}
