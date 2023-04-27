namespace EVMS.Models
{
    public class VoucherViewModel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Expiry_Date { get; set; }
        public string Image { get; set; }
        public int Amount { get; set; }
        public int Payment_Method { get; set; }
        public int Quantity { get; set; }
        public int Buy_Type {get;set;}

    }
}
