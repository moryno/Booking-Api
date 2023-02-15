using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingApi.Models
{
    public class MUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string PhysicalAddress { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Telephone { get; set; } = string.Empty;
        public string OriginCountry { get; set; } = string.Empty;
        public string EmployerName { get; set; } = string.Empty;
        public int Experience { get; set; } 
        public string Position { get; set; } = string.Empty;
        public string DisabilityStatus { get; set; } = string.Empty;
    }
}
