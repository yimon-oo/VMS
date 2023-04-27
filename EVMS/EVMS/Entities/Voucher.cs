using System.ComponentModel.DataAnnotations.Schema;

namespace EVMS.Entities
{
    [Table("voucher")]
    public class Voucher
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime expiry_date { get; set; }
        public string code { get; set; }
        public string qr_image { get; set; }
        public int amount { get; set; }
        public int quantity { get; set; }
        public int maximum { get; set; }
        public bool status { get; set; }
    }
}
