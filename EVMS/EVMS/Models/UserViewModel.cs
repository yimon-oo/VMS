namespace EVMS.Models
{
    public class UserViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool isFirstApiCall { get; set; }
        public DateTime apiCallJwtExpire { get; set; }
        public string Token { get; set; }
    }
}
