using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class RequestCommand : IRequestCommand
    {
        private readonly BookingMicroServiceDbContext _context;

        public RequestCommand(BookingMicroServiceDbContext context)
        {
            _context = context;
        }

        public async Task InsertRequest(Request r)
        {
            _context.Requests.Add(r);
            await _context.SaveChangesAsync();
        }
    }
}
