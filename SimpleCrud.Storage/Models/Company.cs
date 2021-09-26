using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleCrud.Storage.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Industry { get; set; }
        public string Activity { get; set; }
        public int? AmountOfWorkers { get; set; }
        public int? Founded { get; set; }
        public string Requirements { get; set; }
        public string OtherInfo { get; set; }
    }
}
