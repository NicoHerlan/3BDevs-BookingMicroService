using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Reserve
    {
        [Key]
        public Guid ReserveId { get; set; }
        public Guid RequestId { get; set; } //fk
        public Guid RoomId { get; set; } //fk
        public DateTime DayTime { get; set; }

        //Relaciones
        public Request Request { get; set; }
        public Payment Payment { get; set; }

    }
}
