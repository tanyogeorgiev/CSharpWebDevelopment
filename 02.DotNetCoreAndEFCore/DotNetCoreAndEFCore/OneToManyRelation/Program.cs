using System;

namespace OneToManyRelation
{
    public class Program
    {
     public    static void Main(string[] args)
        {

            var db = new MyDbContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

        }
    }
}
