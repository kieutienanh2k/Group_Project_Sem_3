using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectSem3.Models.SaleEntities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime? DateOrder { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Payment { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        /*[ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }*/

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}