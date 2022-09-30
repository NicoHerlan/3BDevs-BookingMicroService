using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }
        public int PaymentId { get; set; } //fk

        //Relaciones
        public Payment Payment { get; set; }

    }
}
