using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace RT.Foxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public TasksController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        /// <summary>
        /// Get Tasks for User
        /// </summary>
        /// <returns>Returns Tasks from db</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _repository.TaskRepository.GetAllAsync();

                return Ok(tasks);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong in the {nameof(Get)} action {e}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
