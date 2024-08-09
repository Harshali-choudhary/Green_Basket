using green_basket.Server.Entities;
using green_basket.Server.Service.Feedback;
using Microsoft.AspNetCore.Mvc;

namespace green_basket.Server.Controllers
{
    
    
        [ApiController]
        [Route("/api/feedbacks")]
        public class FeedbackController : ControllerBase
        {
            private readonly IFeedbackService _service;

            public FeedbackController(IFeedbackService service)
            {
                _service = service;
            }
            [HttpGet]
            public async Task<List<Feedbacks>> GetAll()
            {
                List<Feedbacks> feedbacks = await _service.GetAll();
                return feedbacks;
            }
            [HttpPost]
            public async Task<bool> Insert([FromBody] Feedbacks feedback)
            {
                bool result = await _service.Insert(feedback);
                return result;

            }

            [HttpPut]
            public async Task<bool> Update([FromBody] Feedbacks feedback)
            {
                bool result = await _service.Update(feedback);
                return result;
            }

            [HttpDelete]
            
            public async Task<bool> Delete([FromBody] int id)
            {
                bool result = await _service.Delete(id);
                return result;
            }

        }
    }

