using System;
using ICT13580010A2.Models;
using SQLite;
namespace ICT13580010A2.Helpers
{
    public class DbHelper
    {
        SQLiteConnection db;

        public DbHelper(string dbPath)
        {
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Product>();
        }
        public int AddProduct(Product product)
        {
            return db.Insert(product);
        }
    }
}
