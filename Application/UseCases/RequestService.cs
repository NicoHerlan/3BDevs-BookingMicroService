using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class RequestService : IRequestService
    {
        private readonly IRequestCommand _command;
        private readonly IRequestQuery _query;

        public RequestService(IRequestCommand command, IRequestQuery query)
        {
            _command = command;
            _query = query;
        }
        public async Task<Request> CreateRequest(CreateRequestRequest request)
        {
            var r = new Request
            {
                RequestId = Guid.NewGuid(),
                RoomId = request.RoomId,
                UserId = request.UserId,
                Aprove = false
            };
            await _command.InsertRequest(r);
            return r;
        }

        public Task<List<Request>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
