using Application.Activitis;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Project1.Controllers
{
    public class ActivitisController : BaseApiController
    {

        private readonly IMediator _mediator;
        public ActivitisController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivity()
        {
            //return await _db.Activities.ToListAsync();

            return await _mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            //return await _db.Activities.FindAsync(id);
            return await _mediator.Send(new Detaile.Query { Id = id });
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity)
        {
            return Ok(await _mediator.Send(new Create.Comment { activity = activity }));
        }
        [HttpGet]
        public async Task<IActionResult> EditActivity(Activity activity)
        {
            return Ok(await _mediator.Send(new Edit.Comment { activity = activity }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await _mediator.Send(new Deletee.Common { id=id}));
        }

    }
}
