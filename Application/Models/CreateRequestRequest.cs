using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class CreateRequestRequest //dto
    {
        public Guid RoomId { get; set; }
        public int UserId { get; set; }
    }
}
