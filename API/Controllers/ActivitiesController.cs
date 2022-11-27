using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities() => await Mediator.Send(new ActivitiesList.Query());

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Activity>> GetActivity(int id) =>
            await Mediator.Send(new ActivityDetails.Query { Id = id });

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity) =>
            Ok(await Mediator.Send(new CreateActivity.Command { Activity = activity }));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new UpdateActivity.Command { Activity = activity }));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteActivity(int id) => Ok(await Mediator.Send(new DeleteActivity.Command { Id = id }));
    }
}
