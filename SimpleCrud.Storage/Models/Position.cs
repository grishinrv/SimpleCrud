using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCrud.Storage.Models
{
    public partial class Position
    {
        public int PositionId { get; set; }
        public string Position1 { get; set; }
        public double? YearsOfExperience { get; set; }
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
        public DateTime? StartingDate { get; set; }
        public bool? MasterSDegree { get; set; }
        public bool? PhD { get; set; }
        public bool? PartialRemoteAuthorized { get; set; }
        public bool? FullRemote { get; set; }
        public string LinkToPosition { get; set; }
        public string OtherInfoNeeded { get; set; }
    }
}
