using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken) => 
            await Mediator.Send(new ActivitiesList.Query(), cancellationToken);

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Activity>> GetActivity(int id, CancellationToken cancellationToken) =>
            await Mediator.Send(new ActivityDetails.Query { Id = id }, cancellationToken);

        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(new CreateActivity.Command { Activity = activity }, cancellationToken));

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity, CancellationToken cancellationToken)
        {
            activity.Id = id;
            return Ok(await Mediator.Send(new UpdateActivity.Command { Activity = activity }, cancellationToken));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteActivity(int id, CancellationToken cancellationToken) =>
            Ok(await Mediator.Send(new DeleteActivity.Command { Id = id }, cancellationToken));
    }
}
