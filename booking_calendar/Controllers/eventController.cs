using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace booking_calendar;

[Route("addEvents")]
[ApiController]

public class EventController : Controller
{
    private readonly meetingContext _db;

    public EventController(meetingContext context)
    {
        _db = context;
    }

<<<<<<< Updated upstream
=======
    // This endpoint returns a simple list of mock events.
    [HttpGet]
    public IActionResult GetEvents()
    {
        // This creates a predictable list response for the list view.
        var events = new List<EventListItemDto>
        {
            
            // This adds the first sample event to the list.
            // new EventListItemDto
            // {
            //     // This sets the event id.
            //     Id = 1,
            //     // This sets the event name.
            //     Name = "Team Planning Meeting",
            //     // This sets the event date.
            //     Date = new DateTime(2026, 4, 5),
            //     // This sets the event description.
            //     Description = "Discuss project goals and weekly tasks.",
            //     // This sets the course id using a simple read-only name.
            //     CourseId = 310
            // },
            // // This adds the second sample event to the list.
            // new EventListItemDto
            // {
            //     // This sets the event id.
            //     Id = 2,
            //     // This sets the event name.
            //     Name = "Database Review",
            //     // This sets the event date.
            //     Date = new DateTime(2026, 4, 8),
            //     // This sets the event description.
            //     Description = "Review table structure and sample records.",
            //     // This sets the course id using a simple read-only name.
            //     CourseId = 325
            // },
            // // This adds the third sample event to the list.
            // new EventListItemDto
            // {
            //     // This sets the event id.
            //     Id = 3,
            //     // This sets the event name.
            //     Name = "Final Presentation Prep",
            //     // This sets the event date.
            //     Date = new DateTime(2026, 4, 12),
            //     // This sets the event description.
            //     Description = "Prepare slides and practice the final presentation.",
            //     // This sets the course id using a simple read-only name.
            //     CourseId = 310
            // }
        };

        // This always returns a JSON list for the UI to read.
        return Ok(events);
    }

>>>>>>> Stashed changes
    [HttpPut]
    public async Task<IActionResult> AddEvent (Event evt)
    {
        _db.Events.Add(evt);
        await _db.SaveChangesAsync();
        return Ok(evt);
    }

}
