using System.ComponentModel.DataAnnotations.Schema;

namespace EVMS.Entities
{
    [Table("user_goods")]
    public class UserGoods
    {
        public int id { get; set; }
        public int user_voucher_id { get; set; }
        [ForeignKey("user_voucher_id")]
        public virtual UserVoucher user_voucher { get; set; }
        public int goods_id { get; set; }
        [ForeignKey("goods_id")]
        public virtual Goods goods { get; set; }
        public int promo_price { get; set; }
        public int payment_method { get; set; }
    }
}
