using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models.SaleEntities
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string Form { get; set; }
        public string Status { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}