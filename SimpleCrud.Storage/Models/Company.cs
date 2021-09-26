using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCrud.Storage.Models
{
    public class Company
    {
        [Key]
        [Column("CompanyId")]
        public int CompanyId { get; set; }
        [Column("CompanyName")]
        public string CompanyName { get; set; }
        [Column("Industry")]
        public string Industry { get; set; }
        [Column("Activity")]
        public string Activity { get; set; }
        [Column("AmountOfWorkers")]
        public int? AmountOfWorkers { get; set; }
        [Column("Founded")]
        public int? Founded { get; set; }
        [Column("Requirements")]
        public string Requirements { get; set; }
        [Column("OtherInfo")]
        public string OtherInfo { get; set; }
    }
}
