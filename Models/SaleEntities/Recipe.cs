using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models.SaleEntities
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}