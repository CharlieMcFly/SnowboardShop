using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnowboardShop.Models
{
    public class ShoppingCart
    {
        public List<string> mesBoards { get; set; }

        public ShoppingCart()
        {
            mesBoards = new List<string>();
        }

        public void addSnowboard(string snow)
        {
            mesBoards.Add(snow);
        }

    }
}
 