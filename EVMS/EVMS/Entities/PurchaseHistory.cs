using System.ComponentModel.DataAnnotations.Schema;

namespace EVMS.Entities
{
    [Table("View_PurchaseHistory")]
    public class PurchaseHistory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string title { get; set; }
        public int code { get; set; }
        public DateTime expiry_date { get; set; }
        public string status { get; set; }
        public string goodsname { get; set; }
        public int originalprice { get; set; }
        public int promo_price { get; set; }
    }
}
