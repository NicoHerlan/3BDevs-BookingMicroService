using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; } 
        //public Guid ReserveId { get; set; } //fk
        [MaxLength(25)] 
        public string Type { get; set; }
        
        //Relaciones
        public IList<Reserve> Reserves { get; set; }
        public IList<Ticket> Tickets { get; set; }
    }
}
