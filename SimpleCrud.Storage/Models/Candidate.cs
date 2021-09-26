using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SimpleCrud.Storage.Models
{
    public partial class Candidate
    {
        [Key]
        [Column("CandidateId")]
        public int CandidateId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("PositionId")]
        public int PositionId { get; set; }
        [Column("Position")]
        public string Position { get; set; }
        [Column("YearsOfExperience")]
        public double? YearsOfExperience { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Remote")]
        public bool? Remote { get; set; }
        [Column("FullTime")]
        public bool? FullTime { get; set; }
        [Column("University")]
        public string University { get; set; }
        [Column("Relocate")]
        public bool? Relocate { get; set; }
        [Column("Skills")]
        public string Skills { get; set; }
        [Column("OtherInfo")]
        public string OtherInfo { get; set; }
    }
}
