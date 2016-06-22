using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;


namespace MsUni.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        [Required]
        public string Name { get; set; }

        public short Age { get; set; }

        public string City { get; set; }

        public string Job { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Required]
        public string University { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int CandidateImageId { get; set; }

        public int Vote { get; set; }

        public bool Approved { get; set; }
    }
}