using EVMS.utilities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EVMS.Entities
{
    [Table("user_voucher")]
    public class UserVoucher
    {
        public int id { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual User User { get; set; }
        public int voucher_id { get; set; }
        [ForeignKey("voucher_id")]
        public virtual Voucher Voucher { get; set; }
        public int buy_type { get; set; }
        
        public int gifttouser_id { get; set; }
        public int qty { get; set; }

    }
}
