using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;


namespace MsUni.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public short Age { get; set; }

        public string City { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        public string University { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public int CandidateImageId { get; set; }

        public int Vote { get; set; }

        public bool Approved { get; set; }
    }
}