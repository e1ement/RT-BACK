using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RT.Foxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public ValuesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get Values
        /// </summary>
        /// <returns>Returns values from db</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var values = await _repository.ValueRepository.GetAllAsync(false);

                return Ok(values);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(Get)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
