using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SimpleCrud.Storage.Models
{
    public partial class Position
    {
        [Key]
        [Column("PositionId")]
        public int PositionId { get; set; }
        [Column("Position")]
        public string PositionName { get; set; }
        [Column("YearsOfExperience")]
        public double? YearsOfExperience { get; set; }
        [Column("CompanyId")]
        public int CompanyId { get; set; }
        [Column("Company")]
        public string Company { get; set; }
        [Column("City")]
        public string City { get; set; }
        [Column("Salary")]
        public string Salary { get; set; }
        [Column("StartingDate")]
        public DateTime? StartingDate { get; set; }
        [Column("MasterSDegree")]
        public bool? MasterSDegree { get; set; }
        [Column("PhD")]
        public bool? PhD { get; set; }
        [Column("PartialRemoteAuthorized")]
        public bool? PartialRemoteAuthorized { get; set; }
        [Column("FullRemote")]
        public bool? FullRemote { get; set; }
        [Column("LinkToPosition")]
        public string LinkToPosition { get; set; }
        [Column("OtherInfoNeeded")]
        public string OtherInfoNeeded { get; set; }
    }
}
