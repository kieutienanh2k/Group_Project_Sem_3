using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models.SaleEntities
{
    [Serializable]
    public class CartItem
    {
        /*public Book Book { get; set; }
        public Recipe Recipe { get; set; }*/
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}