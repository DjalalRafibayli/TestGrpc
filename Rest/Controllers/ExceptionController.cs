using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {
        [HttpPost]
        public IActionResult SomeAction()
        {
            try
            {
                // Your logic here

                if (true)
                {
                    var errorModel = new { ErrorCode = "123", ErrorMessage = "Some error message" };
                    throw new CustomException(errorModel, "An error occurred");
                }

                // Continue with your logic

                return Ok(new { SuccessMessage = "Operation completed successfully" });
            }
            catch (CustomException customException)
            {
                // Handle the exception and return a specific response
                return BadRequest(customException.ErrorModel);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                return StatusCode(500, new { ErrorMessage = "Internal Server Error" });
            }
        }
        public class CustomException : Exception
        {
            public object ErrorModel { get; }

            public CustomException(object errorModel, string message) : base(message)
            {
                ErrorModel = errorModel;
            }
        }
    }
}
