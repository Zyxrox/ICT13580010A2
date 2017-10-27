using System;
using SQLite;
using SQLitePCL;
namespace ICT13580010A2.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id{get;set;}

        [NotNull]
        [MaxLength(200)]
        public String Name{get;set;}

        public string Description{get;set;}

        [NotNull]
        [MaxLength(100)]
        public string Category{get;set;}

        public decimal ProductPrice { get; set; }
        public decimal SellPrize { get; set; }
        public int Stock { get; set; }
    }
}
