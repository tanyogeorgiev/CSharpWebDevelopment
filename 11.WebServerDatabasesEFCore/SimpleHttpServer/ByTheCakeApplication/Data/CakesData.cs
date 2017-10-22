using SimpleHttpServer.ByTheCakeApplication.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SimpleHttpServer.ByTheCakeApplication.Data
{
    public  class CakesData
    {
        private const string DatabaseFile = "./ByTheCakeApplication/Data/database.csv";
        public  IEnumerable<Cake> All()
        {
            return File.ReadAllLines(DatabaseFile).
                    Select(l => l.Split(','))
                    .Select(l => new Cake
                    {
                        Id = int.Parse(l[0]),
                        Name = l[1],
                        Price = decimal.Parse(l[2])
                    });
        }

        public void Add (string name, string price)
        {
                     
            var strReader = new StreamReader(DatabaseFile, true);
            var id = strReader.ReadToEnd().Split(Environment.NewLine).Length;
            strReader.Dispose();

            using (var strWriter = new StreamWriter(DatabaseFile, true))
            {
                strWriter.WriteLine($"{id},{name},{price}");
            }
        }

        public Cake Find(int id)
        {
            return this.All().FirstOrDefault(c => c.Id == id);
        }
    }
}
