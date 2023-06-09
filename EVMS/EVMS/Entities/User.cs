﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EVMS.Entities
{
    [Table("user")]
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone_number { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
