using System.Collections.Generic;
using DatesAvailableApi.Models;
using DatesAvailableApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DatesAvailableApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatesAvailableController : ControllerBase
    {
        private readonly DatesAvailableService _datesAvailableService;

        public DatesAvailableController(DatesAvailableService datesAvailableService)
        {
            _datesAvailableService = datesAvailableService;
        }

        [HttpGet]
        public ActionResult<List<DatesAvailable>> Get()
        {
            return _datesAvailableService.Get();
        }

        [HttpGet("{id:length(24)}", Name = "GetDate")]
        public ActionResult<DatesAvailable> Get(string id)
        {
            var date = _datesAvailableService.Get(id);
            if (date == null)
            {
                return NotFound();
            }

            return date;
        }

        [HttpPost]
        public ActionResult<DatesAvailable> Create(DatesAvailable date)
        {
            _datesAvailableService.Create(date);
            return CreatedAtRoute("GetDate", new { id = date.Id.ToString() }, date);
        }
    }

}