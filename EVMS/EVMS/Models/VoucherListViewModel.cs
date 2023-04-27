namespace EVMS.Models
{
    public class VoucherListViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string expiry_date { get; set; }
        public string code { get; set; }
        public string image { get; set; }
        public int amount { get; set; }
        public int quantity { get; set; }
        public int maximum { get; set; }
        public string status { get; set; }

    }
}
