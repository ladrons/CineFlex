using CineFlex.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CineFlex.Domain.Models
{
    public class Ticket : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        

        public Ticket()
        {
            
        }

        //Relational Properties
        public virtual ICollection<SoldTicket>? SoldTickets { get; set; }
    }
}
