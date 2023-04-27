namespace EVMS.Models
{
    public class UserGoodsViewModel
    {
        public int id { get; set; }
        public int user_voucher_id { get; set; }
        public int goods_id { get; set; }
        public int promo_price { get; set; }
        public int payment_method { get; set; }
    }
}
