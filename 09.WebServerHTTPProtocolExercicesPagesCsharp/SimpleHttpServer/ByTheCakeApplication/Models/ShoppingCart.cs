using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleHttpServer.ByTheCakeApplication.Models
{
    class ShoppingCart
    {
        public const string SessionKey = "&^Current_Shopping_Cart^%";

        public List<Cake> Orders { get; private set; } = new List<Cake>();

        internal bool Any()
        {
            throw new NotImplementedException();
        }
    }
}
