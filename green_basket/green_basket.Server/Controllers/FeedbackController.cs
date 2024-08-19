using green_basket.Server.Entities;
using green_basket.Server.Service.Feedback;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace green_basket.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _service;

        public FeedbackController(IFeedbackService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var feedbacks = await _service.GetAll();
                return Ok(new { Success = true, Data = feedbacks });
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] Feedbacks feedback)
        {
            if (feedback == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid feedback data." });
            }

            try
            {
                bool result = await _service.Insert(feedback);
                if (result)
                {
                    return CreatedAtAction(nameof(GetAll), new { id = feedback.fid }, new { Success = true, Data = feedback });
                }
                else
                {
                    return BadRequest(new { Success = false, Message = "Failed to insert feedback." });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Feedbacks feedback)
        {
            if (feedback == null)
            {
                return BadRequest(new { Success = false, Message = "Invalid feedback data." });
            }

            try
            {
                bool result = await _service.Update(feedback);
                if (result)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound(new { Success = false, Message = "Feedback not found." });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { Success = false, Message = "Internal server error" });
            }
        }
    }
}

