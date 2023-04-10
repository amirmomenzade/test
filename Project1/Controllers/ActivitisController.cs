using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Project1.Controllers
{
    public class ActivitisController : BaseApiController
    {

        private readonly DataContext _db;
        public ActivitisController(DataContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetAllActivity()
        {
            return await _db.Activities.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById(Guid id)
        {
            return await _db.Activities.FindAsync(id);
        }

    }
}
