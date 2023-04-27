using System.ComponentModel.DataAnnotations.Schema;

namespace EVMS.Entities
{
    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
    }
}
