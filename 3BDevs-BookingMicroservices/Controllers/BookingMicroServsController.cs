using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3BDevs_BookingMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingMicroServsController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public BookingMicroServsController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRequest(CreateRequestRequest request)
        {
            var result = await _requestService.CreateRequest(request);
            return new JsonResult(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _requestService.GetAll();
            return new JsonResult(result);
        }
    }
}
