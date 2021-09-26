using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCrud.Storage.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public string Position { get; set; }
        public double? YearsOfExperience { get; set; }
        public string City { get; set; }
        public bool? Remote { get; set; }
        public bool? FullTime { get; set; }
        public string University { get; set; }
        public bool? Relocate { get; set; }
        public string Skills { get; set; }
        public string OtherInfo { get; set; }
    }
}
