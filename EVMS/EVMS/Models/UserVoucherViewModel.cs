namespace EVMS.Models
{

    public class UserVoucherViewModel
    {
        public int voucher_id { get; set; }
        public int buy_type { get; set; }
        public int payment_method { get; set; }
        public int qty { get; set;}
        public int gifttouser_id { get; set; }
    }
}
