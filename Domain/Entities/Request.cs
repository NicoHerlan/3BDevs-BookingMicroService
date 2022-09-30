using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Request
    {
        [Key]
        public Guid RequestId { get; set; }
        public Guid RoomId { get; set; } //fk
        public int UserId { get; set; } //fk
        public bool Aprove { get; set; }

        //Relaciones
        public Reserve Reserve { get; set; }
    }
}
